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
        bool isNewNumber = true;
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
            /// <summary>
        /// When the equals button is clicked this method accepts the specified operation and performs it upon two doubles. Dividing with 0 as one of the doubles automatically returns 0
        /// </summary>
        /// <param name="operation"></param>
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
                        txtOut.Text = currentValue.ToString();
                        break;
                    case Operation.Subtract:
                        currentValue = (firstNumber - secondNumber);
                        txtOut.Text = currentValue.ToString();
                        break;
                    case Operation.Multiply:
                        currentValue = (firstNumber * secondNumber);
                        txtOut.Text = currentValue.ToString();
                        break;
                    case Operation.Divide:
                        currentValue = (firstNumber / secondNumber);
                        txtOut.Text = currentValue.ToString();
                        break;
                    //case Operation.Equals:
                    //    Calculate(math);
                    //    break;
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

            /// <summary>
            /// When the add button is clicked, this method stores the current txtOut contents as a double in the var firstNumber, and sets the Operation enum to Add
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Double.Parse(txtOut.Text);
            math = Operation.Add;
            isNewNumber = true;
            isSecondNumber = true;
        }
        /// <summary>
        /// When the subtract button is clicked, this method stores the current txtOut contents as a double in the var firstNumber, and sets the Operation enum to Subtract
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubtract_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Double.Parse(txtOut.Text);
            math = Operation.Subtract;
            isNewNumber = true;
            isSecondNumber = true;
        }
        /// <summary>
        /// When the subtract button is clicked, this method stores the current txtOut contents as a double in the var firstNumber, and sets the Operation enum to Multiply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Double.Parse(txtOut.Text);
            math = Operation.Multiply;
            isNewNumber = true;
            isSecondNumber = true;
        }
        /// <summary>
        /// When the subtract button is clicked, this method stores the current txtOut contents as a double in the var firstNumber, and sets the Operation enum to Divide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Double.Parse(txtOut.Text);
            math = Operation.Divide;
            isNewNumber = true;
            isSecondNumber = true;

        }

        //Clear the current results
        /// <summary>
        /// When the Clear button is clicked this method sets the math enum to Start, txtOut to "0", the first and second numbers to 0, isNewNumber to true, and isSecondNumber to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            math = Operation.Start;
            txtOut.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            isNewNumber = true;
            isSecondNumber = false;
        }

        //Handle the Equals button
        /// <summary>
        /// This method determines if the user entered one or two values. The most recently entered value is stored as a double in secondNumber. If only one value exists, 'math' is set to Add. Calculate is called using the current value of 'math'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (isSecondNumber)
            {
                secondNumber = Double.Parse(txtOut.Text);
                Calculate(math);
                isSecondNumber = false;
            }
            else
            {
                firstNumber = 0;
                secondNumber = Double.Parse(txtOut.Text);
                math = Operation.Add;
                Calculate(math);
            }

        }

    }
}
