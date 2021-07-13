using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DayPlanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DisplayTasks();
            
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
            CheckedListBoxHandler(tasksList, true);
            
        }

        private void completedTasksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBoxHandler(completedTasksList, false);
        }

        private int findTaskId(string item)
        {
            DB db = new DB();
            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT `id` FROM `tasks` WHERE `task` = @task", db.getConnection());
            command.Parameters.Add("@task", MySqlDbType.VarChar).Value = item;
            int id;
            bool isParsable = int.TryParse(command.ExecuteScalar().ToString(), out id);

            db.closeConnection();

            if (isParsable) return id;
            return -1;
        }

        private void DisplayTasks()
        {
            tasksList.Items.Clear();
            completedTasksList.Items.Clear();

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `tasks`", db.getConnection());

            db.openConnection();

            MySqlDataReader DR = command.ExecuteReader();
            while (DR.Read())
            {
                string item = DR.GetValue(1).ToString();
                CheckedListBox list;
                if ((DR.GetValue(2).ToString() == "True"))
                {
                    list = completedTasksList;
                    
                }
                else
                {
                    list = tasksList;
                    
                }

                list.Items.Add(item);
                int index = list.FindString(item);


                int id = findTaskId(item);


                if ((id >= 0))
                {
                    if ((DR.GetValue(2).ToString() == "True"))
                    {
                        list.SetItemChecked(index, true);
                    }
                    else
                    {
                        list.SetItemChecked(index, false);
                    }
                }
            }

            foreach (int indexChecked in tasksList.CheckedIndices)
            {
                completedTasksList.Items.Add(tasksList.Items[indexChecked]);
            }

                db.closeConnection();
        }

        private void CheckedListBoxHandler(CheckedListBox list, bool checkSetTo)
        {
            // Get the currently selected item in the CheckedBox.
            string curItem = list.SelectedItem.ToString();

            // Find the index of the string in the box.
            int index = list.FindString(curItem);

            DB db = new DB();
            db.openConnection();

            int id = findTaskId(curItem);

            if (id >= 0)
                {
                    MySqlCommand command3 = new MySqlCommand("UPDATE `tasks` SET `is_completed` = @iC WHERE `id` = @id", db.getConnection());
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command3.Parameters.Add("@iC", MySqlDbType.Int32).Value = checkSetTo;

                    if (command3.ExecuteNonQuery() == 1)
                        MessageBox.Show("Yes!");
                }
                

            db.closeConnection();
            DisplayTasks();
        }

        
    }
}
