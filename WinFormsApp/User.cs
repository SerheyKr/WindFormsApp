using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFService.Models
{
	public class User : BaseModelWithID
	{
		public string FirstName { get; set; }
		public string Surname { get; set; }
		public string LastName { get; set; }

		public string DRFO { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public DateTime CreationDate { get; set; }
		public DateTime LastModifiedDate { get; set; }
	}
}
