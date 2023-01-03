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
    public partial class VastedTimeForm : Form
    {
        public Guid idEntityToUpdate;
        public string nameEntityToUpdate;
        public int vastedTimeEntityToUpdate;
        public DateTime createdDateEntityToUpdate;

        public VastedTimeForm()
        {
            InitializeComponent();
        }


        public void updateTable()
        {
            DataBase.findBySql("SELECT id, name, vasted_time, created_date from vasted_time", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameForSearch = textBox1.Text.Trim();
            string sql = "SELECT id, name, vasted_time, created_date from vasted_time WHERE name='" + nameForSearch +"';";
            DataBase.findBySql(sql, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewVastedTimeRow addNewVastedTimeRowForm = new AddNewVastedTimeRow(this);
            addNewVastedTimeRowForm.ShowDialog();
        }

        private void VastedTimeForm_Shown(object sender, EventArgs e)
        {
            updateTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DateTime dateTime = getDateTime(e);
                idEntityToUpdate = getRowId(e);
                nameEntityToUpdate = getNameRow(e);
                vastedTimeEntityToUpdate = getVastedTime(e);
                createdDateEntityToUpdate = getDateTime(e);
             
                UpdateEntity updateEntityForm = new UpdateEntity(this);
                updateEntityForm.ShowDialog();
            
                return;
            }

            if (e.ColumnIndex == 1)
            {
                DialogResult isNeedToDelete = MessageBox.Show("Are you want to delete student record?", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (isNeedToDelete == DialogResult.Yes)
                {   
                    DataBase.delete(getRowId(e));
                    updateTable();
                }
               
                return;
            }

        }

        private Guid getRowId(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell dataGridViewCell = dataGridViewRow.Cells[0];
            return new Guid((byte[])dataGridViewRow.Cells[2].Value);
        }

        private string getNameRow(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];
            return (string)dataGridViewRow.Cells[3].Value;
        }

        private int getVastedTime(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];
            return (int)dataGridViewRow.Cells[4].Value;
        }

        private DateTime getDateTime(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];
            return (DateTime)dataGridViewRow.Cells[5].Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
