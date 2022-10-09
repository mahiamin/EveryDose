using EveryDose.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDose.Database.DBConstant
{
    public class DatabaseManager
    {
        public void CreateTable(SQLiteConnection conn)
        {
            Constant.dbConnection = conn;
            conn.CreateTable<Employee>();
        }
    }
}
