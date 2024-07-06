using System.Data;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCFService.Interfaces;
using WCFService.Models;
using WinFormsApp.Services;

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
			DataSet dataSet = new DataSet();
			//dataGridView1.DataSource = users;

			dataGridView1.Rows.Clear();

			foreach (var user in users)
			{
				dataGridView1.Rows.Add(user.FirstName, user.Surname, user.LastName, user.DRFO, user.Email, user.PhoneNumber, user.CreationDate, user.LastModifiedDate,
				user.ID);
			}
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value == null || string.IsNullOrEmpty(e.ToString()))
				return;
			if (e.ColumnIndex == dataGridView1.Columns["Phone"].Index && e.Value.ToString()!.Any(char.IsAsciiLetter))
			{
				//dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["Phone"].Index].ToolTipText = "Is restricted to have letters in phone number";
				dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["Phone"].Index].Value = "";
			}
		}

		//Setting default values
		private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["FirstName"].Value = "First name";
			e.Row.Cells["Surname"].Value = "Surname";
			e.Row.Cells["LastName"].Value = "Last name";
			e.Row.Cells["CreationTime"].Value = DateTime.Now.ToString();
			e.Row.Cells["ChangeTime"].Value = DateTime.Now.ToString();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
		{
			var lastAddedRow = e.Row;

			service.AddValue(new User()
			{
				FirstName = (string)lastAddedRow.Cells[0].Value,
				Surname = (string)lastAddedRow.Cells[1].Value,
				LastName = (string)lastAddedRow.Cells[2].Value,
				DRFO = (string)lastAddedRow.Cells[3].Value,
				Email = (string)lastAddedRow.Cells[4].Value,
				PhoneNumber = (string)lastAddedRow.Cells[5].Value,
			});

			//dataGridView1.Rows.Remove(lastAddedRow);
			LoadData();
		}

		private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
		{
			if (!long.TryParse(e.Row.Cells[8].Value.ToString(), out var id))
			{
				return;
			}

			service.RemoveValue(new User()
			{
				ID = id,
			});
			LoadData();
		}

		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var rowToUpdate = dataGridView1.Rows[e.RowIndex];

			if (!long.TryParse(rowToUpdate.Cells[8].Value.ToString(), out var id))
			{
				return;
			}


			service.UpdateValue(new User()
			{
				FirstName = (string)rowToUpdate.Cells[0].Value,
				Surname = (string)rowToUpdate.Cells[1].Value,
				LastName = (string)rowToUpdate.Cells[2].Value,
				DRFO = (string)rowToUpdate.Cells[3].Value,
				Email = (string)rowToUpdate.Cells[4].Value,
				PhoneNumber = (string)rowToUpdate.Cells[5].Value,
				ID = id,
			});
			LoadData();
		}
	}
}
