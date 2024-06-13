using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Демоэкзамен
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Window
    {
        КЭ_ПоповаДEntities entities = new КЭ_ПоповаДEntities();
        public Авторизация()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Демоэкзамен.КЭ_ПоповаДDataSet кЭ_ПоповаДDataSet = ((Демоэкзамен.КЭ_ПоповаДDataSet)(this.FindResource("кЭ_ПоповаДDataSet")));
            // Загрузить данные в таблицу Users. Можно изменить этот код как требуется.
            Демоэкзамен.КЭ_ПоповаДDataSetTableAdapters.UsersTableAdapter кЭ_ПоповаДDataSetUsersTableAdapter = new Демоэкзамен.КЭ_ПоповаДDataSetTableAdapters.UsersTableAdapter();
            кЭ_ПоповаДDataSetUsersTableAdapter.Fill(кЭ_ПоповаДDataSet.Users);
            System.Windows.Data.CollectionViewSource usersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usersViewSource")));
            usersViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login="", password="";
            if (!string.IsNullOrEmpty(loginTextBox.Text))
            {
                login = loginTextBox.Text;
            }
            else MessageBox.Show("ЛОГИН НЕ ВВЕДЕН :(");
            if (!string.IsNullOrEmpty(passwordTextBox.Text))
            {
                password = passwordTextBox.Text;
            }
            else MessageBox.Show("password НЕ ВВЕДЕН :(");
            if (login !="" && password !="")
            {
          List<Users> users= entities.Users.Where(C => C.Login == login).ToList();
                if (password == users[0].Password)
                {
                    MainWindow mainWindow = new MainWindow();
                    Close();
                    mainWindow.Show();
                }
            }

          

        }
    }
}
