using NUnit.Framework;
using RadioApp;
using WMPLib;

namespace RadioTests
{
    public class RadioOffTests
    {
        private Radio _radio;
        [SetUp]
        public void Setup()
        {
            Station Bbc1 = new Station("BBC 1", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p");
            Station Bbc2 = new Station("BBC 2", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p");
            Station Bbc3 = new Station("BBC 3", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio3_mf_p");
            Station Bbc4 = new Station("BBC 4", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio4_mf_p");

            _radio = new Radio(new WindowsMediaPlayer(), Bbc1, Bbc2, Bbc3, Bbc4);
            _radio.TurnOff();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ChangeToValidChannelWhenOffTest(int newChannel)
        {
            _radio.Channel = newChannel;
            Assert.AreEqual(1, _radio.Channel);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        public void ChangeToInvalidChannelWhenOffTest(int newChannel)
        {
            // act
            _radio.Channel = newChannel;
            // assert
            Assert.AreEqual(1, _radio.Channel);
        }
        [Test]
        public void PlayTest()
        {
            // act
            var message = _radio.Play();
            // assert
            Assert.AreEqual("Radio is off", message);        
        }

        [Test]
        public void TurnOnTest()
        {
            _radio.TurnOn();
            Assert.AreEqual("Playing channel 1", _radio.Play());
        }

        [Test]
        public void StopTest()
        {
            
            var message = _radio.Stop();
            
            Assert.AreEqual("Radio is off", message);
        }

    }
}