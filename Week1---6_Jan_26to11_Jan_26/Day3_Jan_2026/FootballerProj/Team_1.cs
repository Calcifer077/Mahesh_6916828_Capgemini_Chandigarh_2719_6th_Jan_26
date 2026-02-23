using System;
using System.Collections.Generic;
using System.Text;

namespace FootballerProj
{
    internal abstract class Team_1
    {
        public abstract string name { get; }
        public abstract string country { get; }
        public abstract string type { get; }

        public abstract string colorCode { get; }
        
        public abstract int totalPlayers { get; }
        public abstract string[] tournaments { get; }

    }
}
