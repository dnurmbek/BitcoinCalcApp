using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitcoinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btcGetRates_Click(object sender, EventArgs e)
        {
            if(currencyCombo.SelectedItem.ToString()== "EUR")
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                BitcoinRates bitcoin = GetRates();
                float result = Int32.Parse(amountTextBox.Text) * bitcoin.bpi.EUR.rate_float;
                resultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.EUR.code}";
            }
            if (currencyCombo.SelectedItem.ToString() == "USD")
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                BitcoinRates bitcoin = GetRates();
                float result = Int32.Parse(amountTextBox.Text) * bitcoin.bpi.USD.rate_float;
                resultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.USD.code}";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public static BitcoinRates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            BitcoinRates bitcoin;
            using(var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitcoinRates>(response);

            }

            return bitcoin;
        }
    }
}
