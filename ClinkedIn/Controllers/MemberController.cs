using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.DataAccess;
using ClinkedIn.Models;


namespace ClinkedIn.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        
        MemberRepository _memberRepo;
        public MemberController()
        {
            _memberRepo = new MemberRepository();
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            return Ok(_memberRepo.GetAllMembers());
        }
        [HttpPost]
        public IActionResult AddANewMember(Member member)
        {
            _memberRepo.AddAMember(member);
            return Created($"api/Members/{member.InmateId}", member);
        }

        // api/Members/{inmateId}
        [HttpGet("{inmateId}")]
        public IActionResult GetASingleMember(int inmateId)
        {
            return Ok(_memberRepo.GetAMember(inmateId));
        }

        //Add A Friend
        [HttpPut("{id}/friends/add/{friendId}")]
        public IActionResult AddFriend(int id, int friendId)
        {
            var clinker = _memberRepo.GetAMember(id);
            var friend = _memberRepo.GetAMember(friendId);
            clinker.Friends.Add(friend);
            return Ok($"You have added {friend.Name} as a friend");
        }

        //Get friends of a member
        [HttpGet("{id}/friends")]
        public IActionResult GetFriends(int id)
        {
            var clinker = _memberRepo.GetAMember(id);
            if (clinker == null) return NotFound($"There is no clinker with an id of: {id}");
            if (clinker.Friends.Count == 0) return NotFound($"{clinker.Name} has no friends... What a loser!");
            return Ok(clinker.Friends);
        }

        //PUT enemies
        [HttpPut("{inmateId}/enemies/add/{enemyId}")]
        public IActionResult AddEnemy(int inmateId, int enemyId)
        {
            var member = _memberRepo.GetAMember(inmateId);
            _memberRepo.AddEnemy(inmateId, enemyId);
            return Ok(member.Enemies);
        }

        // GET enemies
        [HttpGet("{inmateId}/enemies")]
        public IActionResult GetEnemies(int inmateId)
        {
            var member = _memberRepo.GetAMember(inmateId);
            if (member == null)
            {
                return NotFound("Not found");
            }
            else if (member.Enemies.Count == 0)
            {
                return NotFound("Not found");
            }
            return Ok(member.Enemies);
        }
        
        // GET all Friends of Friends
        [HttpGet("getAllFriends/{id}")]
        public IActionResult GetAllFriends(int id)
        {
           var friendsOfFriends = _memberRepo.GetFriendsOfFriends(id);
           return Ok(friendsOfFriends);
        }

        //Get Days Remaining on Sentence
        [HttpGet("{id}/sentence")]
        public IActionResult GetRemainingDays(int id)
        {
            var clinker = _memberRepo.GetAMember(id);
            return Ok($"Sentence: {clinker.Sentence} day(s) left");
        }
    }
}