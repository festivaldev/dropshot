using System;
using System.IO;
using System.ServiceModel;

namespace DropshotServer {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class RelationshipWebService : IRelationshipWebServiceContract {
		public RelationshipWebService() {
			Console.Write("Initializing RelationshipWebService...\t\t");
		}

		public byte[] SendContactRequest(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetContactRequests(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] AcceptContactRequest(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] DeclineContactRequest(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] DeleteContact(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetContactsByGroups(byte[] data) {
			return new MemoryStream().ToArray();
		}
	}
}