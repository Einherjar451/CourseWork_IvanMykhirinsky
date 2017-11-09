using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;

namespace CourseWork_IvanMykhirinsky
{
    public partial class Form2 : Form {
        private const String PATH = @"C:\dir\MykhirinskyDataBase.db";
        private SQLiteConnection connect;
        private SQLiteCommand command;

        private String namebook;
        private String author;
        private int date;
        private int price;


        public Form2() {
            InitializeComponent();
        }

        private void database_connect() {
            try {
                namebook = textBox1.Text;
                author = textBox2.Text;
                date = Convert.ToInt32(textBox3.Text);
                price = Convert.ToInt32(textBox4.Text);

                connect = new SQLiteConnection(string.Format("Data Source={0};", PATH));
                connect.Open();

                command = new SQLiteCommand("INSERT INTO books(namebook, author,datebook, price) VALUES('" + namebook + "','" + author + "'," + date + "," + price +");", connect);
                
                command.ExecuteNonQuery();
                connect.Close();

                Form2.ActiveForm.Close();

            }
            catch (System.FormatException) {
                MessageBox.Show("Пожалуйста введите корректно данные!");
            }
            catch (SQLiteException) {
                MessageBox.Show("Пожалуйста введите корректно данные!");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            database_connect();
        }
    }
}
