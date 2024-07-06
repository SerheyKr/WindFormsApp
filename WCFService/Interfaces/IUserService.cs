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
        User GetValue(long key);
        [OperationContract]
        List<User> GetValues();
        [OperationContract]
        void AddValue(User value);
        [OperationContract]
        void UpdateValue(User value);
        [OperationContract]
        void RemoveValue(User value);
    }
}
