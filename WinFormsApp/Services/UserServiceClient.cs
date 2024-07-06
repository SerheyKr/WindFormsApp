using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFService.Interfaces;
using WCFService.Models;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WinFormsApp.Services
{
	public class UserServiceClient: IUserService
	{
		readonly ChannelFactory<IUserService> client;

		public UserServiceClient(ChannelFactory<IUserService> channel)
		{
			client = channel;
		}

		public Guid AddValue(User value)
		{
			return client.CreateChannel().AddValue(value);
		}

		public User? GetValue(Guid key)
		{
			return client.CreateChannel().GetValue(key);
		}

		public List<User> GetValues()
		{
			return client.CreateChannel().GetValues();
		}

		public void RemoveValue(User value)
		{
			client.CreateChannel().RemoveValue(value);
		}

		public User UpdateValue(User value)
		{
			return client.CreateChannel().UpdateValue(value);
		}
	}
}
