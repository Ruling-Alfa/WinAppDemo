using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWindowsApplication
{
    public partial class Form1 : Form
    {
        private bool isNew = true;
        DBConnect context = null;
        public Form1()
        {
            context = new DBConnect();
            InitializeComponent();
        }

        //load form
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPhoneComboBox();
        }

        private void LoadPhoneComboBox()
        {
            List<Person> data = context.SelectAll();
            comboBoxPhone.DataSource = data;
            comboBoxPhone.DisplayMember = "Phone";
            comboBoxPhone.ValueMember = "Id";
            comboBoxPhone.SelectedIndex = -1;
        }


        //Close application
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        //select data
        private void btnFetchData_Click(object sender, EventArgs e)
        {
            if (comboBoxPhone.SelectedIndex > -1)
            {
                isNew = false;
                Person p = context.Select(Convert.ToInt32(comboBoxPhone.SelectedValue));
                txtBoxAge.Text = p.Age.ToString();
                txtBoxName.Text = p.Name;
                txtBoxPhone.Text = p.Phone.ToString();
            }
            else
            {
                isNew = true;
            }
        }

        //insert or update data
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtBoxName.Text;
            int age;
            if (!Int32.TryParse(txtBoxAge.Text, out age))
            {
                age = -1;
            }
            double phone;
            if (!Double.TryParse(txtBoxPhone.Text, out phone))
            {
                MessageBox.Show("Enter a proper phone number");
                return;
            }
            int id;
           
            if (isNew)
            {
                context.Insert(name, age, phone);
            }
            else
            {
                if (!Int32.TryParse(comboBoxPhone.SelectedValue.ToString(), out id))
                {
                    id = -1;
                }
                context.Update(name, age, phone,id);
            }
            resetAllInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAllInputs();
        }

        private void resetAllInputs()
        {
            isNew = true;
            txtBoxAge.Text = null;
            txtBoxName.Text = null;
            txtBoxPhone.Text = null;
            comboBoxPhone.SelectedIndex = -1;
        }
    }
}
