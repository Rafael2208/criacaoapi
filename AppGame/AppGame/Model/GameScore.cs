using System;
using System.Collections.Generic;
using System.Text;

namespace AppGame.Model
{
    public class GameScore
    {
        public GameScore()
        {
            this.id = 0;
            this.name = "";
            this.phrase = "";
            this.highscore = 0;
            this.email = "";
            this.game = "";
        }
        public int id { get; set; }
        public int highscore { get; set; }
        public string game { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phrase { get; set; }
    }
}
