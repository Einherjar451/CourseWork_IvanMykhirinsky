
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;

namespace CourseWork_IvanMykhirinsky {

    public partial class Form1 : Form {
        private const String PATH = @"C:\dir\MykhirinskyDataBase.db";
        private SQLiteConnection connect;
        private SQLiteDataReader reader;
        private SQLiteCommand command;

        private String namebook;
        private List<String> all_namebook;
        private String selectedBook;
        private String testedBook;


        public Form1() {
            InitializeComponent();
            databseConn();
        }

        private void databseConn() {
            try {
                connect = new SQLiteConnection(string.Format("Data Source={0};", PATH));
                connect.Open();

                command = new SQLiteCommand("select namebook from books;", connect);
                reader = command.ExecuteReader();

                all_namebook = new List<String>();

                all_namebook.Clear();
                foreach (DbDataRecord record in reader) {
                    namebook = record["namebook"].ToString();
                
                    all_namebook.Add(namebook);
                }
                comboBox1.Items.Clear();
                foreach (String s in all_namebook) {
                    comboBox1.Items.Add(s);
                }

            } catch(SQLiteException) {
                MessageBox.Show("Ошибка выбирете книгу!");
            }
        }
        
        private void button1_Click(object sender, EventArgs e) {
            selectedBook = comboBox1.Text;

            if (selectedBook.Equals("")) {
                MessageBox.Show("Выбирете книгу для покупки!");
                return;
            }
            MessageBox.Show("Приобретено!");
        }

        private void button3_Click(object sender, EventArgs e){
            databseConn();
        }

        private void button2_Click(object sender, EventArgs e) {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
