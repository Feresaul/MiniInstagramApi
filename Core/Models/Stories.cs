using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Stories
    {
        public List<Storie> stories { set; get; }
        public string nombre { set; get; }

        public Stories()
        {
            stories = new List<Storie>();

        }
    }
}
