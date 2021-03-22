using NUnit.Framework;
using RadioApp;
using WMPLib;

namespace RadioTests
{
    class ChannelNameTest
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


        [TestCase("BBC 1", 1)]
        [TestCase("BBC 2", 2)]
        [TestCase("BBC 3", 3)]
        [TestCase("BBC 4", 4)]
        public void GetTheChanelName(string expected, int channel)
        {

            Assert.AreEqual(expected, _radio.ChannelName(channel));

        }

    }

}
