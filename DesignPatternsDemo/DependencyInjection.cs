using System.Collections.Generic;

namespace DesignPatternsDemo
{
    public class InfoSys
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    #region WithoutDI

    //public class InfyDAL
    //{
    //    public List<InfoSys> SelectAllEmployees()
    //    {
    //        List<InfoSys> ListEmployees = new List<InfoSys>();
    //        ListEmployees.Add(new InfoSys { ID = 1, Name = "David", Department = "Research" });
    //        ListEmployees.Add(new InfoSys { ID = 2, Name = "Jason", Department = "Sales" });
    //        ListEmployees.Add(new InfoSys { ID = 1, Name = "Katie", Department = "HR" });
    //        return ListEmployees;
    //    }
    //}

    #endregion WithoutDI

    public class InfyBAL
    {
        public IGetEmployee getEmployee;

        public InfyBAL(IGetEmployee employee)
        {
            getEmployee = employee;
        }

        public List<InfoSys> GetEmployeeList()
        {
            return getEmployee.EmployeeList();
        }
    }

    public interface IGetEmployee
    {
        public List<InfoSys> EmployeeList();
    }

    public class InfyDAL : IGetEmployee
    {
        public List<InfoSys> EmployeeList()
        {
            List<InfoSys> ListEmployees = new List<InfoSys>();
            ListEmployees.Add(new InfoSys { ID = 1, Name = "David", Department = "Research" });
            ListEmployees.Add(new InfoSys { ID = 2, Name = "Jason", Department = "Sales" });
            ListEmployees.Add(new InfoSys { ID = 3, Name = "Katie", Department = "HR" });
            return ListEmployees;
        }
    }
}