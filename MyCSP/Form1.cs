using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MyCSP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeLabel_MouseEnter(object sender, EventArgs e)
        {
            closeLabel.ForeColor = Color.Red;
        }

        private void closeLabel_MouseLeave(object sender, EventArgs e)
        {
            closeLabel.ForeColor = Color.FromArgb(95, 110, 99);
        }

        Point lastPoint;
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void sidePanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void sidePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            string task = addTaskBox.Text.ToString();
            byte is_completed = 0;


            if (task.Replace(" ", "") == "")
            {
                MessageBox.Show("Please, enter the task!");
                return;
            }

            tasksList.Items.Add(task);
            addTaskBox.Clear();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `tasks` (`task`, `is_completed`) VALUES (@task,  @isC)", db.getConnection());
            command.Parameters.Add("@task", MySqlDbType.VarChar).Value = task;
            command.Parameters.Add("@isC", MySqlDbType.Byte).Value = is_completed;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Task successfully added to DB!");
            else
                MessageBox.Show("Something went wrong...");

            db.closeConnection();
        }
    }
}
