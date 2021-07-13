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


            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `tasks`", db.getConnection());

            db.openConnection();

            MySqlDataReader DR = command.ExecuteReader();
            while (DR.Read())
            {
                string item = DR.GetValue(1).ToString();
                tasksList.Items.Add(item);
                int index = tasksList.FindString(item); 
               

                int id = find_task_id(item);

                
                if ((id >= 0))
                {
                    if ((DR.GetValue(2).ToString() == "True"))
                    {
                        tasksList.SetItemChecked(index, true);
                    }
                    else
                    {
                        tasksList.SetItemChecked(index, false);
                    }
                }
            }

            db.closeConnection();
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

        private void tasksList_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Get the currently selected item in the CheckedBox.
            string curItem = tasksList.SelectedItem.ToString();

            // Find the index of the string in the box.
            int index = tasksList.FindString(curItem);

            DB db = new DB();
            db.openConnection();

            MySqlCommand command1 = new MySqlCommand("SELECT `id` FROM `tasks` WHERE `task` = @task", db.getConnection());
            command1.Parameters.Add("@task", MySqlDbType.VarChar).Value = curItem;


            int id;
            bool isParsable = int.TryParse(command1.ExecuteScalar().ToString(), out id);

            if (isParsable)
                if (tasksList.GetItemChecked(index))
                {
                    // item checked

                    tasksList.SetItemChecked(index, false);

                    MySqlCommand command3 = new MySqlCommand("UPDATE `tasks` SET `is_completed` = 0 WHERE `id` = @id", db.getConnection());
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    if (command3.ExecuteNonQuery() == 1)
                        MessageBox.Show("Unchecked");

                } else
                {   
                    // item not checked

                    tasksList.SetItemChecked(index, true);

                    MySqlCommand command2 = new MySqlCommand("UPDATE `tasks` SET `is_completed` = 1 WHERE `id` = @id", db.getConnection());
                    command2.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    if (command2.ExecuteNonQuery() == 1)
                        MessageBox.Show("Successfully checked");
                }


            db.closeConnection();
        }

        private int find_task_id(string item)
        {
            DB db = new DB();
            db.openConnection();

            MySqlCommand command1 = new MySqlCommand("SELECT `id` FROM `tasks` WHERE `task` = @task", db.getConnection());
            command1.Parameters.Add("@task", MySqlDbType.VarChar).Value = item;
            int id;
            bool isParsable = int.TryParse(command1.ExecuteScalar().ToString(), out id);

            db.closeConnection();

            if (isParsable) return id;
            return -1;
        }


    }
}
