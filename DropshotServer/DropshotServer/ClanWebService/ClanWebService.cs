using System;
using System.IO;
using System.ServiceModel;

namespace DropshotServer {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	internal class ClanWebService : IClanWebServiceContract {
		public ClanWebService() {
			Console.Write("Initializing ClanWebService...\t\t\t");
		}

		public byte[] GetOwnClan(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] UpdateMemberPosition(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] InviteMemberToJoinAGroup(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] AcceptClanInvitation(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] DeclineClanInvitation(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] KickMemberFromClan(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] DisbandGroup(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] LeaveAClan(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetMyClanId(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] CancelInvitation(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetAllGroupInvitations(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetPendingGroupInvitations(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] CreateClan(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] TransferOwnership(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] CanOwnAClan(byte[] data) {
			return new MemoryStream().ToArray();
		}
	}
}