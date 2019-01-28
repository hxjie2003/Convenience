namespace ETong.Entity.Presentation.Coffee
{
    /// <summary>
    /// 指令枚举
    /// </summary>
    public enum Operate
    {
        /// <summary>
        /// 系统开始
        /// </summary>
        StartUp = 1,

        /// <summary>
        /// 系统待机
        /// </summary>
        StandBy = 2,

        /// <summary>
        /// 系统关机
        /// </summary>
        ShutDown = 3,

        /// <summary>
        /// 系统排空
        /// </summary>
        Deplete = 4,


        /// <summary>
        /// 意式咖啡
        /// </summary>
        ItalianCoffee = 5,

        /// <summary>
        /// 意式咖啡取消
        /// </summary>
        ItalianCoffeeCancel = 6,

        /// <summary>
        /// 查询机器状态
        /// </summary>
        MachineState = 7,

        /// <summary>
        /// 机器错误代码
        /// </summary>
        MachineErrorCode = 8,


        /// <summary>
        /// 自动落杯
        /// </summary>
        MachineAutoFallCup = 9,


        /// <summary>
        /// 取消自动落杯
        /// </summary>
        MachineCancelAutoFallCup = 10,

        /// <summary>
        /// 落杯
        /// </summary>
        MachineManualFallCup = 11,

        /// <summary>
        /// 参数设置
        /// </summary>
        MachineParamSetting = 12,


        /// <summary>
        /// 自动清洗
        /// </summary>
        MachineAutoWash = 13,


        /// <summary>
        /// 热饮1
        /// </summary>
        HotDrinks1 = 14,


        /// <summary>
        /// 热饮2
        /// </summary>
        HotDrinks2 = 15,


        /// <summary>
        /// 热饮3
        /// </summary>
        HotDrinks3 = 16,


        /// <summary>
        /// 热饮4
        /// </summary>
        HotDrinks4 = 17,


        /// <summary>
        /// 冷饮1
        /// </summary>
        ColdDrinks1 = 18,

        /// <summary>
        /// 冷饮2
        /// </summary>
        ColdDrinks2 = 19,


        /// <summary>
        /// 冷饮3
        /// </summary>
        ColdDrinks3 = 20,

        /// <summary>
        /// 冷饮4
        /// </summary>
        ColdDrinks4 = 21,

    }


}
