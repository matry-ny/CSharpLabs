namespace ComputersInOrganisation
{
    public class Desctop : Computer
    {
        private Computer desctopParems;

        public Desctop()
        {
            desctopParems = SetCpuCoresQuantity(4).SetCpuFrequency(2.5).SetMemorySize(6).SetHddSyze(500);
        }

        public Computer GetParams()
        {
            return desctopParems;
        }
    }
}