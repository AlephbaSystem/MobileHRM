using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;
using MobileHRM.Models.Entities;

namespace MobileHRM.Database
{
    public class IpAddressDataBase
    {
        static SQLiteAsyncConnection Database;
        public static readonly AsyncLazy<IpAddressDataBase> Instance = new AsyncLazy<IpAddressDataBase>(async () =>
        {
            IpAddressDataBase instance = new IpAddressDataBase();
           var f = await instance.CreateTable();
            return instance; 
        });
        public async Task<bool> CreateTable()
        {
            try
            {
                var tableInfo = Database.GetConnection().GetTableInfo(nameof(IpAddress));
                if (tableInfo.Count <= 0)
                {
                    CreateTableResult result = await Database.CreateTableAsync<IpAddress>();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IpAddressDataBase()
        {
            Database = new SQLiteAsyncConnection(Constans.DatabasePath, Constans.Flags);
        }

        public async Task<bool> SaveUserAsync(IpAddress ipAddress)
        {

            if (!ValidateIPAddress(ipAddress)) return false;

            if (!string.IsNullOrEmpty(ipAddress.ip.ToString()))
            {
                await Database.InsertAsync(ipAddress);
                return true;
            }
            return false;
        }

        public async Task<IpAddress> GetUserAsync() => (await Database.QueryAsync<IpAddress>("select * from IpAddress")).FirstOrDefault();

        public async Task<int> RemoveAll()
        {
            var result = await Database.DeleteAllAsync<IpAddress>();
            return result;
        }

        private bool ValidateIPAddress(IpAddress ipAddress)
        {
            Regex regex = new Regex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
            return regex.IsMatch(ipAddress.ip.ToString());
        }
    }

}
