using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace AdressBook_Inlämningsuppgift_1
{
    public partial class FormOne : Form
    {

        string myPath = @"C:\Users\46704\Desktop\AdressBook\AdressInformation.txt";

        public FormOne()
        {

            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            using (StreamWriter sw = new StreamWriter(myPath, true))
            {
                sw.WriteLine(textBoxName.Text + ", " + textBoxLastname.Text + ", " + textBoxAdress.Text + ", " + textBoxPostNumber.Text + ", " +
                textBoxCity.Text + ", " + textBoxNumber.Text + ", " + textBoxMail.Text);

                
                MessageBox.Show("Information added!");
                
            }
            

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            string toString = listBoxOne.SelectedItem.ToString();           

            var update = File.ReadAllText(myPath);
            File.WriteAllText(myPath, update.Replace(toString, textBoxName.Text + ", " + textBoxLastname.Text + ", " + textBoxAdress.Text + ", " + textBoxPostNumber.Text + ", " +
            textBoxCity.Text + ", " + textBoxNumber.Text + ", " + textBoxMail.Text));

            
            listBoxOne.Items.Remove(listBoxOne.SelectedItem);
            listBoxOne.Items.Add(textBoxName.Text + ", " + textBoxLastname.Text + ", " + textBoxAdress.Text + ", " + textBoxPostNumber.Text + ", " +
            textBoxCity.Text + ", " + textBoxNumber.Text + ", " + textBoxMail.Text);
            
            

            MessageBox.Show("Updated sucess!");
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            listBoxOne.Items.Clear();

            List<string> lines = File.ReadAllLines(myPath).ToList();

            foreach (string line in lines)
            {
                listBoxOne.Items.Add(line);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
             
                       
            string change = listBoxOne.SelectedItem.ToString();
            string delete = File.ReadAllText(myPath);           
            File.WriteAllText(myPath, delete.Replace(change, null));


            foreach (string s in listBoxOne.SelectedItems.OfType<string>().ToList())
            listBoxOne.Items.Remove(s);

            MessageBox.Show("Selected adresses deleted!");

        }
      
            
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBoxTwo.Items.Clear();

            string[] lines = File.ReadAllLines(myPath);
            string toFind = textBoxFind.Text;

            if (textBoxFind.Text == "") listBoxTwo.Items.Clear();

            else
            {
                foreach (string s in lines)
                {
                    if (s.Contains(toFind)) listBoxTwo.Items.Add(s);
                }
            }
            
        }

        private void buttonShowInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listBoxTwo.SelectedItem.ToString());
        }
    }               
}
