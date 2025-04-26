// <copyright file="Calculator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

public class Calculator
{
    private double currentValue = 0;
    private double previousValue = 0;
    private char consideredOperator = '\0';
    private bool isNewNumber = true;
    private bool isError = false;

    /// <summary>
    /// Gets current status of the display.
    /// </summary>
    public string CurrentDisplay { get; private set; } = "0";


    public void AppendNumber(string number)
    {
        if (this.CurrentDisplay == "0" && number == "0")
        {
            return;
        }

        if (this.isError)
        {
            this.Clear();
        }

        if (this.isNewNumber)
        {
            this.CurrentDisplay = number;
            this.isNewNumber = false;
        }
        else
        {
            this.CurrentDisplay += number;
        }

        this.currentValue = double.Parse(this.CurrentDisplay);
        this.isError = false;
    }

    public void SetOperator(char op)
    {
        if (this.isError)
        {
            return;
        }

        if (this.consideredOperator != '\0' && !this.isNewNumber)
        {
            this.Calculate();
        }

        this.previousValue = this.currentValue;
        this.consideredOperator = op;
        this.isNewNumber = true;
    }

    public void Calculate()
    {
        try
        {
            switch (this.consideredOperator)
            {
                case '+':
                    this.currentValue = this.previousValue + this.currentValue;
                    break;
                case '-':
                    this.currentValue = this.previousValue - this.currentValue;
                    break;
                case '*':
                    this.currentValue = this.previousValue * this.currentValue;
                    break;
                case '/':
                    if (this.currentValue == 0)
                    {
                        this.isError = true;
                        this.CurrentDisplay = "Деление на ноль невозможно";
                        throw new DivideByZeroException();
                    }

                    this.currentValue = this.previousValue / this.currentValue;
                    break;
            }

            this.CurrentDisplay = this.currentValue.ToString();
        }
        finally
        {
            this.consideredOperator = '\0';
            this.isNewNumber = true;
        }
    }

    public void Clear()
    {
        this.currentValue = 0;
        this.previousValue = 0;
        this.consideredOperator = '\0';
        this.CurrentDisplay = "0";
        this.isNewNumber = true;
        this.isError = false;
    }
}