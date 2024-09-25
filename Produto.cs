namespace PTI

{
    class Produto
    {
        public string Nome { get; set; }
        public string Tamanho { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
            public int Estoque { get; set; } //Propiedade para o estoque

        public Produto(string nome, string tamanho, string cor, double preco)
        {
            Nome = nome;
            Tamanho = tamanho;
            Cor = cor;
            Preco = preco;
            Estoque = 0; //Inicia o estoque em 0
        }
    }
}
