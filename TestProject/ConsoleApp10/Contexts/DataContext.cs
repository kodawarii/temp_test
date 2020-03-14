using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10.Contexts
{
    public class DataContext
    {
        // ID's
        public string uniqueID1 { get; set; }
        public string uniqueID2 { get; set; }

        // Input Trackers
        public Dictionary<string, string> addComputerDetailsTracker = new Dictionary<string, string>();
        public Dictionary<string, string> updateComputerDetailsTracker = new Dictionary<string, string>();
    }
}
