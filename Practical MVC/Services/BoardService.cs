using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practical_MVC.ViewModels;
using WebApplication5.Infrastructure;
using WebApplication5.Models;
using WebApplication5.ViewModels;
using Board = WebApplication5.ViewModels.Board;

namespace WebApplication5.Services
{
    public class BoardService
    {
        private readonly BoardContext boardContext;
        public BoardService(BoardContext boardContext)
        {
            this.boardContext = boardContext;
        }

        public CardDetails GetCard(int id)
        {
            var card = boardContext
                .Cards
                .Include(x => x.Column)
                .ThenInclude(x => x.Board)
                .ThenInclude(x => x.Columns)
                .FirstOrDefault(x => x.Id == id);

            var availableColumns = card.Column.Board.Columns.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString(),
            }).ToList();

            return new CardDetails
            {
                Id = card.Id,
                Title = card.Title,
                Notes = card.Notes,
                ColumnId = card.ColumnId,
                AvailableColumns = availableColumns
            };
        }

        public void UpdateCard(CardDetails cardModel)
        {
            var card = boardContext.Cards.FirstOrDefault(x => x.Id == cardModel.Id);

            card.Notes = cardModel.Notes;
            card.Title = cardModel.Title;
            card.ColumnId = cardModel.ColumnId;

            boardContext.SaveChanges();

        }

        public void Add(NewBoard board)
        {
            boardContext.Boards.Add(new Models.Board()
            {
                Title = board.Title,
                Columns =  {
                    new Column
                    {
                        Title = "Todo",
                        Cards =
                        {
                            new Card() { Title = "Test Card" }
                        }
                    },
                    new Column
                    {
                        Title = "In progress",
                        Cards =
                        {
                            new Card() { Title = "Test Card in progress" }
                        }
                    },
                    new Column
                    {
                        Title = "Done",
                    }
                }
            });
            boardContext.SaveChanges();
        }

        public BoardList ListBoards()
        {
            var boardVMs = boardContext.Boards.Select(b => new BoardList.Board()
            {
                Title = b.Title,
                Id = b.Id
            }).ToList();


            var boardList = new BoardList()
            {
                Boards = boardVMs
            };

            return boardList;
        }

        //public BoardList ListBoards()
        //{
        //    var boardList = new BoardList();
        //    var board1 = new BoardList.Board() { Title = "First Board" };
        //    var board2 = new BoardList.Board() { Title = "Second Board" };
        //    var board3 = new BoardList.Board() { Title = "Third Board" };

        //    boardList.Boards.Add(board1);
        //    boardList.Boards.Add(board2);
        //    boardList.Boards.Add(board3);
        //    boardList.Boards.Add(board3);
        //    return boardList;
        //}

        public void AddCard(AddCard vm)
        {
            var board = boardContext
                .Boards
                .Include(x => x.Columns)
                .First(x => x.Id == vm.BoardId);

            var firstColumn = board.Columns.FirstOrDefault();

            if (null == firstColumn)
            {
                firstColumn = new Column()
                {
                    Title = "Todo"
                };
                board.Columns.Add(firstColumn);
            }

            firstColumn.Cards.Add(new Card { Title = vm.Title });

            boardContext.SaveChanges();
        }


        public Board GetBoard(int id)
        {
            var board = this.boardContext
                .Boards
                .Include(x => x.Columns)
                .ThenInclude(x => x.Cards)
                .FirstOrDefault(x => x.Id == id);

            var boardVM = new Board()
            {
                Id = board.Id,
                Title = board.Title,
                Columns = board.Columns.Select(x =>
                    new Board.Column
                    {
                        Title = x.Title,
                        Cards = x.Cards.Select(c => new Board.Card()
                        {
                            Id = c.Id,
                            Title = c.Title
                        }).ToList()

                    }).ToList()
            };

            return boardVM;
        }

        //public Board GetBoard()
        //{
        //    var board = new Board()
        //    {
        //        Columns = new List<Board.Column>()
        //        {
        //            new Board.Column()
        //            {
        //                Title = "TODO",
        //                Cards = new List<Board.Card>()
        //                {
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 1"
        //                    },
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 2"
        //                    },
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 7"
        //                    }
        //                }
        //            },
        //            new Board.Column()
        //            {
        //                Title = "In Progress",
        //                Cards = new List<Board.Card>()
        //                {
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 3"
        //                    },
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 4"
        //                    }
        //                }
        //            },
        //            new Board.Column()
        //            {
        //                Title = "Done",
        //                Cards = new List<Board.Card>()
        //                {
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 5"
        //                    },
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 6"
        //                    },
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 8"
        //                    },
        //                    new Board.Card()
        //                    {
        //                        Title = "Card 9"
        //                    }
        //                }
        //            }
        //        }
        //    };

        //    return board;
        //}
    }

}
