class Tela
{
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
        Console.WriteLine("[0] Sair");
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
            case 0:
                Sair();
                break;
            case 1:
                AdicionarJogo();
                break;
            case 2:
                ListarJogos();
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
        Console.Write("Em que ano ele foi lancado? ");
        int ano = Convert.ToInt32(Console.ReadLine()!);
        Console.Write("Quem desenvolveu esse jogo? ");
        string desenvolvedor = Console.ReadLine()!;
        Console.Write("Qual o gênero do jogo? ");
        string genero = Console.ReadLine()!;
        Console.Write("Informe o preço do jogo: ");
        double preco = Convert.ToDouble(Console.ReadLine()!);

        Jogo jogo = new Jogo(nome, ano, desenvolvedor, genero);
        jogo.Preco = preco;
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

}