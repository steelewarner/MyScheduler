using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScheduler
{
    public partial class DateClock : UserControl
    {
        private ToolTip t = new ToolTip();
        public DateClock()
        {
            InitializeComponent();
        }

        private void DateClock_Load(object sender, EventArgs e)
        {
            label1.Left = textBox1.Right;
            textBox2.Left = label1.Right;
            label2.Left = textBox2.Right;
            textBox3.Left = label2.Right;
            textBox4.Left = textBox3.Right + label3.Width;
            label3.Left = textBox4.Right;
            textBox5.Left = label3.Right;
        }

        private void DateClock_Resize(object sender, EventArgs e)
        {
            label1.Left = textBox1.Right;
            textBox2.Left = label1.Right;
            label2.Left = textBox2.Right;
            textBox3.Left = label2.Right;
            textBox4.Left = textBox3.Right;
            label3.Left = textBox4.Right;
            textBox5.Left = label3.Right;
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            t.Show(((Control)sender).Text, this, ((Control)sender).Location.X, ((Control)sender).Location.Y + ((Control)sender).Height, 1000);
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox3_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            t.Show(((Control)sender).Text, this, ((Control)sender).Location.X, ((Control)sender).Location.Y + ((Control)sender).Height, 1000);
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            t.Show(((Control)sender).Text, this, ((Control)sender).Location.X, ((Control)sender).Location.Y + ((Control)sender).Height, 1000);
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            t.Show(((Control)sender).Text, this, ((Control)sender).Location.X, ((Control)sender).Location.Y + ((Control)sender).Height, 1000);
        }

        private void textBox5_MouseHover(object sender, EventArgs e)
        {
            t.Show(((Control)sender).Text, this, ((Control)sender).Location.X, ((Control)sender).Location.Y + ((Control)sender).Height, 1000);
        }

        public DateTime ParseDateClock()
        {
            return new DateTime(int.Parse(textBox3.Text), int.Parse(textBox1.Text),
                int.Parse(textBox2.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text), 0);
        }
    }
}
