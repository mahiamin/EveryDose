using EveryDose.DependencyServices;
using EveryDose.Droid.DependencyServices;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQliteDroid))]
namespace EveryDose.Droid.DependencyServices
{
    public class SQliteDroid : Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "Mydatabase";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }
    }
}