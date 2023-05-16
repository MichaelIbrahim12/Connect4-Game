using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class Game : Form
    {
        RectangleF[] boardColumns;
        public  int[,] board;
        Point cornerPoint;
        float padding;
        float width;
        float height;
        public static int cols;
        public static int rows;
        int spacing;
        public static int turn; 
        public static int playerTurn;
        public string player;
        public static Game currntGameboard;
        public static Color HostColor;
        public static Color ChallangerColor;
        public static Brush HostBrush;
        public static Brush ChallangerBrush;
        public static GameResult winOrLose;

        public Game()
        {
            InitializeComponent();
            boardColumns = new RectangleF[cols];
            board = new int[rows, cols];
            cornerPoint = new Point(50, 50);
            rows = 6;
            cols = 7;
            spacing = 40;
            padding = spacing / 2;
            width = cols * spacing + (cols + 1) * padding;
            height = rows * spacing + (rows + 1) * padding;
            HostBrush = new SolidBrush(HostColor);
            ChallangerBrush = new SolidBrush(ChallangerColor);
            currntGameboard = this;
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            drawConnect4();
        }
        
        
        public void drawConnect4()
        {
            Graphics g = this.CreateGraphics();

            g.FillRectangle(Brushes.Blue, cornerPoint.X, cornerPoint.Y, width, height);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0)
                    {
                        boardColumns[j] = new RectangleF(cornerPoint.X + padding + (spacing + padding) * j, cornerPoint.Y, spacing, height);
                    }
                    g.FillEllipse(Brushes.White, cornerPoint.X + padding + (spacing + padding) * j, cornerPoint.Y + padding + (spacing + padding) * i, spacing, spacing);

                }
            }
        }
        public void repaintBord()
        {
            Graphics g = this.CreateGraphics();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == 1)
                    {
                        g.FillEllipse(HostBrush, cornerPoint.X + padding + (spacing + padding) * j, cornerPoint.Y + padding + (spacing + padding) * i, spacing, spacing);
                    }
                    else if (board[i, j] == 2)
                    {
                        g.FillEllipse(ChallangerBrush, cornerPoint.X + padding + (spacing + padding) * j, cornerPoint.Y + padding + (spacing + padding) * i, spacing, spacing);
                    }
                    else if (board[i, j] == 0)
                    {
                        g.FillEllipse(Brushes.White, cornerPoint.X + padding + (spacing + padding) * j, cornerPoint.Y + padding + (spacing + padding) * i, spacing, spacing);
                    }

                }
            }
        }
        //method to get index of col clicked
        private int columnNumber(Point mouse)
        {
            for (int i = 0; i < cols; i++)
            {
                if (mouse.X > boardColumns[i].X && mouse.X < (boardColumns[i].X + spacing))
                {
                    if (mouse.Y > cornerPoint.Y && mouse.Y < cornerPoint.Y + height)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        //method to get empty row index
        private int emptyRow(int col)
        {
            for (int i = rows - 1; i >= 0; i--)
            {

                if (board[i, col] == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            int columnIndex = this.columnNumber(e.Location);
            if (columnIndex != -1)
            {
                int rowindex = this.emptyRow(columnIndex);
                if (rowindex != -1)
                {
                    this.board[rowindex, columnIndex] = turn;  


                    if (playerTurn == turn) //cuurnt player 
                    {


                        GameManger.SendServerRequest(Flag.SendMove, rowindex.ToString(), columnIndex.ToString());


                    }
                    else if (playerTurn == 3)
                    {
                        MessageBox.Show("you are just watching");
                    }
                    else
                    {
                        MessageBox.Show("It's Not Your Turn");
                    }


                }
            }
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {   
            Rooms.lobby.Show();
            GameManger.SendServerRequest(Flag.leaveRoom);
            
        }
    }   
}
