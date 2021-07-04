namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao {get; set;}
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca (Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            QteMovimentos = 0;
            Tabuleiro = tabuleiro;
        }

        public void IncrementarQtdeMovimentos()
        {
            QteMovimentos++;
        }

        public void DecrementarQtdeMovimentos()
        {
            QteMovimentos--;
        }

        public bool ValidarMovimentosPossiveis()
        {
            bool[,] matriz = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if(matriz[i,j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool ValidarMovimentoDestino(Posicao posicao)
        {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }

}
