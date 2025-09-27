using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chess_Chernyshkov.Classes;

namespace Chess_Chernyshkov
{

    public partial class MainWindow : Window
    {

        public List<Pawn> Pawns = new List<Pawn>();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            MainWindow.init = this;
            Pawns.Add(new Classes.Pawn(0, 1, false));
            Pawns.Add(new Classes.Pawn(1, 1, false));
            Pawns.Add(new Classes.Pawn(2, 1, false));
            Pawns.Add(new Classes.Pawn(3, 1, false));
            Pawns.Add(new Classes.Pawn(4, 1, false));
            Pawns.Add(new Classes.Pawn(5, 1, false));
            Pawns.Add(new Classes.Pawn(6, 1, false));
            Pawns.Add(new Classes.Pawn(7, 1, false));
            Pawns.Add(new Classes.Pawn(0, 6, true));
            Pawns.Add(new Classes.Pawn(1, 6, true));
            Pawns.Add(new Classes.Pawn(2, 6, true));
            Pawns.Add(new Classes.Pawn(3, 6, true));
            Pawns.Add(new Classes.Pawn(4, 6, true));
            Pawns.Add(new Classes.Pawn(5, 6, true));
            Pawns.Add(new Classes.Pawn(6, 6, true));
            Pawns.Add(new Classes.Pawn(7, 6, true));

            CreateFigure();
        }
        private void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Title = sender as Grid;
            int X = Grid.GetColumn(Title);
            int Y = Grid.GetRow(Title);
            Classes.Pawn SelectPawn = Pawns.Find(x => x.Select == true);
            if (SelectPawn != null)
            {
                SelectPawn.Transform(X, Y);
            }
        }

        public void CreateFigure()
        {
            foreach (Classes.Pawn Pawn in Pawns)
            {
                Pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                if (Pawn.Black)
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn (black).png")));
                else Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn.png")));

                Grid.SetColumn(Pawn.Figure, Pawn.X);
                Grid.SetRow(Pawn.Figure, Pawn.Y);
                Pawn.Figure.MouseDown += Pawn.SelectFigure;
                gameBoard.Children.Add(Pawn.Figure);

            }
        }
        public void OnSelect(Classes.Pawn SelectPawn)
        {
            foreach (Classes.Pawn Pawn in Pawns)
                if (Pawn != SelectPawn)
                    if (Pawn.Select)
                        Pawn.SelectFigure(null, null);
        }
    }
}
