using EveryDose.Database.DBConstant;
using EveryDose.Database.DBInterface;
using EveryDose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryDose.Database.DBOperation
{
    public class DatabaseOperation : IDatabaseOperation
    {
        public int Addemployee(Employee emp)
        {
            int result = 0;
            result = Constant.dbConnection.Insert(emp);
            return result;
        }

        public List<Employee> GetEmployees()
        {
            var employees = (from x in Constant.dbConnection.Table<Employee>() select x).ToList();
            return employees;
        }

        public int UpdateEmployee(Employee emp)
        {
            int result = 0;

            if (emp.id == 0)
                return result;
           
            result = Constant.dbConnection.Update(emp);
            return result;
        }
    }
}
