using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPLClassLibTeam02;
using WPLClassLibTeam02.Data;
using WPLClassLibTeam02.Entity;

namespace WpfWebshopTeam02
{
    /// <summary>
    /// Interaction logic for WPFTestData.xaml
    /// </summary>
    public partial class WPFTestData : Window
    {
        public WPFTestData()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Data//EntityData
            DgdTestData.ItemsSource = EntityData.TestData.Get().DefaultView;
        }


        private TestData GetTestData()
        {
            TestData testData = new TestData();
            testData.Tekst = TxtTekst.Text;
            testData.Datum = DtmDatum.SelectedDate.GetValueOrDefault();
            int getal = 0;
            int.TryParse(TxtGetal.Text, out getal);
            testData.Getal = getal;
            return testData;
        }


        private void BtnCommand_Click(object sender, RoutedEventArgs e)
        {
            EntityData.TestData.Insert(GetTestData());
        }


        private void DgdTestData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgdTestData.SelectedIndex > -1)
            {
                var row = (DataRowView)DgdTestData.SelectedItem;
                var id = row["testdataid"].ToString();
                MessageBox.Show(id);
                UpdateForm(id);
            }
        }


        private void UpdateForm(string id)
        {
            foreach (DataRow row in EntityData.TestData.Get().Rows)
            {
                if (row["testdataid"].ToString() == id)
                {
                    LblId.Content = id;
                    TxtGetal.Text = row["getal"].ToString();
                    TxtTekst.Text = row["tekst"].ToString();
                    DateTime dtm = DateTime.Now;
                    if (DateTime.TryParse(row["datum"].ToString(), out dtm))
                    {
                        DtmDatum.SelectedDate = dtm;
                    }
                    BtnUpdate.Visibility = Visibility.Visible;
                    break;
                }
            }
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            if (int.TryParse(LblId.Content.ToString(), out id))
            {
                EntityData.TestData.Update(GetTestData(), id);
                DgdTestData.ItemsSource = EntityData.TestData.Get().DefaultView;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
