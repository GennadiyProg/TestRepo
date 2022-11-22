using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class CompanyService
    {
        public static ICollection<Company> CompanyList { get; set; } = new List<Company>();

        public void createCompany(string name, int periodPerformanceReview)
        {
            Company company = new Company();
            company.Name = name;
            company.PeriodPerformanceReview = periodPerformanceReview;
            company.workers = new List<Worker>();
            CompanyList.Add(company);
        }

        public Worker addWorkerToCompany(string companyName, string workerName, int salaryOfMounth)
        {
            Worker worker = new Worker();
            worker.Name = workerName;
            Company company = CompanyList.FirstOrDefault(company => company.Name == companyName);
            int countReview = 12 / company.PeriodPerformanceReview;
            double salary = salaryOfMounth;
            for(int i = 0; i < countReview; i++)
            {
                salary *= 1.25;
            }
            worker.SalaryOfMounth = (int)salary;
            worker.SalaryOfYear = (int)salary*12;
            company.workers.Add(worker);
            return worker;
        }

        public void deleteWorkerFromCompany(string workerName)
        {
            foreach(Company company in CompanyList)
            {
                company.workers.Remove(company.workers.FirstOrDefault(worker => worker.Name == workerName));
            }
        }

        public int getAverageSalaryInCompany(string companyName)
        {
            Company company = CompanyList.FirstOrDefault(company => company.Name == companyName);
            int sum = 0;
            foreach(Worker worker in company.workers)
            {
                sum += worker.SalaryOfMounth;
            }
            return sum/company.workers.Count;
        }
    }
}
