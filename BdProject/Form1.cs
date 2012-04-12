using System;
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
            catch (LibraryDatabaseException)
            {
                textBox1.Text = "Wystąpił błąd podczas komunikacji z bazą";
            }
        }
    }
}
