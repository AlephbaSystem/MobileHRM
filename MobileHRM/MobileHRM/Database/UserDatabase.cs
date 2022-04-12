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
            List<SQLiteConnection.ColumnInfo> tableInfo = Database.GetConnection().GetTableInfo("UserEntitieModel");
            if (tableInfo.Count > 0)
            {
                return instance;
            }
            CreateTableResult result = await Database.CreateTableAsync<UserEntitieModel>();
            return instance;
        });



        public UserDatabase()
        {
            Database = new SQLiteAsyncConnection(Constans.DatabasePath, Constans.Flags);
            var q = Instance;
        }

        //Read All Items  
        public async Task<List<UserEntitieModel>> GetUserAsync()
        {
            return await Database.Table<UserEntitieModel>().ToListAsync();
        }

        //Get a specific user.
        public async Task<UserEntitieModel> GetUserAsync(int id)
        {
            return await Database.Table<UserEntitieModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        //Insert and Update new user  
        public async Task<int> SaveUserAsync(UserEntitieModel user)
        {
            return string.IsNullOrEmpty(user.token) ? await Database.InsertAsync(user) : await Database.UpdateAsync(user);
        }

        //Delete a user.
        public async Task<int> DeleteUserAsync(UserEntitieModel user) => await Database.DeleteAsync(user);
    }
}
