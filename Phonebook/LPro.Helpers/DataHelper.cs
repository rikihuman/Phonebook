using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;


namespace Phonebook.Helpers
{
    public class DataHelper
    {

        public DataHelper()
        {

        }

        public static void ConvertDataRowToEntity<objectType>(ref objectType Entity, DataRow data)
        {
            Type t = Entity.GetType();
            DataColumnCollection columns = data.Table.Columns;
            foreach (PropertyInfo p in t.GetProperties())
            {
                Type _Ptype = p.PropertyType;
                if (columns[p.Name] != null)
                {
                    object value = data[p.Name];
                    if (data[p.Name].GetType() != typeof(System.DBNull))
                    {
                        object propertyConverted = ConvertType(value, _Ptype);
                        p.SetValue(Entity, propertyConverted, null);
                    }
                }
            }
        }

        public static object ConvertType(object obj, Type type)
        {
            if (obj == null)
                return null;
            else if (type == typeof(Boolean))
                return GetNullCheckedBooleanValue(obj);
            else if (type == typeof(Int32))
                return GetNullCheckedIntValue(obj);
            else if (type == typeof(String))
                return GetNullCheckedStringValue(obj);
            else if (type == typeof(DateTime))
                return GetNullCheckedDateValue(obj);
            else
                return obj;
        }

        public static string ByteArrayToBase64String(byte[] byteArray)
        {
            if (byteArray == null)
                return string.Empty;
            string s = Convert.ToBase64String(byteArray, Base64FormattingOptions.None);
            return s;
        }

        public static bool GetNullCheckedBooleanValue(object o)
        {
            if (o != DBNull.Value)
            {
                return (bool)o;
            }
            else
            {
                return false;
            }
        }

        public static int GetNullCheckedIntValue(object o)
        {
            if (o != DBNull.Value)
            {
                return Convert.ToInt32(o);
            }
            else
            {
                return -1;
            }
        }

        public static string GetNullCheckedStringValue(object o)
        {
            if (o != DBNull.Value)
            {
                return o.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static DateTime GetNullCheckedDateValue(object o)
        {
            if (o != DBNull.Value)
            {
                return (DateTime)o;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static Collection<objectType> ConvertDataTableToEntityList<objectType>(DataTable data)
        {
           

            Collection<objectType> dataList = new Collection<objectType>();
            try
            {
                foreach (DataRow row in data.Rows)
                {
                    objectType obj = (objectType)Activator.CreateInstance(typeof(objectType), new object[] { });
                    Type t = obj.GetType();
                    DataColumnCollection columns = data.Columns;
                    foreach (PropertyInfo p in t.GetProperties())
                    {
                        if (columns[p.Name] != null)
                        {
                            Type _Ptype = p.PropertyType;
                            object value = row[p.Name];
                            if (row[p.Name].GetType() != typeof(System.DBNull))
                            {
                                object propertyConverted = ConvertType(value, _Ptype);
                                p.SetValue(obj, propertyConverted, null);
                            }
                        }
                    }
                    dataList.Add(obj);
                }
            }
            catch (Exception Ex)
            {

                string error = Ex.Message;
                              
            }
            return dataList;
        }

        
    }
}
