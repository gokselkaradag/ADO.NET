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

namespace Ado.NETProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection sqlConnection = new SqlConnection("Server=G™KSEL\\SQLEXPRESS;initial catalog=DbCustomer;integrated security=true;TrustServerCertificate=Yes");

        private void btnList_Click(object sender, EventArgs e)
        {
            sqlConnection.Open(); // Veritabanı bağlantısını açar. Bu, SQL sorgularını çalıştırabilmek için gereklidir.

            SqlCommand command = new SqlCommand("Select * From TblCity", sqlConnection);
            // "TblCity" tablosundaki tüm verileri seçmek için bir SQL komutu oluşturur. 
            // Bu komut, bağlantıyı kullanarak veritabanına gönderilecek.

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            // SQL komutunu kullanarak verileri almak için bir veri adaptörü oluşturur. 
            // Veri adaptörleri, verileri doldurmak ve güncellemek için kullanılır.

            DataTable dataTable = new DataTable();
            // Verileri tutmak için bir DataTable nesnesi oluşturur. 
            // DataTable, bellekte geçici olarak veri saklamak için kullanılır.

            adapter.Fill(dataTable);
            // Veri adaptörü aracılığıyla "TblCity" tablosundan gelen verileri 
            // DataTable'a doldurur. Bu veriler daha sonra görüntülenebilir.

            dataGridView1.DataSource = dataTable;
            // DataGridView'in veri kaynağını DataTable olarak ayarlar. 
            // Bu sayede, DataTable'daki veriler DataGridView kontrolünde görüntülenir.

            sqlConnection.Close();
            // Veritabanı bağlantısını kapatır. İşlem bittikten sonra bağlantıyı kapatmak 
            // performans ve güvenlik açısından önemlidir.
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("insert into TblCity (CityName,CityCountry) values (@cityName,@cityCountry)", sqlConnection);
            // "TblCity" tablosuna yeni bir kayıt eklemek için bir SQL komutu oluşturur. 
            // Bu komut, "CityName" ve "CityCountry" sütunlarına değer eklemek üzere parametreleri kullanır.

            command.Parameters.AddWithValue("@cityName", txtCityName.Text);
            // Komuta "CityName" sütunu için bir parametre ekler. 
            // "txtCityName" adlı metin kutusundaki değeri alarak @cityName parametresine atar.

            command.Parameters.AddWithValue("@cityCountry", txtCityCountry.Text);
            // Komuta "CityCountry" sütunu için bir parametre ekler. 
            // "txtCityCountry" adlı metin kutusundaki değeri alarak @cityCountry parametresine atar.

            command.ExecuteNonQuery();
            // SQL komutunu çalıştırır. Bu komut bir "insert" işlemi olduğu için, veritabanına yeni bir kayıt ekler. 
            // ExecuteNonQuery metodu, etkilenen satır sayısını döner, ancak burada geri dönen değer kullanılmaz.
            sqlConnection.Close();
            MessageBox.Show("Şehir Başarılı Bir Şekilde Eklendi");
        }
    }
}
