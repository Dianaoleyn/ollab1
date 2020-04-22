using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiariesController : ControllerBase
    {
        private readonly Diarycontext _context;

        public DiariesController(Diarycontext context)
        {
            _context = context;
        }
      
        // GET: api/Diaries
        [HttpGet ("holidays")]
        [Authorize]
        public IEnumerable<Diary> getDay()
        {
            return _context.getDayHoliday(_context.Diaries);
        }

        // GET: api/Diaries
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Diary>>> GetDiaries()
        {
            return await _context.Diaries.ToListAsync();
     
        }

        // GET: api/Diaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diary>> GetDiary(long id)
        {
            var diary = await _context.Diaries.FindAsync(id);

            if (diary == null)
            {
                return NotFound();
            }

            return diary;
        }

        // PUT: api/Diaries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutDiary(long id, Diary diary)
        {
            if (id != diary.Id)
            {
                return BadRequest();
            }

            _context.Entry(diary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaryExists(id))
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

        // POST: api/Diaries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Diary>> PostDiary(Diary diary)
        {
            _context.Diaries.Add(diary);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDiary), new { id = diary.Id }, diary);
        }
       
    
   

        // DELETE: api/Diaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Diary>> DeleteDiary(long id)
        {
            var diary = await _context.Diaries.FindAsync(id);
            if (diary == null)
            {
                return NotFound();
            }

            _context.Diaries.Remove(diary);
            await _context.SaveChangesAsync();

            return diary;
        }

        private bool DiaryExists(long id)
        {
            return _context.Diaries.Any(e => e.Id == id);
        }
    }
}
