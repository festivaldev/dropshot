using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using System;
using System.Collections.Generic;
using System.IO;
using UberStrike.Core.Serialization;
using UberStrike.Realtime.Client;

namespace Dropshot.Realtime.CommServer
{
    public class CommPeer : Peer
    {
        // Uberstrike client seems not to care about them. But we might.
        internal static readonly SendParameters s_parameters = new SendParameters();

        public CommPeer(Server server, InitRequest initRequest) : base(initRequest)
        {
            if (server == null)
                throw new ArgumentNullException(nameof(server));
            if (initRequest == null)
                throw new ArgumentNullException(nameof(initRequest));

            // Check the client version.
            if (initRequest.ClientVersion.Major != 4 || initRequest.ApplicationId != "2.0")
                Disconnect();

            SetCurrentOperationHandler(server._handler);

            _room = new LobbyRoom(this);
        }

        // This is not Uberstrike's lobby room implementation.
        private readonly LobbyRoom _room;

        public LobbyRoom Lobby => _room;

        public void SendDisconnectAndDisablePhoton(string message)
        {
            var parameters = new Dictionary<byte, object>();
            using (var stream = new MemoryStream())
            {
                StringProxy.Serialize(stream, message);
                parameters.Add(0, stream.ToArray());
            }

            var data = new EventData((byte)ICommPeerEventsType.DisconnectAndDisablePhoton, parameters);
            SendEvent(data, s_parameters);
        }
    }
}
