using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "B";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            //posições possíveis de Biso: só move nas diagonais;
            //X N X
            //N B N
            //X N X

            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            // /\ & >
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

                //Se encontrar uma peça na posição e ela for adversária, tem que parar o while
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                    break;

                //ando mais uma posição acima
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);               
            }

            // /\ & <
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

                //Se encontrar uma peça na posição e ela for adversária, tem que parar o while
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                    break;

                //ando mais uma posição acima
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
            }

            // \/ & >
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

                //Se encontrar uma peça na posição e ela for adversária, tem que parar o while
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                    break;

                //ando mais uma posição acima
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }

            // \/ & <
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

                //Se encontrar uma peça na posição e ela for adversária, tem que parar o while
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                    break;

                //ando mais uma posição acima
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }

            return matriz;
        }
    }
}
