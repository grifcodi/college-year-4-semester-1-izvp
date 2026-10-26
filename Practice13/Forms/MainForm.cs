using Practice13.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Practice13.Forms
{
    public partial class MainForm : Form
    {
        private readonly DiscountCalculatorService _discountCalculatorService;
        public MainForm()
        {
            InitializeComponent();
            _discountCalculatorService = new DiscountCalculatorService();
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(TextBoxPrice.Text, out decimal price))
            {
                MessageBox.Show("Будь ласка, введіть коректне числове значення для суми.",
                                "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(TextBoxDiscount.Text, out decimal discount))
            {
                MessageBox.Show("Будь ласка, введіть коректне числове значення для знижки.",
                                "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal finalPrice = _discountCalculatorService.CalculateFinalPrice(price, discount);
                labelResult.Text = $"До сплати: {finalPrice:F2} грн";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Некоректні дані", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла непередбачувана помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
