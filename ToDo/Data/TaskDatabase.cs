using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;
using System.Threading.Tasks;

namespace ToDo.Data
{
    public class ToDoTaskDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ToDoTaskDatabase(string dbname)
        {
            database=new SQLiteAsyncConnection(dbname);
            database.CreateTableAsync<ToDoTask>().Wait();
        }

        public Task<List<ToDoTask>> GetToDoTasks()
        {
            return database.Table<ToDoTask>().ToListAsync();
        }

        public Task<ToDoTask> GetToDoTask(int id)
        {
            return database.Table<ToDoTask>().Where(i=>i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTask(ToDoTask task)
        {
            if(task.Id != 0)
            {
                return database.UpdateAsync(task);
            }
            else
            {
                return database.InsertAsync(task);
            }
        }

        public Task<int> DeleteTodoTask(ToDoTask task) { 
            return database.DeleteAsync(task);
        }
    }
}
