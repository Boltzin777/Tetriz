using System;
using System.IO;
using System.Text;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do Jogador: ");
            string nome = Console.ReadLine();
            Jogador jogador = new Jogador(nome, 0);
            Tabuleiro tabuleiro = new Tabuleiro();
            bool jogo = true;
            while (jogo)
            {
                Tetrominos tetromino = new Tetrominos();
                string[,] pecaAtual = tetromino.GetPeca;
                if (!tabuleiro.EspacoLivreParaNovaPeca(pecaAtual))
                {
                    jogo = true;
                    break;
                }
                tabuleiro.Comecarjogo(pecaAtual);
                bool caiu = false;
                while (!caiu)
                {
                    tabuleiro.Exibircampodejogo();
                    Console.WriteLine();
                    jogador.ExibirInfo();

                    Console.WriteLine("Comandos: (a) Esquerda | (d) Direita | (s) Baixo | (r) Gira Horário | (e) Gira Anti-Horário | (f) Finalizar");
                    char comando = char.Parse(Console.ReadLine());
                    if (comando == 'f')
                    {
                        jogo = true;
                        break;
                    }
                    else if (comando == 'r')
                    {
                        tabuleiro.LimparPeca(pecaAtual);
                        tetromino.RotacionarHorario();
                        pecaAtual = tetromino.GetPeca;
                        tabuleiro.InserirPeca(pecaAtual);
                        tabuleiro.LimparPeca(pecaAtual);
                        if (tabuleiro.PodeDescer(pecaAtual))
                        {
                            tabuleiro.Movimentar('s', pecaAtual);
                            tabuleiro.InserirPeca(pecaAtual);
                        }
                        else
                        {
                            tabuleiro.InserirPeca(pecaAtual);
                            tabuleiro.FixarPeca(pecaAtual);
                            caiu = true;
                        }
                    }
                    else if (comando == 'e')
                    {
                        tabuleiro.LimparPeca(pecaAtual);
                        tetromino.RotacionarAntiHorario();
                        pecaAtual = tetromino.GetPeca;
                        tabuleiro.InserirPeca(pecaAtual);
                        tabuleiro.LimparPeca(pecaAtual);
                        if (tabuleiro.PodeDescer(pecaAtual))
                        {
                            tabuleiro.Movimentar('s', pecaAtual);
                            tabuleiro.InserirPeca(pecaAtual);
                        }
                        else
                        {
                            tabuleiro.InserirPeca(pecaAtual);
                            tabuleiro.FixarPeca(pecaAtual);
                            caiu = true;
                        }
                    }
                    else if (comando == 'a' || comando == 'd')
                    {
                        tabuleiro.LimparPeca(pecaAtual);
                        tabuleiro.Movimentar(comando, pecaAtual);
                        tabuleiro.InserirPeca(pecaAtual);
                        tabuleiro.LimparPeca(pecaAtual);
                        if (tabuleiro.PodeDescer(pecaAtual))
                        {
                            tabuleiro.Movimentar('s', pecaAtual);
                            tabuleiro.InserirPeca(pecaAtual);
                        }
                        else
                        {
                            tabuleiro.InserirPeca(pecaAtual);
                            tabuleiro.FixarPeca(pecaAtual);
                            caiu = true;
                        }
                    }
                    else if (comando == 's')
                    {
                        tabuleiro.LimparPeca(pecaAtual);
                        if (tabuleiro.PodeDescer(pecaAtual))
                        {
                            tabuleiro.Movimentar('s', pecaAtual);
                            tabuleiro.InserirPeca(pecaAtual);
                        }
                        else
                        {
                            tabuleiro.InserirPeca(pecaAtual);
                            tabuleiro.FixarPeca(pecaAtual);
                            caiu = true;
                        }
                    }
                }

                int quantlinha = tabuleiro.RemoverLinhasCompletas();
                if (quantlinha > 0)
                    jogador.AtualizarPontuacao(300 + (quantlinha - 1) * 100, jogador);
            }

            tabuleiro.Exibircampodejogo();
            Console.WriteLine();
            jogador.ExibirInfo();
            Console.WriteLine("\nFIM DE JOGO!\nPontuação final de " + jogador.Nome + ": " + jogador.Pontuacao);          
            Console.ReadLine();
            try
            {
                StreamWriter arq = new StreamWriter("scores.txt", true, Encoding.UTF8);
                arq.Write($"Jogador:{jogador.Nome}\nPontuacao:{jogador.Pontuacao}");
                arq.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}