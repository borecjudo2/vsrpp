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
    public partial class UpdateEntity : Form
    {
        private readonly VastedTimeForm timeForm;

        public UpdateEntity(VastedTimeForm timeForm)
        {
            InitializeComponent();
            this.timeForm = timeForm;
        }

        private void UpdateEntity_Load(object sender, EventArgs e)
        {

        }

        private void UpdateEntity_Shown(object sender, EventArgs e)
        {
            textBox1.Text = timeForm.nameEntityToUpdate;
            textBox2.Text = timeForm.vastedTimeEntityToUpdate.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VastedTimeEntity entityToUpdate = new VastedTimeEntity(timeForm.idEntityToUpdate, timeForm.nameEntityToUpdate, timeForm.vastedTimeEntityToUpdate, timeForm.createdDateEntityToUpdate);
            entityToUpdate.name = textBox1.Text.Trim();
            entityToUpdate.vastedTime = int.Parse(textBox2.Text.Trim());
            DataBase.update(entityToUpdate);
            timeForm.updateTable();
            Close();
        }
    }
}
