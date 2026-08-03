using System;
using System.Data.SqlClient;
using System.Data;


namespace At_First.Repository
{
    interface IContact_Repository
    {
        DataTable SelectRow(int ID);
        DataTable SelectAll();


        //میتونی یکار جالب بکنی اینه که تاریخ روز تولد رو از روز اومدن کلاینت کم کنی:‌ سن رو محاسبه کنی و توی یک فیلد نشون بدی: 
        
        bool Insert(string Code,string Full_Name, string Mobile, string Service, string Description, string Job, DateTime Date_Born, string Gender, string How_To_Introduce, int Payment, string Discount, int Debit,int All_Payment, int Counter, DateTime Date_Coming, string Address,DateTime Next_Day);
        bool Delete(int ID);
        bool Edit(int ID,string Code, string Full_Name, string Mobile, string Service, string Description, string Job, DateTime Date_Born, string Gender, string How_To_Introduce, int Payment, string Discount, int Debit,int All_Payment, int Counter, DateTime Date_Coming, string Address, DateTime Next_Day);
        
        DataTable SearchFull_Name(string Text); 
        DataTable SearchMobile(string Text); 
        DataTable SearchIntroduce(string Text); 
        DataTable SearchService(string Text); 
        DataTable SearchDescription(string Text);
        DataTable SearchDate(DateTime Text);
        DataTable SearchCode(string Text);



        //bool ExistFull_Name(string Full_Name);
        //DataTable Show(string Full_Name);
    }
}
