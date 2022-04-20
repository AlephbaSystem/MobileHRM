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
            UserDatabase instance = new UserDatabase();
            CreateTableResult result = await Database.CreateTableAsync<UserEntitieModel>();
            return instance;
        });



        public UserDatabase()
        {
            Database = new SQLiteAsyncConnection(Constans.DatabasePath, Constans.Flags);
        }

        //Read All Items  
        public async Task<List<UserEntitieModel>> GetUsersAsync()
        {
            return await Database.Table<UserEntitieModel>().ToListAsync();
        }

        //Read Item
        public async Task<UserEntitieModel> GetUserAsync()
        {
            return await Database.Table<UserEntitieModel>().FirstOrDefaultAsync();
        }

        //Get a specific user.
        public async Task<UserEntitieModel> GetUserAsync(int id)
        {
            return await Database.Table<UserEntitieModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        //Get a specific user.
        public async Task<UserEntitieModel> GetUserAsync(string phone)
        {
            return await Database.Table<UserEntitieModel>()
                            .Where(i => i.phone == phone)
                            .FirstOrDefaultAsync();
        }

        //Insert new user  
        public async Task SaveUserAsync(UserEntitieModel user)
        {
            //return string.IsNullOrEmpty(user.token) ? await Database.InsertAsync(user) : await Database.UpdateAsync(user);
            if (!string.IsNullOrEmpty(user.phone))
            {
                if (await GetUserAsync(user.phone) == null)
                {
                    await Database.InsertAsync(user);
                }
                else
                {
                    await Database.UpdateAsync(user);
                }
            }
        }

        //Delete a user.
        public async Task<int> DeleteUserAsync(UserEntitieModel user) => await Database.DeleteAsync(user);


        ////Insert and Update new user  
        //public async Task<int> SaveUserAsync(User user)
        //{
        //    return string.IsNullOrEmpty(user.token) ? await Database.InsertAsync(user) : await Database.UpdateAsync(user);
        //}
    }
}
