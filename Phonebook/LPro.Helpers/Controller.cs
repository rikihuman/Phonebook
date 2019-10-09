using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.Helpers
{
    public class Controller
    {

        internal static Cryptor _crypt;
        public static Cryptor Cryptor
        {
            get
            {
                if (_crypt == null)
                    _crypt = new Cryptor();
                return _crypt;
            }
        }

    }
}
