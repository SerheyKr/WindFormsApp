namespace WCFService
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            FirstName = new DataGridViewTextBoxColumn();
            Surname = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            DRFO = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            CreationTime = new DataGridViewTextBoxColumn();
            ChangeTime = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { FirstName, Surname, LastName, DRFO, Email, Phone, CreationTime, ChangeTime, ID });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(855, 426);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.DefaultValuesNeeded += dataGridView1_DefaultValuesNeeded;
            dataGridView1.UserAddedRow += dataGridView1_UserAddedRow;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            // 
            // FirstName
            // 
            FirstName.HeaderText = "First name";
            FirstName.MinimumWidth = 8;
            FirstName.Name = "FirstName";
            FirstName.Width = 150;
            // 
            // Surname
            // 
            Surname.HeaderText = "Surname";
            Surname.MinimumWidth = 8;
            Surname.Name = "Surname";
            Surname.Width = 150;
            // 
            // LastName
            // 
            LastName.HeaderText = "Last name";
            LastName.MinimumWidth = 8;
            LastName.Name = "LastName";
            LastName.Width = 150;
            // 
            // DRFO
            // 
            DRFO.HeaderText = "DRFO";
            DRFO.MinimumWidth = 8;
            DRFO.Name = "DRFO";
            DRFO.Width = 150;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 8;
            Email.Name = "Email";
            Email.Width = 150;
            // 
            // Phone
            // 
            Phone.HeaderText = "Phone number";
            Phone.MinimumWidth = 8;
            Phone.Name = "Phone";
            Phone.Width = 150;
            // 
            // CreationTime
            // 
            CreationTime.HeaderText = "Creation date";
            CreationTime.MinimumWidth = 8;
            CreationTime.Name = "CreationTime";
            CreationTime.ReadOnly = true;
            CreationTime.Width = 150;
            // 
            // ChangeTime
            // 
            ChangeTime.HeaderText = "Last-change date";
            ChangeTime.MinimumWidth = 8;
            ChangeTime.Name = "ChangeTime";
            ChangeTime.ReadOnly = true;
            ChangeTime.Width = 150;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 8;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.Width = 150;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 450);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Users";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn Surname;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn DRFO;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn CreationTime;
        private DataGridViewTextBoxColumn ChangeTime;
        private DataGridViewTextBoxColumn ID;
    }
}
