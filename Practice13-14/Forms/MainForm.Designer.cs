namespace Practice13_14.Forms
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
            components = new System.ComponentModel.Container();
            labelName = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textName = new TextBox();
            labelDate = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            cmbLessons = new ComboBox();
            cmbStudents = new ComboBox();
            radioBtnAttendance = new RadioButton();
            textComment = new TextBox();
            numMark = new NumericUpDown();
            labelMark = new Label();
            labelComment = new Label();
            labelAttendance = new Label();
            btnGenerate = new Button();
            cmbDays = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numMark).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(20, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(60, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Ім'я учня:";
            labelName.TextAlign = ContentAlignment.BottomCenter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textName
            // 
            textName.Location = new Point(120, 20);
            textName.Name = "textName";
            textName.Size = new Size(200, 23);
            textName.TabIndex = 2;
            textName.Text = " ";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(400, 20);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(70, 15);
            labelDate.TabIndex = 4;
            labelDate.Text = "Дата уроку:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 60);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(120, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Змінити";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(220, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(480, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbLessons
            // 
            cmbLessons.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLessons.FormattingEnabled = true;
            cmbLessons.Location = new Point(520, 20);
            cmbLessons.Name = "cmbLessons";
            cmbLessons.Size = new Size(121, 23);
            cmbLessons.TabIndex = 9;
            cmbLessons.SelectedIndexChanged += cmbLessons_SelectedIndexChanged;
            // 
            // cmbStudents
            // 
            cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(20, 100);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(308, 23);
            cmbStudents.TabIndex = 10;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;
            // 
            // radioBtnAttendance
            // 
            radioBtnAttendance.AutoSize = true;
            radioBtnAttendance.Location = new Point(520, 60);
            radioBtnAttendance.Name = "radioBtnAttendance";
            radioBtnAttendance.Size = new Size(14, 13);
            radioBtnAttendance.TabIndex = 11;
            radioBtnAttendance.TabStop = true;
            radioBtnAttendance.UseVisualStyleBackColor = true;
            // 
            // textComment
            // 
            textComment.Location = new Point(520, 140);
            textComment.Name = "textComment";
            textComment.Size = new Size(200, 23);
            textComment.TabIndex = 12;
            // 
            // numMark
            // 
            numMark.Location = new Point(520, 100);
            numMark.Name = "numMark";
            numMark.Size = new Size(120, 23);
            numMark.TabIndex = 13;
            // 
            // labelMark
            // 
            labelMark.AutoSize = true;
            labelMark.Location = new Point(400, 100);
            labelMark.Name = "labelMark";
            labelMark.Size = new Size(91, 15);
            labelMark.TabIndex = 14;
            labelMark.Text = "Оцінка за урок:";
            // 
            // labelComment
            // 
            labelComment.AutoSize = true;
            labelComment.Location = new Point(400, 140);
            labelComment.Name = "labelComment";
            labelComment.Size = new Size(115, 15);
            labelComment.TabIndex = 15;
            labelComment.Text = "Коментар до уроку:";
            // 
            // labelAttendance
            // 
            labelAttendance.AutoSize = true;
            labelAttendance.Location = new Point(400, 60);
            labelAttendance.Name = "labelAttendance";
            labelAttendance.Size = new Size(77, 15);
            labelAttendance.TabIndex = 16;
            labelAttendance.Text = "Присутність:";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(20, 220);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(120, 23);
            btnGenerate.TabIndex = 17;
            btnGenerate.Text = "Згенерувати дні";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // cmbDays
            // 
            cmbDays.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDays.FormattingEnabled = true;
            cmbDays.Location = new Point(174, 220);
            cmbDays.Name = "cmbDays";
            cmbDays.Size = new Size(121, 23);
            cmbDays.TabIndex = 19;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbDays);
            Controls.Add(btnGenerate);
            Controls.Add(labelAttendance);
            Controls.Add(labelComment);
            Controls.Add(labelMark);
            Controls.Add(numMark);
            Controls.Add(textComment);
            Controls.Add(radioBtnAttendance);
            Controls.Add(cmbStudents);
            Controls.Add(cmbLessons);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(labelDate);
            Controls.Add(textName);
            Controls.Add(labelName);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)numMark).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textName;
        private Label labelDate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSave;
        private ComboBox cmbLessons;
        private ComboBox cmbStudents;
        private RadioButton radioBtnAttendance;
        private TextBox textComment;
        private NumericUpDown numMark;
        private Label labelMark;
        private Label labelComment;
        private Label labelAttendance;
        private Button btnGenerate;
        private ComboBox cmbDays;
    }
}