using MobileHRM.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHRM.Database
{
    public class PunchDataBase
    {
        public static readonly AsyncLazy<PunchDataBase> Instance = new AsyncLazy<PunchDataBase>(async () =>
        {
            PunchDataBase instance = new PunchDataBase();
            CreateTableResult result = await Database.CreateTableAsync<Punch>();
            return instance;
        });
        static SQLiteAsyncConnection Database;

        public PunchDataBase()
        {
            Database = new SQLiteAsyncConnection(Constans.DatabasePath1, Constans.Flags);
        }
        public async Task<Punch> GetLastPunch()
        {
            var result = await Database.QueryAsync<Punch>("select * from [Punch] order by date desc");
            result = result ?? new List<Punch>();
            return (from p in result where p.date.Day == DateTime.Now.Day select p).FirstOrDefault();
        }
        public async Task InsertPunch(Punch item)
        {
            await Database.InsertAsync(item);
        }
    }
}
