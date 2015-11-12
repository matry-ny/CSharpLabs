namespace ComputersInOrganisation
{
    public class Server : Computer
    {
        private Computer serverParams;

        public Server()
        {
            serverParams = SetCpuCoresQuantity(8).SetCpuFrequency(3).SetMemorySize(16).SetHddSyze(2000);
        }

        public Computer GetParams()
        {
            return serverParams;
        } 
    }
}