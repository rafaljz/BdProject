using System;
using System.Data.Common;
using System.Windows.Forms;

namespace BdProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var database = new LibraryDatabaseConnection())
                {
                    textBox1.Text = database.ExecuteTestCommand();
                }
            }
            catch (DbException ex)
            {
                var message = string.Format(
                    "Wystąpił błąd podczas komunikacji z bazą. Typ wyjątku: {0}. Komunikat: {1}", 
                    ex.GetType().Name,
                    ex.Message);
                textBox1.Text = message;
            }
        }
    }
}
