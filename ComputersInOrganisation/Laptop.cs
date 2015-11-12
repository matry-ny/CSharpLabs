namespace ComputersInOrganisation
{
    public class Laptop : Computer
    {
        private Computer laptopParams;

        public Laptop()
        {
            laptopParams = SetCpuCoresQuantity(2).SetCpuFrequency(1.7).SetMemorySize(4).SetHddSyze(250);
        }

        public Computer GetParams()
        {
            return laptopParams;
        }
    }
}