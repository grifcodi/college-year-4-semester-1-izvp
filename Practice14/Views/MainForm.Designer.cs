namespace Practice14.Views
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
            ListTasks = new CheckedListBox();
            BtnAdd = new Button();
            BtnDelete = new Button();
            TxtName = new TextBox();
            SuspendLayout();
            // 
            // ListTasks
            // 
            ListTasks.FormattingEnabled = true;
            ListTasks.Location = new Point(140, 12);
            ListTasks.Name = "ListTasks";
            ListTasks.Size = new Size(232, 238);
            ListTasks.TabIndex = 0;
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(20, 60);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(75, 23);
            BtnAdd.TabIndex = 1;
            BtnAdd.Text = "Додати";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(20, 100);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(75, 23);
            BtnDelete.TabIndex = 2;
            BtnDelete.Text = "Видалити";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // TxtName
            // 
            TxtName.Location = new Point(20, 20);
            TxtName.Name = "TxtName";
            TxtName.PlaceholderText = "Зробити тест";
            TxtName.Size = new Size(100, 23);
            TxtName.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(TxtName);
            Controls.Add(BtnDelete);
            Controls.Add(BtnAdd);
            Controls.Add(ListTasks);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox ListTasks;
        private Button BtnAdd;
        private Button BtnDelete;
        private TextBox TxtName;
    }
}