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
        VerificarPosicaoValida(posicao);

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

        VerificarPosicaoValida(posicao);
        Console.WriteLine($"{Jogos[posicao].Detalhes()}");
    }

    public void AlterarPreco(int posicao, float preco)
    {
        VerificarPosicaoValida(posicao);
        Jogos[posicao].Preco = preco;
    }

    public void AdicionarAoEstoque(int posicao, int adicaoEstoque)
    {
        VerificarPosicaoValida(posicao);
        Jogo jogo = Jogos[posicao];
        jogo.AdicionarAoEstoque(adicaoEstoque);
    }

    public void RemoverDoEstoque(int posicao, int remocaoEstoque)
    {
        VerificarPosicaoValida(posicao);
        Jogo jogo = Jogos[posicao];
        jogo.RemoverDoEstoque(remocaoEstoque);
    }

    private void VerificarPosicaoValida(int posicao)
    {
        if (posicao < 0 || posicao > Jogos.Length - 1)
        {
            throw new ArgumentException("A posição informada é inválida. Ela deve ser um dos valores na lista de jogos.");
        }
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
        warcraft3.AdicionarAoEstoque(3);

        Jogo morrowind = new Jogo(
            "The Elder Scrolls III: Morrowind",
            2002,
            "Bethesda Game Studios",
            "RPG de ação"
        );
        morrowind.Preco = 90.00f;
        morrowind.AdicionarAoEstoque(4);

        Jogo maxPayne = new Jogo(
            "Max Payne",
            2001,
            "Remedy Entertainment",
            "Tiro em terceira pessoa"
        );
        maxPayne.Preco = 60.00f;
        maxPayne.AdicionarAoEstoque(1);

        Jogo diablo2 = new Jogo(
            "Diablo II",
            2000,
            "Blizzard Entertainment",
            "RPG de ação"
        );
        diablo2.Preco = 60.00f;
        diablo2.AdicionarAoEstoque(2);

        AdicionarJogo(warcraft3);
        AdicionarJogo(morrowind);
        AdicionarJogo(maxPayne);
        AdicionarJogo(diablo2);
    }
}