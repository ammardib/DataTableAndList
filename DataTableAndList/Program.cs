using System;
using System.Collections.Generic;
using System.Data;

namespace DataTableAndList
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Convert DataTable To List
            var dt = Helper.GetSampleDataTable();
            var _list = DataTableAndListConverter.ConvertToList<Employee>(dt);

            //2. Convert List To DataTable
            var list = Helper.GetSampleList();
            var _dt = DataTableAndListConverter.ConvertToDataTable<Employee>(list);
        }

        public static class Helper
        {
            public static DataTable GetSampleDataTable()
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("EmployeeId", typeof(int));
                dataTable.Columns.Add("EmployeeName", typeof(string));
                dataTable.Columns.Add("EmployeeSalary", typeof(decimal));

                dataTable.Rows.Add(12002, "Ivan", 5400);
                dataTable.Rows.Add(12016, "Sam", 3800);
                dataTable.Rows.Add(12092, "Eva", 4600);
                dataTable.Rows.Add(12058, "Ana", 7200);
                dataTable.Rows.Add(12047, "Brian", 5300);

                return dataTable;
            }

            public static List<Employee> GetSampleList()
            {
                List<Employee>  employees = new List<Employee>();
                employees.Add(new Employee { EmployeeId = 12002, EmployeeName = "Ivan", EmployeeSalary = 5400 });
                employees.Add(new Employee { EmployeeId = 12016, EmployeeName = "Sam", EmployeeSalary = 3800 });
                employees.Add(new Employee { EmployeeId = 12092, EmployeeName = "Eva", EmployeeSalary = 4600 });
                employees.Add(new Employee { EmployeeId = 12058, EmployeeName = "Ana", EmployeeSalary = 7200 });
                employees.Add(new Employee { EmployeeId = 12047, EmployeeName = "Brian", EmployeeSalary = 5300 });
                
                return employees;
            }
        }

        public class Employee
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public decimal EmployeeSalary { get; set; }
        }
    }

    
}
