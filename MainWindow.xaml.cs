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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Демоэкзамен
{
    public class PageList

    {
        public int CountInPage = 15;
    public List<Material> Materials { get; set; }

        public List<Material> OffsetMaterials => Materials.Skip(CurrentPage * CountInPage).Take(CountInPage).ToList();

        public int CurrentPage { get; set; } = 0;
        public bool IsFirstPage => CurrentPage != 0;
        public bool IsLastPage => Materials.Count - ((CurrentPage + 2) * CountInPage) > -CountInPage;

    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PageList list = new PageList();
        КЭ_ПоповаДEntities entities = new КЭ_ПоповаДEntities();
        public MainWindow()
        {
            
            InitializeComponent();
            list.Materials=entities.Material.ToList();
            dataGrid.ItemsSource = list.OffsetMaterials;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Демоэкзамен.КЭ_ПоповаДDataSet кЭ_ПоповаДDataSet = ((Демоэкзамен.КЭ_ПоповаДDataSet)(this.FindResource("кЭ_ПоповаДDataSet")));
            // Загрузить данные в таблицу Material. Можно изменить этот код как требуется.
            Демоэкзамен.КЭ_ПоповаДDataSetTableAdapters.MaterialTableAdapter кЭ_ПоповаДDataSetMaterialTableAdapter = new Демоэкзамен.КЭ_ПоповаДDataSetTableAdapters.MaterialTableAdapter();
            кЭ_ПоповаДDataSetMaterialTableAdapter.Fill(кЭ_ПоповаДDataSet.Material);
            System.Windows.Data.CollectionViewSource materialViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("materialViewSource")));
            materialViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entities.SaveChanges();
            }
            catch
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            list.CurrentPage++;
            dataGrid.ItemsSource = list.OffsetMaterials;
            naz.IsEnabled = list.IsFirstPage;
            vpe.IsEnabled = list.IsLastPage;
            counInPage.Text = (list.CurrentPage + 1).ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            list.CurrentPage--;
            dataGrid.ItemsSource = list.OffsetMaterials;
            naz.IsEnabled = list.IsFirstPage;
            vpe.IsEnabled = list.IsLastPage;
            counInPage.Text = (list.CurrentPage + 1).ToString();
        }
    }
}
