﻿// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public enum ConfigOption : short
{
	Invalid = -1,
	None = 0,
	// System Config
	// System - FINAL FANTASY XIV Config File
	// System - Version
	GuidVersion = 2,
	ConfigVersion = 3,
	Language = 4,
	Region = 5,
	// System - Network Settings
	UPnP = 7,
	Port = 8,
	LastLogin0 = 9,
	LastLogin1 = 10,
	WorldId = 11,
	ServiceIndex = 12,
	DktSessionId = 13,
	// System - Display Settings
	MainAdapter = 15,
	ScreenLeft = 16,
	ScreenTop = 17,
	ScreenWidth = 18,
	ScreenHeight = 19,
	ScreenMode = 20,
	FullScreenWidth = 21,
	FullScreenHeight = 22,
	Refreshrate = 23,
	Fps = 24,
	AntiAliasing = 25,
	FPSInActive = 26,
	ResoMouseDrag = 27,
	MouseOpeLimit = 28,
	LangSelectSub = 29,
	Gamma = 30,
	UiBaseScale = 31,
	CharaLight = 32,
	UiHighScale = 33,
	// System - Graphics Settings
	TextureFilterQuality = 35,
	TextureAnisotropicQuality = 36,
	SSAO = 37,
	Glare = 38,
	DistortionWater = 39,
	DepthOfField = 40,
	RadialBlur = 42,
	Vignetting = 43,
	GrassQuality = 44,
	TranslucentQuality = 45,
	ShadowVisibilityType = 46,
	ShadowSoftShadowType = 47,
	ShadowTextureSizeType = 48,
	ShadowCascadeCountType = 49,
	LodType = 50,
	StreamingType = 51,
	GeneralQuality = 52,
	OcclusionCulling = 53,
	ShadowLOD = 54,
	PhysicsType = 59,
	MapResolution = 60,
	ShadowVisibilityTypeSelf = 61,
	ShadowVisibilityTypeParty = 62,
	ShadowVisibilityTypeOther = 63,
	ShadowVisibilityTypeEnemy = 64,
	PhysicsTypeSelf = 65,
	PhysicsTypeParty = 66,
	PhysicsTypeOther = 67,
	PhysicsTypeEnemy = 68,
	ReflectionType = 69,
	ScreenShotImageType = 70,
	// System - Sound Settings
	IsSoundDisable = 72,
	IsSoundAlways = 73,
	IsSoundBgmAlways = 74,
	IsSoundSeAlways = 75,
	IsSoundVoiceAlways = 76,
	IsSoundSystemAlways = 77,
	IsSoundEnvAlways = 78,
	IsSoundPerformAlways = 79,
	// System - Font Settings
	// System - GamePad Settings
	PadGuid = 82,
	InstanceGuid = 83,
	ProductGuid = 84,
	DeadArea = 85,
	Alias = 86,
	AlwaysInput = 87,
	ForceFeedBack = 88,
	PadPovInput = 89,
	PadMode = 90,
	PadAvailable = 91,
	PadReverseConfirmCancel = 92,
	PadSelectButtonIcon = 93,
	PadMouseMode = 94,
	TextPasteEnable = 95,
	EnablePsFunction = 96,
	WaterWet = 97,
	DisplayObjectLimitType = 98,
	WindowDispNum = 99,
	ScreenShotDir = 100,
	// System - Graphics Settings DX11
	AntiAliasing_DX11 = 102,
	TextureFilterQuality_DX11 = 103,
	TextureAnisotropicQuality_DX11 = 104,
	SSAO_DX11 = 105,
	Glare_DX11 = 106,
	DistortionWater_DX11 = 107,
	DepthOfField_DX11 = 108,
	RadialBlur_DX11 = 109,
	Vignetting_DX11 = 110,
	GrassQuality_DX11 = 111,
	TranslucentQuality_DX11 = 112,
	ShadowSoftShadowType_DX11 = 113,
	ShadowTextureSizeType_DX11 = 114,
	ShadowCascadeCountType_DX11 = 115,
	LodType_DX11 = 116,
	OcclusionCulling_DX11 = 117,
	ShadowLOD_DX11 = 118,
	MapResolution_DX11 = 119,
	ShadowVisibilityTypeSelf_DX11 = 120,
	ShadowVisibilityTypeParty_DX11 = 121,
	ShadowVisibilityTypeOther_DX11 = 122,
	ShadowVisibilityTypeEnemy_DX11 = 123,
	PhysicsTypeSelf_DX11 = 124,
	PhysicsTypeParty_DX11 = 125,
	PhysicsTypeOther_DX11 = 126,
	PhysicsTypeEnemy_DX11 = 127,
	ReflectionType_DX11 = 128,
	WaterWet_DX11 = 129,
	ParallaxOcclusion_DX11 = 130,
	Tessellation_DX11 = 131,
	GlareRepresentation_DX11 = 132,
	UiSystemEnlarge = 133,
	SoundPadSeType = 134,
	SoundPad = 135,
	IsSoundPad = 136,
	TouchPadMouse = 137,
	TouchPadCursorSpeed = 138,
	TouchPadButtonExtension = 139,
	TouchPadButton_Left = 140,
	TouchPadButton_Right = 141,
	RemotePlayRearTouchpadEnable = 142,
	SupportButtonAutorunEnable = 143,
	R3ButtonWindowScalingEnable = 144,
	AutoAfkSwitchingTime = 145,
	AutoChangeCameraMode = 146,
	AccessibilitySoundVisualEnable = 147,
	AccessibilitySoundVisualDispSize = 148,
	AccessibilitySoundVisualPermeabilityRate = 149,
	AccessibilityColorBlindFilterEnable = 150,
	AccessibilityColorBlindFilterType = 151,
	AccessibilityColorBlindFilterStrength = 152,
	// System - Mouse Settings
	MouseAutoFocus = 154,
	// System - UI Settings
	FPSDownAFK = 156,
	IdlingCameraAFK = 157,
	MouseSpeed = 178,
	CameraZoom = 192,
	DynamicRezoType = 307,
	// System - Move Operation
	Is3DAudio = 314,
	BattleEffect = 316,
	BGEffect = 317,
	ColorThemeType = 697,
	SystemMouseOperationSoftOn = 785,
	SystemMouseOperationTrajectory = 786,
	SystemMouseOperationCursorScaling = 787,
	HardwareCursorSize = 788,
	UiAssetType = 789,
	FellowshipShowNewNotice = 807,
	// System - Cutscene Settings
	CutsceneMovieVoice = 820,
	CutsceneMovieCaption = 821,
	CutsceneMovieOpening = 822,
	// System - SoundPlay Settings
	SoundMaster = 825,
	SoundBgm = 826,
	SoundSe = 827,
	SoundVoice = 828,
	SoundEnv = 829,
	SoundSystem = 830,
	SoundPerform = 831,
	SoundPlayer = 832,
	SoundParty = 833,
	SoundOther = 834,
	IsSndMaster = 835,
	IsSndBgm = 836,
	IsSndSe = 837,
	IsSndVoice = 838,
	IsSndEnv = 839,
	IsSndSystem = 840,
	IsSndPerform = 841,
	SoundDolby = 842,
	SoundMicpos = 843,
	SoundChocobo = 844,
	SoundFieldBattle = 845,
	SoundCfTimeCount = 846,
	SoundHousing = 847,
	SoundEqualizerType = 848,
	// System - GamePad Button Settings
	PadButton_L2 = 850,
	PadButton_R2 = 851,
	PadButton_L1 = 852,
	PadButton_R1 = 853,
	PadButton_Triangle = 854,
	PadButton_Circle = 855,
	PadButton_Cross = 856,
	PadButton_Square = 857,
	PadButton_Select = 858,
	PadButton_Start = 859,
	PadButton_LS = 860,
	PadButton_RS = 861,
	PadButton_L3 = 862,
	PadButton_R3 = 863,
	// System - CUSTOM CONFIGURATION


	// Ui Config
	BattleEffectSelf = 55,
	BattleEffectParty = 56,
	BattleEffectOther = 57,
	BattleEffectPvPEnemyPc = 58,
	// Ui - GamePad Settings
	// Ui - UI Settings
	// Ui - Charcter Settings
	WeaponAutoPutAway = 159,
	WeaponAutoPutAwayTime = 160,
	LipMotionType = 161,
	// Ui - Game Camera Settings
	FirstPersonDefaultYAngle = 163,
	FirstPersonDefaultZoom = 164,
	FirstPersonDefaultDistance = 165,
	ThirdPersonDefaultYAngle = 166,
	ThirdPersonDefaultZoom = 167,
	ThirdPersonDefaultDistance = 168,
	LockonDefaultYAngle = 169,
	LockonDefaultZoom = 170,
	LockonDefaultZoom_171 = 171,
	CameraProductionOfAction = 187,
	FPSCameraInterpolationType = 188,
	FPSCameraVerticalInterpolation = 189,
	LegacyCameraCorrectionFix = 190,
	LegacyCameraType = 191,
	EventCameraAutoControl = 193,
	CameraLookBlinkType = 194,
	IdleEmoteTime = 195,
	IdleEmoteRandomType = 196,
	CutsceneSkipIsShip = 197,
	CutsceneSkipIsContents = 198,
	CutsceneSkipIsHousing = 199,
	PetTargetOffInCombat = 291,
	GroundTargetFPSPosX = 292,
	GroundTargetFPSPosY = 293,
	GroundTargetTPSPosX = 294,
	GroundTargetTPSPosY = 295,
	TargetDisableAnchor = 296,
	TargetCircleClickFilterEnableNearestCursor = 297,
	TargetEnableMouseOverSelect = 298,
	GroundTargetCursorCorrectType = 299,
	GroundTargetActionExcuteType = 300,
	AutoNearestTarget = 305,
	AutoNearestTargetType = 306,
	RightClickExclusionPC = 308,
	RightClickExclusionBNPC = 309,
	RightClickExclusionMinion = 310,
	TurnSpeed = 313,
	FootEffect = 315,
	LegacySeal = 318,
	GBarrelDisp = 319,
	EgiMirageTypeGaruda = 320,
	EgiMirageTypeTitan = 321,
	EgiMirageTypeIfrit = 322,
	BahamutSize = 323,
	PetMirageTypeCarbuncleSupport = 324,
	PhoenixSize = 325,
	GarudaSize = 326,
	TitanSize = 327,
	IfritSize = 328,
	TimeMode = 329,
	Time12 = 330,
	TimeEorzea = 331,
	TimeLocal = 332,
	TimeServer = 333,
	ActiveLS_H = 334,
	ActiveLS_L = 335,
	HotbarLock = 337,
	HotbarDispRecastTime = 339,
	HotbarCrossContentsActionEnableInput = 340,
	HotbarDispRecastTimeDispType = 341,
	ExHotbarChangeHotbar1 = 354,
	HotbarCommon01 = 356,
	HotbarCommon02 = 357,
	HotbarCommon03 = 358,
	HotbarCommon04 = 359,
	HotbarCommon05 = 360,
	HotbarCommon06 = 361,
	HotbarCommon07 = 362,
	HotbarCommon08 = 363,
	HotbarCommon09 = 364,
	HotbarCommon10 = 365,
	HotbarCrossCommon01 = 366,
	HotbarCrossCommon02 = 367,
	HotbarCrossCommon03 = 368,
	HotbarCrossCommon04 = 369,
	HotbarCrossCommon05 = 370,
	HotbarCrossCommon06 = 371,
	HotbarCrossCommon07 = 372,
	HotbarCrossCommon08 = 373,
	HotbarCrossHelpDisp = 374,
	HotbarCrossOperation = 375,
	HotbarCrossDisp = 376,
	HotbarCrossLock = 377,
	HotbarCrossUsePadGuide = 380,
	HotbarCrossActiveSet = 381,
	HotbarCrossActiveSetPvP = 382,
	HotbarCrossSetChangeCustomIsAuto = 383,
	HotbarCrossSetChangeCustom = 385,
	HotbarCrossSetChangeCustomSet1 = 386,
	HotbarCrossSetChangeCustomSet2 = 387,
	HotbarCrossSetChangeCustomSet3 = 388,
	HotbarCrossSetChangeCustomSet4 = 389,
	HotbarCrossSetChangeCustomSet5 = 390,
	HotbarCrossSetChangeCustomSet6 = 391,
	HotbarCrossSetChangeCustomSet7 = 392,
	HotbarCrossSetChangeCustomSet8 = 393,
	HotbarCrossSetChangeCustomIsSword = 394,
	HotbarCrossSetChangeCustomIsSwordSet1 = 395,
	HotbarCrossSetChangeCustomIsSwordSet2 = 396,
	HotbarCrossSetChangeCustomIsSwordSet3 = 397,
	HotbarCrossSetChangeCustomIsSwordSet4 = 398,
	HotbarCrossSetChangeCustomIsSwordSet5 = 399,
	HotbarCrossSetChangeCustomIsSwordSet6 = 400,
	HotbarCrossSetChangeCustomIsSwordSet7 = 401,
	HotbarCrossSetChangeCustomIsSwordSet8 = 402,
	HotbarCrossAdvancedSetting = 403,
	HotbarCrossAdvancedSettingLeft = 404,
	HotbarCrossAdvancedSettingRight = 405,
	HotbarCrossSetPvpModeActive = 406,
	HotbarCrossSetChangeCustomPvp = 407,
	HotbarCrossSetChangeCustomIsAutoPvp = 408,
	HotbarCrossSetChangeCustomSet1Pvp = 409,
	HotbarCrossSetChangeCustomSet2Pvp = 410,
	HotbarCrossSetChangeCustomSet3Pvp = 411,
	HotbarCrossSetChangeCustomSet4Pvp = 412,
	HotbarCrossSetChangeCustomSet5Pvp = 413,
	HotbarCrossSetChangeCustomSet6Pvp = 414,
	HotbarCrossSetChangeCustomSet7Pvp = 415,
	HotbarCrossSetChangeCustomSet8Pvp = 416,
	HotbarCrossSetChangeCustomIsSwordPvp = 417,
	HotbarCrossSetChangeCustomIsSwordSet1Pvp = 418,
	HotbarCrossSetChangeCustomIsSwordSet2Pvp = 419,
	HotbarCrossSetChangeCustomIsSwordSet3Pvp = 420,
	HotbarCrossSetChangeCustomIsSwordSet4Pvp = 421,
	HotbarCrossSetChangeCustomIsSwordSet5Pvp = 422,
	HotbarCrossSetChangeCustomIsSwordSet6Pvp = 423,
	HotbarCrossSetChangeCustomIsSwordSet7Pvp = 424,
	HotbarCrossSetChangeCustomIsSwordSet8Pvp = 425,
	HotbarCrossAdvancedSettingPvp = 426,
	HotbarCrossAdvancedSettingLeftPvp = 427,
	HotbarCrossAdvancedSettingRightPvp = 428,
	HotbarWXHBEnable = 429,
	HotbarWXHBSetLeft = 430,
	HotbarWXHBSetRight = 431,
	HotbarWXHBEnablePvP = 432,
	HotbarWXHBSetLeftPvP = 433,
	HotbarWXHBSetRightPvP = 434,
	HotbarWXHB8Button = 435,
	HotbarWXHB8ButtonPvP = 436,
	HotbarWXHBSetInputTime = 437,
	HotbarWXHBDisplay = 438,
	HotbarWXHBFreeLayout = 439,
	HotbarXHBActiveTransmissionAlpha = 440,
	HotbarXHBAlphaDefault = 441,
	HotbarXHBAlphaActiveSet = 442,
	HotbarXHBAlphaInactiveSet = 443,
	HotbarWXHBInputOnce = 444,
	IdlingCameraSwitchType = 445,
	PlateType = 446,
	PlateDispHPBar = 447,
	PlateDisableMaxHPBar = 448,
	NamePlateHpSizeType = 449,
	NamePlateColorSelf = 450,
	NamePlateEdgeSelf = 451,
	NamePlateDispTypeSelf = 452,
	NamePlateNameTypeSelf = 453,
	NamePlateHpTypeSelf = 454,
	NamePlateColorSelfBuddy = 455,
	NamePlateEdgeSelfBuddy = 456,
	NamePlateDispTypeSelfBuddy = 457,
	NamePlateHpTypeSelfBuddy = 458,
	NamePlateColorSelfPet = 459,
	NamePlateEdgeSelfPet = 460,
	NamePlateDispTypeSelfPet = 461,
	NamePlateHpTypeSelfPet = 462,
	NamePlateColorParty = 463,
	NamePlateEdgeParty = 464,
	NamePlateDispTypeParty = 465,
	NamePlateNameTypeParty = 466,
	NamePlateHpTypeParty = 467,
	NamePlateDispTypePartyPet = 468,
	NamePlateHpTypePartyPet = 469,
	NamePlateDispTypePartyBuddy = 470,
	NamePlateHpTypePartyBuddy = 471,
	NamePlateColorAlliance = 472,
	NamePlateEdgeAlliance = 473,
	NamePlateDispTypeAlliance = 474,
	NamePlateNameTypeAlliance = 475,
	NamePlateHpTypeAlliance = 476,
	NamePlateDispTypeAlliancePet = 477,
	NamePlateHpTypeAlliancePet = 478,
	NamePlateColorOther = 479,
	NamePlateEdgeOther = 480,
	NamePlateDispTypeOther = 481,
	NamePlateNameTypeOther = 482,
	NamePlateHpTypeOther = 483,
	NamePlateDispTypeOtherPet = 484,
	NamePlateHpTypeOtherPet = 485,
	NamePlateDispTypeOtherBuddy = 486,
	NamePlateHpTypeOtherBuddy = 487,
	NamePlateColorUnengagedEnemy = 488,
	NamePlateEdgeUnengagedEnemy = 489,
	NamePlateDispTypeUnengagedEnemy = 490,
	NamePlateHpTypeUnengagedEmemy = 491,
	NamePlateColorEngagedEnemy = 492,
	NamePlateEdgeEngagedEnemy = 493,
	NamePlateDispTypeEngagedEnemy = 494,
	NamePlateHpTypeEngagedEmemy = 495,
	NamePlateColorClaimedEnemy = 496,
	NamePlateEdgeClaimedEnemy = 497,
	NamePlateDispTypeClaimedEnemy = 498,
	NamePlateHpTypeClaimedEmemy = 499,
	NamePlateColorUnclaimedEnemy = 500,
	NamePlateEdgeUnclaimedEnemy = 501,
	NamePlateDispTypeUnclaimedEnemy = 502,
	NamePlateHpTypeUnclaimedEmemy = 503,
	NamePlateColorNpc = 504,
	NamePlateEdgeNpc = 505,
	NamePlateDispTypeNpc = 506,
	NamePlateHpTypeNpc = 507,
	NamePlateColorObject = 508,
	NamePlateEdgeObject = 509,
	NamePlateDispTypeObject = 510,
	NamePlateHpTypeObject = 511,
	NamePlateColorMinion = 512,
	NamePlateEdgeMinion = 513,
	NamePlateDispTypeMinion = 514,
	NamePlateColorOtherBuddy = 515,
	NamePlateEdgeOtherBuddy = 516,
	NamePlateColorOtherPet = 517,
	NamePlateEdgeOtherPet = 518,
	NamePlateNameTitleTypeSelf = 519,
	NamePlateNameTitleTypeParty = 520,
	NamePlateNameTitleTypeAlliance = 521,
	NamePlateNameTitleTypeOther = 522,
	NamePlateNameTitleTypeFriend = 523,
	NamePlateColorFriend = 524,
	NamePlateColorFriendEdge = 525,
	NamePlateDispTypeFriend = 526,
	NamePlateNameTypeFriend = 527,
	NamePlateHpTypeFriend = 528,
	NamePlateDispTypeFriendPet = 529,
	NamePlateHpTypeFriendPet = 530,
	NamePlateDispTypeFriendBuddy = 531,
	NamePlateHpTypeFriendBuddy = 532,
	NamePlateColorLim = 533,
	NamePlateColorLimEdge = 534,
	NamePlateColorGri = 535,
	NamePlateColorGriEdge = 536,
	NamePlateColorUld = 537,
	NamePlateColorUldEdge = 538,
	NamePlateColorHousingFurniture = 539,
	NamePlateColorHousingFurnitureEdge = 540,
	NamePlateDispTypeHousingFurniture = 541,
	NamePlateColorHousingField = 542,
	NamePlateColorHousingFieldEdge = 543,
	NamePlateDispTypeHousingField = 544,
	NamePlateNameTypePvPEnemy = 545,
	NamePlateDispTypeFeast = 546,
	NamePlateNameTypeFeast = 547,
	NamePlateHpTypeFeast = 548,
	NamePlateDispTypeFeastPet = 549,
	NamePlateHpTypeFeastPet = 550,
	NamePlateNameTitleTypeFeast = 551,
	NamePlateDispSize = 552,
	ActiveInfo = 553,
	PartyList = 554,
	PartyListStatus = 555,
	PartyListStatusTimer = 557,
	EnemyList = 558,
	TargetInfo = 559,
	Gil = 560,
	DTR = 561,
	PlayerInfo = 563,
	NaviMap = 564,
	Help = 565,
	CrossMainHelp = 567,
	HousingLocatePreview = 569,
	Log = 570,
	LogTell = 571,
	LogFontSize = 573,
	LogTabName2 = 574,
	LogTabName3 = 575,
	LogTabFilter0 = 576,
	LogTabFilter1 = 577,
	LogTabFilter2 = 578,
	LogTabFilter3 = 579,
	LogChatFilter = 580,
	LogEnableErrMsgLv1 = 581,
	LogNameType = 583,
	LogTimeDisp = 584,
	LogTimeSettingType = 585,
	LogTimeDispType = 586,
	IsLogTell = 587,
	IsLogParty = 588,
	LogParty = 589,
	IsLogAlliance = 590,
	LogAlliance = 591,
	IsLogFc = 592,
	LogFc = 593,
	IsLogPvpTeam = 594,
	LogPvpTeam = 595,
	IsLogLs1 = 596,
	LogLs1 = 597,
	IsLogLs2 = 598,
	LogLs2 = 599,
	IsLogLs3 = 600,
	LogLs3 = 601,
	IsLogLs4 = 602,
	LogLs4 = 603,
	IsLogLs5 = 604,
	LogLs5 = 605,
	IsLogLs6 = 606,
	LogLs6 = 607,
	IsLogLs7 = 608,
	LogLs7 = 609,
	IsLogLs8 = 610,
	LogLs8 = 611,
	IsLogBeginner = 612,
	LogBeginner = 613,
	IsLogCwls = 614,
	IsLogCwls2 = 615,
	IsLogCwls3 = 616,
	IsLogCwls4 = 617,
	IsLogCwls5 = 618,
	IsLogCwls6 = 619,
	IsLogCwls7 = 620,
	IsLogCwls8 = 621,
	LogCwls = 622,
	LogCwls2 = 623,
	LogCwls3 = 624,
	LogCwls4 = 625,
	LogCwls5 = 626,
	LogCwls6 = 627,
	LogCwls7 = 628,
	LogCwls8 = 629,
	LogRecastActionErrDisp = 630,
	LogPermeationRate = 631,
	LogFontSizeForm = 632,
	LogItemLinkEnableType = 633,
	LogFontSizeLog2 = 634,
	LogTimeDispLog2 = 635,
	LogPermeationRateLog2 = 636,
	LogFontSizeLog3 = 637,
	LogTimeDispLog3 = 638,
	LogPermeationRateLog3 = 639,
	LogFontSizeLog4 = 640,
	LogTimeDispLog4 = 641,
	LogPermeationRateLog4 = 642,
	LogFlyingHeightMaxErrDisp = 643,
	LogCrossWorldName = 644,
	LogDragResize = 645,
	ChatType = 646,
	ShopSell = 647,
	ColorSay = 648,
	ColorShout = 649,
	ColorTell = 650,
	ColorParty = 651,
	ColorAlliance = 652,
	ColorLS1 = 653,
	ColorLS2 = 654,
	ColorLS3 = 655,
	ColorLS4 = 656,
	ColorLS5 = 657,
	ColorLS6 = 658,
	ColorLS7 = 659,
	ColorLS8 = 660,
	ColorFCompany = 661,
	ColorPvPGroup = 662,
	ColorPvPGroupAnnounce = 663,
	ColorBeginner = 664,
	ColorEmoteUser = 665,
	ColorEmote = 666,
	ColorYell = 667,
	ColorBeginnerAnnounce = 669,
	ColorCWLS = 670,
	ColorCWLS2 = 671,
	ColorCWLS3 = 672,
	ColorCWLS4 = 673,
	ColorCWLS5 = 674,
	ColorCWLS6 = 675,
	ColorCWLS7 = 676,
	ColorCWLS8 = 677,
	ColorAttackSuccess = 678,
	ColorAttackFailure = 679,
	ColorAction = 680,
	ColorItem = 681,
	ColorCureGive = 682,
	ColorBuffGive = 683,
	ColorDebuffGive = 684,
	ColorEcho = 685,
	ColorSysMsg = 686,
	ColorFCAnnounce = 687,
	ColorSysBattle = 688,
	ColorSysGathering = 689,
	ColorSysErr = 690,
	ColorNpcSay = 691,
	ColorItemNotice = 692,
	ColorGrowup = 693,
	ColorLoot = 694,
	ColorCraft = 695,
	ColorGathering = 696,
	ShopConfirm = 698,
	ShopConfirmMateria = 699,
	ShopConfirmExRare = 700,
	ShopConfirmSpiritBondMax = 701,
	ItemSortItemCategory = 702,
	ItemSortEquipLevel = 703,
	ItemSortItemLevel = 704,
	ItemSortItemStack = 705,
	ItemSortTidyingType = 706,
	ItemNoArmoryMaskOff = 707,
	InfoSettingDispWorldNameType = 720,
	TargetNamePlateNameType = 722,
	FocusTargetNamePlateNameType = 725,
	ItemDetailTemporarilySwitch = 727,
	ItemDetailTemporarilySwitchKey = 728,
	ItemDetailTemporarilyHide = 729,
	ItemDetailTemporarilyHideKey = 730,
	ToolTipDispSize = 740,
	RecommendLoginDisp = 741,
	RecommendAreaChangeDisp = 742,
	PlayGuideLoginDisp = 743,
	PlayGuideAreaChangeDisp = 744,
	MapPadOperationYReverse = 747,
	MapPadOperationXReverse = 748,
	MapDispSize = 750,
	FlyTextDispSize = 751,
	PopUpTextDispSize = 753,
	DetailDispDelayType = 754,
	PartyListSortTypeTank = 755,
	PartyListSortTypeHealer = 756,
	PartyListSortTypeDps = 757,
	PartyListSortTypeOther = 758,
	RatioHpDisp = 759,
	BuffDispType = 760,
	ContentsFinderListSortType = 763,
	ContentsFinderSupplyEnable = 764,
	EnemyListCastbarEnable = 770,
	AchievementAppealLoginDisp = 771,
	ContentsFinderUseLangTypeJA = 772,
	ContentsFinderUseLangTypeEN = 773,
	ContentsFinderUseLangTypeDE = 774,
	ContentsFinderUseLangTypeFR = 775,
	ItemInventryWindowSizeType = 783,
	ItemInventryRetainerWindowSizeType = 784,
	BattleTalkShowFace = 790,
	BannerContentsDispType = 791,
	BannerContentsNotice = 792,
	MipDispType = 793,
	BannerContentsOrderType = 794,
	EmoteTextType = 795,
	IsEmoteSe = 796,
	EmoteSeType = 797,
	PartyFinderNewArrivalDisp = 798,
	GPoseTargetFilterNPCLookAt = 799,
	GPoseMotionFilterAction = 800,
	LsListSortPriority = 801,
	FriendListSortPriority = 802,
	FriendListFilterType = 803,
	FriendListSortType = 804,
	LetterListFilterType = 805,
	LetterListSortType = 806,
	ContentsReplayEnable = 808,
	MouseWheelOperationUp = 809,
	MouseWheelOperationDown = 810,
	MouseWheelOperationCtrlUp = 811,
	MouseWheelOperationCtrlDown = 812,
	MouseWheelOperationAltUp = 813,
	MouseWheelOperationAltDown = 814,
	MouseWheelOperationShiftUp = 815,
	MouseWheelOperationShiftDown = 816,
	TelepoTicketUseType = 817,
	TelepoTicketGilSetting = 818,
	PvPFrontlinesGCFree = 823,


	// UiControl Config
	// UiControl - Charcter Settings
	AutoChangePointOfView = 172,
	KeyboardCameraInterpolationType = 173,
	KeyboardCameraVerticalInterpolation = 174,
	TiltOffset = 175,
	KeyboardSpeed = 176,
	PadSpeed = 177,
	PadFpsXReverse = 179,
	PadFpsYReverse = 180,
	PadTpsXReverse = 181,
	PadTpsYReverse = 182,
	MouseFpsXReverse = 183,
	MouseFpsYReverse = 184,
	MouseTpsXReverse = 185,
	MouseTpsYReverse = 186,
	FlyingControlType = 200,
	FlyingLegacyAutorun = 201,
	// UiControl - Target Settings
	AutoFaceTargetOnAction = 203,
	SelfClick = 204,
	NoTargetClickCancel = 205,
	AutoTarget = 206,
	TargetTypeSelect = 207,
	AutoLockOn = 208,
	CircleBattleModeAutoChange = 210,
	CircleIsCustom = 211,
	CircleSwordDrawnIsActive = 212,
	CircleSwordDrawnNonPartyPc = 213,
	CircleSwordDrawnParty = 214,
	CircleSwordDrawnEnemy = 215,
	CircleSwordDrawnAggro = 216,
	CircleSwordDrawnNpcOrObject = 217,
	CircleSwordDrawnMinion = 218,
	CircleSwordDrawnDutyEnemy = 219,
	CircleSwordDrawnPet = 220,
	CircleSwordDrawnAlliance = 221,
	CircleSwordDrawnMark = 222,
	CircleSheathedIsActive = 223,
	CircleSheathedNonPartyPc = 224,
	CircleSheathedParty = 225,
	CircleSheathedEnemy = 226,
	CircleSheathedAggro = 227,
	CircleSheathedNpcOrObject = 228,
	CircleSheathedMinion = 229,
	CircleSheathedDutyEnemy = 230,
	CircleSheathedPet = 231,
	CircleSheathedAlliance = 232,
	CircleSheathedMark = 233,
	CircleClickIsActive = 234,
	CircleClickNonPartyPc = 235,
	CircleClickParty = 236,
	CircleClickEnemy = 237,
	CircleClickAggro = 238,
	CircleClickNpcOrObject = 239,
	CircleClickMinion = 240,
	CircleClickDutyEnemy = 241,
	CircleClickPet = 242,
	CircleClickAlliance = 243,
	CircleClickMark = 244,
	CircleXButtonIsActive = 245,
	CircleXButtonNonPartyPc = 246,
	CircleXButtonParty = 247,
	CircleXButtonEnemy = 248,
	CircleXButtonAggro = 249,
	CircleXButtonNpcOrObject = 250,
	CircleXButtonMinion = 251,
	CircleXButtonDutyEnemy = 252,
	CircleXButtonPet = 253,
	CircleXButtonAlliance = 254,
	CircleXButtonMark = 255,
	CircleYButtonIsActive = 256,
	CircleYButtonNonPartyPc = 257,
	CircleYButtonParty = 258,
	CircleYButtonEnemy = 259,
	CircleYButtonAggro = 260,
	CircleYButtonNpcOrObject = 261,
	CircleYButtonMinion = 262,
	CircleYButtonDutyEnemy = 263,
	CircleYButtonPet = 264,
	CircleYButtonAlliance = 265,
	CircleYButtonMark = 266,
	CircleBButtonIsActive = 267,
	CircleBButtonNonPartyPc = 268,
	CircleBButtonParty = 269,
	CircleBButtonEnemy = 270,
	CircleBButtonAggro = 271,
	CircleBButtonNpcOrObject = 272,
	CircleBButtonMinion = 273,
	CircleBButtonDutyEnemy = 274,
	CircleBButtonPet = 275,
	CircleBButtonAlliance = 276,
	CircleBButtonMark = 277,
	CircleAButtonIsActive = 278,
	CircleAButtonNonPartyPc = 279,
	CircleAButtonParty = 280,
	CircleAButtonEnemy = 281,
	CircleAButtonAggro = 282,
	CircleAButtonNpcOrObject = 283,
	CircleAButtonMinion = 284,
	CircleAButtonDutyEnemy = 285,
	CircleAButtonPet = 286,
	CircleAButtonAlliance = 287,
	CircleAButtonMark = 288,
	GroundTargetType = 289,
	GroundTargetCursorSpeed = 290,
	TargetCircleType = 301,
	TargetLineType = 302,
	LinkLineType = 303,
	ObjectBorderingType = 304,
	MoveMode = 312,
	HotbarDisp = 336,
	HotbarEmptyVisible = 338,
	HotbarNoneSlotDisp01 = 342,
	HotbarNoneSlotDisp02 = 343,
	HotbarNoneSlotDisp03 = 344,
	HotbarNoneSlotDisp04 = 345,
	HotbarNoneSlotDisp05 = 346,
	HotbarNoneSlotDisp06 = 347,
	HotbarNoneSlotDisp07 = 348,
	HotbarNoneSlotDisp08 = 349,
	HotbarNoneSlotDisp09 = 350,
	HotbarNoneSlotDisp10 = 351,
	HotbarNoneSlotDispEX = 352,
	ExHotbarSetting = 353,
	HotbarExHotbarUseSetting = 355,
	HotbarCrossUseEx = 378,
	HotbarCrossUseExDirection = 379,
	HotbarCrossDispType = 384,
	PartyListSoloOff = 556,
	HowTo = 566,
	HousingFurnitureBindConfirm = 568,
	DirectChat = 582,
	CharaParamDisp = 708,
	LimitBreakGaugeDisp = 709,
	ScenarioTreeDisp = 710,
	ScenarioTreeCompleteDisp = 711,
	HotbarCrossDispAlways = 712,
	ExpDisp = 713,
	InventryStatusDisp = 714,
	DutyListDisp = 715,
	NaviMapDisp = 716,
	GilStatusDisp = 717,
	InfoSettingDisp = 718,
	InfoSettingDispType = 719,
	TargetInfoDisp = 721,
	EnemyListDisp = 723,
	FocusTargetDisp = 724,
	ItemDetailDisp = 726,
	ActionDetailDisp = 731,
	DetailTrackingType = 732,
	ToolTipDisp = 733,
	MapPermeationRate = 734,
	MapOperationType = 735,
	PartyListDisp = 736,
	PartyListNameType = 737,
	FlyTextDisp = 738,
	MapPermeationMode = 739,
	AllianceList1Disp = 745,
	AllianceList2Disp = 746,
	TargetInfoSelfBuff = 749,
	PopUpTextDisp = 752,
	ContentsInfoDisp = 761,
	DutyListHideWhenCntInfoDisp = 762,
	DutyListNumDisp = 765,
	InInstanceContentDutyListDisp = 766,
	InPublicContentDutyListDisp = 767,
	ContentsInfoJoiningRequestDisp = 768,
	ContentsInfoJoiningRequestSituationDisp = 769,
	HotbarDispSetNum = 776,
	HotbarDispSetChangeType = 777,
	HotbarDispSetDragType = 778,
	MainCommandType = 779,
	MainCommandDisp = 780,
	MainCommandDragShortcut = 781,
	HotbarDispLookNum = 782,
}