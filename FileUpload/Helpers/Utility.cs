using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.Odbc;
using System;
using System.Web;
using System.Data.OleDb;
using FileUpload.Controllers;
using ExcelDataReader;
using Newtonsoft.Json;
using System.Reflection;
using FileUpload.Models;

namespace FileUpload.Models
{
    public class Utility
    {     
        public static void ConvertXSLX(string fileName)
        {
            string json;
            // required because of known issue when running on .NET Core
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(Helpers.Constants.EXCEL_PATH + fileName, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                DataTableCollection sheets = reader.AsDataSet(GetDataSetConfig()).Tables;
                DataTable sheet = sheets[Helpers.Constants.SHEET]; 
                List<User> userList = sheet.DataTableToList<User>();
                json = JsonConvert.SerializeObject(userList, Formatting.Indented);
                File.WriteAllText(Helpers.Constants.JSON_PATH, json);
            }
        }

        
        
        private static ExcelDataSetConfiguration GetDataSetConfig()
        {
            return new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true,
                    ReadHeaderRow = rowReader => Console.WriteLine("{0}: {1} {2} {3} {4}", rowReader[0], rowReader[1], rowReader[2], rowReader[3], rowReader[4])                 
                }
            };
        }

        // private static List<Models.User> GetData()
        public static List<Models.User> GetData()
        {   
            string json = File.ReadAllText(Helpers.Constants.JSON_PATH);
            // Ignore Bad Data
            var settings = new JsonSerializerSettings { Error = (se, ev) => { ev.ErrorContext.Handled = true; } };
            // Deserialize data.json
            return JsonConvert.DeserializeObject<List<User>>(json, settings);
            //return dataList;
        }

      

    }
}

public class Enum<EnumType> where EnumType : struct, IConvertible
{

    /// <summary>
    /// Retrieves an array of the values of the constants in a specified enumeration.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public static EnumType[] GetValues()
    {
        return (EnumType[])Enum.GetValues(typeof(EnumType));
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static EnumType Parse(string name)
    {
        return (EnumType)Enum.Parse(typeof(EnumType), name);
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ignoreCase"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static EnumType Parse(string name, bool ignoreCase)
    {
        return (EnumType)Enum.Parse(typeof(EnumType), name, ignoreCase);
    }

    /// <summary>
    /// Converts the specified object with an integer value to an enumeration member.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static EnumType ToObject(object value)
    {
        return (EnumType)Enum.ToObject(typeof(EnumType), value);
    }
}

public static class Helper
{
    /// <summary>
    /// Converts a DataTable to a list with generic objects
    /// </summary>
    /// <typeparam name="T">Generic object</typeparam>
    /// <param name="table">DataTable</param>
    /// <returns>List with generic objects</returns>
    public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            List<T> list = new List<T>();

            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();

                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        if (propertyInfo.PropertyType.IsEnum)
                        {
                            propertyInfo.SetValue(obj, (Status)Enum.Parse(propertyInfo.PropertyType, row[prop.Name].ToString()));
                        }
                        else
                        {
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        catch
        {
            return null;
        }
    }

    public static IEnumerable<DataRow> AsEnumerable(this DataTable table)
    {
        for (int i = 0; i < table.Rows.Count; i++)
        {
            yield return table.Rows[i];
        }
    }
}