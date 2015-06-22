using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MyScheduler
{
    public partial class UserSetup : Form
    {
        private string _username;
        private string _firstname;
        private string _lastname;
        public string Username
        {
            get { return _username; }
        }
        public string Firstname
        {
            get { return _firstname; }
        }
        public string Lastname
        {
            get { return _lastname; }
        }

        public UserSetup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                _username = textBox1.Text;
                _firstname = textBox2.Text;
                _lastname = textBox3.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show( "Must enter a Username","Invalid Entry");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpFileDialog = new OpenFileDialog())
            {
                if (OpFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlReader reader = XmlReader.Create(OpFileDialog.FileName);

                    _username = reader.ReadElementContentAsString("Username", "User");
                    _firstname = reader.ReadElementContentAsString("Firstname", "User");
                    _lastname = reader.ReadElementContentAsString("Lastname", "User");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            
        }
    }
}
