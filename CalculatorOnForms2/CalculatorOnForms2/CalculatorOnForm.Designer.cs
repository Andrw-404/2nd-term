namespace CalculatorOnForms2
{
    partial class CalculatorOnForm
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
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            buttonClear = new Button();
            buttonPlus = new Button();
            buttonEquals = new Button();
            buttonMinus = new Button();
            buttonDivision = new Button();
            buttonMultiplication = new Button();
            button0 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(437, 81);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(160, 159);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonNumber_Click;
            // 
            // button2
            // 
            button2.Location = new Point(270, 159);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonNumber_Click;
            // 
            // button3
            // 
            button3.Location = new Point(379, 159);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ButtonNumber_Click;
            // 
            // button4
            // 
            button4.Location = new Point(491, 159);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 4;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ButtonNumber_Click;
            // 
            // button5
            // 
            button5.Location = new Point(160, 219);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += ButtonNumber_Click;
            // 
            // button6
            // 
            button6.Location = new Point(270, 219);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 6;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ButtonNumber_Click;
            // 
            // button7
            // 
            button7.Location = new Point(379, 219);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 7;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += ButtonNumber_Click;
            // 
            // button8
            // 
            button8.Location = new Point(491, 219);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 8;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += ButtonNumber_Click;
            // 
            // button9
            // 
            button9.Location = new Point(160, 269);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 9;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += ButtonNumber_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(491, 344);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 29);
            buttonClear.TabIndex = 10;
            buttonClear.Text = "C";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += ButtonClear_Click;
            // 
            // buttonPlus
            // 
            buttonPlus.Location = new Point(644, 159);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(94, 29);
            buttonPlus.TabIndex = 11;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = true;
            buttonPlus.Click += ButtonOperator_Click;
            // 
            // buttonEquals
            // 
            buttonEquals.Location = new Point(379, 344);
            buttonEquals.Name = "buttonEquals";
            buttonEquals.Size = new Size(94, 29);
            buttonEquals.TabIndex = 12;
            buttonEquals.Text = "=";
            buttonEquals.UseVisualStyleBackColor = true;
            buttonEquals.Click += ButtonEquals_Click;
            // 
            // buttonMinus
            // 
            buttonMinus.Location = new Point(644, 219);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.Size = new Size(94, 29);
            buttonMinus.TabIndex = 13;
            buttonMinus.Text = "-";
            buttonMinus.UseVisualStyleBackColor = true;
            buttonMinus.Click += ButtonOperator_Click;
            // 
            // buttonDivision
            // 
            buttonDivision.Location = new Point(644, 317);
            buttonDivision.Name = "buttonDivision";
            buttonDivision.Size = new Size(94, 29);
            buttonDivision.TabIndex = 14;
            buttonDivision.Text = "/";
            buttonDivision.UseVisualStyleBackColor = true;
            buttonDivision.Click += ButtonOperator_Click;
            // 
            // buttonMultiplication
            // 
            buttonMultiplication.Location = new Point(644, 269);
            buttonMultiplication.Name = "buttonMultiplication";
            buttonMultiplication.Size = new Size(94, 29);
            buttonMultiplication.TabIndex = 15;
            buttonMultiplication.Text = "*";
            buttonMultiplication.UseVisualStyleBackColor = true;
            buttonMultiplication.Click += ButtonOperator_Click;
            // 
            // button0
            // 
            button0.Location = new Point(270, 269);
            button0.Name = "button0";
            button0.Size = new Size(94, 29);
            button0.TabIndex = 16;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += ButtonNumber_Click;
            // 
            // CalculatorOnForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button0);
            Controls.Add(buttonMultiplication);
            Controls.Add(buttonDivision);
            Controls.Add(buttonMinus);
            Controls.Add(buttonEquals);
            Controls.Add(buttonPlus);
            Controls.Add(buttonClear);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "CalculatorOnForm";
            Text = "CalculatorOnForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button buttonClear;
        private Button buttonPlus;
        private Button buttonEquals;
        private Button buttonMinus;
        private Button buttonDivision;
        private Button buttonMultiplication;
        private Button button0;
    }
}