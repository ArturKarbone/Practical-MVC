using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.ViewModels
{
    public class Board
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public List<Column> Columns = new List<Column>();
        public class Column
        {
            public string Title { get; set; }
            public List<Card> Cards = new List<Card>();
        }

        public class Card
        {
            public int Id { get; set; }
            public string Title { get; set; }

        }
    }
}
