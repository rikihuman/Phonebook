using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Phonebook.Data
{
    public class Data
    {
        public Collection<Phonebook.Model.Relationship> exGetRelationships()
        {
            string SQL = "exGetRelationships";
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.AddWithValue("@ipaddress", fingerAudit.ipaddress);
            cmd.CommandText = SQL;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return Helpers.DataHelper.ConvertDataTableToEntityList<Phonebook.Model.Relationship>(Helpers.DataAccess.RunFillDataTable(cmd));
        }

        public Collection<Phonebook.Model.NumberType> exGetNumberTypes()
        {
            string SQL = "exGetNumberType";
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.AddWithValue("@ipaddress", fingerAudit.ipaddress);
            cmd.CommandText = SQL;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return Helpers.DataHelper.ConvertDataTableToEntityList<Phonebook.Model.NumberType>(Helpers.DataAccess.RunFillDataTable(cmd));
        }

        public Collection<Phonebook.Model.Contact> exGetContacts()
        {
            string SQL = "exGetContacts";
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.AddWithValue("@ipaddress", fingerAudit.ipaddress);
            cmd.CommandText = SQL;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return Helpers.DataHelper.ConvertDataTableToEntityList<Phonebook.Model.Contact>(Helpers.DataAccess.RunFillDataTable(cmd));
        }

        public Collection<Phonebook.Model.ContactNumber> exGetContactNumbers()
        {
            string SQL = "exGetContactNumber";
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.AddWithValue("@ipaddress", fingerAudit.ipaddress);
            cmd.CommandText = SQL;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return Helpers.DataHelper.ConvertDataTableToEntityList<Phonebook.Model.ContactNumber>(Helpers.DataAccess.RunFillDataTable(cmd));
        }

        public bool exSaveContacts(Phonebook.Model.Contact contact, Phonebook.Model.ContactNumber contactNumber)
        {
            string SQL = "exSaveContacts";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@ContactID", contact.ContactID);
            cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
            cmd.Parameters.AddWithValue("@ContactSurname", contact.ContactSurname);
            cmd.Parameters.AddWithValue("@Relationship", contact.Relationship);
            cmd.Parameters.AddWithValue("@deleted", contact.Deleted);
            cmd.Parameters.AddWithValue("@ContactNumberID", contactNumber.ContactNumberID);
            cmd.Parameters.AddWithValue("@NumberType", contactNumber.NumberType);
            cmd.Parameters.AddWithValue("@Number", contactNumber.Number);
            return Helpers.DataAccess.RunBoolExecuteNonQuery(cmd);
        }
        //public ExamPAK.Device.Model.Questions.LearnerTestQuestionsJV FetchLearnerQuestion(String question_no, String test_language)
        //{
        //    string SQL = "mob_FetchLearnerQuestion";
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = SQL;
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@question_no", question_no);
        //    cmd.Parameters.AddWithValue("@test_language", test_language);

        //    ExamPAK.Device.Model.Questions.LearnerTestQuestionsJV e = new Device.Model.Questions.LearnerTestQuestionsJV();

        //    DataTable dt = Helpers.DataAccess.RunFillDataTable(cmd);

        //    if (dt.Rows.Count > 0)
        //    {
        //        Helpers.DataHelper.ConvertDataRowToEntity<ExamPAK.Device.Model.Questions.LearnerTestQuestionsJV>(ref e, dt.Rows[0]);
        //    }

        //    return e;
        //}

        //public Collection<Phonebook.Model.> exGetFingerAudit(exFingerAudit fingerAudit)
        //{
        //    string SQL = "exGetFingerAudit";
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.AddWithValue("@idnumber", fingerAudit.idNumber);
        //    //cmd.Parameters.AddWithValue("@ipaddress", fingerAudit.ipaddress);
        //    cmd.CommandText = SQL;
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    return Helpers.DataHelper.ConvertDataTableToEntityList<Phonebook.Device.Model.Applicant.exFingerAudit>(Helpers.DataAccess.RunFillDataTable(cmd));
        //}
        //public bool exUpdateFingerAudit(Phonebook.Device.Model.Applicant.exFingerAudit fingerAudit)
        //{
        //    string SQL = "exUpdateFingerAudit";
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = SQL;
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@idnumber", fingerAudit.idNumber);
        //    cmd.Parameters.AddWithValue("@ipaddress", fingerAudit.ipaddress);
        //    cmd.Parameters.AddWithValue("@captureType", fingerAudit.captureType);
        //    cmd.Parameters.AddWithValue("@isMatched", fingerAudit.isMatched);
        //    cmd.Parameters.AddWithValue("@isEnrolled", fingerAudit.isEnrolled);
        //    return Helpers.DataAccess.RunBoolExecuteNonQuery(cmd);
        //}

    }
}
