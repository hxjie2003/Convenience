using System;

namespace ETong.Entity.Framework
{
    /// <summary>
    /// 登录后的会员信息类
    /// </summary>
    [Serializable]
    public class LoginInfo
    {
        /// <summary>
        /// 登录是否成功
        /// </summary>
        public bool LoginSuccess { get; set; }

        private string _errorMessage = string.Empty;

        /// <summary>
        /// 登录错误信息
        /// </summary>
        public string ErrorMessage { get { return this._errorMessage; } set { this._errorMessage = value; } }

        /// <summary>
        /// 登录时间，可据此判断是否超时
        /// </summary>
        public DateTime LoginTime { get; set; }

        private string _memberId = string.Empty;

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberID { get { return this._memberId; } set { this._memberId = value; } }

        private string _userName = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get { return this._userName; } set { this._userName = value; } }

        /// <summary>
        /// 会员状态，0 正常，1 禁用
        /// </summary>
        public int MemberState { get; set; }

        /// <summary>
        /// 会员性别，1 男，0 女
        /// </summary>
        public int Gender { get; set; }

        private string _email = string.Empty;

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get { return this._email; } set { this._email = value; } }

        private string _mobile = string.Empty;

        /// <summary>
        /// 用户手机
        /// </summary>
        public string Mobile { get { return this._mobile; } set { this._mobile = value; } }

        private string _levelId = "0";

        /// <summary>
        /// 用户等级id
        /// </summary>
        public string LevelId
        {
            get { return this._levelId; }
            set { this._levelId = value; }
        }

        private string _levelName = string.Empty;

        /// <summary>
        /// 会员等级名称
        /// </summary>
        public string LevelName
        {
            get { return this._levelName; }
            set { this._levelName = value; }
        }

        private string _trueName = string.Empty;

        /// <summary>
        /// 会员真实姓名
        /// </summary>
        public string TrueName
        {
            get { return this._trueName; }
            set { this._trueName = value; }
        }

        private string _idCardNum = string.Empty;

        /// <summary>
        /// 会员身份证号
        /// </summary>
        public string IdCardNum
        {
            get { return this._idCardNum; }
            set { this._idCardNum = value; }
        }

        private string _birthday = string.Empty;

        /// <summary>
        /// 会员生日
        /// </summary>
        public string Birthday { get { return this._birthday; } set { this._birthday = value; } }

        /// <summary>
        /// 是否激活
        /// </summary>
        public int MemberActivate { get; set; }

        private string _memberPhotoUrl = string.Empty;

        /// <summary>
        /// 会员头像地址
        /// </summary>
        public string MemberPhotoUrl { get { return this._memberPhotoUrl; } set { this._memberPhotoUrl = value; } }

        /// <summary>
        /// 最近登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 登陆总次数
        /// </summary>
        public int LoginTotalTimes { get; set; }

        /// <summary>
        /// 是否已经实名注册
        /// </summary>
        public int? AUDIT_STATUS { get; set; }
    }
}