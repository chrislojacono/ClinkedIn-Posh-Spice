using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ClinkedIn.DataAccess
{
    public class MemberRepository
    {
        

        const string ConnectionString = "Server=localhost;Database=ClinkedIn;Trusted_Connection=True";

        public List<Member> GetAllMembers()
        {
            using var connection = new SqlConnection(ConnectionString);

            var sql = @"select * 
                        from Members";

            var results = connection.Query<Member>(sql).ToList();
         

            return results;
            
        }

        public void AddAMember(Member member)
        {
            using var db = new SqlConnection(ConnectionString);

            var sql = @"INSERT INTO [dbo].[Members]([Name],[Sentence])
                        OUTPUT inserted.InmateId
                        VALUES(@Name,@Sentence)";
            var id = db.ExecuteScalar<int>(sql, member);

            member.InmateId = id;
        }

        public Member GetAMember(int id)
        {
            var sql = @"select *
                        from Members
                        Where Id = @Id";

            using var db = new SqlConnection(ConnectionString);

            var loaf = db.QueryFirstOrDefault<Member>(sql, new { Id = id });

            return loaf;
        }

        public void RemoveAMember(int id)
        {
            var memberToRemove = GetAMember(id);
           // _allMembers.Remove(memberToRemove);
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
