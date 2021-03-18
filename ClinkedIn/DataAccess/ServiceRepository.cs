using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClinkedIn.Models;
using ClinkedIn.DataAccess;

namespace ClinkedIn.DataAccess
{
    public class ServiceRepository
    {
        public List<Service> ListServices(int id)
        {
            var newMemberRepo = new MemberRepository();
            var member = newMemberRepo.GetAMember(id);
            var listOfServices = member.MemberServices;
            return listOfServices;
        }
    }
}
