using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form3 : Form
    {
        int highestScore;
        long timeElapsed;
        public Form3(int score, long time)
        {
            highestScore = score;
            timeElapsed = time;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string difficulty = textBox3.Text;
            string folder = @"C:\Users\Su Khoi\source\repos\MinesweeperGUI\MinesweeperGUI";
            // Filename  
            string fileName = "PlayerStats.txt";
            // Fullpath
            string fullPath = folder + fileName;
            // array of strings  
            string[] info = {"First Name:" + firstName, "Last Name: " + lastName,
                "Difficulty: " + difficulty, "Time Elapsed: " + timeElapsed.ToString() + " miliseconds",
                "Highest score: " + highestScore.ToString() + " pts"};
            // Write array of strings to a file using WriteAllLines.    
            File.WriteAllLines(fullPath, info);
            MessageBox.Show("File saved successfully!");
        }
    }
}
