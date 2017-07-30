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
        //public Rank()
        //{
        //    minutes = 0;
        //    seconds = 0;
        //    level = 0;
        //}
    }

    public static class DB
    {
        private const string dbLocation = @"2H2S.db";

        public static void Init()
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var rank = db.GetCollection<Rank>("rank");

            }
        }

        public static void AddNewScore(int _level, int _minutes, int _seconds)
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                int minTime;
                var rankDB = db.GetCollection<Rank>("rank");
                int newTime = _minutes * 60 + _seconds;

                var newRank = new Rank
                {
                    level = _level,
                    time = newTime
                };

                minTime = newTime;



                if (rankDB.Count(item => item.level == _level) != 0)
                {
                    //minMinutes = searchedLevel.FirstOrDefault().minutes;
                    //minSeconds = searchedLevel.FirstOrDefault().seconds;

                    //foreach (var item in searchedLevel)
                    //{
                    //    if (item.minutes < minMinutes)
                    //        minMinutes = item.minutes;
                    //    if (item.seconds < minSeconds)
                    //        minSeconds = item.seconds;
                    //}
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

                }

                newRank.time = minTime;


                rankDB.Insert(newRank);
                //rankDB.EnsureIndex(x => x.minutes);
                //rankDB.EnsureIndex(x => x.seconds);

            }
        }
        public static IEnumerable<Rank> GetDatabaseContent()
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var rankDB = db.GetCollection<Rank>("rank");
                var result = rankDB.FindAll().OrderBy(item => item.level);
                return result;
            }


        }
    }
}
