using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Zdoom_Wrapper.Properties;

namespace Zdoom_Wrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String gameType = "host";
        String zdoomDir = "Null";
        String numPlayers = "1";
        String episode = "1";
        String mission = "1";
        String hostname = "Null";

        private void Form1_Load(object sender, EventArgs e)
        {
            zdoomDir = Settings.Default.Path;
            textBox2.Text = zdoomDir;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            openFileDialog1.Title = "Select zdoom.exe";
            openFileDialog1.Filter = "zdoom.exe|*.exe";
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.SafeFileName == "zdoom.exe")
            {
                zdoomDir = openFileDialog1.FileName;
                textBox2.Text = zdoomDir;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (gameType == "host")
                {
                    Process.Start(zdoomDir, "-" + gameType + " " + numPlayers + " " + "-warp " + episode + " " + mission);
                }else
                {
                    Process.Start(zdoomDir, "-" + gameType + " " + hostname);
                }
                
            }
            catch
            {
                MessageBox.Show("Please select zdoom.exe");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox2.Hide();
                groupBox1.Show();
                gameType = "join";
            }
            if (radioButton2.Checked)
            {
                groupBox1.Hide();
                groupBox2.Show();
                gameType = "host";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox2.Hide();
                groupBox1.Show();
                gameType = "join";
            }
            if (radioButton2.Checked)
            {
                groupBox1.Hide();
                groupBox2.Show();
                gameType = "host";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numPlayers = numericUpDown1.Value.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            episode = numericUpDown2.Value.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            mission = numericUpDown3.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hostname = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            zdoomDir = textBox2.Text;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Path = zdoomDir;
            Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown2.Maximum = 32;
            } else
            {
                numericUpDown2.Maximum = 9;
            }
        }
    }
}
