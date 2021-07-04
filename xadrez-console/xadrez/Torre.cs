using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }
        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            //posicoes possíveis de uma torre: Qualquer direção, exceto na diagonal e enquanto possuírem casas livres ou até encontrar uma peça adversária
            //N X N
            //X T X
            //N X N

            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);
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
