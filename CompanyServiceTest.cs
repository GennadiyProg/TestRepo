using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Lab4
{
    public class CompanyServiceTest
    {
        CompanyService companyService = new CompanyService();

        [Fact]
        public void isCreatedCompany()
        {
            CompanyService.CompanyList = new List<Company>();
            int countCompanyOnStart = CompanyService.CompanyList.Count;

            companyService.createCompany("myFirstCompany", 3);

            Assert.Equal(countCompanyOnStart + 1, CompanyService.CompanyList.Count);
        }

        [Fact]
        public void isAddedWorkerToCompany()
        {
            CompanyService.CompanyList = new List<Company>();
            string companyName = "myFirstCompany";
            companyService.createCompany(companyName, 3);
            int workerCount = 0;
            foreach(Company company in CompanyService.CompanyList)
            {
                if(company.Name == companyName) workerCount = company.workers.Count;
            }

            companyService.addWorkerToCompany(companyName, "bestWorker", 30000);

            int afterWorkerCount = 0;
            foreach (Company company in CompanyService.CompanyList)
            {
                if (company.Name == companyName) afterWorkerCount = company.workers.Count;
            }

            Assert.Equal(workerCount + 1, afterWorkerCount);
        }

        [Fact]
        public void isRightCalculateWorkerSalary()
        {
            CompanyService.CompanyList = new List<Company>();
            string companyName = "myFirstCompany";
            int countReview = 3;
            companyService.createCompany(companyName, countReview);
            double baseSalary = 30000;
            Worker worker = companyService.addWorkerToCompany(companyName, "bestWorker", (int)baseSalary);

            for (int i = 0; i < 12/countReview; i++)
            {
                baseSalary *= 1.25;
            }

            Assert.Equal((int)baseSalary, worker.SalaryOfMounth);
        }

        [Fact]
        public void isDeletedWorkerFromCompany()
        {
            CompanyService.CompanyList = new List<Company>();
            string companyName = "myFirstCompany";
            companyService.createCompany(companyName, 3);
            int countWorker = CompanyService.CompanyList.First(company => company.Name == companyName).workers.Count;
            companyService.addWorkerToCompany(companyName, "bestWorker", 30000);

            Assert.Equal(countWorker + 1, CompanyService.CompanyList.First(company => company.Name == companyName).workers.Count);
        }

        [Fact]
        public void isRightAvarageSalary()
        {
            CompanyService.CompanyList = new List<Company>();
            string companyName = "myFirstCompany";
            companyService.createCompany(companyName, 3);
            Worker worker1 = companyService.addWorkerToCompany(companyName, "bestWorker", 30000);
            Worker worker2 = companyService.addWorkerToCompany(companyName, "bestWorkerSecond", 40000);
            int avarageSalary = (worker1.SalaryOfMounth + worker2.SalaryOfMounth) /2;

            Assert.Equal(avarageSalary, companyService.getAverageSalaryInCompany(companyName));
        }
    }
}