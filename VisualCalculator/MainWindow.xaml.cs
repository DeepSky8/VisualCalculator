using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace VisualCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double currentValue = 0;
        enum Operation { Add, Subtract, Multiply, Divide, Equals, Start };
        Operation math = Operation.Start;
        bool isNewNumber = false;
        bool isSecondNumber = false;
        double firstNumber = 0;
        double secondNumber = 0;


        public MainWindow()
        {
            InitializeComponent();
            txtOut.Text = currentValue.ToString();
        }


        /// <summary>
        /// Whenever number buttons are clicked, this method stores them as part of the current double
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEntry_Click(object sender, RoutedEventArgs e)
        {

            Button anyButton = (Button)sender;

            object content = anyButton.Content.ToString();

            if (isNewNumber || txtOut.Text == "0")
            {
                txtOut.Text = (string)content;
                isNewNumber = false;
            }
            else
            {
                txtOut.Text += content;
            }


        }

        private void Calculate(Operation operation)
        {
            if (math == Operation.Divide && (firstNumber == 0 || secondNumber == 0))
            {
                math = Operation.Start;
                currentValue = 0;
                txtOut.Text = "0";
            }
            else
            {
                switch (operation)
                {
                    case Operation.Add:
                        currentValue = (firstNumber + secondNumber);
                        break;
                    case Operation.Subtract:
                        currentValue = (firstNumber - secondNumber);
                        break;
                    case Operation.Multiply:
                        currentValue = (firstNumber * secondNumber);
                        break;
                    case Operation.Divide:
                        currentValue = (firstNumber / secondNumber);
                        break;
                    case Operation.Equals:
                        Calculate(math);
                        break;
                    case Operation.Start:
                        txtOut.Text = currentValue.ToString();
                        break;
                    default:
                        txtOut.Text = "burp!";
                        break;

                }
            }

        }

        // 4 event handlers for operations:
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Double.Parse(txtOut.Text);
            math = Operation.Add;
            //Calculate(Operation.Add);
            isNewNumber = true;
        }

        private void BtnSubtract_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Double.Parse(txtOut.Text);
            math = Operation.Subtract;
            //Calculate(Operation.Subtract);
            isNewNumber = true;
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Double.Parse(txtOut.Text);
            math = Operation.Multiply;
            //Calculate(Operation.Multiply);
            isNewNumber = true;
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Double.Parse(txtOut.Text);
            math = Operation.Divide;
            //Calculate(Operation.Divide);
            isNewNumber = true;

        }

        //Clear the current results
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            math = Operation.Start;
            txtOut.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            isNewNumber = true;
        }

        //Handle the Equals button
        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            math = Operation.Equals;
            secondNumber = Double.Parse(txtOut.Text);
            Calculate(Operation.Equals);

        }

    }
}
