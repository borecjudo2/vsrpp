using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp0
{
    public partial class AddNewRowForm : Form
    {
        private readonly MainForm mainForm;
        public AddNewRowForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person person = new Person(Guid.NewGuid(), textBox1.Text.Trim(), textBox2.Text.Trim() + " " + textBox3.Text.Trim());
            mainForm.addToTable(person);
            Close();
        }
    }
}
