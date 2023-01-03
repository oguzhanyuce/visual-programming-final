using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace visualprogrammingfinalemlak.Forms
{

    public partial class PropertyOwnerForm : Form
    {
        public PropertyOwnerForm()
        {
            InitializeComponent();
        }

        Classes.PERSON person = new Classes.PERSON();

        private void PropertyOwnerForm_Load(object sender, EventArgs e)
        {

            LoadDatagridviewOwners();

            //satıcıların sayısını göster
            displayOwnersCount();
        }

        // YENİ  SATICI EKLE
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int id = 0;
            string fname = textBoxFName.Text;
            string lname = textBoxLName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddres.Text;

            person = new Classes.PERSON(id, fname, lname, phone, email, address);

            if (verifTextBoxes())
            {

                if (person.insertPerson("property_owner", person))
                {
                    MessageBox.Show("Yeni Satıcı Eklendi", "Satıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatagridviewOwners();
                    displayOwnersCount();
                }
                else
                {
                    MessageBox.Show("Satıcı Eklenemedi", "Satıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Satıcı Ad Soyad Telefon Giriniz", "Satıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool verifTextBoxes()
        {
            string fname = textBoxFName.Text.Trim();
            string lname = textBoxLName.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            if (fname.Equals("") || lname.Equals("") || phone.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

        }

        public void LoadDatagridviewOwners()
        {
            

            dataGridViewOwners.DataSource = person.getAllPersons("property_owner");
        }

        public void displayOwnersCount()
        {
            person = new Classes.PERSON();
            string ownersCount = person.getAllPersons("property_owner").Rows.Count.ToString();
            labelCount.Text = ownersCount + "Satıcı(lar)";
        }
        private void dataGridViewOwners_Click(object sender, EventArgs e)
        {

            textBoxID.Text = dataGridViewOwners.CurrentRow.Cells[0].Value.ToString();
            textBoxFName.Text = dataGridViewOwners.CurrentRow.Cells[1].Value.ToString();
            textBoxLName.Text = dataGridViewOwners.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridViewOwners.CurrentRow.Cells[3].Value.ToString();
            textBoxEmail.Text = dataGridViewOwners.CurrentRow.Cells[4].Value.ToString();
            textBoxAddres.Text = dataGridViewOwners.CurrentRow.Cells[5].Value.ToString();

        }

        
    }
}