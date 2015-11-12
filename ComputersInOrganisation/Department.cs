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
    }
}