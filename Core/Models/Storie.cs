using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Storie
    {
        public DateTime date { set; get; }
        public string url { set; get; }

        public int id { set; get; }

        public Storie()
        {
            date = new DateTime();
        }
    }
}
