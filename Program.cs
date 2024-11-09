namespace controle_estoque;

class Program
{
    static void Main(string[] args)
    {
        Jogo warcraft3 = new Jogo(
            "Warcraft 3",
            2002,
            "Blizzard Entertainment",
            "Estratégia em Tempo Real"
        );

        warcraft3.Preco = 99.90f;

        Console.WriteLine(warcraft3.Informacoes());
        Console.WriteLine(warcraft3.Detalhes());
    }
}
