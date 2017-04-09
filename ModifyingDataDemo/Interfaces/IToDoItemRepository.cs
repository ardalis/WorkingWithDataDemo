using ModifyingDataDemo.Data.Migrations;
using ModifyingDataDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModifyingDataDemo.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<List<ToDoItem>> ListAsync();
        Task AddAsync(ToDoItem item);
    }
}
