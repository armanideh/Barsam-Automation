using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automasion_Software
{
    public class User
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string family;
        public string Family
        {
            get { return family; }
            set { family = value; }
        }

        string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        string pass;
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        string groupName;
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        string emzaAddress;
        public string EmzaAddress
        {
            get { return emzaAddress; }
            set { emzaAddress = value; }
        }

        string rule;
        public string Rule
        {
            get { return rule; }
            set { rule = value; }
        }
        int groupIndex;

        public int GroupIndex
        {
            get { return groupIndex; }
            set { groupIndex = value; }
        }
    }
}
