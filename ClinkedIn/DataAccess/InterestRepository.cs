using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.DataAccess
{
    public class InterestRepository
    {
        static List<Interest> _interests = new List<Interest>
        {
            new Interest() { Id = 1, Interests = "Baking Cookies", Type = InterestType.Cooking },
            new Interest() { Id = 2, Interests = "Writing childrens books", Type = InterestType.Writing },
            new Interest() { Id = 3, Interests = "Hot air ballooning", Type = InterestType.Adventure },
            new Interest() { Id = 4, Interests = "Having Picnics", Type = InterestType.Adventure },
            new Interest() { Id = 5, Interests = "Working in the garden", Type = InterestType.Gardening },
            new Interest() { Id = 6, Interests = "Scrapbooking", Type = InterestType.Writing },
            new Interest() { Id = 7, Interests = "Knitting", Type = InterestType.Adventure },
            new Interest() { Id = 8, Interests = "Frisbee golf", Type = InterestType.Adventure },
            new Interest() { Id = 9, Interests = "Mass murder", Type = InterestType.Violence },
            new Interest() { Id = 10, Interests = "Stabbing things", Type = InterestType.Violence }
        };

        public List<Interest> GetAll()
        {
            return _interests;
        }

        public void Add (Interest interest)
        {
            var newIdNumber = _interests.Max(l => l.Id);
            interest.Id = newIdNumber + 1;
            _interests.Add(interest);
        }

        public Interest GetInterestById(int id)
        {
            var interest = _interests.FirstOrDefault(interest => interest.Id == id);
            return interest;
        }

        public IEnumerable<Interest> GetInterestByType(InterestType type)
        {
            var interestByType = _interests.Where(interestType => interestType.Type == type);
            return interestByType;
        }

        public void Remove(int id)
        {
            var interestToRemove = GetInterestById(id);
        }

        //This funtion takes in a string of the specific interest and return only the names of the inmates that enjoy that interest
        public List<String> GetMemberByInterest(string interest)
        {
            var newInstance = new MemberRepository();
            var listOfMembers = newInstance.GetAllMembers();
            var membersWithInterest = new List<string>();
            foreach (var member in listOfMembers)
            {
                foreach (var item in member.MemberInterests)
                {
                    if (item.Interests == interest)
                    {
                        membersWithInterest.Add(member.Name);
                    }
                }
            }
            return membersWithInterest;
        }
         
        //This method takes in an enum InterestType and returns the full member Object 
        public IEnumerable<Member> GetMemberByInterest(InterestType interest)
        {
            var newInstance = new MemberRepository();
            var listOfMembers = newInstance.GetAllMembers();
            var membersWithInterest = new List<Member>();
            foreach (var member in listOfMembers)
            {
                foreach (var item in member.MemberInterests)
                {
                    if (item.Type == interest)
                    {
                        membersWithInterest.Add(member);
                    }
                }
            }
            var distinctValues = membersWithInterest.Distinct();
            return distinctValues;
        }
    }
}
