using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 医院信息
    /// </summary>
    public class HospitalInfo
    {
        /// <summary>
        /// 医院ID
        /// </summary>
        public int HOSPITAL_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 省份ID
        /// </summary>
        public int HOSPITAL_PROVINCEID
        {
            get;
            set;
        }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string HOSPITAL_PROVINCENAME
        {
            get;
            set;
        }

        /// <summary>
        /// 城市ID
        /// </summary>
        public int HOSPITAL_CITYID
        {
            get;
            set;
        }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string HOSPITAL_CITYNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HOSPITAL_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 医院等级
        /// </summary>
        public string HOSPITAL_LEVEL
        {
            get;
            set;
        }

        /// <summary>
        /// 性质（公立、私营)
        /// </summary>
        public string HOSPITAL_OWNERSYS
        {
            get;
            set;
        }
        
        /// <summary>
        /// 医院类型(妇产医院、妇科医院、妇儿医院、综合医院、男科医院、整形医院、美容医院、皮肤医院、肿瘤医院、妇幼医院、野战医院、胸科医院、脑科医院、隔离医院、精神医院、陆军医院、传染医院、骨科医院、附属医院、麻风医院、眼科医院)
        /// </summary>
        public string HOSPITAL_TYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 乘车线路
        /// </summary>
        public string HOSPITAL_BUS
        {
            get;
            set;
        }

        /// <summary>
        /// 详细介绍——简介
        /// </summary>
        public string HOSPITAL_INTRO
        {
            get;
            set;
        }

        /// <summary>
        /// 详细介绍——科研成果
        /// </summary>
        public string HOSPITAL_TECHRES
        {
            get;
            set;
        }

        /// <summary>
        /// 详细介绍——获奖荣誉
        /// </summary>
        public string HOSPITAL_AWARD
        {
            get;
            set;
        }

        /// <summary>
        /// 详细介绍——先进设备
        /// </summary>
        public string HOSPITAL_EQUIPMENT
        {
            get;
            set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string HOSPITAL_ADDRESS
        {
            get;
            set;
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string HOSPITAL_PHONE
        {
            get;
            set;
        }

        /// <summary>
        /// 合作标志(0-平台，1—39，2－好医生，3－好大夫)
        /// </summary>
        public string HOSPITAL_PARTNERTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 状态标志(0—停用，1－在用，2—试用)
        /// </summary>
        public string HOSPITAL_STATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 分润ID(待用)
        /// </summary>
        public string HOSPITAL_PROFITID
        {
            get;
            set;
        }

        /// <summary>
        /// 医院照片，文件URL
        /// </summary>
        public string HOSPITAL_PHOTO
        {
            get;
            set;
        }

        /// <summary>
        /// 第三方ID
        /// </summary>
        public int HOSPITAL_PARTNERID
        {
            get;
            set;
        }

    }
}
