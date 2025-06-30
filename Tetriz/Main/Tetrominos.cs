using System;

namespace Main
{
    internal class Tetrominos
    {
        private string[,] peca = new string[3, 3];
       

        public Tetrominos()
        {
           
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    peca[i, j] = " ";

            switch (rnd.Next(1, 8))
            {
                case 1:
                    peca = new string[,]
                    {
                        {" ", "X", " "},
                        {"X", "X", "X"},
                        {" ", " ", " "}
                    };
                    break;

                case 2:
                    peca = new string[,]
                    {
                        {" ", " ", "X"},
                        {"X", "X", "X"},
                        {" ", " ", " "}
                    };
                    break;

                case 3:
                    peca = new string[,]
                    {
                        {"X", " ", " "},
                        {"X", "X", "X"},
                        {" ", " ", " "}
                    };
                    break;

                case 4:
                    peca = new string[,]
                    {
                        {" ", "X", "X"},
                        {" ", "X", "X"},
                        {" ", " ", " "}
                    };
                    break;

                case 5:
                    peca = new string[,]
                    {
                        {" ", "X", " "},
                        {" ", "X", " "},
                        {" ", "X", " "}
                    };
                    break;

                case 6:
                    peca = new string[,]
                    {
                        {" ", "X", "X"},
                        {"X", "X", " "},
                        {" ", " ", " "}
                    };
                    break;

                case 7:
                    peca = new string[,]
                    {
                        {"X", "X", " "},
                        {" ", "X", "X"},
                        {" ", " ", " "}
                    };
                    break;
            }
        }
        public string [,]GetPeca
        {
            get { return peca; }          
        }
        public void RotacionarHorario()
        {
            string[,] novaMatriz = new string[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    novaMatriz[j, 2 - i] = peca[i, j];

            peca = novaMatriz;
            
        }
        public void RotacionarAntiHorario()
        {
            string[,] novaMatriz = new string[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    novaMatriz[2 - j, i] = peca[i, j];

            peca = novaMatriz;
        }

    }
}