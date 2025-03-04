﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegButton_Click;
            percentageButton.Click += PerButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {

                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Sustraction:
                        result = SimpleMath.Sustraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();


            }


        }



        private void PerButton_Click(object sender, RoutedEventArgs e)
        {

            double tempNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber)) 
            {

                tempNumber = tempNumber / 100;
                if (lastNumber != 0)
                    tempNumber *= lastNumber;

                resultLabel.Content = tempNumber.ToString();


            }

        }



        private void NegButton_Click(object sender, RoutedEventArgs e) // in that evevt we need to specify the number is
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {

                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();


            }

        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";

            result = 0;
            lastNumber = 0;

        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber)) 
            {

                resultLabel.Content = "0";


            }


            if (sender == multiplicationButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                selectedOperator = SelectedOperator.Sustraction;

        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                // Do nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }


        private void NumberButton_Click(object sender, RoutedEventArgs e) // we try to reactoring old way of code 

        {
            #region old code
            //int selectedvalue = 0;
            //if(sender == zeroButton)
            //    selectedvalue = 0;
            //if (sender == oneButton)
            //    selectedvalue = 1;
            //if( sender == twoButton)
            //    selectedvalue = 2;
            //if (sender == threeButton)
            //    selectedvalue = 3;
            //if (sender == fourButton)
            //    selectedvalue = 4;
            //if (sender == FiveButton)
            //    selectedvalue = 5;
            //if (sender == sexButton)
            //    selectedvalue = 6;
            //if (sender == SevenButton)
            //    selectedvalue = 7;
            //if (sender == eightButton)
            //    selectedvalue = 8;
            //if ( sender == nineButton)
            //    selectedvalue = 9;


            //if (resultlabel.Content.ToString() == "0")
            //{
            //    resultlabel.Content = $"{selectedvalue}";

            //}

            //else {
            //    resultlabel.Content = $"{resultlabel.Content} {selectedvalue}";

            //}
            #endregion
            var buttonMapping = new Dictionary<Button, int> 
            {

                 { zeroButton, 0 }, { oneButton, 1 }, { twoButton, 2 }, { threeButton, 3 },
        { fourButton, 4 }, { fiveButton, 5 }, { sixButton, 6 }, { sevenButton, 7 },
        { eightButton, 8 }, { nineButton, 9 }
            };


            if (sender is Button ClickButton && buttonMapping.TryGetValue(ClickButton, out int selectedvalue))
            {
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedvalue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedvalue.ToString();
                }

            }
        }
    }


        public enum SelectedOperator
        {
            Addition,
            Sustraction,
            Multiplication,
            Division
        }

        public class SimpleMath
        {
            public static double Add(double n1, double n2)
            {
                return n1 + n2;
            }

            public static double Sustraction(double n1, double n2)
            {

                return n1 - n2;
            }

            public static double Multiply(double n1, double n2)
            {

                return n1 * n2;
            }

            public static double Divide(double n1, double n2)
            {

            if (n2 == 0)
            {
                MessageBox.Show("القسمة ليس لها معني", "Wrong operation", MessageBoxButton.OK,MessageBoxImage.Warning);
                return 0;

            }
                return n1 / n2;
            }

        }
    }

