class Tela
{
    public const int OPCAO_SAIDA = 0;
    private GerenciadorEstoque Gerenciador;

    public Tela(GerenciadorEstoque gerenciador)
    {
        Gerenciador = gerenciador;
    }

    public void ExibirMenu()
    {
        Console.WriteLine();
        Console.WriteLine("****** Bem-vindo à loja PC Gamer! ©2002 ******");
        Console.WriteLine("*** Os melhores jogos para o novo milênio! ***");
        Console.WriteLine();
        Console.WriteLine("O que você deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("[1] Adicionar novo jogo");
        Console.WriteLine("[2] Listar jogos");
        Console.WriteLine("[3] Detalhar jogo");
        Console.WriteLine("[4] Remover jogo");
        Console.WriteLine("[5] Adicionar ao estoque");
        Console.WriteLine("[6] Remover do estoque");
        Console.WriteLine($"[{OPCAO_SAIDA}] Sair");
    }

    public int LerOpcao()
    {
        try
        {
            Console.WriteLine();
            Console.Write("Informe uma opção: ");
            return Convert.ToInt32(Console.ReadLine()!);
        } 
        catch (Exception)
        {
            return -1;
        }
    }

    public void ExecutarAcao(int opcao)
    {
        switch (opcao)
        {
            case 1:
                AdicionarJogo();
                break;
            case 2:
                ListarJogos();
                break;
            case 3:
                DetalharJogo();
                break;
            case 4:
                RemoverJogo();
                break;
            case 5:
                AdicionarAoEstoque();
                break;
            case 6:
                RemoverDoEstoque();
                break;
            case OPCAO_SAIDA:
                Sair();
                break;
            default:
                OpcaoInvalida();
                break;
        }
    }
    private void AguardarInteracaoParaVoltarAoMenu()
    {      
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

    private void Sair()
    {
        Console.WriteLine();
        Console.WriteLine("Saindo da aplicação. Até breve!");
        Console.WriteLine();
    }

    private void AdicionarJogo()
    {
        Console.Clear();
        Console.WriteLine("Adicionar um novo jogo");
        Console.WriteLine();

        Console.Write("Qual o nome do jogo? ");
        string nome = Console.ReadLine()!;

        int? ano = TentarLerInteiro("Em que ano ele foi lançado? ");
        if (ano == null) return;

        Console.Write("Quem desenvolveu esse jogo? ");
        string desenvolvedor = Console.ReadLine()!;

        Console.Write("Qual o gênero do jogo? ");
        string genero = Console.ReadLine()!;

        double? preco = TentarLerDouble("Informe o preço do jogo: ");
        if (preco == null) return;

        Jogo jogo = new Jogo(nome, ano.Value, desenvolvedor, genero);
        jogo.Preco = preco.Value;
        Gerenciador.AdicionarJogo(jogo);

        Console.WriteLine();
        Console.WriteLine("Jogo adicionado com sucesso!");
        AguardarInteracaoParaVoltarAoMenu();
    }

    private void ListarJogos()
    {
        Console.Clear();
        Console.WriteLine("Jogos cadastrados");
        Console.WriteLine();
        Gerenciador.ListarJogos();
        AguardarInteracaoParaVoltarAoMenu();
    }

    private void DetalharJogo()
    {
        Console.Clear();
        Console.WriteLine("Detalhar jogo");
        Console.WriteLine();
        Gerenciador.ListarJogos();
        
        try
        {
            Console.WriteLine();
            int? numJogo = TentarLerInteiro("Informe o número do jogo a detalhar: ");
            if (numJogo == null) return;

            Console.WriteLine();
            Gerenciador.DetalharJogo(numJogo.Value - 1);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        AguardarInteracaoParaVoltarAoMenu();
    }

    private void RemoverJogo()
    {
        Console.Clear();
        Console.WriteLine("Remover jogo");
        Console.WriteLine();
        Gerenciador.ListarJogos();

        try
        {
            Console.WriteLine();
            int? numJogo = TentarLerInteiro("Informe o número do jogo a remover: ");
            if (numJogo == null) return;

            Console.WriteLine();
            Gerenciador.RemoverJogo(numJogo.Value - 1);
            Console.WriteLine("Jogo removido com sucesso!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        AguardarInteracaoParaVoltarAoMenu();
    }

    private void AdicionarAoEstoque()
    {
        Console.Clear();
        Console.WriteLine("Adicionar produtos ao estoque");
        Console.WriteLine();
        Gerenciador.ListarJogos();

        try
        {
            Console.WriteLine();
            int? numJogo = TentarLerInteiro("Informe o número do jogo que receberá a entrada de estoque: ");
            if (numJogo == null) return;

            int? adicaoEstoque = TentarLerInteiro("Quantos novos produtos serão adicionados? ");
            if (adicaoEstoque == null) return;

            Console.WriteLine();
            Gerenciador.AdicionarAoEstoque(numJogo.Value - 1, adicaoEstoque.Value);
            Console.WriteLine("O estoque do jogo foi atualizado!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        AguardarInteracaoParaVoltarAoMenu();
    }

    private void RemoverDoEstoque()
    {
        Console.Clear();
        Console.WriteLine("Remover produtos do estoque");
        Console.WriteLine();
        Gerenciador.ListarJogos();

        try
        {
            Console.WriteLine();
            int? numJogo = TentarLerInteiro("Informe o número do jogo que terá a saída de estoque: ");
            if (numJogo == null) return;

            int? remocaoEstoque = TentarLerInteiro("Quantos produtos serão removidos? ");
            if (remocaoEstoque == null) return;

            Console.WriteLine();
            Gerenciador.RemoverDoEstoque(numJogo.Value - 1, remocaoEstoque.Value);
            Console.WriteLine("O estoque do jogo foi atualizado!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }

        AguardarInteracaoParaVoltarAoMenu();
    }

    private void OpcaoInvalida()
    {
        Console.WriteLine();
        Console.WriteLine("Opção inválida!");

        int aguardarIteracoes = 3;
        while (aguardarIteracoes > 0)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"Você poderá tentar novamente em {aguardarIteracoes--}");
            Thread.Sleep(1000);
        }
        Console.Clear();
    }

    private int? TentarLerInteiro(string mensagem)
    {
        Console.Write(mensagem);

        if (int.TryParse(Console.ReadLine(), out int valor))
        {
            return valor;
        }

        Console.WriteLine();
        Console.WriteLine("Valor inválido.");
        AguardarInteracaoParaVoltarAoMenu();
        return null;
    }

    private double? TentarLerDouble(string mensagem)
    {
        Console.Write(mensagem);

        if (double.TryParse(Console.ReadLine(), out double valor))
        {
            return valor;
        }
        
        Console.WriteLine();
        Console.WriteLine("Valor inválido.");
        AguardarInteracaoParaVoltarAoMenu();
        return null;
    }
}