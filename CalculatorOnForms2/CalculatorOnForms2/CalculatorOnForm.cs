// <copyright file="CalculatorOnForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorOnForms2
{
    public partial class CalculatorOnForm : Form
    {
        private Calculator calculator = new Calculator();

        public CalculatorOnForm()
        {
            this.InitializeComponent();
            this.UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            this.textBox1.Text = this.calculator.CurrentDisplay;
        }

        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            this.calculator.AppendNumber(btn.Text);
            this.UpdateDisplay();
        }

        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            this.calculator.SetOperator(btn.Text[0]);
            this.UpdateDisplay();
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                this.calculator.Calculate();
                this.UpdateDisplay();
            }
            catch (DivideByZeroException)
            {
                this.textBox1.Text = "Деление на ноль невозможно";
                this.calculator.Clear();
                this.calculator.AppendNumber("0");
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.calculator.Clear();
            this.UpdateDisplay();
        }

        private void TextDisplay_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
