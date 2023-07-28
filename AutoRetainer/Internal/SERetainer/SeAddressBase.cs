﻿using Dalamud.Game;

namespace AutoRetainer.Internal.SERetainer;

public class SeAddressBase
{
    public readonly IntPtr Address;

    public SeAddressBase(SigScanner sigScanner, string signature, int offset = 0)
    {
        Address = sigScanner.GetStaticAddressFromSig(signature);
        if (Address != IntPtr.Zero)
            Address += offset;
        var baseOffset = (ulong)Address.ToInt64() - (ulong)sigScanner.Module.BaseAddress.ToInt64();
        P.DebugLog($"{GetType().Name} address 0x{Address.ToInt64():X16}, baseOffset 0x{baseOffset:X16}.");
    }
}
