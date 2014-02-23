using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public enum OwnerShowFormat: int
    {
        Default = 0,
        DomainUser = 1,
        FullName = 2,
        ShortName = 3,
        Phone = 4
    }

    public class OwnerEntry
    {
        private string _domain = string.Empty;
        private string _user = string.Empty;
        private string _fullName = string.Empty;
        private string _shortName = string.Empty;
        private string _phone = string.Empty;
        private string _key = string.Empty;

        public string DomainUser
        {
            get { return _domain + "\\" + _user; }
        }
        public string Domain
        {
            get { return _domain; }
            set { _domain = value.ToLower(); _key = _domain + "\\" + _user; }
        }

        public string User
        {
            get { return _user; }
            set { _user = value.ToLower(); _key = _domain + "\\" + _user; }
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

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Key
        {
            get { return _key; }
        }

        public OwnerEntry(string domainUser) //like "corp\yuanf"
        {
            domainUser = domainUser.ToLower();
            string[] stemp = domainUser.Split(new char[] { '\\', '/' });
            if (stemp.Length > 0)
            {
                _domain = stemp[0];
                if (stemp.Length > 1)
                {
                    _user = stemp[1];
                    _fullName = _domain + "\\" + _user;
                    _shortName = _user;
                    _key = _fullName;
                }
            } 
        }

        public OwnerEntry()
        {

        }

        public OwnerEntry Clone()
        {
            OwnerEntry p = new OwnerEntry();
            p.Domain = (string)this.Domain.Clone();
            p.User = (string)this.User.Clone();
            p.FullName = (string)this.FullName.Clone();
            p.ShortName = (string)this.ShortName.Clone();
            p.Phone = (string)this.Phone.Clone();

            return p;
        }

        public bool Equals(OwnerEntry p, StringComparison cmp = StringComparison.InvariantCultureIgnoreCase)
        {
            return (p.Domain.Equals(this.Domain, cmp) && p.User.Equals(this.User, cmp)
                    && p.FullName.Equals(this.FullName, cmp) && p.ShortName.Equals(this.ShortName, cmp)
                    && p.Phone.Equals(this.Phone, cmp));
        }

        public static bool VerifyDomainUser(string domainUser)
        {
            if (domainUser == null || domainUser.Length <= 0)
                return false;

            int firstIdx = domainUser.IndexOf('\\');
            int lastIdx = domainUser.IndexOf('\\');
            if (firstIdx != lastIdx || firstIdx < 0 || lastIdx < 0)
                return false;

            for (int i = 0; i < domainUser.Length; i++)
            {
                int c = domainUser[i];
                if (i == firstIdx)
                    continue;
                else if (!(c >= '0' && c <= '9' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z'
                        || c == '_' || c == '-'))
                {
                    return false;
                }
            }

            return true;
        }
    }
    static class OwnerTranslate
    {
        private static SortedDictionary<string, OwnerEntry> _allOwners = new SortedDictionary<string, OwnerEntry>();

        public static string GetOwnerShow(OwnerShowFormat fmt, string domainuser)
        {
            if (fmt == OwnerShowFormat.Default)
                return domainuser;

            string lowdu = domainuser.ToLower();
            if (fmt == OwnerShowFormat.DomainUser)
                return lowdu;

            if (!_allOwners.ContainsKey(lowdu))
            {
                return domainuser;
            }

            OwnerEntry owner = _allOwners[lowdu];
            if (owner == null)
                return domainuser;

            if (fmt == OwnerShowFormat.FullName)
                return owner.FullName;
            else if (fmt == OwnerShowFormat.ShortName)
                return owner.ShortName;
            else if (fmt == OwnerShowFormat.Phone)
                return owner.Phone;
            else
                return domainuser;
        }

        public static void Add(OwnerEntry owner)
        {
            if (_allOwners.ContainsKey(owner.Key))
                return;
            _allOwners.Add(owner.Key, owner);
        }

        public static void Remove(string domainuser)
        {
            domainuser = domainuser.ToLower();
            if (_allOwners.ContainsKey(domainuser))
                _allOwners.Remove(domainuser);
        }

        public static void Clear()
        {
            _allOwners.Clear();
        }

        public static SortedDictionary<string, OwnerEntry> AllOwners
        {
            get { return _allOwners; }
        }

        public static bool Contains(string domainuser)
        {
            return _allOwners.ContainsKey(domainuser.ToLower());
        }

        public static OwnerEntry Get(string domainuser)
        {
            domainuser = domainuser.ToLower();
            if (_allOwners.ContainsKey(domainuser))
                return _allOwners[domainuser];
            else
                return null;
        }

        public static void LoadFromFile(string path)
        {
            StreamReader fs = null;
            try
            {
                fs = File.OpenText(path);
                fs.ReadLine(); //version number
                _allOwners.Clear();
                while (!fs.EndOfStream)
                {
                    string line = fs.ReadLine();
                    string[] stemp = line.Split(new char[] { '|' });
                    if (stemp.Length >= 3)
                    {
                        OwnerEntry owner = new OwnerEntry(stemp[0]);
                        owner.FullName = stemp[1];
                        owner.ShortName = stemp[2];
                        if (stemp.Length >= 4)
                            owner.Phone = stemp[3];

                        Add(owner);
                    }
                }
            }
            catch
            {
                _allOwners.Clear();
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        public static void SaveToFile(string path)
        {
            if (_allOwners == null)
                return;

            FileStream fs = null;

            try
            {
                fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] verdata = Encoding.UTF8.GetBytes("version=1.0" + System.Environment.NewLine);
                fs.Write(verdata, 0, verdata.Length);
                foreach (OwnerEntry owner in _allOwners.Values)
                {
                    byte[] bdata = Encoding.UTF8.GetBytes(owner.Key + "|" + owner.FullName + "|" + owner.ShortName + "|" + owner.Phone
                        + System.Environment.NewLine);
                    fs.Write(bdata, 0, bdata.Length);
                }
                fs.Flush();
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }
}
