using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prog_1103_HW3_Calc
{
    public partial class Calculator : Form
    {
        double result;
        decimal memstore = 0;
        private string currentCalculation = "";
        decimal endres;

        public Calculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A button click function that takes input whenever a user clicks a 
        /// button on the calculator application. It also displays that
        /// user input to the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// Contains a reference to the object which raised the event.
        /// <param name="e"></param>
        /// Contains event data.
        private void button_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;
            this.Display.Text = currentCalculation;
        }

        /// <summary>
        /// This method calculates & displays the user inputs. One to a basic textbox
        /// & the final calculation result to the rich textbox for better readability
        /// and overall appearence. Added a try catch function as well.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            string calculation = this.currentCalculation.ToString().Replace("X", "*").ToString().Replace("&divide;", "/");

            try
            {
                this.CalcrichTextBox.Text = new DataTable().Compute(calculation, null).ToString();
            }
            catch (Exception)
            {
                this.Display.Text = "0";
                this.currentCalculation = "";
            }
        }

        /// <summary>
        /// This method clears both textboxes and clears the "currentCalculation" string.
        /// So that the user can enter new calculations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.Display.Text = string.Empty;
            this.CalcrichTextBox.Text = string.Empty;
            this.currentCalculation = string.Empty;
        }

        /// <summary>
        /// This function Performs a back click function. Removing the last digit
        /// the user gave. I've also included a try/catch function that will display an error message 
        /// when the user clicks back when there are no more integers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Backbutton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Display.Text = this.Display.Text.Remove(this.Display.Text.Length - 1);
            }

            catch (Exception E)
            {
                this.Display.BackColor = Color.Red;
                this.Display.Text = "Error: length < 0";
                this.DisplayBox.Text = string.Empty;
            }
            this.Display.BackColor = Color.White;
            this.DisplayBox.Text = string.Empty;

        }

        /// <summary>
        /// This function uses the Math class to calculate the square root of a value given.
        /// Added a try catch function to display an error when the user inputs a wrong value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SquareRootbutton_Click(object sender, EventArgs e)
        {
            try
            {
                result = Math.Sqrt(Convert.ToDouble(this.currentCalculation));
                this.CalcrichTextBox.Text = result.ToString();
            }
            catch(Exception E)
            {
                this.CalcrichTextBox.Text = "ERROR invalid input given!";
                this.Display.Text = String.Empty;
                return;
            }
            
        }

        /// <summary>
        /// Memory clear button function.
        /// This function will set "memstore" value to zero and will
        /// clear the "Calc.richTextBox" rich textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemoryClearbutton_onclick(object sender, EventArgs e)
        {
            memstore = 0;
            this.CalcrichTextBox.Text = string.Empty;
            return;
        }

        /// <summary>
        /// This function recalls the stored memory & displays
        /// the value to the results textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemoeyRecallbutton_onclick(Object sender, EventArgs e)
        {
            if (memstore <= 0)
            {
                this.CalcrichTextBox.Text = "Error: Memory empty";
            }
            else
            {
                this.CalcrichTextBox.Text = this.memstore.ToString();
                return;
            }
        }

        /// <summary>
        /// This function stores the memory value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemoryStore_onclick(Object sender, EventArgs e)
        {
            try
            {
                
                memstore = decimal.Parse(this.CalcrichTextBox.Text);
                this.Display.Text = String.Empty;
                this.CalcrichTextBox.Text = "Value stored successfully";
            }
            catch(Exception E)
            {
                this.CalcrichTextBox.Text = "ERROR Mem value < 0";
                return;            
            }

        }

        /// <summary>
        /// This functtion adds to the memory stored value with the endres value
        /// which equates to the value matched with the richtextbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemoryAdd_onclick(Object sender, EventArgs e)
        {
            try
            {
                endres = Convert.ToDecimal(this.CalcrichTextBox.Text);
                decimal Memory = memstore += endres;
                this.CalcrichTextBox.Text = memstore.ToString();
                return;
            }
            catch (Exception E)
            {
                this.CalcrichTextBox.Text = "ERROR";
            }
            this.CalcrichTextBox.Text = String.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Reciprocalbutton_Click(object sender, EventArgs e)
        {
            try
            {
                result = 1 / Convert.ToDouble(this.Display.Text);
                this.CalcrichTextBox.Text = result.ToString();
            }
            catch( Exception E)
            {
                this.Display.Text = String.Empty;
                this.CalcrichTextBox.Text = "ERROR: Invalid / No input given!";
            }
        }
    }
}
