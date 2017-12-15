using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment5
{
    public partial class Form1 : Form
    {
        private Library library = new Library();
        private string[] s = new string[5];
        private string[] s1 = new string[5];
        private int count = 0;
        private int count1 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Title";
            label2.Enabled = true;
            textBox2.Enabled = true;
            label3.Enabled = false;
            textBox3.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Title";
            label2.Enabled = true;
            textBox2.Enabled = true;
            label3.Enabled = true;
            textBox3.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Enabled = false;
            textBox3.Enabled = false;
            label2.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                if (textBox1.Text == null)
                    MessageBox.Show("Enter Customer Name");
                else
                {
                    library.AddNewCustomer(textBox1.Text);
                }
             }
            else if(radioButton2.Checked)
            {
              if (textBox1.Text == null || textBox2.Text == null)
              MessageBox.Show("Enter Text Book Details");
              else
              {
                library.AddNewBook(textBox1.Text, textBox2.Text);
               }

            }
            else
            {
                if (radioButton3.Checked)
                {

                    if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null)
                        MessageBox.Show("Enter Text Book Details");
                    else
                    {
                        library.AddNewBook(textBox1.Text, textBox2.Text, Int32.Parse(textBox3.Text));
                    }
                }

            }

            if (radioButton1.Checked)
            { s = library.GetCustomerList();
                listBox1.Items.Add(s[count]);
                count++;
             }
            else if (radioButton2.Checked || radioButton3.Checked)
            {
                s1 = library.GetBooksList();
                listBox2.Items.Add(s1[count1]);
                count1++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            int idx2 = listBox2.SelectedIndex;

            if(idx < 0 || idx2 <0)
            MessageBox.Show("You have to select an employee and book first");
            else
            {
                bool val=library.IssueBook(idx + 1, idx2 + 101);
                if (val == false)
                    MessageBox.Show("Book Issue failed");
                else
                {
                    s1 = library.GetBooksList();
                    listBox2.Items.RemoveAt(idx2);
                    listBox2.Items.Insert(idx2, s1[idx2]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idx2 = listBox2.SelectedIndex;
            if(idx2 <0)
                MessageBox.Show("You have to select a book first");
            else
            {
                bool val = library.ReturnBook(idx2 + 101);
                if (val == false)
                    MessageBox.Show("Book Return failed");
                else
                {
                    s1 = library.GetBooksList();
                    listBox2.Items.RemoveAt(idx2);
                    listBox2.Items.Insert(idx2, s1[idx2]);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idx2 = listBox2.SelectedIndex;
            if (idx2 < 0)
                MessageBox.Show("You have to select a book first");
            else
            {
                bool val = library.RenewBook(idx2 + 101);
                if (val == false)
                    MessageBox.Show("Book Return failed");
                else
                {
                    s1 = library.GetBooksList();
                    listBox2.Items.RemoveAt(idx2);
                    listBox2.Items.Insert(idx2, s1[idx2]);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
