using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCFService.Interfaces;
using WCFService.Models;
using WinFormsApp;
using WinFormsApp.Services;
using User = WCFService.Models.User;

namespace WCFService
{

	public partial class Form1 : Form
	{
		const string remoteAddress = "http://localhost:55624/Services/UserService.svc";
		private UserServiceClient service;
		private List<User> users;


		public Form1()
		{
			InitializeComponent();
			Init();
			LoadData();
		}

		private void Init()
		{
			System.ServiceModel.Channels.Binding binding = new BasicHttpBinding();
			EndpointAddress endpointAddress = new EndpointAddress(remoteAddress);

			ChannelFactory<IUserService> factory = new ChannelFactory<IUserService>(binding, endpointAddress);
			service = new UserServiceClient(factory);

		}

		private void LoadData()
		{
			users = service.GetValues();

			foreach (var user in users)
			{
				dataGridView1.Rows.Add(user.FirstName, user.Surname, user.LastName, user.DRFO, user.Email, user.PhoneNumber, user.CreationDate, user.LastModifiedDate,
				user.ID);
			}
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value == null || string.IsNullOrEmpty(e.ToString()) || e.Value is DateTime)
				return;
			e.Value = new string (((string)e.Value).Where(c => !char.IsWhiteSpace(c)).ToArray());

			if (e.ColumnIndex == dataGridView1.Columns["Phone"].Index && e.Value.ToString()!.Any(char.IsAsciiLetter))
			{
				//dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["Phone"].Index].ToolTipText = "Is restricted to have letters in phone number";
				dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["Phone"].Index].Value = 
				new string(((string)dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["Phone"].Index].Value).
				Where(char.IsDigit).Where(x => !char.IsWhiteSpace(x))
				.ToArray());
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
		{
			service.RemoveValue(new User()
			{
				ID = (Guid)e.Row.Cells[8].Value,
			});
		}

		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowToUpdate = dataGridView1.Rows[e.RowIndex];

			if (rowToUpdate.Cells[8].Value == null)
			{
				AddNewUser(rowToUpdate);
			} else
			{
				UpdateUser(rowToUpdate);
			}
        }

        private void AddNewUser(DataGridViewRow lastAddedRow)
        {
            var id = service.AddValue(new User()
            {
                FirstName = (string)lastAddedRow.Cells[0].Value,
                Surname = (string)lastAddedRow.Cells[1].Value,
                LastName = (string)lastAddedRow.Cells[2].Value,
                DRFO = (string)lastAddedRow.Cells[3].Value,
                Email = (string)lastAddedRow.Cells[4].Value,
                PhoneNumber = (string)lastAddedRow.Cells[5].Value,
            });

			var user = service.GetValue(id);


            lastAddedRow.Cells[6].Value = user.CreationDate.ToString();
            lastAddedRow.Cells[7].Value = user.LastModifiedDate.ToString();
            lastAddedRow.Cells[8].Value = id;
        }

        private void UpdateUser(DataGridViewRow rowToUpdate)
		{
			var user = service.UpdateValue(new User()
			{
				FirstName = (string)rowToUpdate.Cells[0].Value,
				Surname = (string)rowToUpdate.Cells[1].Value,
				LastName = (string)rowToUpdate.Cells[2].Value,
				DRFO = (string)rowToUpdate.Cells[3].Value,
				Email = (string)rowToUpdate.Cells[4].Value,
				PhoneNumber = (string)rowToUpdate.Cells[5].Value,
				ID = (Guid)rowToUpdate.Cells[8].Value,
			});

			rowToUpdate.Cells[6].Value = user.CreationDate.ToString();
			rowToUpdate.Cells[7].Value = user.LastModifiedDate.ToString();
		}
	}
}
