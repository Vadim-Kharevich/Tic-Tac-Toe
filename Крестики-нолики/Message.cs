using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Крестики_нолики
{
    public partial class Message : Form
    {
        public Message(string message)
        {
            InitializeComponent();
            this.message = message;
        }
        string message;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Message_Load(object sender, EventArgs e)
        {
            label1.Text = message;
        }

        private void Message_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}
