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
using RadioApp;
using WMPLib;

namespace RadioAppInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Radio radio;

        Station Bbc1;
        Station Bbc2;
        Station Bbc5;
        Station Bbc6;

        Station BbcBerkshire;
        Station BbcEssex;
        Station BbcCambridge;
        Station BbcCornwall;

        public MainWindow()
        {
            
             Bbc1 = new Station("BBC 1", "http://stream.live.vc.bbcmedia.co.uk/bbc_radio_one");
             Bbc2 = new Station("BBC 2", "http://stream.live.vc.bbcmedia.co.uk/bbc_radio_two");
             Bbc5 = new Station("BBC 5 Live", "http://stream.live.vc.bbcmedia.co.uk/bbc_radio_five_live");
             Bbc6 = new Station("BBC 6", "http://stream.live.vc.bbcmedia.co.uk/bbc_6music");

             BbcBerkshire = new Station("BBC Berkshire", "http://stream.live.vc.bbcmedia.co.uk/bbc_radio_berkshire");
             BbcEssex = new Station("BBC Essex", "http://stream.live.vc.bbcmedia.co.uk/bbc_radio_essex");
             BbcCambridge = new Station("BBC Cambridge", "http://stream.live.vc.bbcmedia.co.uk/bbc_radio_five_live");
             BbcCornwall = new Station("BBC Cornwall", "http://stream.live.vc.bbcmedia.co.uk/bbc_radio_cornwall");

            radio = new Radio(new WindowsMediaPlayer(), Bbc1, Bbc2, Bbc5, Bbc6);
           
            DisplayBox = new TextBox();


            Channel1Name = new Label();
            Channel2Name = new Label();
            Channel3Name = new Label();
            Channel4Name = new Label();

            InitializeComponent();


            Channel1Name.Content = radio.ChannelName(1);
            Channel2Name.Content = radio.ChannelName(2);
            Channel3Name.Content = radio.ChannelName(3);
            Channel4Name.Content = radio.ChannelName(4);

        }

        private void OnBtnClick(object sender, RoutedEventArgs e)
        {

            radio.TurnOn();
            DisplayBox.Text = "Radio is On";
        }

        private void PlayBtnClick(object sender, RoutedEventArgs e) => DisplayBox.Text = radio.Play();       

        private void OffBtnClick(object sender, RoutedEventArgs e)
        {
            radio.IsPlaying = false;
            radio.TurnOff();

        }

        private void Channel1Checked(object sender, RoutedEventArgs e) => PlayChannel(1);

        private void Channel2Checked(object sender, RoutedEventArgs e) => PlayChannel(2);

        private void Channel3Checked(object sender, RoutedEventArgs e) => PlayChannel(3);

        private void Channel4Checked(object sender, RoutedEventArgs e) => PlayChannel(4);

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => radio.Volume = (int)VolumeSlider.Value;
        
        private void StopBtnClick(object sender, RoutedEventArgs e) => DisplayBox.Text = radio.Stop();

        private void PlayChannel(int channel)
        {

            radio.Channel = channel;
            DisplayBox.Text = radio.Play();

        }

        private void SwitchToChannel1(object sender, RoutedEventArgs e)
        {

            radio.SwitchChannelSet(Bbc1, Bbc2, Bbc5, Bbc6);

            Channel1Name.Content = radio.ChannelName(1);
            Channel2Name.Content = radio.ChannelName(2);
            Channel3Name.Content = radio.ChannelName(3);
            Channel4Name.Content = radio.ChannelName(4);
            
            radio.Play();

        }

        private void SwitchToChannel2(object sender, RoutedEventArgs e)
        {

            radio.SwitchChannelSet(BbcBerkshire, BbcEssex, BbcCambridge, BbcCornwall);

            Channel1Name.Content = radio.ChannelName(1);
            Channel2Name.Content = radio.ChannelName(2);
            Channel3Name.Content = radio.ChannelName(3);
            Channel4Name.Content = radio.ChannelName(4);

            radio.Play();

        }
    }
}
