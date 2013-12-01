using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public class UserNameMapItem
    {
        private string _procName;
        private string _fullName;
        private string _shortName;
        private string _extPhoneNumber;

        public string ProcName
        {
            get { return _procName; }
            set { _procName = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        public string ExtPhoneNumber
        {
            get { return _extPhoneNumber; }
            set { _extPhoneNumber = value; }
        }

        }
    }

    public class UserNameMap
    {
    }
}
