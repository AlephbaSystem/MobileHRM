﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MobileHRM.Database
{
    public class Constans
    {
        public const string DatabaseFilename = "UserDb.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
                return basePath;
            }
        }
    }
}
