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

	public enum UberstrikeItemClass {
		WeaponMelee = 1,
		WeaponMachinegun = 3,
		WeaponShotgun,
		WeaponSniperRifle,
		WeaponCannon,
		WeaponSplattergun,
		WeaponLauncher,
		WeaponModScope,
		WeaponModMuzzle,
		WeaponModWeaponMod,
		GearBoots,
		GearHead,
		GearFace,
		GearUpperBody,
		GearLowerBody,
		GearGloves,
		QuickUseGeneral,
		QuickUseGrenade,
		QuickUseMine,
		FunctionalGeneral,
		SpecialGeneral,
		GearHolo
	}

	public enum UberstrikeItemType {
		Weapon = 1,
		WeaponMod,
		Gear,
		QuickUse,
		Functional,
		Special
	}

	public enum UberStrikeCurrencyType {
		None,
		Credits,
		Points
	}

	public enum PackType {
		One,
		Two,
		Three
	}

	public enum BuyingDurationType {
		None,
		OneDay,
		SevenDays,
		ThirtyDays,
		NinetyDays,
		Permanent
	}

	public enum ItemShopHighlightType {
		None,
		Featured,
		Popular,
		New
	}

	public enum ItemPropertyType {
		XpBoost = 1,
		PointsBoost,
		IsGiftable,
		CritDamageBonus
	}

	public enum QuickItemLogic {
		None,
		SpringGrenade,
		HealthPack,
		ArmorPack,
		AmmoPack,
		ExplosiveGrenade
	}
}
