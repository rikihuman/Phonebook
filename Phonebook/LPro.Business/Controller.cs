using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.Business
{
    public class Controller
    {
        private static Rules _Rules = null;
        private static Data.Data _Data = null;
        

        internal static Data.Data Data
        {
            get
            {
                if (_Data == null)
                {
                    _Data = new Data.Data();
                }
                return _Data;
            }
        }
        public static Rules tRules
        {
            get
            {
                if (_Rules == null)
                {
                    _Rules = new Rules();
                }
                return _Rules;
            }
        }
    }
}
