﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public interface IProgressEvent
    {
        void ProgressUpdate(string msg);
    }
}
