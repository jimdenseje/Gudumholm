using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.DTOs;
using Entities.Models;
using AutoMapper;

namespace Gudumholm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public MembersController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberReadDTO>>> GetMembers()
        {
            var members = await _context.Members.ToListAsync();
            var membersReadDTO = _mapper.Map<List<MemberReadDTO>>(members);
            return Ok(membersReadDTO);
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MemberReadDTO>> PostMember(MemberWriteDTO memberDTO)
        {

            //var member = _mapper.Map<Member>(memberDTO);

            if (null == memberDTO.MemberType)
            {
                if (memberDTO.MemberTypeId == null)
                {
                    return NotFound();
                }

                memberDTO.MemberType = await _context.MemberTypes.FindAsync(memberDTO.MemberTypeId);
                if (memberDTO.MemberType == null)
                {
                    return NotFound();
                }
            } else
            {
                MemberType memberType = await _context.MemberTypes.FindAsync(memberDTO.MemberTypeId);
                if (memberType != null) {
                    //memberDTO.MemberType.Name;
                }
            }

            if (null == memberDTO.Household)
            {
                if (memberDTO.HouseholdId == null)
                {
                    return NotFound();
                }

                memberDTO.Household = await _context.Households.FindAsync(memberDTO.HouseholdId);

                if (memberDTO.Household == null)
                {
                    return NotFound();
                }
            }

            Member member = new Member(memberDTO.Name, memberDTO.CPR, memberDTO.MemberType, memberDTO.Household);
            _context.Members.Add(member);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
