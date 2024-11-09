class GerenciadorEstoque
{
    private Jogo[] Jogos = [];

    public void AdicionarJogo(Jogo jogo)
    {
        Jogo[] jogosAtualizados = new Jogo[Jogos.Length + 1];

        for (int i = 0; i < Jogos.Length; i++)
        {
            jogosAtualizados[i] = Jogos[i];
        }

        jogosAtualizados[jogosAtualizados.Length - 1] = jogo;
        Jogos = jogosAtualizados;
    }

    public void RemoverJogo(int posicao)
    {
        if (posicao < 0 || posicao > Jogos.Length - 1)
        {
            throw new ArgumentException("A posição informada é inválida. Ela deve ser um dos valores na lista de jogos.");
        }

        Jogo[] jogosAtualizados = new Jogo[Jogos.Length - 1];

        int aux = 0;

        for (int i = 0; i < Jogos.Length; i++)
        {
            if (i == posicao)
            {
                continue;
            }

            jogosAtualizados[aux++] = Jogos[i];
        }

        Jogos = jogosAtualizados;
    }

    public void ListarJogos()
    {
        if (Jogos.Length == 0)
        {
            Console.WriteLine("Não há jogos no estoque.");
            return;
        }

        for (int i = 0; i < Jogos.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Jogos[i].Informacoes()}");
        }
    }

    public void DetalharJogo(int posicao)
    {
        if (Jogos.Length == 0)
        {
            Console.WriteLine("Não há jogos no estoque.");
            return;
        }

        if (posicao < 0 || posicao > Jogos.Length - 1)
        {
            throw new ArgumentException("A posição informada é inválida. Ela deve ser um dos valores na lista de jogos.");
        }

        Console.WriteLine($"{Jogos[posicao].Detalhes()}");
    }
}