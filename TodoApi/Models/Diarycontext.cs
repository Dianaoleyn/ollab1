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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diary>().OwnsMany(p => p.Tasks);
        }
        public IEnumerable <Diary> getDayHoliday (IEnumerable <Diary> Diary )
        {
            return Diary.Where(p => p.Holiday == true);
        }
        public IEnumerable<Diary> getTasksFirstDayofMonth (IEnumerable<Diary> Diary)
        {
            return Diary.Where(p => p.Date.StartsWith("01"));
        }
        public DbSet<Diary> Diaries { get; set; }
        
    }
}