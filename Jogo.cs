class Jogo
{
    public string Nome { get; init; }
    public int AnoLancamento { get; init; }
    public string Desenvolvedor { get; init; }
    public string Genero { get; init; }
    private int QtdEstoque { get; set; }

    private float _preco;
    public float Preco 
    { 
        get { return _preco; }
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("O preço não pode ser menor do que zero");
            }
            
            this._preco = value;
        } 
    }

    public Jogo(string nome, int ano, string produtora, string genero)
    {
        Nome = nome;
        AnoLancamento = ano;
        Desenvolvedor = produtora;
        Genero = genero;
        QtdEstoque = 0;
    }

    public string Informacoes()
    {
        return $"{Nome} (R$ {Preco}) - {QtdEstoque} em estoque";
    }

    public string Detalhes()
    {
        return $"{Nome} ({AnoLancamento})\nDesenvolvedor(a): {Desenvolvedor}\nGênero: {Genero}\nPreço: R$ {Preco}\nQuantidade em estoque: {QtdEstoque}";
    }

    public void AdicionarAoEstoque(int qtdAdicionada)
    {
        if (qtdAdicionada < 0)
        {
            throw new ArgumentException("A quantidade a adicionar não pode ser negativa");
        }

        QtdEstoque += qtdAdicionada;
    }

    public void RemoverDoEstoque(int qtdRemovida)
    {
        if (qtdRemovida < 0)
        {
            throw new ArgumentException("A quantidade a remover não pode ser negativa");
        }

        if (qtdRemovida > QtdEstoque) {
            throw new InvalidOperationException("Quantidade a remover é superior à quantidade em estoque");
        }

        QtdEstoque -= qtdRemovida;
    }
}