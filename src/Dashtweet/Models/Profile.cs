using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashtweet.Models
{
    /* The concept of profiles is due to data mining analytics: to get any useful information from 
     * large amounts of data, that data needs to be based on known homogeneous characteristics. 
     * The Profile class should have properties corresponding to this demand, so that every 
     * profile Id corresponds to a set of comparable data. */

    public class Profile
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }

        public string[] Tracks { get; private set; }

        public Profile(string[] tracks)
        {
            Tracks = tracks;
        }
    }
}
