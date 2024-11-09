class GerenciadorEstoque
{
    private Jogo[] Jogos = [];

    public GerenciadorEstoque()
    {
        CargaInicial();
    }

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

    public void AlterarPreco(int posicao, float preco)
    {
        Jogos[posicao].Preco = preco;
    }

    private void CargaInicial()
    {
        Jogo warcraft3 = new Jogo(
            "Warcraft 3",
            2002,
            "Blizzard Entertainment",
            "Estratégia em tempo real"
        );
        warcraft3.Preco = 79.90f;

        Jogo morrowind = new Jogo(
            "The Elder Scrolls III: Morrowind",
            2002,
            "Bethesda Game Studios",
            "RPG de ação"
        );
        morrowind.Preco = 90.00f;

        Jogo maxPayne = new Jogo(
            "Max Payne",
            2001,
            "Remedy Entertainment",
            "Tiro em terceira pessoa"
        );
        maxPayne.Preco = 60.00f;

        Jogo diablo2 = new Jogo(
            "Diablo II",
            2000,
            "Blizzard Entertainment",
            "RPG de ação"
        );
        diablo2.Preco = 60.00f;

        AdicionarJogo(warcraft3);
        AdicionarJogo(morrowind);
        AdicionarJogo(maxPayne);
        AdicionarJogo(diablo2);
    }
}