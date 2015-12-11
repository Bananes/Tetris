using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Project_Tetra
{
    class Barre :Formes
    {
        public override void initForme(Rectangle[,] grille)
        {
            for (int i = 0; i < this.CoordoneesX.Count; i++)
            {
                for (int j = 0; j < this.CoordoneesY.Count; j++)
                {
                    grille[this.CoordoneesX[i], this.CoordoneesY[j]].Fill = Brushes.Gold;
                }
            }
        }

        public override void SetCoordoneesX()
        {
            CoordoneesX.Add(0);
            CoordoneesX.Add(1);
            CoordoneesX.Add(2);
            CoordoneesX.Add(3);
        }
        public override void SetCoordoneesY()
        {
            CoordoneesY.Add(4);
        }

        public override void DownCoordonees(Rectangle[,] grille)
        {
            grille[this.CoordoneesX[0], this.CoordoneesY[0]].Fill = Brushes.White;

            for (int i = 0; i < this.CoordoneesX.Count; i++)
            {

                this.CoordoneesX[i] = this.CoordoneesX[i] + 1;

            }
            for (int i = 0; i < this.CoordoneesX.Count; i++)
            {
                grille[this.CoordoneesX[i], this.CoordoneesY[0]].Fill = Brushes.Gold;
            }
        }

        public override void RightCoordonee(Rectangle[,] grille)
        {
            if (this.CoordoneesY[0] != 9)
            {
                for (int i = 0; i < this.CoordoneesX.Count; i++)
                {
                    grille[this.CoordoneesX[i], this.CoordoneesY[0]].Fill = Brushes.White;
                }
                for (int i = 0; i < this.CoordoneesY.Count; i++)
                {

                    this.CoordoneesY[i] = this.CoordoneesY[i] + 1;

                }
                for (int i = 0; i < this.CoordoneesX.Count; i++)
                {
                    grille[this.CoordoneesX[i], this.CoordoneesY[0]].Fill = Brushes.Gold;
                }
            }
        }
        public override void LeftCoordonee(Rectangle[,] grille)
        {

            if (this.CoordoneesY[0] != 0)
            {

                for (int i = 0; i < this.CoordoneesX.Count; i++)
                {
                    grille[this.CoordoneesX[i], this.CoordoneesY[0]].Fill = Brushes.White;
                }
                for (int i = 0; i < this.CoordoneesY.Count; i++)
                {

                    this.CoordoneesY[i] = this.CoordoneesY[i] - 1;

                }
                grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.Gold;
                for (int i = 0; i < this.CoordoneesX.Count; i++)
                {
                    grille[this.CoordoneesX[i], this.CoordoneesY[0]].Fill = Brushes.Gold;
                }
            }
        }
        public override bool GaucheForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[0], this.CoordoneesY[0] - 1].Fill == Brushes.White && grille[this.CoordoneesX[1], this.CoordoneesY[0] - 1].Fill == Brushes.White && grille[this.CoordoneesX[2], this.CoordoneesY[0] - 1].Fill == Brushes.White && grille[this.CoordoneesX[3], this.CoordoneesY[0] - 1].Fill == Brushes.White)
            {
                return true;
            }
            return false;
        }

        public override bool DroiteForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[0], this.CoordoneesY[0] + 1].Fill == Brushes.White && grille[this.CoordoneesX[1], this.CoordoneesY[0] + 1].Fill == Brushes.White && grille[this.CoordoneesX[2], this.CoordoneesY[0] + 1].Fill == Brushes.White && grille[this.CoordoneesX[3], this.CoordoneesY[0] + 1].Fill == Brushes.White)
            {
                return true;
            }
            return false;
        }
        public override bool ArretForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[3] + 1, this.CoordoneesY[0]].Fill == Brushes.White)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
