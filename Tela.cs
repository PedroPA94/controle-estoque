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
        Console.WriteLine("Bem-vindo à loja PC Gamer!");
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
            case OPCAO_SAIDA:
                Sair();
                break;
            default:
                Console.WriteLine("Opção inválida, tente novamente.");
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
        Gerenciador.ListarJogos();
        AguardarInteracaoParaVoltarAoMenu();
    }

    private void DetalharJogo()
    {
        Console.Clear();
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