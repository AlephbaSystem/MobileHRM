using MobileHRM.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHRM.Database
{
    public class UserAuthDatabase
    {

        static SQLiteAsyncConnection Database;
        public static readonly AsyncLazy<UserAuthDatabase> Instance = new AsyncLazy<UserAuthDatabase>(async () =>
        {
            UserAuthDatabase instance = new UserAuthDatabase();
            //CreateTableResult result = await Database.CreateTableAsync<UserEntitieModel>();
            CreateTableResult result = await Database.CreateTableAsync<UserAutentication>();
            return instance;
        });

        public UserAuthDatabase() => Database = new SQLiteAsyncConnection(Constans.DatabasePath, Constans.Flags);


        //Insert and Update new user  
        public async Task<int> SaveUserAutAsync(UserAutentication user) => await Database.InsertOrReplaceAsync(user);

        //Read Item
        public async Task<UserAutentication> GetUserAsync() => (await Database.QueryAsync<UserAutentication>("select * from UserAutentication")).FirstOrDefault();
    }
}
