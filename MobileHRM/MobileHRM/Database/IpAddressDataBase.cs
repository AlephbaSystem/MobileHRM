using SQLite;
using System;
using System.Collections.Generic;
using MobileHRM.Models;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;

namespace MobileHRM.Database
{
    public class IpAddressDataBase
    {
        static SQLiteAsyncConnection Database;
        public static readonly AsyncLazy<IpAddressDataBase> Instance = new AsyncLazy<IpAddressDataBase>(async () =>
        {
            IpAddressDataBase instance = new IpAddressDataBase();
            CreateTableResult result = await Database.CreateTableAsync<IpAddress>();
            return instance;
        });


        public IpAddressDataBase()
        {
            Database = new SQLiteAsyncConnection(Constans.DatabasePath, Constans.Flags);
        }

        public async Task<bool> SaveUserAsync(IpAddress ipAddress)
        {

            if (!ValidateIPAddress(ipAddress)) return false;


            if (!string.IsNullOrEmpty(ipAddress.ipAddress.ToString()))
            {
                await Database.InsertAsync(ipAddress);
                return true;
            }
            return false;
        }

        private bool ValidateIPAddress(IpAddress ipAddress)
        {
            Regex regex = new Regex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
            return regex.IsMatch(ipAddress.ipAddress.ToString());
        }
    }

}
