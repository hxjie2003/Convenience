using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Maintenance.Common
{
    /// <summary>
    /// 命令接口
    /// </summary>
    [ServiceContract]
   
    public interface ICommandService
    {
        [OperationContract()]
        void Execute(string command);
    }
}
