using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{

    public partial class Form1 : Form
    {

        // Create a Random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();

        // These integer variables store the numbers 
        // for the addition problem. 
        int addend1;
        int addend2;

        // These integer variables store the numbers 
        // for the subtraction problem. 
        int subend1;
        int subend2;

        // These integer variables store the numbers 
        // for the multiplication problem. 
        int mulend1;
        int mulend2;

        // These integer variables store the numbers 
        // for the division problem. 
        int divend1;
        int divend2;

        // This integer variable keeps track of the 
        // remaining time.
        int timeLeft;   


        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer.
        /// </summary>
        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Fill in the subtraction problem.
            subend1 = randomizer.Next(1, 101);
            subend2 = randomizer.Next(1, subend1);

            minusLeftLabel.Text = subend1.ToString();
            minusRightLabel.Text = subend2.ToString();

            difference.Value = 0;

            // Fill in the multiplication problem.
            mulend1 = randomizer.Next(2, 11);
            mulend2 = randomizer.Next(2, 11);

            timesLeftLabel.Text = mulend1.ToString();
            timesRightLabel.Text = mulend2.ToString();

            product.Value = 0;

            // Fill in the division problem.
            divend1 = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            divend2 = divend1 * temporaryQuotient;

            dividedLeftLabel.Text = divend2.ToString();
            dividedRightLabel.Text = divend1.ToString();

            quotient.Value = 0;

            timeLabel.BackColor = Color.White;
            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {                           
                if (timeLeft < 6)
                {
                    timeLabel.BackColor = Color.Red;
                }
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = subend1 - subend2;
                product.Value = mulend1 * mulend2;
                quotient.Value = divend1 / divend2;
                startButton.Enabled = true;
                
            }
        }

        /// <summary>
        /// Check the answer to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise.</returns>
        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value && subend1 - subend2 == difference.Value
                && mulend1 * mulend2 == product.Value && divend2 / divend1 == quotient.Value)
                return true;
            else
                return false;
        }


        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
