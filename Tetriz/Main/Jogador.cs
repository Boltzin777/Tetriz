using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Jogador
    {
        private string nome;
        private int pontuacao;
       

        public Jogador(string nome,int pontuacao)
        {
            this.nome = nome;
            this.pontuacao = 0;
        }
        public int Pontuacao
        {
            get { return this.pontuacao; }
            set { this.pontuacao = value; }
        }
        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }
        public void AtualizarPontuacao(int valor,Jogador jogador)
        {
            jogador.pontuacao += valor;
        }
        public void ExibirInfo()
        {
            Console.WriteLine("Jogador: " + nome + " \nPontuação: " + pontuacao);
        }

    }
}
