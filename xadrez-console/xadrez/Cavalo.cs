using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "C";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            //posicoes possíveis de um cavalo: anda em L, dois pra um
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            //X X X
            //N N C
            //N N N
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            //N X X
            //N N X
            //N N C
            posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            //N X X
            //N X N
            //N C N
            posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            //N N N
            //X X X
            //C N N
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            //N N N
            //C N N
            //X X X
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            //C N N
            //X N N
            //X X N
            posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            //N C N
            //N X N
            //X X N
            posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            //N N C
            //X X X
            //N N N
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                matriz[posicao.Linha, posicao.Coluna] = true;

            return matriz;
        }
    }
}
