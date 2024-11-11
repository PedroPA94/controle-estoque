namespace controle_estoque;

class Program
{
    static void Main(string[] args)
    {
        GerenciadorEstoque gerenciador = new GerenciadorEstoque();
        Tela tela = new Tela(gerenciador);
        int opcao = -1;

        while (opcao != 0)
        {
            tela.ExibirMenu();
            opcao = Convert.ToInt32(Console.ReadLine()!); 
            tela.ExecutarAcao(opcao);
        }
    }    
}
