using System;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace LearnWords.Services
{
    public class WordsService : IDisposable
    {
        private readonly SQLiteConnection _connection;
        private readonly string _words;
        private readonly bool _exist;

        public WordsService()
        {
            _words = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/words.txt");
            var dbPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/words.db");
            _exist = File.Exists(dbPath);
            _connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            _connection.Open();
        }

        public void Initialize()
        {
            if (!_exist)
            {
                using (var cmd = _connection.CreateCommand())
                {
                    StringBuilder createdb = new StringBuilder();
                    createdb.Append(
                        "CREATE TABLE IF NOT EXISTS [Words]([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[Word] NVARCHAR(200) NULL); ");
                    createdb.Append("CREATE INDEX word_idx ON Words(Word); ");
                    cmd.CommandText = createdb.ToString();
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteTransaction tr = _connection.BeginTransaction())
                {
                    using (var cmd = _connection.CreateCommand())
                    {
                        cmd.Transaction = tr;

                        try
                        {
                            // Insert data
                            using (TextReader reader = new StreamReader(_words))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    line = line.Replace("'", "''");
                                    cmd.CommandText = $"insert into Words(Word) values ('{line}'); ";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            tr.Commit();
                        }
                        catch (Exception e)
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }

               
            }
        }

        public bool Exist(string word)
        {
            if (!_exist)
            {
                Initialize();
            }

            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select word from words where word like '{word}'";
                var obj = cmd.ExecuteScalar();
                return obj != null;
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}