using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsDemo
{
        internal enum Gender
        {
            Male,
            Female
        }

        internal enum Position
        {
            Administrator,
            Manager,
            Executive
        }

        internal class Employee
        {
            public string Name { get; set; }
            public Gender Gender { get; set; }
            public Position Position { get; set; }
        }

    internal class EmployeeManager : IEmployeeSearch
    {
        private readonly List<Employee> _employees;

        public List<Employee> Employees;

        public EmployeeManager()
        {
            _employees = new List<Employee>();
            Employees = new List<Employee>(_employees);
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public IEnumerable<Employee> GetEmployeeByGender(Gender gender) => _employees.Where(emp => emp.Gender == Gender.Female && emp.Position==Position.Manager);
    }

    internal class EmployeeResearch
    {
        private EmployeeManager _employeeManager;

        public EmployeeResearch(EmployeeManager empManager)
        {
            _employeeManager = empManager;
        }

        #region WithoutDI

        /// <summary>
        ///In this approach,we are directly exposing low level fields of Employee manager i.e. list of employees( Employees) 
        ///to the higher class i.e. EmployeeResearch which is not right..Low level componenets should not directly interact with high level components directly.
        ///There should be some adapter between them them ex-Interface which can communicate between them.
        /// </summary>
        /// <returns></returns>
        public int CountFemaleMangers() => _employeeManager.Employees.Count(emp => emp.Gender == Gender.Female);

        #endregion WithoutDI

        #region WithDI
        /// <summary>
        ///In this approach,we have used the principle of dependency inversion.The interface can act as a medium to communicate between high level(EmmplyeeResearch) and low level(EmployeeManager)
        ///It will return the count of managers according to gender.
        /// </summary>
        /// <returns></returns>
        public int CountFemaleManger() => _employeeManager.GetEmployeeByGender(Gender.Female).Count();

        #endregion WithDI
    }

    internal interface IEmployeeSearch
    {
        IEnumerable<Employee> GetEmployeeByGender(Gender gender);
    }
}