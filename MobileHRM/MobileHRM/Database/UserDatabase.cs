using MobileHRM.Models;
using MobileHRM.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileHRM.Database
{
    public class UserDatabase
    {
        static SQLiteAsyncConnection Database;
        public static readonly AsyncLazy<UserDatabase> Instance = new AsyncLazy<UserDatabase>(async () =>
        {
            var instance = new UserDatabase();
            CreateTableResult result = await Database.CreateTableAsync<UserEntitieModel>();
            return instance;
        });

        public UserDatabase()
        {
            Database = new SQLiteAsyncConnection(Constans.DatabasePath, Constans.Flags);
        }

        //Read All Items  
        public async Task<List<UserEntitieModel>> GetItemsAsync()
        {
            return await Database.Table<UserEntitieModel>().ToListAsync();
        }

        //Get all notes.
        public async Task<List<UserEntitieModel>> GetNotesAsync()
        {
            return await Database.Table<UserEntitieModel>().ToListAsync();
        }

        // Get a specific note.
        public async Task<UserEntitieModel> GetNoteAsync(int id)
        {
            return await Database.Table<UserEntitieModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        //Insert and Update new record  
        public async Task<int> SaveItemAsync(UserEntitieModel user)
        {
            if (string.IsNullOrEmpty(user.token))
            {
                return await Database.InsertAsync(user);
            }
            else
            {
                return await Database.UpdateAsync(user);
            }
        }

        // Delete a note.
        public async Task<int> DeleteNoteAsync(UserEntitieModel user)
        {
            return await Database.DeleteAsync(user);
        }
    }
}
