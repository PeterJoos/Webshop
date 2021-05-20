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
using WPLClassLibTeam02.Entity;
using WPLClassLibTeam02.Tools;

namespace WpfWebshopTeam02
{
    /// <summary>
    /// Interaction logic for WpfInsertData.xaml
    /// </summary>
    public partial class WpfInsertData : Window
    {
        public WpfInsertData()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            Product product = new Product();
            var result = product.Read();
            DgdProductData.ItemsSource = result.DataTable.DefaultView;

        }
        private void BtnReadFile_Click(object sender, RoutedEventArgs e)
        {
            FileResult result = FileHelper.OpenFile();

            if (result.Succeeded)
            {
                ProductHelper.CreateProducts(result.CsvObjectRows);
            }

            LoadData();
        }

       

       
    }
}
