using System;
using System.Collections.Generic;

using PTI;

 class Program
    {
        static void Main(string[] args)
        {

List<Produto> listaDeProdutos = new List<Produto>();
bool executar = true;

while (executar)
{
    Console.Clear(); // Limpa o console antes de exibir o menu novamente.
    Console.WriteLine(" === Menu de opções ===");
    Console.WriteLine("1. Novo Produto");
    Console.WriteLine("2. Lista de Produtos");
    Console.WriteLine("3. Remover Produto");
    Console.WriteLine("4. Entrada de Estoque");
    Console.WriteLine("5. Saída de Estoque");
    Console.WriteLine("0. Sair");
    Console.Write("Escolha a opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        //captura dos dados
        case "1":
            Console.Write("Informe o nome do chinelo: ");
            string nome = Console.ReadLine();  // Armazena o nome do produto.

            Console.Write("Informe o tamanho: ");
            string tamanho = Console.ReadLine();  // Armazena o tamanho.

            Console.Write("Informe a cor: ");
            string cor = Console.ReadLine();  // Armazena a cor.

            //Console.Write("Informe o preço: ");
            //string preco = Console.ReadLine();  // Armazena o preço.

            Console.Write("Informe o preço: ");
            double preco;
            while (!double.TryParse(Console.ReadLine(), out preco)){

                 Console.WriteLine("Por favor, insira um valor válido para o preço.");
                 Console.Write("Informe o preço: ");
            }

            // Criação de produto à lista
            Produto novoProduto = new Produto(nome, tamanho, cor, preco);
            listaDeProdutos.Add(novoProduto);

            // Mensagem de cofirmaçação
            Console.WriteLine ("\nProduto adicionado com sucesso");

            // Exibe os dados inseridos.
                Console.WriteLine($"\nProduto adicionado:\nNome: {nome}\nTamanho: {tamanho}\nCor: {cor}\nPreço: {preco}\n");
            break;

            case "2":

            // Exibição da lista de produtos
            if (listaDeProdutos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado");
            }

            else
            {
                Console.WriteLine("Lista de Produtos:");
                int contador = 1;

                foreach (Produto produto in listaDeProdutos){

                
                Console.WriteLine($"{contador} Nome: {produto.Nome}, Tamanho: {produto.Tamanho}, Cor: {produto.Cor}, Preço: {produto.Preco:C}");
                contador++;
        
            }

        }

            break;


            case "3":
            // Remover Produto

            if (listaDeProdutos.Count == 0)
            {
                Console.WriteLine ("Nenhum produto cadastrado");
            }

            else 
            {
                Console.WriteLine("Lista de Produtos:");

                // Exibir produto numerados

                int contador = 1;
                foreach (Produto produto in listaDeProdutos){
                    Console.WriteLine($"{contador}. Nome: {produto.Nome}, Tamanho: {produto.Tamanho}, Cor: {produto.Cor}, Preço: {produto.Preco:C}");
            contador++;
                }

                Console.WriteLine("Informe o número do produto que deseja remover: ");
                string input = Console.ReadLine();

                // Tentar converter a entrada para um número inteiro
        if (int.TryParse(input, out int numeroProduto) && numeroProduto > 0 && numeroProduto <= listaDeProdutos.Count)
        {
            // Remover o produto com base no índice (número - 1)
            listaDeProdutos.RemoveAt(numeroProduto - 1);
            Console.WriteLine("Produto removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Número inválido. Nenhum produto foi removido.");
        }
    }
        break;

        case "4":
    // Entrada de Estoque
    if (listaDeProdutos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
    }
    else
    {
        Console.WriteLine("Lista de Produtos para entrada de estoque:");
        
        // Exibe a lista numerada de produtos
        int contador = 1;
        foreach (Produto produto in listaDeProdutos)
        {
            Console.WriteLine($"{contador}. Nome: {produto.Nome}, Tamanho: {produto.Tamanho}, Cor: {produto.Cor}, Preço: {produto.Preco:C}, Estoque: {produto.Estoque}");
            contador++;
        }

        Console.Write("\nInforme o número do produto para adicionar ao estoque: ");
        string input = Console.ReadLine();

        // Verifica se a entrada é um número válido
        if (int.TryParse(input, out int numeroProduto) && numeroProduto > 0 && numeroProduto <= listaDeProdutos.Count)
        {
            Produto produtoSelecionado = listaDeProdutos[numeroProduto - 1]; // Seleciona o produto correspondente

            Console.Write($"Informe a quantidade para adicionar ao estoque de {produtoSelecionado.Nome}: ");
            string quantidadeInput = Console.ReadLine();

            // Verifica se a quantidade inserida é válida
            if (int.TryParse(quantidadeInput, out int quantidade) && quantidade > 0)
            {
                produtoSelecionado.Estoque += quantidade; // Adiciona a quantidade ao estoque do produto
                Console.WriteLine($"Quantidade de {quantidade} adicionada ao estoque de {produtoSelecionado.Nome}. Estoque atual: {produtoSelecionado.Estoque}");
            }
            else
            {
                Console.WriteLine("Quantidade inválida. Nenhuma alteração foi feita.");
            }
        }
        else
        {
            Console.WriteLine("Número inválido. Nenhuma alteração foi feita.");
        }
    }
    break;

        case "5":
    // Saída de Estoque

    if (listaDeProdutos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
    }

    else
    {
        Console.WriteLine("Selecione o produto para a saída do estoque:");
        int contador = 1;
        
        // Exibe os produtos numerados
        foreach (Produto produto in listaDeProdutos)
        {
            Console.WriteLine($"{contador}. Nome: {produto.Nome}, Estoque: {produto.Estoque}");
            contador++;
        }

    }
        
        Console.Write("Informe o numero do produto para remover do estoque: ");
        string inputSaida = Console.ReadLine();

        // Verifica se a entrada é um número válido
        if (int.TryParse(inputSaida, out int numeroProdutoSaida) && numeroProdutoSaida > 0 && numeroProdutoSaida <= listaDeProdutos.Count)
        {
            Produto produtoSelecionado = listaDeProdutos[numeroProdutoSaida - 1]; // Seleciona o produto correspondente

            Console.Write($"Informe a quantidade para remover do estoque de {produtoSelecionado.Nome}: ");
            string quantidadeSaidaInput = Console.ReadLine();

        // Verifica se a quantidade inserida é válida
            if (int.TryParse(quantidadeSaidaInput, out int quantidadeSaida) && quantidadeSaida > 0)
            {
                if (produtoSelecionado.Estoque >= quantidadeSaida)
                {
                    produtoSelecionado.Estoque -= quantidadeSaida; // Remove a quantidade do estoque do produto
                    Console.WriteLine($"Quantidade de {quantidadeSaida} removida do estoque de {produtoSelecionado.Nome}. Estoque atual: {produtoSelecionado.Estoque}");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente no estoque. Nenhuma alteração foi feita.");
                }
            }
            else
            {
                Console.WriteLine("Quantidade inválida. Nenhuma alteração foi feita.");
            }
        }
        else
        {
            Console.WriteLine("Número inválido. Nenhuma alteração foi feita.");
        }
    
    break;


        case "0":
            executar = false;
            Console.WriteLine("Encerrando o programa...");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();  // Aguarda uma tecla para voltar ao menu.
}

}

}

