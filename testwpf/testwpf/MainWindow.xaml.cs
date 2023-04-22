using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlConnector;

namespace testwpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;database=mydb;user id=root;password=1234;charset=utf8;Pooling=false;SslMode=None;");

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into test(username,userpass) values(@user,@pass)", conn);
                    cmd.Parameters.AddWithValue("@user", textBoxLogin.Text);
                    cmd.Parameters.AddWithValue("@pass", textBoxPassword.Text);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
