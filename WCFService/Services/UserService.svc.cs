using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFService.Interfaces;
using WCFService.Models;

namespace WCFService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class UserService : IUserService
	{
		private const string connectionString = "server=localhost;DataBase=UserServiceDB;Trusted_Connection=True;TrustServerCertificate=True;";

		public UserService()
		{
			CreateDB();
		}

		private void CreateDB()
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users') CREATE TABLE Users (UserId INT PRIMARY KEY,FirstName NVARCHAR(255) NULL,LastName NVARCHAR(255) NULL,Surname NVARCHAR(255) NULL,DRFO NVARCHAR(255) NULL,Email NVARCHAR(255) NULL,PhoneNumber NVARCHAR(15) NULL,CreationDate DATETIME,LastModifiedDate DATETIME);", conn);

				cmd.ExecuteNonQuery();
			}
		}

		public List<User> GetValues()
		{
			List<User> users = new List<User>();

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					users.Add(new User
					{
						ID = (int)reader["UserId"],
						FirstName = (string)reader["FirstName"],
						LastName = (string)reader["LastName"],
						Surname = (string)reader["Surname"],
						DRFO = (string)reader["DRFO"],
						Email = (string)reader["Email"],
						PhoneNumber = (string)reader["PhoneNumber"],
						CreationDate = (DateTime)reader["CreationDate"],
						LastModifiedDate = (DateTime)reader["LastModifiedDate"]
					});
				}
			}

			return users;
		}
		public void AddValue(User value)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("INSERT INTO Users (FirstName, LastName, Surname, DRFO, Email, PhoneNumber, CreationDate, LastModifiedDate, UserId) " +
					"VALUES (@FirstName, @LastName, @Surname, @DRFO, @Email, @PhoneNumber, @CreationDate, @LastModifiedDate, 0)", conn);
				cmd.Parameters.AddWithValue("@FirstName", value.FirstName ?? "");
				cmd.Parameters.AddWithValue("@LastName", value.LastName ?? "");
				cmd.Parameters.AddWithValue("@Surname", value.Surname ?? "");
				cmd.Parameters.AddWithValue("@DRFO", value.DRFO ?? "");
				cmd.Parameters.AddWithValue("@Email", value.Email ?? "");
				cmd.Parameters.AddWithValue("@PhoneNumber", value.PhoneNumber ?? "");
				cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
				cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
				cmd.ExecuteNonQuery();
			}
		}

		public User GetValue(long key)
		{
			User user = null;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserId = @UserId", conn);
				cmd.Parameters.AddWithValue("@UserId", key);
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					user = new User
					{
						ID = (int)reader["UserId"],
						FirstName = (string)reader["FirstName"],
						LastName = (string)reader["LastName"],
						Surname = (string)reader["Surname"],
						DRFO = (string)reader["DRFO"],
						Email = (string)reader["Email"],
						PhoneNumber = (string)reader["PhoneNumber"],
						CreationDate = (DateTime)reader["CreationDate"],
						LastModifiedDate = (DateTime)reader["LastModifiedDate"]
					};
				}
			}

			return user;
		}

		public void RemoveValue(User value)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserId = @UserId", conn);
				cmd.Parameters.AddWithValue("@UserId", value.ID);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateValue(User value)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Surname = @Surname, DRFO = @DRFO, Email = @Email, " +
					"PhoneNumber = @PhoneNumber, LastModifiedDate = @LastModifiedDate WHERE UserId = @UserId", conn);
				cmd.Parameters.AddWithValue("@UserId", value.ID);
				cmd.Parameters.AddWithValue("@FirstName", value.FirstName);
				cmd.Parameters.AddWithValue("@LastName", value.LastName);
				cmd.Parameters.AddWithValue("@Surname", value.Surname);
				cmd.Parameters.AddWithValue("@DRFO", value.DRFO);
				cmd.Parameters.AddWithValue("@Email", value.Email);
				cmd.Parameters.AddWithValue("@PhoneNumber", value.PhoneNumber);
				cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
				cmd.ExecuteNonQuery();
			}
		}

	}
}
