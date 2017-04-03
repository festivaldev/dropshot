using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberStrike.Core.Entities {
	public enum MemberAuthenticationResult {
		Ok,
		InvalidData,
		InvalidName,
		InvalidEmail,
		InvalidPassword,
		IsBanned,
		InvalidHandle,
		InvalidEsns,
		InvalidCookie,
		IsIpBanned,
		UnknownError
	}

	public enum MemberAccessLevel {
		Default,
		QA = 3,
		Moderator,
		SeniorQA = 6,
		SeniorModerator,
		Admin = 10
	}

	public enum EmailAddressStatus {
		Unverified,
		Verified,
		Invalid
	}

	public enum RegionType {
		UsEast,
		EuWest,
		AsiaPacific,
		UsWest,
		SouthKorea,
		Japan
	}

	public enum PhotonUsageType {
		None,
		All,
		Mobile,
		CommServer = 6
	}

	public enum GameModeType {
		None,
		DeathMatch,
		TeamDeathMatch,
		EliminationMode
	}
}
