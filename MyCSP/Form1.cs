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

        private void doneLabel_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            

            MySqlCommand command = new MySqlCommand("UPDATE `tasks` SET `is_visible` = @iV WHERE `is_completed`= @iC", db.getConnection());
            command.Parameters.Add("@iC", MySqlDbType.Int32).Value = 1;
            command.Parameters.Add("@iV", MySqlDbType.Int32).Value = 0;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Click");

            db.closeConnection();

            DisplayTasks();
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

            if (CheckVisible(task)) tasksList.Items.Add(task); // add a method?

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

        private int FindTaskId(string item)
        {
            DB db = new DB();

            db.openConnection();

            int id;
            MySqlCommand command = new MySqlCommand("SELECT `id` FROM `tasks` WHERE `task` = @task", db.getConnection());
            command.Parameters.Add("@task", MySqlDbType.VarChar).Value = item;
            bool isParsable = int.TryParse(command.ExecuteScalar().ToString(), out id);

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Id found");

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

                if (CheckVisible(item))
                {
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


                    int id = FindTaskId(item);


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

            }

            db.closeConnection();
        }

        private void CheckedListBoxHandler(CheckedListBox list, bool checkSetTo)
        {
            // Get the currently selected item in the CheckedBox.
            string curItem = list.SelectedItem.ToString();

            DB db = new DB();
            db.openConnection();

            int id = FindTaskId(curItem);

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

        private bool CheckVisible (string item) 
        {
            int id = FindTaskId(item);

            DB db = new DB();

            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `tasks` WHERE `id` = @Id AND `task` = @task AND `is_visible` = @V", db.getConnection());
            command.Parameters.Add("@task", MySqlDbType.VarChar).Value = item;
            command.Parameters.Add("@V", MySqlDbType.Int32).Value = 1;
            command.Parameters.Add("@Id", MySqlDbType.Int32).Value = id;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            if (table.Rows.Count > 0)
                return true;
               
            return false;
        }

       
    }
}
