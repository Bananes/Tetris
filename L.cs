using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Project_Tetra
{
    class L : Formes
    {

        public int position = 1;

        public override void initForme(Rectangle[,] grille)
        {
            for (int i = 0; i < this.CoordoneesX.Count; i++)
            {
                for (int j = 0; j < this.CoordoneesY.Count; j++)
                {
                    if (j == 1 && i == 2)
                    {
                        grille[this.CoordoneesX[i], this.CoordoneesY[j]].Fill = Brushes.SkyBlue;
                    }
                    else if (j==1)
                    {
                        
                    }
                    else
                    {
                        grille[this.CoordoneesX[i], this.CoordoneesY[j]].Fill = Brushes.SkyBlue;
                    }
                }
            }
        }

        public void RotationCoordonees(Rectangle[,] grille)
        {
            List<int> XProvisoire = new List<int>();
            List<int> YProvisoire = new List<int>();
            switch (position)
            {
                case 0:
                    position = 1;
                    this.initForme(grille);
                break;
                case 1:
                    position = 0;
                    YProvisoire.Add(CoordoneesY[0]);
                    YProvisoire.Add(CoordoneesY[0]+1);
                    YProvisoire.Add(CoordoneesY[0]+2);
                    XProvisoire.Add(CoordoneesX[0]);
                    XProvisoire.Add(CoordoneesX[0]+1);
                    for (int i = 0; i < this.CoordoneesX.Count; i++)
                    {
                        for (int j = 0; j < this.CoordoneesY.Count; j++)
                        {
                            if (j == 1 && i == 2)
                            {
                                grille[this.CoordoneesX[i], this.CoordoneesY[j]].Fill = Brushes.White;
                            }
                            else if (j == 1)
                            {

                            }
                            else
                            {
                                grille[this.CoordoneesX[i], this.CoordoneesY[j]].Fill = Brushes.White;
                            }
                        }
                    }
                    CoordoneesX = XProvisoire;
                    CoordoneesY = YProvisoire;
                    for (int i = 0; i < XProvisoire.Count; i++)
                    {
                        for (int j = 0; j < YProvisoire.Count; j++)
                        {
                            if(i == 1 && j==2)
                            {
                                grille[this.CoordoneesX[i], this.CoordoneesY[j]].Fill = Brushes.SkyBlue;
                            }
                            else if (i == 1)
                            {}
                            else
                            {
                                grille[this.CoordoneesX[i], this.CoordoneesY[j]].Fill = Brushes.SkyBlue;
                            }
                        }
                    }
                    break;
            }
        }

        public override void DownCoordonees(Rectangle[,] grille)
        {
            grille[this.CoordoneesX[0], this.CoordoneesY[0]].Fill = Brushes.White;
            grille[this.CoordoneesX[2], this.CoordoneesY[1]].Fill = Brushes.White;
            for (int i = 0; i < this.CoordoneesX.Count; i++)
            {

                this.CoordoneesX[i] = this.CoordoneesX[i] + 1;

            }
            grille[this.CoordoneesX[0], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
            grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
            grille[this.CoordoneesX[2], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
            grille[this.CoordoneesX[2], this.CoordoneesY[1]].Fill = Brushes.SkyBlue;
        }

        public override void LeftCoordonee(Rectangle[,] grille)
        {

            if (this.CoordoneesY[0] != 0)
            {
                grille[this.CoordoneesX[0], this.CoordoneesY[0]].Fill = Brushes.White;
                grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.White;
                grille[this.CoordoneesX[2], this.CoordoneesY[1]].Fill = Brushes.White;
                for (int i = 0; i < this.CoordoneesY.Count; i++)
                {
                    this.CoordoneesY[i] = this.CoordoneesY[i] - 1;
                }
                grille[this.CoordoneesX[0], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
                grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
                grille[this.CoordoneesX[2], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
                grille[this.CoordoneesX[2], this.CoordoneesY[1]].Fill = Brushes.SkyBlue;
            }
        }

        public override void RightCoordonee(Rectangle[,] grille)
        {
            if (this.CoordoneesY[1] != 9)
            {
                grille[this.CoordoneesX[0], this.CoordoneesY[0]].Fill = Brushes.White;
                grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.White;
                grille[this.CoordoneesX[2], this.CoordoneesY[0]].Fill = Brushes.White;
                for (int i = 0; i < this.CoordoneesY.Count; i++)
                {

                    this.CoordoneesY[i] = this.CoordoneesY[i] + 1;

                }
                grille[this.CoordoneesX[0], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
                grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
                grille[this.CoordoneesX[2], this.CoordoneesY[0]].Fill = Brushes.SkyBlue;
                grille[this.CoordoneesX[2], this.CoordoneesY[1]].Fill = Brushes.SkyBlue;
            }
        }
        public override void SetCoordoneesX()
        {
            CoordoneesX.Add(0);
            CoordoneesX.Add(1);
            CoordoneesX.Add(2);
        }
        public override void SetCoordoneesY()
        {
            CoordoneesY.Add(4);
            CoordoneesY.Add(5);
        }

        public override bool GaucheForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[0], this.CoordoneesY[0] - 1].Fill == Brushes.White && grille[this.CoordoneesX[1], this.CoordoneesY[0] - 1].Fill == Brushes.White && grille[this.CoordoneesX[2], this.CoordoneesY[0] - 1].Fill == Brushes.White)
            {
                return true;
            }
            return false;
        }

        public override bool DroiteForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[0], this.CoordoneesY[0] + 1].Fill == Brushes.White && grille[this.CoordoneesX[1], this.CoordoneesY[0] + 1].Fill == Brushes.White && grille[this.CoordoneesX[2], this.CoordoneesY[1] + 1].Fill == Brushes.White)
            {
                return true;
            }
            return false;
        }
        public override bool ArretForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[2] + 1, this.CoordoneesY[0]].Fill == Brushes.White && grille[this.CoordoneesX[2] + 1, this.CoordoneesY[1]].Fill == Brushes.White)
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
