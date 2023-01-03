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
    public partial class PersonInfo : Form
    {
        private readonly Person person;
        public PersonInfo(Person person)
        {
            InitializeComponent();
            this.person = person;
        }

        private void PersonInfo_Shown(object sender, EventArgs e)
        {
            textBox1.Text = person.firstName;
            textBox2.Text = person.lastNameAndFatherName.Split(' ')[0];
            textBox3.Text = person.lastNameAndFatherName.Split(' ')[1];
        }
    }
}
