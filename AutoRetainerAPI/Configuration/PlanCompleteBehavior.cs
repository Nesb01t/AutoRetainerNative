﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRetainerAPI.Configuration
{
    public enum PlanCompleteBehavior
    {
        Restart_plan,
        Assign_Quick_Venture,
        Do_nothing,
        Repeat_last_venture
    }
}
