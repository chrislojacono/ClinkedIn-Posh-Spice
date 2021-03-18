using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Member
    {

        public int InmateId { get; set; }
        public string Name { get; set; }
        public List<Interest> MemberInterests { get; set; } = new List<Interest>();
        public List<Service> MemberServices { get; set; } = new List<Service>();
        public List<Member> Friends { get; set; } = new List<Member>();
        public List<Member> Enemies { get; set; } = new List<Member>();
        public int Sentence { get; set; }
    }
}

