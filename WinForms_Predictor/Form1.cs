using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Learning_C_WinForms_Predictor
{
    public partial class Form1 : Form
    {
        const string APP_NAME = "ULTIMATE_PREDICTOR";
        readonly string PREDICTIONS_CONFIG_PATH = $"{Environment.CurrentDirectory}\\predictionsConfig.json";
        private string[] _predictions;
        private Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private async void bPredict_Click(object sender, EventArgs e)
        {
            bPredict.Enabled = false;

            await Task.Run(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    this.Invoke(new Action(() =>
                    {
                        UpdateProgressBar(i);
                        this.Text = $"{APP_NAME} - {i}%";
                    }));
                    Thread.Sleep(5);
                }
            });

            var index = _random.Next(_predictions.Length);

            var prediction = _predictions[index];

            MessageBox.Show($"{prediction} !!!");

            progressBar1.Value = 0;
            this.Text = APP_NAME;
            bPredict.Enabled = true;
        }

        private void UpdateProgressBar(int i)
        {
            // To get around the progressive animation, we need to move the
            // progress bar backwards.
            if (i == progressBar1.Maximum)
            {
                // Special case as value can't be set greater than Maximum.
                progressBar1.Maximum = i + 1;   // Temporarily Increase Maximum
                progressBar1.Value = i + 1;     // Move past
                progressBar1.Maximum = i;       // Reset maximum
            }
            else
            {
                progressBar1.Value = i + 1;     // Move past
            }

            progressBar1.Value = i;             // Move to correct value
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = APP_NAME;

            try
            {
                var data = File.ReadAllText(PREDICTIONS_CONFIG_PATH);
                _predictions = JsonConvert.DeserializeObject<string[]>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_predictions == null)
                {
                    Close();
                }
                else if (_predictions.Length == 0)
                {
                    MessageBox.Show("Предсказания закончились, кина не будет! =)");
                    Close();
                }
            }
        }
    }
}
