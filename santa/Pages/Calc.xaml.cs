﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace santa.Pages
{
    /// <summary>
    /// Логика взаимодействия для Calc.xaml
    /// </summary>
    public partial class Calc : Page
    {
        string leftop = ""; 
        string operation = ""; 
        string rightop = ""; 

        public Calc()
        {
            InitializeComponent();
           
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
           
            textBlock.Text += s;
            int num;
            
            bool result = Int32.TryParse(s, out num);
      
            if (result == true)
            {
                if (operation == "")
                {
                    leftop += s;
                }
                else
                {
                    rightop += s;
                }
            }
            
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                }
                // Очищаем поле и переменные
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }

                else if (s == "x2")
                {

                    textBlock.Text = Math.Pow(Int32.Parse(leftop), 2).ToString();

                }

                else if (s == "10x")
                {

                    textBlock.Text = Math.Pow(10, Int32.Parse(leftop)).ToString();

                }
               
                else if (s == "√x")
                {

                    textBlock.Text = Math.Sqrt(Int32.Parse(leftop)).ToString();

                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }
        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);
            
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
       
            var uri = new Uri("DictionaryCalc.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
           
            Application.Current.Resources.Clear();

            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}

