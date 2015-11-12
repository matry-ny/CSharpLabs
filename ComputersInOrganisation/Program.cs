using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

            int departmentIndex = 0;
            foreach (Department element in departmentsConfiguration)
            {
                allComputersQuantity += element.GetAllComputersQuantity();
                var hddData = element.GetLargestHddValue().First();
                if (hddData.Key > largestStorageValue)
                {
                    largestStorageValue = hddData.Key;
                    computerWithLargestStorage = hddData.Value;
                    departmentWithLargestStorage = departments[departmentIndex];
                }
                departmentIndex++;
            }

            Console.WriteLine("Computers quantity: {0}", allComputersQuantity);
            Console.WriteLine(
                "Computer with largest storage is {0} ({1} Gb) in {2}",
                computerWithLargestStorage,
                largestStorageValue,
                departmentWithLargestStorage
            );
        }
    }
}
