using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFService.Models
{
	[DataContract]
	public class User
	{
		private Guid Id;
		private string firstName;
		private string surname;
		private string lastName;
		private string drfo;
		private string email;
		private string phoneNumber;
		private DateTime creationDate;
		private DateTime lastModifiedDate; 
		
		[DataMember]
		public Guid ID
		{
			get { return Id; }
			set { Id = value; }
		}

		[DataMember]
		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		[DataMember]
		public string Surname
		{
			get { return surname; }
			set { surname = value; }
		}

		[DataMember]
		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		[DataMember]
		public string DRFO
		{
			get { return drfo; }
			set { drfo = value; }
		}

		[DataMember]
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		[DataMember]
		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}

		[DataMember]
		public DateTime CreationDate
		{
			get { return creationDate; }
			set { creationDate = value; }
		}

		[DataMember]
		public DateTime LastModifiedDate
		{
			get { return lastModifiedDate; }
			set { lastModifiedDate = value; }
		}
	}
}
