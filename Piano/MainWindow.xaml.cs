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
//Librerias de NAudio
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Piano
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Variables globales
        private WaveOut waveOut;
        private MixingSampleProvider mixer;

        public MainWindow()
        {
            InitializeComponent();
            waveOut = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100,1));
            mixer.ReadFully = true;
            waveOut.Init(mixer);
            waveOut.Play();

        }

        private void BtnDO_Click(object sender, RoutedEventArgs e)
        {
            var nota_do =

                new SignalGenerator(44100, 1)
                {
                    Gain = 0.5,
                    Frequency = 1046.5,
                    Type = SignalGeneratorType.Sin,


                }.Take(TimeSpan.FromMilliseconds(200));
            mixer.AddMixerInput(nota_do);
        }

        private void BtnRE_Click(object sender, RoutedEventArgs e)
        {
            var nota_re =

               new SignalGenerator(44100, 1)
               {
                   Gain = 0.5,
                   Frequency = 1174.66,
                   Type = SignalGeneratorType.Sin,


               }.Take(TimeSpan.FromMilliseconds(200));
            mixer.AddMixerInput(nota_re);
        }

        private void BtnMI_Click(object sender, RoutedEventArgs e)
        {
            var nota_mi =

               new SignalGenerator(44100, 1)
               {
                   Gain = 0.5,
                   Frequency = 1318.51,
                   Type = SignalGeneratorType.Sin,


               }.Take(TimeSpan.FromMilliseconds(200));
            mixer.AddMixerInput(nota_mi);
        }
    }
}
