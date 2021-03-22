using WMPLib;
using System.Collections.Generic;

namespace RadioApp
{
    public class Radio
    {

        public WindowsMediaPlayer Player { get; set; }

        private Dictionary<int, Station> _stations = new Dictionary<int, Station>();

        private int _channel;
        private bool _on;
        public bool IsPlaying { get; set; }

        public int Channel
        {
            get { return _channel; }
            set {

                if (value < 1 || value > 4) return;
                
                if (!_on) _channel = 1;
                else _channel = value;
            }
        }

        public int Volume
        {
            get { return Player.settings.volume; }
            set { Player.settings.volume = value; }
        }

        public Radio(WindowsMediaPlayer player, params Station[] stations)
        {

            Player = player;
            _on = false;
            IsPlaying = false;
            Channel = 1;
            Volume = 50;

            for(int i = 1; i < 5; i++)
            {

                _stations.Add(i, stations[i - 1]);

            }


        }

        public string ChannelName(int channel) => _stations[channel].Name;

        public void SwitchChannelSet(params Station[] stations)
        {

            _stations.Clear();

            for (int i = 1; i < 5; i++)
            {

                _stations.Add(i, stations[i - 1]);

            }

        }


        public string Play()
        {
            if (_on)
            {
                IsPlaying = true;
                Player.URL = _stations[Channel].URL;
                
                Player.controls.play();
                return $"Playing channel {Channel}";
            }
            else return $"Radio is off";
        }

        public string Stop()
        {

            if (_on && IsPlaying)
            {

                Player.controls.stop();
                IsPlaying = false;
                return $"Stopped playing channel {Channel}";

            }
            else return "Radio is off";

        }

        public void TurnOff()
        {

            if(_on)
            {

                Player.controls.stop();
                _on = false;

            }


        }

        public void TurnOn() => _on = true;      

    }
    // implement a class Radio that corresponds to the Class diagram 
    //   and specification in the Radio_Mini_Project document
}