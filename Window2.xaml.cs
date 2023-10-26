using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private string currentInput = "";
        private string currentOperator = "";
        private double result = 0;

        public Window2()
        {
            InitializeComponent();
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (currentOperator == "=")
            {
                currentOperator = "";
                currentInput = "";
            }

            string digit = (sender as Button).Content.ToString();

            if (!(currentInput == "0" && digit == "0"))
            {
                currentInput += digit;
                currentNumber.Text = currentInput;
            }
        }

        private void DecimalPoint_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                currentNumber.Text = currentInput;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (currentInput != "")
            {
                if (currentOperator != "")
                {
                    Calculate();
                    previousExpression.Text = result + " " + currentOperator;
                }
                else
                {
                    result = double.Parse(currentInput);
                    previousExpression.Text = result + " " + (sender as Button).Content.ToString();
                }

                currentInput = "";
                currentOperator = (sender as Button).Content.ToString();
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (currentInput != "")
            {
                Calculate();
                previousExpression.Text = "";
                currentOperator = "=";
                currentInput = result.ToString();
                currentNumber.Text = result.ToString();
            }
        }

        private void Calculate()
        {
            double secondNumber = double.Parse(currentInput);

            switch (currentOperator)
            {
                case "+":
                    result += secondNumber;
                    break;
                case "-":
                    result -= secondNumber;
                    break;
                case "*":
                    result *= secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        result /= secondNumber;
                    }
                    else
                    {
                        currentNumber.Text = "Error";
                        result = 0;
                    }
                    break;
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            currentNumber.Text = "0";
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            currentOperator = "";
            result = 0;
            currentNumber.Text = "0";
            previousExpression.Text = "";
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                currentNumber.Text = currentInput;
            }
        }
    }
}