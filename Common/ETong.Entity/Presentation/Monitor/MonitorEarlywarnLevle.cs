using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor 
{
    /// <summary>
    /// 预警级别
    /// </summary>
   public class MonitorEarlywarnLevle
    {
      
       /// <summary>
        /// 预警Id
       /// </summary>
       public string Earlywarn_Id { set; get; }
    
       /// <summary>
       /// 预警级别
       /// </summary>
       public int EarlywarnLevle { set; get; }
        
       /// <summary>
       /// 预警名称
       /// </summary>
       public string Earlywarn_Name { set; get; }
   	
       /// <summary>
       /// 预警通知类型：0：邮件，1：短信，2：QQ，3：自动（根据联系人输入的内容判断是邮箱、电话、QQ选择对应的通知方式）  ，默认为0
       /// </summary>
       public int Notification_Type { set; get; }
       	
       /// <summary>
       /// 预警通知联系人：用逗号分隔
       /// </summary>
       public string Earlywarn_LikePerson { set; get; }
    	
       /// <summary>
       /// 备注
       /// </summary>
       public string Remark { set; get; }

    }


   /// <summary>
   /// 预警对应邮箱配置--SMTP邮件服务器
   /// </summary>
   /// <remarks> 
   ///<add key="MS_SMTPHOST" value="smtp.163.com" />
   ///<!--SMTP邮件服务器端口-->
   ///<add key="MS_SMTPPORT" value="25" />
   ///<add key="MS_USESSL" value="false" />
   ///<!--发送邮箱地址-->
   ///<add key="MS_SMTPUSERNAME" value="etongdev@163.com" />
   ///<!--发送邮箱密码-->
   ///<add key="MS_SMTPPASSWORD" value="etong123456" />
   ///<!--自定义邮件BodyHTML样式-->
   ///<add key="MS_USEHTML" value="true" />
   /// </remarks>
   public class MonitorEarlywarnLevleToEMail
   {

       /// <summary>
       /// SMTP邮件服务器
       /// </summary>
       public string SMTPHOST { set; get; }

       /// <summary>
       /// SMTP邮件端口 
       /// </summary>
       public int SMTPPORT { set; get; }

       /// <summary>
       ///  
       /// </summary>
       public  bool USESSL { set; get; }

       /// <summary>
       /// 发送邮箱地址
       /// </summary>
       public string SMTPUSERNAME { set; get; }

       /// <summary>
       /// 发送邮箱密码
       /// </summary>
       public string SMTPPASSWORD { set; get; }

       /// <summary>
       /// 自定义邮件BodyHTML样式
       /// </summary>
       public bool  USEHTML { set; get; }

       /// <summary>
       /// 短信发送接口地址
       /// </summary>
       public string SMSENDPOINT { set; get; }
   }
}
