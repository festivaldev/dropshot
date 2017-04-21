using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.IO;
using UberStrike.Core.Serialization;
using UberStrike.Realtime.Client;

namespace Dropshot.Realtime.CommServer
{
    // Represents a lobby room.
    public class LobbyRoom
    {
        public LobbyRoom(CommPeer peer)
        {
            if (peer == null)
                throw new ArgumentNullException(nameof(peer));

            _peer = peer;
        }

        private readonly CommPeer _peer;

        public void SendMessage(int cmid, string name, string message)
        {
            var parameters = new Dictionary<byte, object>();
            using (var stream = new MemoryStream())
            {
                Int32Proxy.Serialize(stream, cmid);
                StringProxy.Serialize(stream, name);
                StringProxy.Serialize(stream, message);
                parameters.Add(0, stream.ToArray());
            }

            var data = new EventData((byte)ILobbyRoomEventsType.LobbyChatMessage, parameters);
            _peer.SendEvent(data, CommPeer.s_parameters);
        }
    }
}
