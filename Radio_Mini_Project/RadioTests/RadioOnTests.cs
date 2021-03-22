using NUnit.Framework;
using RadioApp;
using WMPLib;


namespace RadioTests
{
    public class RadioOnTests
    {
        private Radio _radio;
        [SetUp]
        public void Setup()
        {
            Station Bbc1 = new Station("BBC 1", "http://stream.live.vc.bbcmedia.co.uk/bbc_radio_one");
            Station Bbc2 = new Station("BBC 2", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p");
            Station Bbc3 = new Station("BBC 3", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio3_mf_p");
            Station Bbc4 = new Station("BBC 4", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio4_mf_p");

            _radio = new Radio(new WindowsMediaPlayer(), Bbc1, Bbc2, Bbc3, Bbc4);
            _radio.TurnOn();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ChangeToValidChannelTest(int newChannel)
        {
            _radio.Channel = newChannel;
            Assert.AreEqual(newChannel, _radio.Channel);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        public void ChangeToInvalidChannelTest(int newChannel)
        {
            // arrange
            _radio.Channel = 2;
            // act
            _radio.Channel = newChannel;
            // assert
            Assert.AreEqual(2, _radio.Channel);
        }
        [Test]
        public void PlayTest()
        {
            // arrange
            _radio.Channel = 4;
            // act
            var message = _radio.Play();
            // assert
            Assert.AreEqual("Playing channel 4", message);
            
        }

        [Test]
        public void TurnOffTest()
        {
            _radio.TurnOff();
            Assert.AreEqual("Radio is off", _radio.Play());
        }

        public void StopTest()
        {

            _radio.Channel = 3;
            var message = _radio.Stop();
            Assert.AreEqual("Stopped playing channel 3", message);

        }

    }
}