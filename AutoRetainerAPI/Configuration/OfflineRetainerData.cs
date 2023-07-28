﻿using ECommons.DalamudServices;
using System;
using System.Collections.Generic;

namespace AutoRetainerAPI.Configuration;

[Serializable]
public class OfflineRetainerData : IEquatable<OfflineRetainerData>
{
    public readonly ulong CreationFrame = Svc.PluginInterface.UiBuilder.FrameCount;
    public bool ShouldSerializeCreationFrame => false;
    public string Name = "";
    public long VentureEndsAt = 0;
    public bool HasVenture = false;
    public int Level = 0;
    public long VentureBeginsAt = 0;
    public uint Job = 0;
    public uint VentureID = 0;
    public uint Gil = 0;
    public int DisplayOrder = 0;

    public string Identity => $"{Name}";
    public bool ShouldSerializeIdentity() => false;

    public override bool Equals(object obj)
    {
        return Equals(obj as OfflineRetainerData);
    }

    public bool Equals(OfflineRetainerData other)
    {
        return other is not null &&
               Name == other.Name &&
               VentureEndsAt == other.VentureEndsAt &&
               HasVenture == other.HasVenture &&
               Level == other.Level &&
               VentureBeginsAt == other.VentureBeginsAt &&
               DisplayOrder == other.DisplayOrder;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, VentureEndsAt, HasVenture, Level, VentureBeginsAt);
    }

    public static bool operator ==(OfflineRetainerData left, OfflineRetainerData right)
    {
        return EqualityComparer<OfflineRetainerData>.Default.Equals(left, right);
    }

    public static bool operator !=(OfflineRetainerData left, OfflineRetainerData right)
    {
        return !(left == right);
    }
}
