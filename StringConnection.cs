using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 总包test
{
    public class StringConnection
    {
        public string Uid { get; set; }
        public string Database { get; set; }
        public string Pwd { get; set; }

        public override string ToString()
        {
            string strCon = String.Format("Data Source=MicroWin10-2015;database={0};uid={1};pwd={2};", Database, Uid, Pwd);
            return strCon;
        }

        public static StringConnection Instance()
        {
            if (s_c == null)
                s_c = new StringConnection();
            return s_c;
        }

        private static StringConnection s_c;
    }
}
