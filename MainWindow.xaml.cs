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
using System.Timers;
using System.Windows.Threading;

namespace Project_Tetra
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DispatcherTimer tim;
        Formes actualPiece;
        Formes suivant = new Carre();
        Grille terrain = new Grille();
        public static MainWindow windows;
        Random formeSuivantes = new Random();
        int scores = 0;
        public MainWindow()
        {
            InitializeComponent();
            windows = this;
            terrain.CreaGrille();
            score.Text = scores.ToString();
            tim = new DispatcherTimer();
            tim.Tick += Tim_Tick;
            tim.Interval = new TimeSpan(0, 0, 0, 0, 200);
        }

        private void ActualPiece_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Q))
            {
                if (tim.IsEnabled)
                {
                    if (actualPiece.CoordoneesY[0] != 0)
                    {
                        if (actualPiece.GaucheForme(terrain.grille))
                        {
                            actualPiece.LeftCoordonee(terrain.grille);
                        }
                    }
                }
            }
            else if (e.Key.Equals(Key.D))
            {
                if (tim.IsEnabled)
                {
                    if (actualPiece.CoordoneesY[actualPiece.CoordoneesY.Count - 1] != 9)
                    {
                        if (actualPiece.DroiteForme(terrain.grille))
                        {
                            actualPiece.RightCoordonee(terrain.grille);
                        }
                    }
                }
            }
        }

        public Rectangle CreaCarre()
        {
            Rectangle carre = new Rectangle();
            carre.Height = 40;
            carre.Width = 40;
            carre.StrokeThickness = 2;
            carre.Stroke = Brushes.Plum;

            return carre;
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            bStart.Visibility = Visibility.Hidden;
            DescAuto();
        }

        

        private void Tim_Tick(object sender, EventArgs e)
        {
            if (actualPiece.CoordoneesX[actualPiece.CoordoneesX.Count-1] == 14)
            {
                tim.Stop();
                scores = scores + 100;
                score.Text = scores.ToString();
                SupLigne();
                DescAuto();
            }
            else
            {
                if (actualPiece.ArretForme(terrain.grille))
                {
                    actualPiece.DownCoordonees(terrain.grille);
                }
                else
                {
                    tim.Stop();
                    scores = scores + 100;
                    score.Text = scores.ToString();
                    SupLigne();
                    DescAuto();
                }
            }
        }

        public void SupLigne()
        {
            int i;
            int compteur = 0;
            for (int j = 0; j < actualPiece.CoordoneesX.Count; j++)
            {
                for (i = 0; i < 10; i++)
                {
                    if (terrain.grille[actualPiece.CoordoneesX[j], i].Fill != Brushes.White)
                    {
                        compteur++;
                    }
                }
                if (compteur == 10)
                {
                    for ( i = 0; i < 10; i++)
                    {
                        terrain.grille[actualPiece.CoordoneesX[j], i].Fill = Brushes.White;
                        compteur = 0;
                    }
                    for (int a = actualPiece.CoordoneesX[j]; a > 0; a--)
                    {
                        for (i = 0; i < 10; i++)
                        {
                            terrain.grille[a, i].Fill = terrain.grille[a - 1, i].Fill;
                        }
                    }
                    scores = scores + 1000;
                    score.Text = scores.ToString();
                }
                compteur = 0;
            }
        }

        public void DescAuto()
        {
            int random = formeSuivantes.Next(1, 8);
            switch (random)
            {
                case 1:
                    suivant = new Carre();
                    actualPiece = (Carre)suivant;
                    break;
                case 2:
                    suivant = new T();
                    actualPiece = (T)suivant;
                    break;
                case 3:
                    suivant = new L();
                    actualPiece = (L)suivant;
                    break;
                case 4:
                    suivant = new Z();
                    actualPiece = (Z)suivant;
                    break;
                case 5:
                    suivant = new Barre();
                    actualPiece = (Barre)suivant;
                    break;
                case 6:
                    suivant = new Zinv();
                    actualPiece = (Zinv)suivant;
                    break;
                case 7:
                    suivant = new Linv();
                    actualPiece = (Linv)suivant;
                    break;
            }
            actualPiece.SetCoordoneesY();
            actualPiece.SetCoordoneesX();
            actualPiece.initForme(terrain.grille);
            tim.Start();
        }        
    }
}
