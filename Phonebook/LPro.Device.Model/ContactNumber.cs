using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Model
{
    public class ContactNumber
    {
        public int ContactNumberID { get; set; }
        public int ContactID { get; set; }
        public int NumberType { get; set; }
        public string Number { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
