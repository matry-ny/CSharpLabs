using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ComputersInOrganisation
{
    public class Department
    {
        private int desctops;
        private int laptops;
        private int servers;

        public Department AddDesctops(int desctopsCount)
        {
            desctops += desctopsCount;
            return this;
        }

        public int GetDesctopsQuantity()
        {
            return desctops;
        }

        public Department AddLaptops(int laptopsCount)
        {
            laptops += laptopsCount;
            return this;
        }

        public int GetLaptopsQuantity()
        {
            return laptops;
        }

        public Department AddServers(int serversCount)
        {
            servers += serversCount;
            return this;
        }

        public int GetServersQuantity()
        {
            return servers;
        }

        public int GetAllComputersQuantity()
        {
            return GetDesctopsQuantity() + GetLaptopsQuantity() + GetServersQuantity();
        }

        public Dictionary<int, string> GetLargestHddValue()
        {
            int maxHddValue = 0;
            string computerType = "";

            if (desctops > 0)
            {
                maxHddValue = (new Desctop()).GetHddSyze();
                computerType = "desctop";
            }

            var laptopHdd = (new Laptop()).GetHddSyze();
            if (laptops > 0 && laptopHdd > maxHddValue)
            {
                maxHddValue = laptopHdd;
                computerType = "laptop";
            }


            var serverHdd = (new Server()).GetHddSyze();
            if (servers > 0)
            {
                maxHddValue = serverHdd;
                computerType = "server";
            }

            return new Dictionary<int, string>
            {
                {maxHddValue, computerType}
            };
        }

        private double minCpuFrequency = 0.0;
        private int minMemorySize = 0;
        private string computerType = "";

        public Department FindLowestProductivityComputer()
        {
            if (desctops > 0)
            {
                var desctopObject = new Desctop();
                minCpuFrequency = desctopObject.GetCpuFrequency();
                minMemorySize = desctopObject.GetMemorySize();
                computerType = "desctop";
            }

            if (laptops > 0)
            {
                var laptopObject = new Laptop();
                if (Equals(minCpuFrequency, 0.0) ||
                    (laptopObject.GetCpuFrequency() < minCpuFrequency && laptopObject.GetMemorySize() < minMemorySize)
                ) {
                    minCpuFrequency = laptopObject.GetCpuFrequency();
                    minMemorySize = laptopObject.GetMemorySize();
                    computerType = "laptop";
                }
            }

            if (servers > 0)
            {
                var serverObject = new Server();
                if (Equals(minCpuFrequency, 0.0) ||
                    (serverObject.GetCpuFrequency() < minCpuFrequency && serverObject.GetMemorySize() < minMemorySize)
                ) {
                    minCpuFrequency = serverObject.GetCpuFrequency();
                    minMemorySize = serverObject.GetMemorySize();
                    computerType = "server";
                }
            }

            return this;
        }

        public double GetLowestCpuFrequency()
        {
            return minCpuFrequency;
        }

        public int GetLowestMemorySize()
        {
            return minMemorySize;
        }

        public string GetLowestProductivityComputerType()
        {
            return computerType;
        }
        
    }
}