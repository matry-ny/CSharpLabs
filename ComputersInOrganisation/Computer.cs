namespace ComputersInOrganisation
{
    public class Computer
    {
        private int cpuCores;
        private double cpuFrequency;
        private int memory;
        private int hdd;

        public Computer SetCpuCoresQuantity(int coresQuantity)
        {
            cpuCores = coresQuantity;
            return this;
        }

        public int GetCpuCoresQuantity()
        {
            return cpuCores;
        }

        public Computer SetCpuFrequency(double frequency)
        {
            cpuFrequency = frequency;
            return this;
        }

        public double GetCpuFrequency()
        {
            return cpuFrequency;
        }

        public Computer SetMemorySize(int memorySize)
        {
            memory = memorySize;
            return this;
        }

        public int GetMemorySize()
        {
            return memory;
        }

        public Computer SetHddSyze(int hddSize)
        {
            hdd = hddSize;
            return this;
        }

        public int GetHddSyze()
        {
            return hdd;
        }
    }
}