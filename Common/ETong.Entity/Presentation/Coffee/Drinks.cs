using System;
using System.Collections.Generic;

namespace ETong.Entity.Presentation.Coffee
{
    /// <summary>
    /// 饮料
    /// </summary>
    [Serializable]
    public class Drink
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对应值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 物料属性集
        /// </summary>
        public List<Material> Materials { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        ///  单杯价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 单杯咖啡容量(单位 ml)
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 出水量
        /// </summary>
        public string WaterValue { get; set; }

        /// <summary>
        /// 出料量
        /// </summary>
        public string MaterialValue { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        public CurStatus CurStatus { get; set; }
    }


    /// <summary>
    /// 物料集
    /// </summary>
    [Serializable]
    public class Material
    {
        /// <summary>
        /// 配料名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 对应值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 属性集
        /// </summary>
        public List<Weight> Weights { get; set; }

    }


    /// <summary>
    /// 物料属性
    /// </summary>
    [Serializable]
    public class Weight
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 出料时间
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 水量
        /// </summary>
        public string WaterValue { get; set; }
    }


    /// <summary>
    /// 状态枚举类
    /// </summary>
    [Serializable]
    public enum CurStatus
    {
        /// <summary>
        /// 准备
        /// </summary>
        Prepare = 0,

        /// <summary>
        /// 运行中
        /// </summary>
        Running = 1,

        /// <summary>
        /// 已完成
        /// </summary>
        Finish = 2,


    }        
}
