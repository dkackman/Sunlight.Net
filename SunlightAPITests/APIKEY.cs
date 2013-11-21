using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SunlightAPITests
{
    static class APIKEY
    {
//#error either place you key in the file loaded below or return it directly here
//#warning http://sunlightfoundation.com/api/accounts/register/
        private static readonly string _key;

        static APIKEY()
        {
            try
            {
                using (var file = File.OpenRead(@"D:\temp\sunlight.key.txt"))
                using (var reader = new StreamReader(file))
                    _key = reader.ReadLine();
            }
            catch
            {
                _key = "";
            }
        }

        public static string Key
        {
            get
            {
                return _key;
            }
        }
    }
}
