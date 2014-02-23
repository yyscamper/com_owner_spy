using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public interface IInputOwnerTranslate
    {
        void OnInputOwnerTranslateCompleted(InputOwnerTranslateMode mode, OwnerEntry owner);
    }
}
