using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Project_Tetra
{
    
    class Grille
    {
        public Rectangle[,] grille = new Rectangle[15, 10];

        public void CreaGrille()
        {
            //Cette méthode initialise la grille
            var x = 0;
            var y = 0;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle carre = new Rectangle();
                    carre.Height = 40;
                    carre.Width = 40;
                    carre.StrokeThickness = 1;
                    carre.Stroke = Brushes.IndianRed;
                    carre.Fill = Brushes.White;
                    Canvas.SetLeft(carre, x);
                    Canvas.SetTop(carre, y);
                    MainWindow.windows.gameField.Children.Add(carre);
                    x = x + 40;
                    grille[i, j] = carre;
                }
                x = 0;
                y = y + 40;
            }
        }

    }
}
