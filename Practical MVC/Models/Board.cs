using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//todo X rename solution
//todo X rename project
//todo clean up garbage
//todo finish up the last chappter
//todo put to github



namespace WebApplication5.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
    }

    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Board Board { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
    }



    [Table("Card")]
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public Column Column { get; set; }
        public int ColumnId { get; set; }
    }
}
