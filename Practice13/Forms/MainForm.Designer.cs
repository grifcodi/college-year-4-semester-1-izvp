namespace Practice13.Forms
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
            TextBoxPrice = new TextBox();
            TextBoxDiscount = new TextBox();
            LabelDiscount = new Label();
            LabelPrice = new Label();
            ButtonCalculate = new Button();
            labelResult = new Label();
            SuspendLayout();
            // 
            // TextBoxPrice
            // 
            TextBoxPrice.Location = new Point(100, 20);
            TextBoxPrice.Name = "TextBoxPrice";
            TextBoxPrice.Size = new Size(100, 23);
            TextBoxPrice.TabIndex = 0;
            // 
            // TextBoxDiscount
            // 
            TextBoxDiscount.Location = new Point(100, 80);
            TextBoxDiscount.Name = "TextBoxDiscount";
            TextBoxDiscount.Size = new Size(100, 23);
            TextBoxDiscount.TabIndex = 1;
            // 
            // LabelDiscount
            // 
            LabelDiscount.AutoSize = true;
            LabelDiscount.Location = new Point(40, 80);
            LabelDiscount.Name = "LabelDiscount";
            LabelDiscount.Size = new Size(52, 15);
            LabelDiscount.TabIndex = 2;
            LabelDiscount.Text = "Знижка:";
            // 
            // LabelPrice
            // 
            LabelPrice.AutoSize = true;
            LabelPrice.Location = new Point(40, 20);
            LabelPrice.Name = "LabelPrice";
            LabelPrice.Size = new Size(35, 15);
            LabelPrice.TabIndex = 3;
            LabelPrice.Text = "Ціна:";
            // 
            // ButtonCalculate
            // 
            ButtonCalculate.Location = new Point(40, 146);
            ButtonCalculate.Name = "ButtonCalculate";
            ButtonCalculate.Size = new Size(88, 23);
            ButtonCalculate.TabIndex = 4;
            ButtonCalculate.Text = "Порахувати";
            ButtonCalculate.UseVisualStyleBackColor = true;
            ButtonCalculate.Click += ButtonCalculate_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(100, 207);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(39, 15);
            labelResult.TabIndex = 5;
            labelResult.Text = "Result";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 361);
            Controls.Add(labelResult);
            Controls.Add(ButtonCalculate);
            Controls.Add(LabelPrice);
            Controls.Add(LabelDiscount);
            Controls.Add(TextBoxDiscount);
            Controls.Add(TextBoxPrice);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxPrice;
        private TextBox TextBoxDiscount;
        private Label LabelDiscount;
        private Label LabelPrice;
        private Button ButtonCalculate;
        private Label labelResult;
    }
}