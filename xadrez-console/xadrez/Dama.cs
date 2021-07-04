using tabuleiro;

namespace xadrez
{
    class Dama : Peca 
    {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "D";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            //posicoes possíveis de uma Dama: os mesmos de bispo e torre;
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

            //acima: /\
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

                //Se encontrar uma peça na posição e ela for adversária, tem que parar o while
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }

                //ando mais uma posição acima
                posicao.Linha = posicao.Linha - 1;
            }

            //abaixo: \/
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

                //Se encontrar uma peça na posição e ela for adversária, tem que parar o while
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }

                //ando mais uma posição abaixo
                posicao.Linha = posicao.Linha + 1;
            }

            //Direita: >
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

                //Se encontrar uma peça na posição e ela for adversária, tem que parar o while
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }

                //ando mais uma posição à direita
                posicao.Coluna = posicao.Coluna + 1;
            }

            //esquerda: <
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;

                //Se encontrar uma peça na posição e ela for adversária, tem que parar o while
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }

                //ando mais uma posição à esquerda
                posicao.Coluna = posicao.Coluna - 1;
            }

            return matriz;
        }
    }
}
