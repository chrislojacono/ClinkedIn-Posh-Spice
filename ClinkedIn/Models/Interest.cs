using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Interests { get; set; }
        public InterestType Type { get; set; }
        
    }

    public enum InterestType
    {
        Cooking,
        Writing,
        Adventure,
        Gardening,
        Violence,
        Exercise,
        Gaming,
        Arts
    }
}
