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
    public partial class MainForm : Form
    {
        public BindingList<Person> list = new BindingList<Person>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            dataGridView1.DataSource = list;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindingList<Person> sortedList = new BindingList<Person>();

            foreach (Person person in list)
            {
                bool isNeed = false;

                if (textBox1.Text.Trim().Length > 0)
                {
                    if (person.firstName.Equals(textBox1.Text.Trim()))
                    {
                        isNeed = true;
                    } else
                    {
                        isNeed = false;
                        continue;
                    }
                    
                }

                if (textBox2.Text.Trim().Length > 0)
                {
                    if (person.lastNameAndFatherName.Split(' ')[0].Equals(textBox2.Text.Trim()))
                    {
                        isNeed = true;
                        
                    }
                    else
                    {
                        isNeed = false;
                        continue;
                    }

                }

                if (textBox3.Text.Trim().Length > 0)
                {
                    if (person.lastNameAndFatherName.Split(' ')[1].Equals(textBox3.Text.Trim()))
                    {
                        isNeed = true;
                    }
                    else
                    {
                        isNeed = false;
                        continue;
                    }

                }

                if (isNeed)
                {
                    sortedList.Add(person);
                }
            }
            dataGridView1.DataSource = sortedList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNewRowForm form = new AddNewRowForm(this);
            form.Show();
        }

        public void addToTable(Person person)
        {
            list.Add(person);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            list.Add(new Person(Guid.NewGuid(), "Vlad", "Karpeka Mih"));
            list.Add(new Person(Guid.NewGuid(), "Dima", "Karpeka Mih"));

            dataGridView1.DataSource = list;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
       
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            Person person = (Person)dataGridView1.Rows[selectedRowCount-1].DataBoundItem;
            PersonInfo form = new PersonInfo(person);
            form.Show();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
