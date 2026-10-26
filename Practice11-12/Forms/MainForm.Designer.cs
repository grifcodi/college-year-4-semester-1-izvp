namespace _11_practice.Models
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textName = new TextBox();
            numAge = new NumericUpDown();
            textCourse = new TextBox();
            dgvStudents = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            labelName = new Label();
            labelAge = new Label();
            labelCourse = new Label();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // textName
            // 
            textName.Location = new Point(130, 21);
            textName.Name = "textName";
            textName.Size = new Size(200, 23);
            textName.TabIndex = 0;
            // 
            // numAge
            // 
            numAge.Location = new Point(130, 60);
            numAge.Name = "numAge";
            numAge.Size = new Size(200, 23);
            numAge.TabIndex = 1;
            // 
            // textCourse
            // 
            textCourse.Location = new Point(130, 100);
            textCourse.Name = "textCourse";
            textCourse.Size = new Size(200, 23);
            textCourse.TabIndex = 2;
            // 
            // dgvStudents
            // 
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(20, 150);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(740, 330);
            dgvStudents.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(360, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Create";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(360, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 23);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(470, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(470, 60);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 23);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(20, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(44, 15);
            labelName.TabIndex = 8;
            labelName.Text = "Initials:";
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(20, 60);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(31, 15);
            labelAge.TabIndex = 9;
            labelAge.Text = "Age:";
            // 
            // labelCourse
            // 
            labelCourse.AutoSize = true;
            labelCourse.Location = new Point(20, 100);
            labelCourse.Name = "labelCourse";
            labelCourse.Size = new Size(43, 15);
            labelCourse.TabIndex = 10;
            labelCourse.Text = "Couse:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 511);
            Controls.Add(labelCourse);
            Controls.Add(labelAge);
            Controls.Add(labelName);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvStudents);
            Controls.Add(textCourse);
            Controls.Add(numAge);
            Controls.Add(textName);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textName;
        private NumericUpDown numAge;
        private TextBox textCourse;
        private DataGridView dgvStudents;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label labelName;
        private Label labelAge;
        private Label labelCourse;
    }
}