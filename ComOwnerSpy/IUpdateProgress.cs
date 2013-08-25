
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public interface IProgressEvent
    {
        void ProgressInit();
        void ProgressSet(int min, int max);
        void ProgressUpdate(int percent);
        void ProgressCompleted();
        void ProgressNotifyError(string msg);
    }
}
