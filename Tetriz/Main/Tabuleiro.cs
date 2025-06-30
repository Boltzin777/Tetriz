using System;

namespace Main
{
    internal class Tabuleiro
    {
        private string[,] campodejogo = new string[21, 13];
        private int linha = 0;
        private int coluna = 5;

        public Tabuleiro()
        {
            for (int i = 0; i < campodejogo.GetLength(0); i++)
            {
                for (int j = 0; j < campodejogo.GetLength(1); j++)
                {
                    if (j == 0 || j == campodejogo.GetLength(1) - 1)
                        campodejogo[i, j] = "|";
                    else if (i == campodejogo.GetLength(0) - 1)
                        campodejogo[i, j] = "-";
                    else
                        campodejogo[i, j] = " ";
                }
            }
        }

        public string[,] Campodejogo
        {
            get { return campodejogo; }
            set { campodejogo = value; }
        }

        public void Comecarjogo(string[,] peca)
        {
            linha = 0;
            coluna = 5;
            InserirPeca(peca);
        }

        public void LimparPeca(string[,] peca)
        {
            for (int i = 0; i < peca.GetLength(0); i++)
            {
                for (int j = 0; j < peca.GetLength(1); j++)
                {
                    if (peca[i, j] != " ")
                    {
                        campodejogo[linha + i, coluna + j] = " ";
                    }
                }
            }
        }

        public void InserirPeca(string[,] peca)
        {
            for (int i = 0; i < peca.GetLength(0); i++)
            {
                for (int j = 0; j < peca.GetLength(1); j++)
                {
                    if (peca[i, j] != " ")
                    {
                        campodejogo[linha + i, coluna + j] = peca[i, j];
                    }
                }
            }
        }
        public void Movimentar(char mov, string[,] peca)
        {
            LimparPeca(peca);
            if (mov == 'a' && coluna > 1 && PodeMover(peca, linha, coluna - 1))
            {
                coluna--;
            }
            else if (mov == 'd' && coluna < campodejogo.GetLength(1) - 1 - peca.GetLength(1) && PodeMover(peca, linha, coluna + 1))
            {
                coluna++;
            }
            else if (mov == 's' && linha < campodejogo.GetLength(0) - 1 - peca.GetLength(0) && PodeMover(peca, linha + 1, coluna))
            {
                linha++;
            }
            InserirPeca(peca);
        }
        private bool PodeMover(string[,] peca, int novaLinha, int novaColuna)
        {
            int alturaPeca = peca.GetLength(0);
            int larguraPeca = peca.GetLength(1);

            for (int i = 0; i < alturaPeca; i++)
            {
                for (int j = 0; j < larguraPeca; j++)
                {
                    if (peca[i, j] != " ")
                    {
                        int linhaTab = novaLinha + i;
                        int colunaTab = novaColuna + j;
                        if (linhaTab < 0 || linhaTab >= campodejogo.GetLength(0) ||
                            colunaTab < 0 || colunaTab >= campodejogo.GetLength(1))
                            return false;
                        if (campodejogo[linhaTab, colunaTab] != " " &&
                            campodejogo[linhaTab, colunaTab] != peca[i, j])
                            return false;
                    }
                }
            }
            return true;
        }

        public bool PodeDescer(string[,] peca)
        {
            int alturaPeca = peca.GetLength(0);
            int larguraPeca = peca.GetLength(1);

            for (int j = 0; j < larguraPeca; j++)
            {
                for (int i = alturaPeca - 1; i >= 0; i--)
                {
                    if (peca[i, j] != " ")
                    {
                        int linhaTab = linha + i + 1;
                        int colunaTab = coluna + j;                        
                        if (linhaTab >= 19)
                            return false;                     
                        if (campodejogo[linhaTab, colunaTab] != " ")
                            return false;

                        break;
                    }
                }
            }
            return true;
        }

        public void FixarPeca(string[,] peca)
        {
            for (int i = 0; i < peca.GetLength(0); i++)
            {
                for (int j = 0; j < peca.GetLength(1); j++)
                {
                    if (peca[i, j] != " ")
                    {
                        campodejogo[linha + i, coluna + j] = "X";
                    }
                }
            }
        }

        public int RemoverLinhasCompletas()
        {
            int linhasRemovidas = 0;
            for (int i = campodejogo.GetLength(0) - 2; i >= 0; i--)
            {
                bool linhaCompleta = true;
                for (int j = 1; j < campodejogo.GetLength(1) - 1; j++)
                {
                    if (campodejogo[i, j] != "X")
                    {
                        linhaCompleta = false;
                        break;
                    }
                }
                if (linhaCompleta)
                {
                    RemoverLinha(i);
                    linhasRemovidas++;
                    i++; 
                }
            }
            return linhasRemovidas;
        }

        private void RemoverLinha(int linhaRemover)
        {
            for (int l = linhaRemover; l > 0; l--)
            {
                for (int j = 1; j < campodejogo.GetLength(1) - 1; j++)
                {
                    campodejogo[l, j] = campodejogo[l - 1, j];
                }
            }         
            for (int j = 1; j < campodejogo.GetLength(1) - 1; j++)
            {
                campodejogo[0, j] = " ";
            }
        }

        public bool EspacoLivreParaNovaPeca(string[,] peca)
        {
            for (int i = 0; i < peca.GetLength(0); i++)
                for (int j = 0; j < peca.GetLength(1); j++)
                    if (peca[i, j] != " " && campodejogo[i, 5 + j] != " ")
                        return false;
            return true;
        }

        public void Exibircampodejogo()
        {
            for (int i = 0; i < campodejogo.GetLength(0); i++)
            {
                for (int j = 0; j < campodejogo.GetLength(1); j++)
                {
                    Console.Write(campodejogo[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}