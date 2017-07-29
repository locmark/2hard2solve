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
        public int score { get; set; }
        public int level { get; set; }
        public Rank()
        {
            score = 0;
            level = 0;
        }
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

        public static void AddNewScore(int level, int score)
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var rankDB = db.GetCollection<Rank>("rank");

                var newRank = new Rank();
                
                newRank.level = level;
                newRank.score = score;

                rankDB.Insert(newRank);

            }
        }
    }
}
