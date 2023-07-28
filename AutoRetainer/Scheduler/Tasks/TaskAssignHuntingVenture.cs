﻿using AutoRetainer.Scheduler.Handlers;
using Lumina.Excel.GeneratedSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRetainer.Scheduler.Tasks
{
    internal static class TaskAssignHuntingVenture
    {
        internal static void Enqueue(uint VentureID)
        {
            P.TaskManager.Enqueue(YesAlready.WaitForYesAlreadyDisabledTask);
            if (C.RetainerMenuDelay > 0)
            {
                TaskWaitSelectString.Enqueue(C.RetainerMenuDelay);
            }
            P.TaskManager.Enqueue(RetainerHandlers.SelectAssignVenture);
            P.TaskManager.Enqueue(() => RetainerHandlers.GenericSelectByName(Lang.HuntingVentureNames), $"GenericSelectByName({Lang.HuntingVentureNames})");
            //P.TaskManager.Enqueue(() => RetainerHandlers.GenericSelectByName(VentureUtils.GetVentureLevelCategory(VentureID)), $"GenericSelectByName(VentureUtils.GetVentureLevelCategory({VentureID})");
            //P.TaskManager.Enqueue(() => RetainerHandlers.SelectSpecificVenture(VentureID), $"SelectSpecificVenture({VentureID})");
            //P.TaskManager.Enqueue(() => RetainerHandlers.SearchVentureByName(VentureID));
            P.TaskManager.Enqueue(RetainerHandlers.ClearTaskSupplylist);
            P.TaskManager.Enqueue(() => RetainerHandlers.SelectSpecificVentureByName(VentureID));
            P.TaskManager.DelayNext(10, true);
            P.TaskManager.Enqueue(RetainerHandlers.ClickAskAssign);
        }
    }
}
