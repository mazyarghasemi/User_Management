using System;
using System.Windows.Forms;
using System.Data;

using At_First.Repository;
using At_First.Services;
using System.Drawing.Printing;

namespace At_First
{
    public partial class AddOrEdit : Form
    {
        
        IContact_Repository repository;

        public int ContactID = 0;

        public AddOrEdit()
        {
            InitializeComponent();
            repository = new Contact_Repository();
        }
        private void AddOrEdit_Load(object sender, EventArgs e)
        {
            if (ContactID == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "اصلاح اطلاعات کاربر ";
                DataTable data = repository.SelectRow(ContactID);
                txtCode.Text = data.Rows[0][16].ToString();
                txtAll_Payment.Value = int.Parse(data.Rows[0][15].ToString());
                txtFull_Name.Text = data.Rows[0][1].ToString();
                txtMobile.Text = data.Rows[0][2].ToString();
                txtService.Text = data.Rows[0][3].ToString();
                txtDescription.Text = data.Rows[0][4].ToString();
                txtJob.Text = data.Rows[0][5].ToString();
                txtDate_Born.Value = Convert.ToDateTime(data.Rows[0][6]);
                txtGender.Text = data.Rows[0][7].ToString();
                txtHow_To_Introduce.Text = data.Rows[0][8].ToString();
                txtPayment.Value = int.Parse(data.Rows[0][9].ToString());
                txtDiscount.Text = data.Rows[0][10].ToString();
                txtDebit.Value = int.Parse(data.Rows[0][11].ToString());
                txtCounter.Value = int.Parse(data.Rows[0][12].ToString());
                txtDate_Coming.Value = Convert.ToDateTime(data.Rows[0][13]);
                txtAddress.Text = data.Rows[0][14].ToString();
                btnsubmit.Text = "ویرایش";
            }
        }

        bool IsValid()
        {
            if (txtFull_Name.Text == "")
            {
                MessageBox.Show("لطفا نام و نام خانوادگی کلاینت را وارد کنید!", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (txtCode.Text == "") { MessageBox.Show("لطفا شماره پرونده را وارد کنید", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            if (txtMobile.Text == "") { MessageBox.Show("لطفا شماره موبایل را وارد کنید!", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtService.Text == "") { MessageBox.Show("لطفا نوی سرویس خدماتی رو مشخص کنید!", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtDescription.Text == "") { MessageBox.Show("لطفا قسمت توضیحات به نوبه خود پر کنید! ", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtJob.Text == "") { MessageBox.Show("فیلد شفل را تکمیل کنید.", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtDate_Born.Value == txtDate_Born.MinDate) { MessageBox.Show("لطفا تاریخ تولد کلاینت را با دقت وارد کنید!", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtGender.Text == "") { MessageBox.Show("جنسیت را مشخص کنید!", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtHow_To_Introduce.Text == "") { MessageBox.Show("لطفا قسمت معرفی را تکمیل کنید !", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtPayment.Value == 0) { MessageBox.Show("هزینه سرویس را وارد کنید!", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtAll_Payment.Value == 0) { MessageBox.Show("لطفا هزینه پرداختی را وارد کنید", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtCounter.Value == 0) { MessageBox.Show("تعداد دفعات مراجعه کلاینت را وارد کنید!", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (txtDate_Coming.Value == txtDate_Coming.MinDate) { MessageBox.Show("لطفا تاریخ مراجعه کلاینت را وارد کنید!", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            return true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isSuccess;

            if (!IsValid()) return;

            //if (repository.ExistFull_Name(txtFull_Name.Text))
            //{
            //    MessageBox.Show("فیلد نام و نام خانوادگی تکراری است","هشدار",MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (ContactID == 0)
            {
                isSuccess = repository.Insert(txtCode.Text, txtFull_Name.Text, txtMobile.Text, txtService.Text, txtDescription.Text, txtJob.Text, txtDate_Born.Value, txtGender.Text, txtHow_To_Introduce.Text, (int)txtPayment.Value, txtDiscount.Text, (int)txtDebit.Value, (int)txtAll_Payment.Value, (int)txtCounter.Value, txtDate_Coming.Value, txtAddress.Text);
            }
            else
            {
                isSuccess = repository.Edit(ContactID, txtCode.Text, txtFull_Name.Text, txtMobile.Text, txtService.Text, txtDescription.Text, txtJob.Text, txtDate_Born.Value, txtGender.Text, txtHow_To_Introduce.Text, (int)txtPayment.Value, txtDiscount.Text, (int)txtDebit.Value, (int)txtAll_Payment.Value, (int)txtCounter.Value, txtDate_Coming.Value, txtAddress.Text);
            }
            if (isSuccess)
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show("عملیات با موفقیت انجام شد!", "موفقیت", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("عملیات با شکست مواجه شد !", "شکست", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
