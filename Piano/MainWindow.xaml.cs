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
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
            mixer.ReadFully = true;
            waveOut.Init(mixer);
            waveOut.Play();

            KeyDown += MainWindow_KeyDown;

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {//
            if (e.IsRepeat) return;

            if(e.Key == Key.Z)
            {
                BtnDO_Click(this,null);
            }
            if (e.Key == Key.X)
            {
                BtnDoS_Click(this, null);
            }
            if (e.Key == Key.C)
            {
                BtnRE_Click(this,null);
            }
            if (e.Key == Key.V)
            {
                BtnReS_Click(this, null);
            }
            if (e.Key == Key.B)
            {
                BtnMI_Click(this, null);
            }
            if (e.Key == Key.N)
            {
                BtnFA_Click(this, null);
            }
            if (e.Key == Key.M)
            {
                BtnFaS_Click(this, null);
            }
            if (e.Key == Key.G)
            {
                BtnSOL_Click(this, null);
            }
            if (e.Key == Key.H)
            {
               BtnSolS_Click(this, null);
            }
            if (e.Key == Key.J)
            {
                BtnLA_Click(this, null);
            }
            if (e.Key == Key.K)
            {
                BtnLaS_Click(this, null);
            }
            if (e.Key == Key.L)
            {
                BtnSI_Click(this, null);
            }
        }

        private void BtnDO_Click(object sender, RoutedEventArgs e)
        {
            var nota_Do =

                new SignalGenerator(44100, 1)
                {
                    Gain = 0.5,
                    Frequency = 1046.502,
                    Type = SignalGeneratorType.Sin,


                }.Take(TimeSpan.FromMilliseconds(200));
            mixer.AddMixerInput(nota_Do);
        }
        private void BtnDoS_Click(object sender, RoutedEventArgs e)
        {
            var nota_doSos = DoModificado(1.0 / 12);
            mixer.AddMixerInput(nota_doSos);
        }
        private void BtnRE_Click(object sender, RoutedEventArgs e)
        {           
            var nota_re = DoModificado(2.0 / 12.0);
            mixer.AddMixerInput(nota_re);

        }
        private void BtnReS_Click(object sender, RoutedEventArgs e)
        {
            var nota_reSos = DoModificado(3.0 / 12.0);
            mixer.AddMixerInput(nota_reSos);
        }
        private void BtnMI_Click(object sender, RoutedEventArgs e)
        {
            var nota_mi = DoModificado(4.0 / 12.0);
            mixer.AddMixerInput(nota_mi);
        }

        private void BtnFA_Click(object sender, RoutedEventArgs e)
        {
            var nota_fa = DoModificado(5.0 / 12.0);
            mixer.AddMixerInput(nota_fa);
        }
        private void BtnFaS_Click(object sender, RoutedEventArgs e)
        {
            var nota_faSos = DoModificado(6.0 / 12.0);
            mixer.AddMixerInput(nota_faSos);
        }
        private void BtnSOL_Click(object sender, RoutedEventArgs e)
        {
            var nota_faSos = DoModificado(7.0 / 12.0);
            mixer.AddMixerInput(nota_faSos);
        }
        private void BtnSolS_Click(object sender, RoutedEventArgs e)
        {
            var nota_faSos = DoModificado(8.0 / 12.0);
            mixer.AddMixerInput(nota_faSos);
        }
        private void BtnLA_Click(object sender, RoutedEventArgs e)
        {
            var nota_faSos = DoModificado(9.0 / 12.0);
            mixer.AddMixerInput(nota_faSos);
        }
        private void BtnLaS_Click(object sender, RoutedEventArgs e)
        {
            var nota_faSos = DoModificado(10.0 / 12.0);
            mixer.AddMixerInput(nota_faSos);
        }
        private void BtnSI_Click(object sender, RoutedEventArgs e)
        {

            var nota_faSos = DoModificado(11.0 / 12.0);
            mixer.AddMixerInput(nota_faSos);
        }

        //NOTA DO
        private ISampleProvider NotaDo()
        {
            var nota_do = new SignalGenerator(44100, 1)
            {
                Gain = 0.5,
                Frequency = 1046.502,
                Type = SignalGeneratorType.Sin,
            }.Take(TimeSpan.FromMilliseconds(200));

            return nota_do;
        }

        private SmbPitchShiftingSampleProvider DoModificado(double exponente)
        {
            var nota_do = NotaDo();
            var nota_modificada = new SmbPitchShiftingSampleProvider(nota_do);
            nota_modificada.PitchFactor = (float)Math.Pow(2.0, exponente);
            return nota_modificada;
        }

        
    }
}

