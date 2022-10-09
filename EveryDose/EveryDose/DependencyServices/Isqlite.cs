using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDose.DependencyServices
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
