using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class Diarycontext : DbContext
    {

        public Diarycontext(DbContextOptions<Diarycontext> options)
            : base(options)
        {

        }
        public IEnumerable <Diary> getDayHoliday (IEnumerable <Diary> Diary )
        {
            return Diary.Where(p => p.Holiday == true);
        }
        public DbSet<Diary> Diaries { get; set; }
        
    }
}