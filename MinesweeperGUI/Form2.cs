using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form2 : Form
    {
        public static Stopwatch watch = new Stopwatch();
        public Button[,] btnGrid = new Button[8, 8];
        Random random = new Random();
        int score = 0;
        int scoreBonus1 = 1000;
        int scoreBonus2 = 500;
        int scoreBonus3 = 200;

        public Form2()
        {
            InitializeComponent();
            populateGrid();
        }

        public void populateGrid()
        {
            // this function will fill the panel1 control with buttons
            int buttonSize = panel1.Width / 10; // calculate the width
            panel1.Height = panel1.Width; // set the grid to be square

            // nested loop: Create buttons and place in the Panel
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    btnGrid[r, c] = new Button();

                    // make each button square
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].Click += Grid_Button_Click; // Add the same click event to each button
                    panel1.Controls.Add(btnGrid[r, c]); // place the button on the panel
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c); // position in x,y
                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            // set the label 4 to print out the score
            label4.Text = score.ToString();

            // making a set of random based on the difficulty
            int easy = random.Next(1, 10);
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    btnGrid[r, c] = new Button();
                    btnGrid[r, c] = sender as Button;

                    if (easy == 1 || easy == 4)
                    {
                        btnGrid[r, c].Text = "1";
                        btnGrid[r, c].ForeColor = System.Drawing.Color.BlueViolet;
                        score += 100;
                    }

                    if (easy == 2 || easy == 5)
                    {
                        btnGrid[r, c].Text = "2";
                        btnGrid[r, c].ForeColor = System.Drawing.Color.BlueViolet;
                        score += 100;
                    }
                    if (easy == 3 || easy == 6)
                    {
                        btnGrid[r, c].Text = "3";
                        btnGrid[r, c].ForeColor = System.Drawing.Color.BlueViolet;
                        score += 100;
                    }
                    if (easy == 7 || easy == 8)
                    {
                        btnGrid[r, c].Text = "~";
                        btnGrid[r, c].ForeColor = System.Drawing.Color.BlueViolet;
                        score += 200;
                    }
                    if (easy == 9)
                    {
                        int sum1 = score + scoreBonus1;
                        int sum2 = score + scoreBonus2;
                        int sum3 = score + scoreBonus3;

                        btnGrid[r, c].Text = "BOMB";
                        btnGrid[r, c].ForeColor = System.Drawing.Color.Red;
                        /*
                        MessageBox.Show("Too bad, better luck next time!", "Game Over");
                        // stop the watch
                        watch.Stop();
                        if(watch.ElapsedMilliseconds >= 500)
                        {
                            MessageBox.Show("Your current score: " + score 
                                + "\nTimer bonus: +" + scoreBonus1 + "\nTotal Score: " + sum1 
                                + "\nPlaytime: " + watch.ElapsedMilliseconds + " seconds", "Highest score");
                        }
                        else if(watch.ElapsedMilliseconds >= 1000)
                        {
                            MessageBox.Show("Your current score: " + score
                                + "\nTimer bonus: +" + scoreBonus1 + "\nTotal Score: " + sum2 
                                + "\nPlaytime: " + watch.ElapsedMilliseconds + " seconds", "Highest score");
                        }
                        else
                        {
                            MessageBox.Show("Your current score: " + score
                                + "\nTimer bonus: +" + scoreBonus1 + "\nTotal Score: " + sum3
                                + "\nPlaytime: " + watch.ElapsedMilliseconds + " seconds", "Highest score");
                        }
                        */
                        Form3 f3 = new Form3(score, watch.ElapsedMilliseconds);
                        f3.Show();
                        break;
                    }
                }
            }
            // set the image of clicked button to something different
            // Bitmap b = new Bitmap(@"C: \Users\Su Khoi\source\repos\MinesweeperGUI\MinesweeperGUI\Properties\one.png");
        }

        // add a timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = watch.Elapsed.ToString();
        }

        // start the watch
        private void Form2_Load(object sender, EventArgs e)
        {
            watch.Start();
        }
    }
}
