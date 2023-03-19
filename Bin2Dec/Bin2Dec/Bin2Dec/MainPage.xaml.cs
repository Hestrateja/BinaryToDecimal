using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bin2Dec
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        bool IsValidBinary(string number)
        {
            int length = number.Length;
            if (length == 0)
                return false;
            for (int i = 0; i < length; i++)
            {
                if (number[i] != '0' && number[i] != '1')
                    return false;
            }
            return true;
        }
        int BinaryToDec(string binary)
        {
            int result = 0;
            int counter = 0;
            for (int i = binary.Length-1; i >= 0; i--)
            {
                if (binary[i] == '1')
                    result += (int)Math.Pow(2, counter); 
                counter++;
            }
            return result;
        }
        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var oldText = e.OldTextValue;
            var newText = e.NewTextValue;

            if (newText == "")
            {
                Instructions.TextColor = Color.Black;
                decText.Text = "";
                return;
            }
            else
            { 
                if (IsValidBinary(newText))
                {
                    Instructions.Text = "Your number is valid";
                    Instructions.TextColor = Color.Green;
                    decText.Text = BinaryToDec(newText).ToString();
                }
                else
                {
                    Instructions.Text = "Please enter a valid binary number";
                    Instructions.TextColor = Color.Red;
                    decText.Text = "ERROR";
                }
            }
        }
    }
}
