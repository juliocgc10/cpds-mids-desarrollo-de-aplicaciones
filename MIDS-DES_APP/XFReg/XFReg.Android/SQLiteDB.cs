using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XFReg.DataAccess;
using XFReg.Droid;

[assembly: Dependency(typeof(SQLiteDB))]
namespace XFReg.Droid
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string dbPath = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(dbPath);
        }
    }
}