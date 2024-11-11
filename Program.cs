namespace controle_estoque;

class Program
{
    static void Main(string[] args)
    {
        GerenciadorEstoque gerenciador = new GerenciadorEstoque();
        Tela tela = new Tela(gerenciador);
        int opcao = -1;

        while (opcao != Tela.OPCAO_SAIDA)
        {
            tela.ExibirMenu();
            opcao = tela.LerOpcao();
            tela.ExecutarAcao(opcao);
        }
    }    
}
