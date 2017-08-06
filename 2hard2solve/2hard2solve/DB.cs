using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LiteDB;

namespace _2hard2solve
{
   
    public class Rank
    {
        public int time { get; set; }
        public int level { get; set; }
    }

    public static class DB
    {
        private const string dbLocation = @"data.db";

        public static void Init()
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var rank = db.GetCollection<Rank>("rank");

            }
        }

        public static void AddNewScore(int _level, int _time)
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                int minTime;
                var rankDB = db.GetCollection<Rank>("rank");
               
                minTime = _time;

                var newRank = new Rank
                {
                    level = _level,
                    time = _time
                };

                if (rankDB.Count(item => item.level == _level) != 0)
                {
                    var sameLevelEntries = rankDB.Find(item => item.level == _level);

                    foreach (var item in sameLevelEntries)
                    {
                        if (item.time < minTime)
                            minTime = item.time;
                    }

                    foreach (var item in rankDB.FindAll())
                    {
                        rankDB.Delete(x => x.level == _level);
                    }

                    newRank.time = minTime;
                }

                rankDB.Insert(newRank);
               
            }
        }
        public static IEnumerable<Rank> GetDatabaseContent()
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var rankDB = db.GetCollection<Rank>("rank");
                return rankDB.FindAll().OrderBy(item => item.level);
            }
        }
    }
}
