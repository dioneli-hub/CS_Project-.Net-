
namespace MyCSP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.sidePanel = new System.Windows.Forms.Panel();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.addTaskBox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tasksList = new System.Windows.Forms.CheckedListBox();
            this.closeLabel = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            this.completedTasksList = new System.Windows.Forms.CheckedListBox();
            this.todoLabel = new System.Windows.Forms.Label();
            this.doneLabel = new System.Windows.Forms.Label();
            this.sidePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sidePanel.Controls.Add(this.AddTaskButton);
            this.sidePanel.Controls.Add(this.addTaskBox);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(226, 423);
            this.sidePanel.TabIndex = 2;
            this.sidePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sidePanel_MouseDown);
            this.sidePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sidePanel_MouseMove);
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Location = new System.Drawing.Point(28, 336);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(158, 51);
            this.AddTaskButton.TabIndex = 3;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // addTaskBox
            // 
            this.addTaskBox.Location = new System.Drawing.Point(28, 300);
            this.addTaskBox.Name = "addTaskBox";
            this.addTaskBox.Size = new System.Drawing.Size(158, 20);
            this.addTaskBox.TabIndex = 2;
            this.addTaskBox.Text = "mjkg";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mainPanel.Controls.Add(this.doneLabel);
            this.mainPanel.Controls.Add(this.todoLabel);
            this.mainPanel.Controls.Add(this.completedTasksList);
            this.mainPanel.Controls.Add(this.tasksList);
            this.mainPanel.Controls.Add(this.closeLabel);
            this.mainPanel.Controls.Add(this.mainLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mainPanel.Location = new System.Drawing.Point(226, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(449, 423);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            // 
            // tasksList
            // 
            this.tasksList.FormattingEnabled = true;
            this.tasksList.Location = new System.Drawing.Point(37, 113);
            this.tasksList.Name = "tasksList";
            this.tasksList.Size = new System.Drawing.Size(165, 274);
            this.tasksList.TabIndex = 2;
            this.tasksList.SelectedIndexChanged += new System.EventHandler(this.tasksList_SelectedIndexChanged);
            // 
            // closeLabel
            // 
            this.closeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeLabel.Location = new System.Drawing.Point(418, 9);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(19, 21);
            this.closeLabel.TabIndex = 1;
            this.closeLabel.Text = "X";
            this.closeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            this.closeLabel.MouseEnter += new System.EventHandler(this.closeLabel_MouseEnter);
            this.closeLabel.MouseLeave += new System.EventHandler(this.closeLabel_MouseLeave);
            // 
            // mainLabel
            // 
            this.mainLabel.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mainLabel.Location = new System.Drawing.Point(122, 9);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(215, 56);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Urgent tasks";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // completedTasksList
            // 
            this.completedTasksList.FormattingEnabled = true;
            this.completedTasksList.Location = new System.Drawing.Point(245, 113);
            this.completedTasksList.Name = "completedTasksList";
            this.completedTasksList.Size = new System.Drawing.Size(165, 274);
            this.completedTasksList.TabIndex = 3;
            // 
            // todoLabel
            // 
            this.todoLabel.AutoSize = true;
            this.todoLabel.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.todoLabel.Location = new System.Drawing.Point(79, 75);
            this.todoLabel.Name = "todoLabel";
            this.todoLabel.Size = new System.Drawing.Size(64, 26);
            this.todoLabel.TabIndex = 4;
            this.todoLabel.Text = "TO DO";
            // 
            // doneLabel
            // 
            this.doneLabel.AutoSize = true;
            this.doneLabel.Font = new System.Drawing.Font("Segoe Print", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.doneLabel.Location = new System.Drawing.Point(298, 75);
            this.doneLabel.Name = "doneLabel";
            this.doneLabel.Size = new System.Drawing.Size(58, 26);
            this.doneLabel.TabIndex = 5;
            this.doneLabel.Text = "DONE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 423);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.TextBox addTaskBox;
        private System.Windows.Forms.CheckedListBox tasksList;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Label todoLabel;
        private System.Windows.Forms.CheckedListBox completedTasksList;
        private System.Windows.Forms.Label doneLabel;
    }
}

