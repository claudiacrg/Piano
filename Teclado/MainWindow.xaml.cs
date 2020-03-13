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

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Teclado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private WaveOut waveOut;
        private MixingSampleProvider mixer;
        public MainWindow()
        {
            InitializeComponent();

            waveOut = new WaveOut();
            mixer =
                new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(
                    44100, 1));
            mixer.ReadFully = true;
            waveOut.Init(mixer);
            waveOut.Play();

            KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.IsRepeat) return;
            if(e.Key == Key.A)
            {
                BtnC_Click(this, null);
            }
            if (e.Key == Key.W)
            {
                BtnCSostenido_Click(this, null);
            }
            if (e.Key == Key.S)
            {
                BtnD_Click(this, null);
            }
            if (e.Key == Key.E)
            {
                BtnDSostenido_Click(this, null);
            }
            if (e.Key == Key.D)
            {
                BtnE_Click(this, null);
            }
            if (e.Key == Key.F)
            {
                BtnF_Click(this, null);
            }
            if (e.Key == Key.T)
            {
                BtnFSostenido_Click(this, null);
            }
            if (e.Key == Key.G)
            {
                BtnG_Click(this, null);
            }
            if (e.Key == Key.Y)
            {
                BtnGSostenido_Click(this, null);
            }
            if (e.Key == Key.H)
            {
                BtnA_Click(this, null);
            }
            if (e.Key == Key.U)
            {
                BtnASostenido_Click(this, null);
            }
            if (e.Key == Key.J)
            {
                BtnB_Click(this, null);
            }
        }

        private ISampleProvider NotaDo()
        {
            var nota_do =
                new SignalGenerator(44100, 1)
                {
                    Gain = 0.5,
                    Frequency = 1046.502,
                    Type = SignalGeneratorType.Sin
                }.Take(TimeSpan.FromMilliseconds(250));
            return nota_do;
        }
        private SmbPitchShiftingSampleProvider DoModificado(double exponente)
        {
            var nota_do = NotaDo();
            var nota_modificada =
                new SmbPitchShiftingSampleProvider(nota_do);
            nota_modificada.PitchFactor =
                (float)Math.Pow(2.0, exponente);
            return nota_modificada;
        }
        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            var nota_do = DoModificado(1.0 / 12.0);
            mixer.AddMixerInput(nota_do);
        }

        private void BtnCSostenido_Click(object sender, RoutedEventArgs e)
        {
            var nota_doSostenido = DoModificado(2.0 / 12.0);
            mixer.AddMixerInput(nota_doSostenido);
        }

        private void BtnD_Click(object sender, RoutedEventArgs e)
        {
            var nota_re = DoModificado(3.0 / 12.0);
            mixer.AddMixerInput(nota_re);
        }

        private void BtnDSostenido_Click(object sender, RoutedEventArgs e)
        {
            var nota_reSostenido = DoModificado(4.0 / 12.0);
            mixer.AddMixerInput(nota_reSostenido);
        }

        private void BtnE_Click(object sender, RoutedEventArgs e)
        {
            var nota_mi = DoModificado(5.0 / 12.0);
            mixer.AddMixerInput(nota_mi);
        }

        private void BtnF_Click(object sender, RoutedEventArgs e)
        {
            var nota_fa = DoModificado(6.0 / 12.0);
            mixer.AddMixerInput(nota_fa);
        }

        private void BtnFSostenido_Click(object sender, RoutedEventArgs e)
        {
            var nota_faSostenido = DoModificado(7.0 / 12.0);
            mixer.AddMixerInput(nota_faSostenido);
        }

        private void BtnG_Click(object sender, RoutedEventArgs e)
        {
            var nota_sol = DoModificado(8.0 / 12.0);
            mixer.AddMixerInput(nota_sol);
        }

        private void BtnGSostenido_Click(object sender, RoutedEventArgs e)
        {
            var nota_solSostenido = DoModificado(9.0 / 12.0);
            mixer.AddMixerInput(nota_solSostenido);
        }

        private void BtnA_Click(object sender, RoutedEventArgs e)
        {
            var nota_la = DoModificado(10.0 / 12.0);
            mixer.AddMixerInput(nota_la);
        }

        private void BtnASostenido_Click(object sender, RoutedEventArgs e)
        {
            var nota_laSostenido = DoModificado(11.0 / 12.0);
            mixer.AddMixerInput(nota_laSostenido);
        }

        private void BtnB_Click(object sender, RoutedEventArgs e)
        {
            var nota_si = DoModificado(12.0 / 12.0);
            mixer.AddMixerInput(nota_si);
        }
    }
}
