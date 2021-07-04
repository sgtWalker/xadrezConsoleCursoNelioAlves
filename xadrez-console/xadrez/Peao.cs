using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;
        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) 
        {
            this.Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }
        private bool VerificarExistenciaInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool VerificarCasaLivre(Posicao posicao)
        {
            return Tabuleiro.Peca(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            //Posições possíveis de um peão: Branco só pra cima, preto só pra baixo ou vice-versa, depende de como estão posicionados no tabuleiro as cores;
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && VerificarCasaLivre(posicao))
                    matriz[posicao.Linha, posicao.Coluna] = true;

                posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao posicaoDois = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicaoDois) && VerificarCasaLivre(posicaoDois) && Tabuleiro.PosicaoValida(posicao) && VerificarCasaLivre(posicao) && QteMovimentos == 0)
                    matriz[posicao.Linha, posicao.Coluna] = true;

                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && VerificarExistenciaInimigo(posicao))
                    matriz[posicao.Linha, posicao.Coluna] = true;

                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && VerificarExistenciaInimigo(posicao))
                    matriz[posicao.Linha, posicao.Coluna] = true;

                //jogada especial en passant
                if (Posicao.Linha == 3)
                {
                    Posicao posicaoEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(posicaoEsquerda) && VerificarExistenciaInimigo(posicaoEsquerda) && Tabuleiro.Peca(posicaoEsquerda) == Partida.VulneravelEnPassant)
                    {
                        matriz[posicaoEsquerda.Linha - 1, posicaoEsquerda.Coluna] = true;
                    }
                    Posicao posicaoDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(posicaoDireita) && VerificarExistenciaInimigo(posicaoDireita) && Tabuleiro.Peca(posicaoDireita) == Partida.VulneravelEnPassant)
                    {
                        matriz[posicaoDireita.Linha - 1, posicaoDireita.Coluna] = true;
                    }
                }
            }
            else
            {
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && VerificarCasaLivre(posicao))
                    matriz[posicao.Linha, posicao.Coluna] = true;

                posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao posicaoDois = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicaoDois) && VerificarCasaLivre(posicaoDois) && Tabuleiro.PosicaoValida(posicao) && VerificarCasaLivre(posicao) && QteMovimentos == 0)
                    matriz[posicao.Linha, posicao.Coluna] = true;

                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && VerificarExistenciaInimigo(posicao))
                    matriz[posicao.Linha, posicao.Coluna] = true;

                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && VerificarExistenciaInimigo(posicao))
                    matriz[posicao.Linha, posicao.Coluna] = true;

                //jogada especial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao posicaoEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(posicaoEsquerda) && VerificarExistenciaInimigo(posicaoEsquerda) && Tabuleiro.Peca(posicaoEsquerda) == Partida.VulneravelEnPassant)
                    {
                        matriz[posicaoEsquerda.Linha + 1, posicaoEsquerda.Coluna] = true;
                    }
                    Posicao posicaoDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(posicaoDireita) && VerificarExistenciaInimigo(posicaoDireita) && Tabuleiro.Peca(posicaoDireita) == Partida.VulneravelEnPassant)
                    {
                        matriz[posicaoDireita.Linha + 1, posicaoDireita.Coluna] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
