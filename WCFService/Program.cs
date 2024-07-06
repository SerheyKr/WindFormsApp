using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using WCFService.Interfaces;

namespace WCFService
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(UserService)))
            {
                host.AddServiceEndpoint(typeof(IUserService), new WSHttpBinding(), "");
                host.Open();
            }
        }
    }
}