using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using At_First.Properties;
using At_First.Repository;
using At_First.Services;

namespace At_First
{
    public partial class Main_Form : Form
    {
        IContact_Repository repository;
        public Main_Form() 
        {
            InitializeComponent();
            repository = new Contact_Repository();
        }
        private void Restart()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = repository.SelectAll();
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {
            Restart();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            AddOrEdit frm = new AddOrEdit();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                Restart();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                AddOrEdit frm = new AddOrEdit();
                int ID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frm.ContactID = ID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Restart();
                }
            }
            else
            {
                MessageBox.Show("لطفا فیلد مورد نظر را انتخاب نمایید!", "راهنمایی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string full_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show($"آیا از حذف کلاینت ( {full_name} ) اطمینان دارید؟","سوال",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int ID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    bool isSucess = repository.Delete(ID);
                    if (isSucess)
                    {
                        Restart();
                        MessageBox.Show($"کلاینت ({full_name}) با موفقیت حذف شد!","موفقیت",MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        MessageBox.Show("عملیات با شکست مواجه شد!","ارور",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفا ردیف مورد نظر را انتخاب نمایید!","اطلاع رسانی",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void srchFull_Name_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.SearchFull_Name(srchFull_Name.Text);
        }

        private void srchIntroduce_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.SearchIntroduce(srchIntroduce.Text);
        }

        private void srchService_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.SearchService(srchService.Text);
        }

        private void srchDescription_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.SearchDescription(srchDescription.Text);
        }

        private void schMobile_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.SearchMobile(srchMobile.Text);
        }

        private void srchDate_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.SearchDate(srchDate.Value);
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.SearchCode(txtCode.Text);
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    dataGridView1.DataSource = repository.SearchFull_Name(txtExist.Text);
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.CurrentRow != null)
        //    {
        //        Show show = new Show();
        //        show.contactid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        //        show.Show();
        //    }
        //    else { MessageBox.Show("لطفا فیلد مورد نظر را انتخاب نمایید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //}
    }
}
