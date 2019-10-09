using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Model
{
    public class Contact
    {
        public int ContactID
        {
            get;
            set;
        }
        public String ContactName
        {
            get;
            set;
        }
        public String ContactSurname
        {
            get;
            set;
        }
        public int Relationship
        {
            get;
            set;
        }

        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public int ContactNumberID { get; set; }
        public int NumberType { get; set; }
        public string Number { get; set; }

        public string NumberName { get; set; }
        public string RelationshipName { get; set; }
    }
}
