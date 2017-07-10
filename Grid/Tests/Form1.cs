using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid.Tests
{
    public partial class Form1 : Form
    {
        public event Action<string> TextEvented;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextEvented?.Invoke(textBox1.Text);
        }
    }
}
