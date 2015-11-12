using System;
using System.Linq;

namespace ComputersInOrganisation
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new[]
            {
                "1 department",
                "2 department",
                "3 department",
                "4 department"
            };

            object[] departmentsConfiguration = new object[4];
            departmentsConfiguration[0] = (new Department()).AddDesctops(2).AddLaptops(2).AddServers(1);
            departmentsConfiguration[1] = (new Department()).AddLaptops(3);
            departmentsConfiguration[2] = (new Department()).AddDesctops(3).AddLaptops(2);
            departmentsConfiguration[3] = (new Department()).AddDesctops(1).AddLaptops(1).AddServers(2);

            int allComputersQuantity = 0;
            string departmentWithLargestStorage = "";
            string computerWithLargestStorage = "";
            int largestStorageValue = 0;

            Department lowestComputerDepartment = new Department();

            int largestStorageDepartmentIndex = 0;
            int lowestProductivityDepartmentIndex = 0;
            foreach (Department element in departmentsConfiguration)
            {
                allComputersQuantity += element.GetAllComputersQuantity();
                var hddData = element.GetLargestHddValue().First();
                if (hddData.Key > largestStorageValue)
                {
                    largestStorageValue = hddData.Key;
                    computerWithLargestStorage = hddData.Value;
                    departmentWithLargestStorage = departments[largestStorageDepartmentIndex];
                    largestStorageDepartmentIndex++;
                }

                var departmentLowestComputerConfig = element.FindLowestProductivityComputer();
                if (Equals(lowestComputerDepartment.GetLowestCpuFrequency(), 0.0) ||
                    (departmentLowestComputerConfig.GetLowestCpuFrequency() < lowestComputerDepartment.GetLowestCpuFrequency() &&
                    departmentLowestComputerConfig.GetLowestMemorySize() < lowestComputerDepartment.GetLowestMemorySize())
                )
                {
                    lowestComputerDepartment = departmentLowestComputerConfig;
                    lowestProductivityDepartmentIndex++;
                }
            }

            Console.WriteLine("Computers quantity: {0}", allComputersQuantity);
            Console.WriteLine(
                "Computer with largest storage is {0} ({1} Gb) in {2}",
                computerWithLargestStorage,
                largestStorageValue,
                departmentWithLargestStorage
            );
            Console.WriteLine(
                "Computer with lowest productivity is {0} ({1} HGz, {2} Gb) in {3}",
                lowestComputerDepartment.GetLowestProductivityComputerType(),
                lowestComputerDepartment.GetLowestCpuFrequency(),
                lowestComputerDepartment.GetLowestMemorySize(),
                departments[lowestProductivityDepartmentIndex]
            );
        }
    }
}
