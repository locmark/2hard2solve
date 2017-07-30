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
    public static class LinqExtensions
    {
        public static T MinBy<T>(this IEnumerable<T> source, Func<T, IComparable> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
            return source.Aggregate((min, cur) =>
            {
                if (min == null)
                {
                    return cur;
                }
                var minComparer = selector(min);
                if (minComparer == null)
                {
                    return cur;
                }
                var curComparer = selector(cur);
                if (curComparer == null)
                {
                    return min;
                }
                return minComparer.CompareTo(curComparer) > 0 ? cur : min;
            });
        }
    }
    public class Rank
    {
        public int minutes { get; set; }
        public int seconds { get; set; }
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
                int minSeconds, minMinutes;
                var rankDB = db.GetCollection<Rank>("rank");
                

                var newRank = new Rank
                {
                    level = _level,
                    minutes = _minutes,
                    seconds = _seconds
                };


                var searchedLevel = rankDB.Find(item => item.level == _level);

                if(searchedLevel != null)
                {
                    minMinutes = searchedLevel.FirstOrDefault().minutes;
                    minSeconds = searchedLevel.FirstOrDefault().seconds;

                    foreach (var item in searchedLevel)
                    {
                        if (item.minutes < minMinutes)
                            minMinutes = item.minutes;
                        if (item.seconds < minSeconds)
                            minSeconds = item.seconds;
                    }





                    foreach (var item in rankDB.FindAll())
                    {
                        rankDB.Delete(x => x.level == _level);
                    }
                    newRank.minutes = minMinutes;
                    newRank.seconds = minSeconds;
                }
               
                


                rankDB.Insert(newRank);
                rankDB.EnsureIndex(x => x.minutes);
                rankDB.EnsureIndex(x => x.seconds);
                rankDB.EnsureIndex(x => x.level);
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
