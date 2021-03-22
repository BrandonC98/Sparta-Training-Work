using System;
using System.Collections.Generic;
using System.Text;

namespace RadioApp
{
    public struct Station
    {

        public string Name { get; set; }
        public string URL { get; set; }

        public Station(string name, string url)
        {

            Name = name;
            URL = url;

        }

    }
}
