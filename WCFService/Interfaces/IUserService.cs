using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFService.Models;

namespace WCFService.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetValue(Guid key);
        [OperationContract]
        List<User> GetValues();
        [OperationContract]
        Guid AddValue(User value);
        [OperationContract]
        User UpdateValue(User value);
        [OperationContract]
        void RemoveValue(User value);
    }
}
