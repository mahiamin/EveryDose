using EveryDose.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDose.Database.DBInterface
{
    public interface IDatabaseOperation
    {
        int Addemployee(Employee emp);
        int UpdateEmployee(Employee emp);

        List<Employee> GetEmployees();
    }
}
