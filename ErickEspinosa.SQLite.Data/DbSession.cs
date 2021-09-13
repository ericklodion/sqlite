using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace ErickEspinosa.SQLite.Data
{
    public sealed class DbSession : IDisposable
    {
        private static readonly string _path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Database";
        private static readonly string _databaseFile = $@"{_path}/products.sqlite";
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession()
        {
            if (!File.Exists(_databaseFile))
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);

                SQLiteConnection.CreateFile(_databaseFile);
            }

            Connection = new SQLiteConnection($"Data Source={_databaseFile}; Version=3;");
            Connection.Open();

            CreateTables();
        }

        public void CreateTables()
        {
            var sql = @"
                CREATE TABLE IF NOT EXISTS USER (GUID VARCHAR(36) NOT NULL, PASSWORD VARCHAR(100) NOT NULL, EMAIL VARCHAR(200) NOT NULL, ROLE VARCHAR(200) NOT NULL);
                CREATE TABLE IF NOT EXISTS PRODUCT (GUID VARCHAR(36) NOT NULL, NAME VARCHAR(100) NOT NULL, PRICE NUMERIC(9,2) NOT NULL);
            ";

            Connection.Execute(sql, null, Transaction);
        }

        public void Dispose() => Connection?.Dispose();
    }
}
