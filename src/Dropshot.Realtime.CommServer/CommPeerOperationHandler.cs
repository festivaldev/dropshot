using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using System;
using System.IO;
using UberStrike.Core.Serialization;
using UberStrike.Realtime.Client;

namespace Dropshot.Realtime.CommServer
{
    public class CommPeerOperationHandler : IOperationHandler
    {
        private const int OP_ID = 1;

        public CommPeerOperationHandler(Server server)
        {
            if (server == null)
                throw new ArgumentNullException(nameof(server));

            _server = server;
        }

        private readonly Server _server;

        public void OnDisconnect(PeerBase peer)
        {
            //TODO: Handle disconnection.
        }

        public OperationResponse OnOperationRequest(PeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
        {
            var commPeer = (CommPeer)peer;
            // Basically all the operations here are to check the integrity of the game instance (Some form of Anti-Cheat).
            var operationType = (ICommPeerOperationsType)operationRequest.OperationCode;
            switch (operationType)
            {
                // AuthenticationRequest is used to check if the .dlls haven't been modified,
                // I forgot the exact procedure, but its somewhere on my computer.
                case ICommPeerOperationsType.AuthenticationRequest:
                    var authData = (byte[])operationRequest.Parameters[OP_ID];
                    using (var stream = new MemoryStream(authData))
                    {
                        var authToken = StringProxy.Deserialize(stream);
                        var magicHash = StringProxy.Deserialize(stream);

                        // Not doing much with it at the moment.
                    }

                    commPeer.Lobby.SendMessage(0, "Dropshot", "Test chat message.");
                    break;

                // SendHeartbeatResponse is used to check if any other assemblies other than allowed
                // ones are in the AppDomain, but I forgot the exact procedure for this one too, but its
                // somewhere on my computer.
                case ICommPeerOperationsType.SendHeartbeatResponse:
                    var heartbeatData = (byte[])operationRequest.Parameters[OP_ID];
                    using (var stream = new MemoryStream(heartbeatData))
                    {
                        var authToken = StringProxy.Deserialize(stream);
                        var responseHash = StringProxy.Deserialize(stream);

                        // Not doing much with it at the moment.
                    }
                    break;
            }
            return null;
        }
    }
}
