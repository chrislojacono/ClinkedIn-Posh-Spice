using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.DataAccess
{
    public class MemberRepository
    {
        static List<Member> _allMembers = new List<Member>
            {
                new Member {
                    InmateId = 1,
                    Name="Prison Mike",
                    MemberInterests = new List<Interest>
                    {
                       new Interest{ Id = 1, Interests = "Playing Spades", Type= InterestType.Gaming},
                       new Interest{ Id = 2, Interests = "Playing Solitare", Type= InterestType.Gaming},
                       new Interest{ Id = 3, Interests = "Lifting Weights", Type= InterestType.Exercise},
                    },
                    MemberServices = new List<Service>
                    {
                        new Service{ Id = 1, Services = "Cleaning blood"},
                        new Service{ Id = 2, Services = "Creating blood"},
                        new Service{ Id = 3, Services = "Starting Fight"}
                    },
                    Sentence = 420,
                },
                new Member {
                    InmateId = 2,
                    Name="Martha Stewart",
                    MemberInterests = new List<Interest>
                    {
                       new Interest{ Id = 4, Interests = "Slam Poetry", Type= InterestType.Arts},
                       new Interest{ Id = 2, Interests = "Playing Solitare", Type= InterestType.Gaming},
                       new Interest{ Id = 6, Interests = "Doing Push-ups", Type= InterestType.Exercise},
                    },
                    MemberServices = new List<Service>
                    {
                        new Service{ Id = 1, Services = "Shanking a Guard"},
                        new Service{ Id = 2, Services = "Personal Trainer"},
                        new Service{ Id = 3, Services = "Manufacturing Weapons"}
                    },
                    Sentence = 200,
                },
                new Member {
                    InmateId = 3,
                    Name="Ghosteface Killa",
                    MemberInterests = new List<Interest>
                    {
                       new Interest{ Id = 4, Interests = "Slam Poetry", Type= InterestType.Arts},
                       new Interest{ Id = 7, Interests = "Juggling Shanks", Type= InterestType.Arts},
                       new Interest{ Id = 8, Interests = "Community Puppet Shows", Type= InterestType.Arts},
                    },
                    MemberServices = new List<Service>
                    {
                        new Service{ Id = 1, Services = "Laundry"},
                        new Service{ Id = 2, Services = "Back Massage"},
                        new Service{ Id = 3, Services = "Shower Assistant"}
                    },
                    Sentence = 404,
                },
            };
        
        public List<Member> GetAllMembers()
        {
            return _allMembers;
        }

        public void AddAMember(Member member)
        {
            var biggestExistingId = _allMembers.Max(memb => memb.InmateId);
            member.InmateId = biggestExistingId + 1;
            _allMembers.Add(member);
        }
        public Member GetAMember(int id)
        {
            var member = _allMembers.FirstOrDefault(memb => memb.InmateId == id);
            return member;
        }

        public void RemoveAMember(int id)
        {
            var memberToRemove = GetAMember(id);
            _allMembers.Remove(memberToRemove);
        }

        public void AddEnemy(int inmateId, int enemyId)
        {
            var member = GetAMember(inmateId);
            var enemy = GetAMember(enemyId);
            member.Enemies.Add(enemy);      
        }

        public List<Member> GetFriends(int inmateId)
        {
            var member = GetAMember(inmateId);
            var listOfFriends = member.Friends;
            return listOfFriends;
        }
        public IEnumerable<string> GetFriendsOfFriends(int inmateId)
        {
            var listOfAllFriends = new List<string>();
            var friendsOfInmate = GetFriends(inmateId);
            foreach (var member in friendsOfInmate)
            {
                var listOfIteratingFriend = GetFriends(member.InmateId);
                foreach (var memberName in listOfIteratingFriend)
                {
                    listOfAllFriends.Add(memberName.Name);
                }
            }
            var noDuplicates = listOfAllFriends.Distinct();

            return noDuplicates;
        }
    }
}
