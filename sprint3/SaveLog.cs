using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSE3902_CSE3902_Project
{
    /// <summary>
    /// Container for your save game data.
    /// Put the variables you need here, as long as it's serializable.
    /// </summary>
    [Serializable]
    public class SaveLog
    {
        public int p1Wins;
        public int p2Wins;
        public List<String> log;
    }
}
