using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceMemory.Models
{
    public partial class PlayersScore
    {
        public int Pk { get; set; }
        public string PlayerName { get; set; }
        public int? PlayerScore { get; set; }
    }
}
