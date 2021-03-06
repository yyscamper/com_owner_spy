﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public interface IGeneralEvent
    {
        void UpdateRowHeight(int rowHeight);
        void UpdateOwnerFormat(OwnerShowFormat fmt);

        void OnNotifyChangeTheme(Theme newTheme);
    }
}
