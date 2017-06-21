using Photon.SocketServer;

namespace Dropshot.Realtime.CommServer
{
    public class Server : ApplicationBase
    {
        internal CommPeerOperationHandler _handler;

        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new CommPeer(this, initRequest);
        }

        protected override void Setup()
        {
            _handler = new CommPeerOperationHandler(this);
        }

        protected override void TearDown()
        {
            // Space
        }
    }
}
