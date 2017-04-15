using System;
using System.ServiceModel;

namespace DropshotServer {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	internal class PrivateMessageWebService : IPrivateMessageWebServiceContract {
		public PrivateMessageWebService() {
			Console.Write("Initializing PrivateMessageWebService...\t");
		}

		public byte[] GetAllMessageThreadsForUser(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetThreadMessages(byte[] data) {
			return new byte[] { };
		}

		public byte[] SendMessage(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetMessageWithIdForCmid(byte[] data) {
			return new byte[] { };
		}

		public byte[] MarkThreadAsRead(byte[] data) {
			return new byte[] { };
		}

		public byte[] DeleteThread(byte[] data) {
			return new byte[] { };
		}
	}
}