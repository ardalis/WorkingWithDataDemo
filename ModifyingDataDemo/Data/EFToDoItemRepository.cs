using ModifyingDataDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModifyingDataDemo.Models;

namespace ModifyingDataDemo.Data
{
    public class EFToDoItemRepository : IToDoItemRepository
    {
        private readonly ApplicationDbContext _db;
        public EFToDoItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ToDoItem item)
        {
            _db.ToDoItems.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ToDoItem>> ListAsync()
        {
            return await _db.ToDoItems.ToListAsync();
        }
    }
}
