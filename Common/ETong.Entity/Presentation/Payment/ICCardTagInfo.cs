using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Payment
{
    /// <summary>
    /// 银行IC卡标签类
    /// </summary>
    public class ICCardTagInfo
    {
        #region 报文需要

        /// <summary>
        /// 应用主账号(PAN)
        /// </summary>
        public string Tag_5A { get; set; }

        /// <summary>
        /// 应用密文
        /// </summary>
        public string Tag_9F26 { get; set; }

        /// <summary>
        /// 密文信息数据
        /// </summary>
        public string Tag_9F27 { get; set; }

        /// <summary>
        /// 发卡行应用数据
        /// </summary>
        public string Tag_9F10 { get; set; }

        /// <summary>
        /// 不可预知数
        /// </summary>
        public string Tag_9F37 { get; set; }

        /// <summary>
        /// 应用交易计数器
        /// </summary>
        public string Tag_9F36 { get; set; }

        /// <summary>
        /// 终端验证结果
        /// </summary>
        public string Tag_95 { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        public string Tag_9A { get; set; }

        /// <summary>
        /// 终端交易类型，查询31，消费00
        /// </summary>
        public string Tag_9C { get; set; }

        /// <summary>
        /// 授权金额
        /// </summary>
        public string Tag_9F02 { get; set; }

        /// <summary>
        /// 交易货币代码
        /// </summary>
        public string Tag_5F2A { get; set; }

        /// <summary>
        /// 应用交互特征AIP
        /// </summary>
        public string Tag_82 { get; set; }

        /// <summary>
        /// 终端国家代码
        /// </summary>
        public string Tag_9F1A { get; set; }

        /// <summary>
        /// 其他金额
        /// </summary>
        public string Tag_9F03 { get; set; }

        /// <summary>
        /// 终端性能
        /// </summary>
        public string Tag_9F33 { get; set; }

        /// <summary>
        /// 持卡人验证方法结果
        /// </summary>
        public string Tag_9F34 { get; set; }

        /// <summary>
        /// 终端类型
        /// </summary>
        public string Tag_9F35 { get; set; }

        /// <summary>
        /// 终端接口设备序列号
        /// </summary>
        public string Tag_9F1E { get; set; }

        /// <summary>
        /// 专用文件名称
        /// </summary>
        public string Tag_84 { get; set; }

        /// <summary>
        /// 终端应用版本号
        /// </summary>
        public string Tag_9F09 { get; set; }

        /// <summary>
        /// 终端交易序列计数器
        /// </summary>
        public string Tag_9F41 { get; set; }

        /// <summary>
        /// 卡产品标识
        /// </summary>
        public string Tag_9F63 { get; set; }

        /// <summary>
        /// 发卡行脚本结果
        /// </summary>
        public string Tag_DF31 { get; set; }

        #endregion

        #region 报文不需要

        /// <summary>
        /// 目录基本文件的SFI
        /// </summary>
        public string Tag_88 { get; set; }

        /// <summary>
        /// 卡片风险管理数据对象列表1（CDOL1）
        /// </summary>
        public string Tag_8C { get; set; }

        /// <summary>
        /// 应用失效日期 yyMMdd
        /// </summary>
        public string Tag_5F24 { get; set; }

        /// <summary>
        /// 应用生效日期 yyMMdd
        /// </summary>
        public string Tag_5F25 { get; set; }

        /// <summary>
        /// 卡片应用版本号
        /// </summary>
        public string Tag_9F08 { get; set; }

        /// <summary>
        /// 应用主账号序列号
        /// </summary>
        public string Tag_5F34 { get; set; }

        /// <summary>
        /// 磁条2等效数据
        /// </summary>
        public string Tag_57 { get; set; }

        /// <summary>
        /// 应用货币代码
        /// </summary>
        public string Tag_9F42 { get; set; }

        #endregion

        /// <summary>
        /// 55域IC卡数据
        /// </summary>
        public string Field55 { get; set; }

        /// <summary>
        /// 23域卡序列号，用于区别具有相同PAN的不同卡
        /// </summary>
        public string Field23 { get; set; }

        /// <summary>
        /// 对传入的TLV串(16进制)进行解析
        /// </summary>
        /// <param name="inputTlv">待解析TLV字符串</param>
        /// <param name="dicTlv">保存解析结果的字典集合</param>
        /// <param name="containsValue">TLV串是否含有值</param>
        public void ParseTlv(string inputTlv, Dictionary<string, string> dicTlv, bool containsValue)
        {
            int n = 0;
            string tagName = string.Empty;
            string tagLengthString = string.Empty;
            string tagValue = string.Empty;
            while (n < inputTlv.Length)
            {
                //获取tag名称
                tagName = inputTlv.Substring(n, 2);
                //每个字节判断一下是否tag，不是的话就取2个字节
                int tagNameDecimal = Convert.ToInt32(tagName, 16);
                if ((tagNameDecimal & 0x1F) == 0x1F)
                {
                    //此tag为2个字节
                    tagName = inputTlv.Substring(n, 4);
                    n += 4;
                }
                else
                {
                    //此tag为1个字节
                    n += 2;
                }

                //获取tag的长度，占1~3个字节长度
                tagLengthString = inputTlv.Substring(n, 2);
                int tagLength = Convert.ToInt32(tagLengthString, 16);
                if ((tagLength & 0x80) == 0x00)
                {
                    //长度只有一个字节
                    n += 2;
                }
                else
                {
                    //长度为2个字节以上，暂未涉及3个字节
                    tagLengthString = inputTlv.Substring(n + 2, 2);
                    tagLength = Convert.ToInt32(tagLengthString, 16);
                    n += 4;
                }

                if (containsValue)
                {
                    //获取tag值
                    tagValue = inputTlv.Substring(n, tagLength * 2);
                    n += tagLength * 2;
                }

                if (!dicTlv.ContainsKey(tagName))
                    dicTlv.Add(tagName, tagValue);
                //如果包含子域则递归获取
                if (tagName.Length == 2 && (Convert.ToInt32(tagName, 16) & 0x20) == 0x20)
                    ParseTlv(tagValue, dicTlv, containsValue);

            }

        }
    }
}
