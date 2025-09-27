using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace Chess_Chernyshkov.Classes
{
    internal class Pawn
    {
        
        public int X { get; set; }
        
        public int Y { get; set; }
        
        public bool Select = false;

        public bool Black = false;



        public Grid Figure { get; set; }
        
        public Pawn(int X, int Y, bool Black)
        {
            this.X = X;
            this.Y = Y;
            this.Black = Black;


            
        }
        public void SelectFigure(object sender, MouseButtonEventArgs e)
        {
            bool atack = false;
            
            Pawn SelectPawn = MainWindow.mainWindow.Pawns.Find(x => x.Select == true);
            
            if (SelectPawn != null)
            {
                if (this.Black && this.Y - 1 == SelectPawn.Y && ( this.X - 1 == SelectPawn.X || this.X == SelectPawn.X || this.X + 1 == SelectPawn.X ) || !this.Black && this.Y + 1 == SelectPawn.Y && (this.X - 1 == SelectPawn.X || this.X == SelectPawn.X || this.X + 1 == SelectPawn.X))
                {
                    MainWindow.mainWindow.gameBoard.Children.Remove(this.Figure);
                   
                    Grid.SetColumn(SelectPawn.Figure, this.X);
                    Grid.SetRow(SelectPawn.Figure, this.Y);
                 
                    SelectPawn.X = X;
                    SelectPawn.Y = Y;

                    SelectPawn.SelectFigure(null, null);
                    atack = true;
                }
            }
            if (!atack)
            {
                MainWindow.mainWindow.OnSelect(this);
                if (this.Select)
                {
                    if (this.Black)
                    
                        this.Figure.Background = new ImageBrush(new BitmapImage(new Uri("C: /Users/student - a502/Desktop/Chess_Chernyshkov/Images/Pawn(black).png")));
                        else this.Figure.Background = new ImageBrush(new BitmapImage(new Uri("C://Users//student-a502//Desktop//Chess_Chernyshkov//Images//Pawn.png")));
                        this.Select = false;
                    
                }
                else
                {
                    this.Figure.Background = new ImageBrush(new BitmapImage(new Uri("C://Users//student-a502//Desktop//Chess_Chernyshkov//Images//Pawn (select).png")));
                    this.Select = true;
                }
            }
        }
        public void Transform(int X, int Y) {
            if ( X != this.X)
            {
                SelectFigure(null, null);
                return;

            }
            if (!Black && ((this.Y == 1 && this.Y + 2 == Y) || this.Y + 1 == Y) || Black && ((this.Y == 6 && this.Y - 2 == Y)))
            {
                Grid.SetColumn(this.Figure, X);
                Grid.SetColumn(this.Figure, Y);
                this.X = X;
                this.Y = Y;

            }
            SelectFigure(null , null);
        
        
        
        }
            
    }
}
