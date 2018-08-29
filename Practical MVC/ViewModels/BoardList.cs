using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.ViewModels
{
    public class BoardList
    {
        public List<Board> Boards = new List<Board>();
        public class Board
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}
