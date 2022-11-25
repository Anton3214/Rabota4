using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pr
{
    public partial class Schedule : Form
    {
        DataSet data;
        SqlDataAdapter For;
        SqlCommandBuilder FF;
        //Подключение к SQL Servery
        string connectionString = @"Data Source=MSI\SQLEXPRESS; Initial Catalog=school; Integrated Security=True";
        string sql = "SELECT * FROM schedule";
        public Schedule()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                For = new SqlDataAdapter(sql, connection);

                data = new DataSet();
                For.Fill(data);
                dataGridView1.DataSource = data.Tables[0];
            }
        }
    

        private void Schedule_Load(object sender, EventArgs e)
        {

        }
        // кнопка добавления
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DataRow row = data.Tables[0].NewRow();
            data.Tables[0].Rows.Add(row);
        }
        //Обновление таблицы
        void openchild(Panel pen, Form emptyF)
        {
            emptyF.TopLevel = false;
            emptyF.FormBorderStyle = FormBorderStyle.None;
            emptyF.Dock = DockStyle.Fill;
            pen.Controls.Add(emptyF);
            emptyF.BringToFront();
            emptyF.Show();
        }
            private void button2_Click(object sender, EventArgs e)
        {
            openchild(panel1, new lessons());
        }
        //Сохранение таблицы
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                For = new SqlDataAdapter(sql, connection);
                FF = new SqlCommandBuilder(For);
                For.InsertCommand = new SqlCommand("add_schedule", connection);
                For.InsertCommand.CommandType = CommandType.StoredProcedure;
                For.InsertCommand.Parameters.Add(new SqlParameter("@id_lesson", SqlDbType.Int, 0, "id_lesson"));
                For.InsertCommand.Parameters.Add(new SqlParameter("@id_teacher", SqlDbType.VarChar, 50, "id_teacher"));
                For.InsertCommand.Parameters.Add(new SqlParameter("@when_start", SqlDbType.VarChar, 20, "when_start"));
                For.InsertCommand.Parameters.Add(new SqlParameter("@when_end", SqlDbType.VarChar, 20, "when_end"));

                For.Update(data);
            }
        }
        //Удаление выделеной строки
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
        // кнопка добавления
        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = data.Tables[0].NewRow();
            data.Tables[0].Rows.Add(row);
        }
    }
}
