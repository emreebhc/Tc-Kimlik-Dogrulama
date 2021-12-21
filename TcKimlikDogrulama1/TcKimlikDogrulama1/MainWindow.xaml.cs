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

namespace TcKimlikDogrulama1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btn_Sorgula_Click(object sender, RoutedEventArgs e)
        {
            if (txt_TcKimlik.Text == "" || txt_Ad.Text == "" || txt_Soyad.Text == "" || txt_DogumYili.Text == "")
            {
                MessageBox.Show("Boş Alan Bırakılamaz !", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {   
                 bool Result =TcKimlikService();
                if(Result==true)
                    MessageBox.Show("Kayıt Doğrulandı , Bilgiler Doğru", "Tebrikler", MessageBoxButton.OK);
                else
                    MessageBox.Show("Kayıt Bulunamadı", "Hata", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


        private bool TcKimlikService()
        {
            bool value = false;

            try
            {
                TcDogrulamaService.KPSPublic service = new TcDogrulamaService.KPSPublic();
                value = service.TCKimlikNoDogrula(long.Parse(txt_TcKimlik.Text), txt_Ad.Text.ToUpper(), txt_Soyad.Text.ToUpper(), int.Parse(txt_DogumYili.Text));
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata");
            }
           
            return value;
        }
    }
}
