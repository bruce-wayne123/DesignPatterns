using System.Collections.Generic;

namespace DesignPatternsDemo
{
    #region WithoutOCP

    internal class NormalSalaryCalculator
    {
        private readonly IEnumerable<DeveloperReport> _developerReport;

        public NormalSalaryCalculator(List<DeveloperReport> developerReports)
        {
            _developerReport = developerReports;
        }

        public double CalculateTotalSalaries()
        {
            double totalSalaries = 0D;
            foreach (var devitem in _developerReport)
            {
                totalSalaries += devitem.WorkingHours * devitem.HourlyRate;
            }
            return totalSalaries;
        }
    }

    #endregion WithoutOCP

   
    public class DeveloperReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public int WorkingHours { get; set; }

        public double HourlyRate { get; set; }
    }

    public abstract class BaseSalaryCalculator
    {
        protected DeveloperReport _developerReport { get; private set; }

        public BaseSalaryCalculator(DeveloperReport developerReport)
        {
            _developerReport = developerReport;
        }

        public abstract double CalculateSalary();
    }


    public class SeniorDevCalculator : BaseSalaryCalculator
    {
        public SeniorDevCalculator(DeveloperReport report) : base(report)
        {
        }

        public override double CalculateSalary() => _developerReport.WorkingHours * _developerReport.HourlyRate * 1.2;//1.2 addtional bonus for Senior Dev
    }

    public class JuniorDevCalculator : BaseSalaryCalculator
    {
        public JuniorDevCalculator(DeveloperReport report) : base(report)
        {
        }

        public override double CalculateSalary() => _developerReport.WorkingHours * _developerReport.HourlyRate;
    }

    public class SalaryCalculator
    {
        private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;
        public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
        {
            _developerCalculation = developerCalculation;
        }

        public double CalculateTotalSalaries()
        {
            double totalSalaries = 0D;
            foreach (var devCalc in  _developerCalculation)
            {
                totalSalaries += devCalc.CalculateSalary();
            }
            return totalSalaries;
        }

    }


}