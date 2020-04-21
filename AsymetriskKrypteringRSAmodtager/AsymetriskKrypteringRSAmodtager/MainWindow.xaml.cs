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

namespace AsymetriskKrypteringRSAmodtager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            //opret og indsæt public/private key (public key indsættes)
            var rsa = new RSAWithXMLKey();
            rsa.UpdateRsaKeys();

            Textbox_Exponent.Text = BitConverter.ToString(rsa.GetExponent());
            Textbox_Modulus.Text = BitConverter.ToString(rsa.GetModulus());

            //indsæt private rsaParametre i tekstbokse
            SetPrivateData();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void CipherBytes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Decrypt_Click(object sender, RoutedEventArgs e)
        {
            var rsa = new RSAWithXMLKey();

            // Converter hex string til byte array, decrypter og udskriv det decrypterede tekst
            byte[] texttodecrypt = Textbox_Cipherbytes.Text.Split('-').Select(item => Convert.ToByte(item, 16)).ToArray();
            Textbox_Decryptedtext.Text = rsa.DecryptfromXml(texttodecrypt);
        }

        private void Button_Generate_Keys_Click(object sender, RoutedEventArgs e)
        {

            var rsa = new RSAWithXMLKey();
            // updater modulus/exponent og udskriv dem som en hexidecimal teksttreng
            rsa.UpdateRsaKeys();

            Textbox_Modulus.Text = BitConverter.ToString(rsa.GetModulus());
            Textbox_Exponent.Text = BitConverter.ToString(rsa.GetExponent());
        }

        private void D_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DP_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DQ_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void InverseQ_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void P_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Q_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SetPrivateData()
        {
            var rsa = new RSAWithXMLKey();

            // hent alt private data og udskriv dem som hexidecimale tekststrenge
            D.Text = BitConverter.ToString(rsa.GetPrivateData_D());
            DP.Text = BitConverter.ToString(rsa.GetPrivateData_Dp());
            DQ.Text = BitConverter.ToString(rsa.GetPrivateData_Dq());
            InverseQ.Text = BitConverter.ToString(rsa.GetPrivateData_InverseQ());
            P.Text = BitConverter.ToString(rsa.GetPrivateData_P());
            Q.Text = BitConverter.ToString(rsa.GetPrivateData_Q());
        }
    }
}
