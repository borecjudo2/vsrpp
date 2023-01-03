using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddNewVastedTimeRow : Form
    {
        private readonly VastedTimeForm vastedTimeForm;
        public AddNewVastedTimeRow(VastedTimeForm vastedTimeForm)
        {
            InitializeComponent();
            this.vastedTimeForm = vastedTimeForm;
        }

        private void clearInputs()
        {
            textBox1.Text = textBox2.Text = string.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length < 1)
            {
                MessageBox.Show("Name is empty!");
                return;
            }

            if (textBox2.Text.Trim().Length < 1)
            {
                MessageBox.Show("Vasted time is empty!");
                return;
            }

            VastedTimeEntity entity = new VastedTimeEntity(Guid.NewGuid(), textBox1.Text.Trim(), int.Parse(textBox2.Text.Trim()), DateTime.Now);
            DataBase.save(entity);
            clearInputs();
            vastedTimeForm.updateTable();
            Close();
        }
    }
}
