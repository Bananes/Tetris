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

        //Quand une touche est appuyé
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
                        if (actualPiece.DroiteForme(terrain.grille))//Vérifie si la pièce peut se déplacer
                        {
                            actualPiece.RightCoordonee(terrain.grille);
                        }
                    }
                }
            }
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            bStart.Visibility = Visibility.Hidden; //On enlève la visibilité du bouton start après démarrage
            DescAuto();
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            //Méthode appelé à chaque interval du timer
            if (actualPiece.CoordoneesX[actualPiece.CoordoneesX.Count-1] == 14) //Vérifie si la pièce se situe en bas de la grille
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
                    if (actualPiece.CoordoneesX[0] != 0)
                    {
                        tim.Stop();
                        scores = scores + 100;
                        score.Text = scores.ToString();
                        SupLigne();
                        DescAuto();
                    }
                    else
                    {
                        tim.Stop();
                        MessageBoxResult restart = MessageBox.Show("Partie Terminé. Voulez-vous recommencer ?", "GAME OVER", MessageBoxButton.YesNo);
                        //Permet à l'utilisateur de recommencé une partie
                        switch(restart)
                        {
                            case MessageBoxResult.Yes:
                            Grille grilleRestart = new Grille();
                            grilleRestart.CreaGrille();
                            terrain = grilleRestart;
                            scores = 0;
                            DescAuto();
                                break;
                            case MessageBoxResult.No:
                                System.Environment.Exit(-1);
                                break;
                        }
                    }
                }
            }
        }

        public void SupLigne()
        {
            //Méthode pour supprimer les lignes pleines et faire descendre les autres blocs
            int i;
            int compteur = 0;
            for (int j = 0; j < actualPiece.CoordoneesX.Count; j++)
            {
                for (i = 0; i < 10; i++)
                {
                    if (terrain.grille[actualPiece.CoordoneesX[j], i].Fill != Brushes.White)
                    {
                        //Pour charque case sur une ligne, on vérifie si une case est coloré
                        compteur++;//si la case est coloré on incrémente le compteur
                    }
                }
                if (compteur == 10) //Il n'y a que 10 colonnes sur une ligne
                {
                    for ( i = 0; i < 10; i++)
                    {//ici on supprime la ligne, on remplace tout les blocs coloré par des blocs blancs
                        terrain.grille[actualPiece.CoordoneesX[j], i].Fill = Brushes.White;
                        compteur = 0;
                    }
                    for (int a = actualPiece.CoordoneesX[j]; a > 0; a--)
                    {
                        for (i = 0; i < 10; i++)
                        {
                        //On fait descendre les blocs au dessus de la ligne supprimé
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
            //on va cherché à connaitre la forme suivante aléatoirement
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
            //Une fois la pièce choisi on la set sur la grille
            actualPiece.SetCoordoneesY();
            actualPiece.SetCoordoneesX();
            actualPiece.initForme(terrain.grille);
            tim.Start();
        }        
    }
}
