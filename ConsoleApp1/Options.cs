using System;
using System.IO;

namespace PracticalWotkI
{
    public class Options
    {
        protected string name;
        public Options(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
    }

    public class Load_File : Options
    {
        public Load_File(string name) : base(name)
        {
        }
    }

    public class Load_Manual : Options
    {
        public Load_Manual(string name) : base(name)
        {
        }
    }

    public class Manual_Start : Options
    {
        public Manual_Start(string name) : base(name)
        {
        }
    }
}