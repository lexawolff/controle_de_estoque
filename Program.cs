class Program
    {
    class Celular
    {
        public int Codigo;
        public string Modelo;
        public int Quantidade;
        public double Preco;
        public int NumeroSerie;
        public int Ano;
    }

    static List<Celular> estoque = new List<Celular>();

    public Program()
    {
    }

    static void NovoCelular()
    {
        Console.WriteLine("Digite o código do celular: ");
        int codigo = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o modelo do celular: ");
        string modelo = Console.ReadLine();

        Console.WriteLine("Digite o preço do celular: ");
        double preco = double.Parse(Console.ReadLine());

        Console.WriteLine("Digite o número de série do celular: ");
        int numeroSerie = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o ano de fabricação: ");
        int ano = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a quantidade em estoque: ");
        int quantidade = int.Parse(Console.ReadLine());

        Celular celular = new Celular { Codigo = codigo, Modelo = modelo, Quantidade = quantidade, Preco = preco, NumeroSerie = numeroSerie, Ano = ano };
        estoque.Add(celular);
        Console.WriteLine("Produto adicionado ao estoque. \n");
    }
    static void ListarCelular()
    {
        if (estoque.Count == 0)
        {
            Console.WriteLine("Nenhum Produto no estoque.\n");
        }
        else
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Código |    Modelo    |    Preço    | Número de Série | Ano de Fabricação | Quantidade |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

            foreach (Celular celular in estoque)
            {
                Console.WriteLine($"| {celular.Codigo,-6} | {celular.Modelo,-12} | {celular.Preco,-12} | {celular.NumeroSerie,-15} | {celular.Ano,-18} | {celular.Quantidade,-10} |");
            }

        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine();
        }
    }
    static void DeleteCelular()
    {
        Console.WriteLine("Digite o código do celular a ser removido: ");
        int codigo = int.Parse(Console.ReadLine());

        Celular DeleteCelular = estoque.Find(celular => celular.Codigo == codigo);

        if (DeleteCelular != null)
        {
            estoque.Remove(DeleteCelular);
            Console.WriteLine("Produto removido do estoque. \n");
        }
        else
        {
            Console.WriteLine("Produto não encontrado no estoque. \n");
        }
    }

    static void EntradaEstoque()
    {
        Console.WriteLine("Digite o código do produto que deseja dar entrada no estoque: ");
        int codigo = int.Parse(Console.ReadLine());

        Celular celularEntrada = estoque.Find(celular => celular.Codigo == codigo);

        if (celularEntrada != null)
        {
            Console.Write("Digite a quantidade a ser adicionada ao estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            celularEntrada.Quantidade += quantidade;
            Console.WriteLine("Entrada de estoque atualizada. \n");
        }
        else
        {
            Console.WriteLine("Produto não encontrado no estoque. \n");
        }
    }

    static void SaidaEstoque()
    {
        Console.WriteLine("Digite o códido do celular para a saída do estoque: ");
        int codigo = int.Parse(Console.ReadLine());

        Celular celularSaida = estoque.Find(celular => celular.Codigo == codigo);

        if(celularSaida != null)
        {
            Console.Write("Digite a quantidade a ser retirada do estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            if(celularSaida.Quantidade >= quantidade)
            {
                celularSaida.Quantidade -= quantidade;
                Console.WriteLine("Saída de estoque realizada. \n");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente em estoque.\n");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado no estoque.\n");
        }
    }

    static void Menu()
    {
        Console.WriteLine("||||||CONTROLE DE ESTOQUE - LOJA DE CELULARES|||||");

        Console.WriteLine("Escolha uma opção: \n");

        Console.WriteLine("[1]- Novo");
        Console.WriteLine("[2]- Listar Produtos");
        Console.WriteLine("[3]- Remover Produtos");
        Console.WriteLine("[4]- Entrada de Estoque");
        Console.WriteLine("[5]- Saída de Estoque");
        Console.WriteLine("[0]- Sair");

        string opcao =Console.ReadLine();

        switch (opcao)
        {
            case "1":
                NovoCelular();
                break;
            case "2":
                ListarCelular();
                break;
            case "3":
                DeleteCelular();
                break;
            case "4":
                EntradaEstoque();
                break;
            case "5":
                SaidaEstoque();
                break;
            case "0":
                Console.WriteLine("Saindo do programa..");
                return;
            default:
                Console.WriteLine("Opção inválida.\n");
                break;
        }
        Menu();
    }
    static void Main(string[] args)
    {
        Menu();
    }
    }
