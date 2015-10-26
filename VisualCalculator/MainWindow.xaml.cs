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
        bool haveFirstNumber = false;
        bool haveSecondNumber = false;
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
            if (math == Operation.Multiply && (firstNumber == 0 || secondNumber == 0))
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
                        txtOut.Text = currentValue.ToString();
                        break;
                    case Operation.Start:
                        txtOut.Text = "0";
                        firstNumber = 0;
                        secondNumber = 0;
                        isNewNumber = true;
                        haveFirstNumber = false;
                        haveSecondNumber = false;
                        break;
                    default:
                        txtOut.Text = "burp!";
                        break;

                }
            }

        }

        // 4 event handlers for operations:

        /// <summary>
        /// Stores the currently-displayed double. If two user-selected doubles are stored, the previous math operation is performed upon those two doubles. The result is stored in var firstNumber, and the math operation enum is changed to Add.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!haveFirstNumber)
            {
                firstNumber = Double.Parse(txtOut.Text);
                haveFirstNumber = true;
                isNewNumber = true;
                math = Operation.Add;
            }
            else
            {
                secondNumber = Double.Parse(txtOut.Text);
                Calculate(math);
                txtOut.Text = currentValue.ToString();
                firstNumber = currentValue;
                secondNumber = 0;
                haveSecondNumber = false;
                isNewNumber = true;
                math = Operation.Add;
            }

        }
        /// <summary>
        /// Stores the currently-displayed double. If two user-selected doubles are stored, the previous math operation is performed upon those two doubles. The result is stored in var firstNumber, and the math operation enum is changed to Subtract.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubtract_Click(object sender, RoutedEventArgs e)
        {
            if (!haveFirstNumber)
            {
                firstNumber = Double.Parse(txtOut.Text);
                haveFirstNumber = true;
                isNewNumber = true;
                math = Operation.Subtract;
            }
            else
            {
                secondNumber = Double.Parse(txtOut.Text);
                Calculate(math);
                txtOut.Text = currentValue.ToString();
                firstNumber = currentValue;
                secondNumber = 0;
                haveSecondNumber = false;
                isNewNumber = true;
                math = Operation.Subtract;
            }
        }
        /// <summary>
        /// Stores the currently-displayed double. If two user-selected doubles are stored, the previous math operation is performed upon those two doubles. The result is stored in var firstNumber, and the math operation enum is changed to Multiply.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (!haveFirstNumber)
            {
                firstNumber = Double.Parse(txtOut.Text);
                haveFirstNumber = true;
                isNewNumber = true;
                math = Operation.Multiply;
            }
            else
            {
                secondNumber = Double.Parse(txtOut.Text);
                Calculate(math);
                txtOut.Text = currentValue.ToString();
                firstNumber = currentValue;
                secondNumber = 0;
                haveSecondNumber = false;
                isNewNumber = true;
                math = Operation.Multiply;
            }
        }
        /// <summary>
        /// Stores the currently-displayed double. If two user-selected doubles are stored, the previous math operation is performed upon those two doubles. The result is stored in var firstNumber, and the math operation enum is changed to Divide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            if (!haveFirstNumber)
            {
                firstNumber = Double.Parse(txtOut.Text);
                haveFirstNumber = true;
                isNewNumber = true;
                math = Operation.Divide;
            }
            else
            {
                secondNumber = Double.Parse(txtOut.Text);
                Calculate(math);
                txtOut.Text = currentValue.ToString();
                firstNumber = currentValue;
                secondNumber = 0;
                haveSecondNumber = false;
                isNewNumber = true;
                math = Operation.Divide;
            }
        }

        //Clear the current results
        /// <summary>
        /// When the Clear button is clicked this method sets the math enum to Start, txtOut to "0", the first and second numbers to 0, isNewNumber to true, and haveSecondNumber to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            math = Operation.Start;
            Calculate(math);
        }

        //Handle the Equals button
        /// <summary>
        /// If there is no stored value, this method stores the displayed value in var firstNumber. If there is a previously stored value, this method stores the displayed value in var secondNumber. The most recently called operation is performed upon the two stored values. The result is both displayed and stored in var firstNumber
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (!haveFirstNumber)
            {
                firstNumber = Double.Parse(txtOut.Text);
                txtOut.Text = firstNumber.ToString();
            }
            else
            {
                secondNumber = Double.Parse(txtOut.Text);
                Calculate(math);
                Calculate(Operation.Equals);
                isNewNumber = true;
                haveFirstNumber = true;
                haveSecondNumber = false;
                secondNumber = 0;
                math = Operation.Start;
            }


        }

    }
}
