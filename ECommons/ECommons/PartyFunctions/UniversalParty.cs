﻿using Dalamud.Game.ClientState.Conditions;
using Dalamud.Memory;
using ECommons.DalamudServices;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using System;
using System.Collections.Generic;

namespace ECommons.PartyFunctions;

public unsafe static class UniversalParty
{
    public static bool IsCrossWorldParty => Svc.Condition[ConditionFlag.ParticipatingInCrossWorldPartyOrAlliance];

    public static int Length  
    {
        get 
        {
            var cnt = IsCrossWorldParty ? InfoProxyCrossRealm.Instance()->CrossRealmGroupSpan.Length : Svc.Party.Length;
            return cnt > 1?cnt:0;
        }
    }

    public static UniversalPartyMember[] Members
    {
        get
        {
            if (Length == 0) return Array.Empty<UniversalPartyMember>();
            var span = new List<UniversalPartyMember>();
            if (IsCrossWorldParty)
            {
                foreach (var x in InfoProxyCrossRealm.Instance()->CrossRealmGroupSpan[0].GroupMemberSpan)
                {
                    span.Add(new()
                    {
                        Name = MemoryHelper.ReadStringNullTerminated((IntPtr)x.Name),
                        HomeWorld = new((uint)x.HomeWorld),
                        CurrentWorld = new((uint)x.CurrentWorld),
                    });
                }
            }
            else
            {
                foreach(var x in Svc.Party)
                {
                    span.Add(new()
                    {
                        Name = x.Name.ToString(),
                        HomeWorld = new(x.World),
                        CurrentWorld = new(Svc.ClientState.LocalPlayer.CurrentWorld),
                        GameObjectInternal = x.GameObject
                    });
                }
            }
            return span.ToArray();
        }
    }
}
