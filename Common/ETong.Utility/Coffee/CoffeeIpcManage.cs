namespace ETong.Utility.Coffee
{
    public static class CoffeeIpcManage
    {

        /// <summary>
        /// 获取饮料机服务端
        /// </summary>
        /// <returns></returns>
        public static CoffeeIpc GetCoffeeIpcService()
        {
            CoffeeIpc coffeeIpc = new CoffeeIpc("CoffeeIpcService");
            coffeeIpc.RunIPCService();
            return coffeeIpc;
        }

        /// <summary>
        /// 获取饮料机客户端
        /// </summary>
        /// <returns></returns>
        public static CoffeeIpc GetCoffeeIpcClient()
        {
            CoffeeIpc coffeeIpc = new CoffeeIpc("CoffeeIpcService");
            return coffeeIpc;
        }


        /// <summary>
        /// 获取ETM服务端
        /// </summary>
        /// <returns></returns>
        public static CoffeeIpc GetEtmIpcService()
        {
            CoffeeIpc etmIpc = new CoffeeIpc("CoffeeEtmIpcService");
            etmIpc.RunIPCService();
            return etmIpc;
        }

        /// <summary>
        /// 获取ETM客户端
        /// </summary>
        /// <returns></returns>
        public static CoffeeIpc GetEtmIpcClient()
        {
            CoffeeIpc etmIpc = new CoffeeIpc("CoffeeEtmIpcService");
            return etmIpc;
        }

    }
}
