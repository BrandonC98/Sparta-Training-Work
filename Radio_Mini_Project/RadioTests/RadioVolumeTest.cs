using NUnit.Framework;
using RadioApp;
using WMPLib;

namespace RadioTests
{
    class RadioVolumeTest
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
        }

        [Test]
        public void VolumeDefualtValueIs50()
        {

            Assert.AreEqual(50, _radio.Volume);

        }

        [TestCase(40, 40)]
        [TestCase(100, 101)]
        [TestCase(100, 100)]
        [TestCase(0, 0)]
        [TestCase(0, -1)]
        public void SetTheVolume(int expected, int volumeValue)
        {

            _radio.Volume = volumeValue;
            Assert.AreEqual(expected, _radio.Volume);

        }

    }
}
