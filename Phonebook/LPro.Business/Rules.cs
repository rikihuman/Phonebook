using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Phonebook.Business
{
    public class Rules
    {
        public bool exSaveContacts(Phonebook.Model.Contact contact, Phonebook.Model.ContactNumber contactNumber)
        {
            return Controller.Data.exSaveContacts(contact, contactNumber);
        }

        public Collection<Phonebook.Model.Relationship> exGetRelationships()
        {
            return Controller.Data.exGetRelationships();
        }

        public Collection<Phonebook.Model.NumberType> exGetNumberTypes()
        {
            return Controller.Data.exGetNumberTypes();
        }

        public Collection<Phonebook.Model.ContactNumber> exGetContactNumbers()
        {
            return Controller.Data.exGetContactNumbers();
        }

        public Collection<Phonebook.Model.Contact> exGetContacts()
        {
            return Controller.Data.exGetContacts();
        }


        //public Collection<Phonebook.Device.Model.Applicant.exFingerAudit> exGetFingerAudit(Phonebook.Device.Model.Applicant.exFingerAudit fingerAudit)
        //{
        //    return Controller.ApplicantData.exGetFingerAudit(fingerAudit);
        //}
        //public bool SaveTestResult(Phonebook.Device.Model.Questions.ExTestResult result)
        //{
        //    return Controller.ApplicantData.SaveTestResult(result);
        //}



    }
}
