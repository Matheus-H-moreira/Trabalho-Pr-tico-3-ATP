class Program
{
    const int MAX_INGRESSOS = 100;

    static string nomeCidade = "";
    static int MAX_COMUM = 0;
    static int MAX_PRIORITARIO = 0;
    static int MAX_VIP = 0;

    static string[] nomes = new string[MAX_INGRESSOS];
    static int[] idades = new int[MAX_INGRESSOS];
    static int[] numerosIngresso = new int[MAX_INGRESSOS];
    static string[] tipos = new string[MAX_INGRESSOS];

    static int totalEntradas = 0;
    static int totalSaidas = 0;

    static string ultimoNomeEntrada = "", ultimoTipoEntrada = "";
    static int ultimaIdadeEntrada = 0, ultimoNumEntrada = 0;

    static string ultimoNomeSaida = "", ultimoTipoSaida = "";
    static int ultimaIdadeSaida = 0, ultimoNumSaida = 0;

    static void Main()
    {
        CarregarDadosIniciais(out nomeCidade, out MAX_VIP, out MAX_PRIORITARIO, out MAX_COMUM);
        int opcao;

        do
        {
            opcao = Menu();

            switch (opcao)
            {
                case 1:
                    RegistrarEntrada(nomes, idades, numerosIngresso, tipos);
                    break;
                case 2:
                    RegistrarSaida(nomes, idades, numerosIngresso, tipos);
                    break;
                case 3:
                    ConsultarIngressos(MAX_VIP, MAX_PRIORITARIO, MAX_COMUM);
                    break;
                case 4:
                    ExibirResumo();
                    break;
                case 5:
                    ListarEspectadores();
                    break;
                case 6:
                    Console.WriteLine("Encerrando o programa... [Aperte Enter]");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opção inválida [Aperte Enter]");
                    Console.ReadLine();
                    break;
            }

        } while (opcao != 6);
    }

    static int Menu()
    {
        Console.Clear();
        Console.WriteLine("----- EVENTO EM " + nomeCidade.ToUpper() + " -----");
        Console.WriteLine("1. Registrar entrada");
        Console.WriteLine("2. Registrar saída");
        Console.WriteLine("3. Consultar ingressos disponíveis");
        Console.WriteLine("4. Exibir resumo");
        Console.WriteLine("5. Listar todos os espectadores");
        Console.WriteLine("6. Sair");
        Console.WriteLine("-------------------------------");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static void RegistrarEntrada(string[] nomes, int[] idades, int[] numerosIngresso, string[] tipos)
    {
        if (totalEntradas >= MAX_INGRESSOS)
        {
            Console.WriteLine("Limite máximo de ingressos atingido.");
            Console.ReadLine();
            return;
        }

        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Idade: ");
        int idade = int.Parse(Console.ReadLine());

        int numIngresso;
        do
        {
            Console.Write("Número do ingresso (4 dígitos): ");
            numIngresso = int.Parse(Console.ReadLine());
        } while (numIngresso < 1000 || numIngresso > 9999);

        string tipo;
        do
        {
            Console.Write("Tipo (Comum / Prioritario / VIP): ");
            tipo = Console.ReadLine().ToLower();
        } while (tipo != "comum" && tipo != "prioritario" && tipo != "vip");

        int qtdCom = 0, qtdPri = 0, qtdVip = 0;

        for (int i = 0; i < totalEntradas; i++)
        {
            if (tipos[i] == "comum")
            {
                qtdCom++;
            }
            else if (tipos[i] == "prioritario")
            {
                qtdPri++;
            }
            else if (tipos[i] == "vip")
            {
                qtdVip++;
            }
        }

        if ((tipo == "comum" && qtdCom >= MAX_COMUM) || (tipo == "prioritario" && qtdPri >= MAX_PRIORITARIO) || (tipo == "vip" && qtdVip >= MAX_VIP))
        {
            Console.WriteLine("Ingressos esgotados para essa categoria. [Aperte Enter]");
            Console.ReadLine();
            return;
        }

        nomes[totalEntradas] = nome;
        idades[totalEntradas] = idade;
        numerosIngresso[totalEntradas] = numIngresso;
        tipos[totalEntradas] = tipo;
        totalEntradas++;

        ultimoNomeEntrada = nome;
        ultimaIdadeEntrada = idade;
        ultimoNumEntrada = numIngresso;
        ultimoTipoEntrada = tipo;

        Console.WriteLine("Entrada registrada com sucesso! [Aperte Enter]");
        Console.ReadLine();
    }

    static void RegistrarSaida(string[] nomes, int[] idades, int[] numerosIngresso, string[] tipos)
    {
        Console.Write("Número do ingresso (4 dígitos): ");
        int num = int.Parse(Console.ReadLine());

        bool encontrado = false;

        for (int i = 0; i < totalEntradas; i++)
        {
            if (numerosIngresso[i] == num && !string.IsNullOrEmpty(nomes[i]))
            {
                ultimoNomeSaida = nomes[i];
                ultimaIdadeSaida = idades[i];
                ultimoNumSaida = numerosIngresso[i];
                ultimoTipoSaida = tipos[i];

                nomes[i] = "";
                idades[i] = 0;
                numerosIngresso[i] = 0;
                tipos[i] = "";

                totalSaidas++;
                encontrado = true;
                break;
            }
        }

        Console.WriteLine(encontrado ? "Saída registrada com sucesso! [Aperte Enter]" : "Ingresso não encontrado. [Aperte Enter]");
        Console.ReadLine();
    }

    static void ConsultarIngressos(int vip, int prioritario, int comum)
    {
        int vipUsados = 0, priUsados = 0, comUsados = 0;

        for (int i = 0; i < totalEntradas; i++)
        {
            if (tipos[i] == "vip") vipUsados++;
            else if (tipos[i] == "prioritario") priUsados++;
            else if (tipos[i] == "comum") comUsados++;
        }

        string saida = $"Cidade: {nomeCidade}\n";
        saida += "Ingressos disponíveis:\n";
        saida += $"VIP: {vip - vipUsados}\n";
        saida += $"Prioritário: {prioritario - priUsados}\n";
        saida += $"Comum: {comum - comUsados}";

        Console.WriteLine(saida);
        EscreverSaida(saida);

        Console.WriteLine("\nAperte Enter");
        Console.ReadLine();
    }

    static void ExibirResumo()
    {
        int vip = 0, pri = 0, com = 0;

        for (int i = 0; i < totalEntradas; i++)
        {
            if (!string.IsNullOrEmpty(tipos[i]))
            {
                if (tipos[i] == "vip") vip++;
                else if (tipos[i] == "prioritario") pri++;
                else if (tipos[i] == "comum") com++;
            }
        }

        int totalPresentes = vip + pri + com;

        string resumo = $"Cidade: {nomeCidade}\n";
        resumo += $"Total de espectadores: {totalPresentes}\n";
        resumo += $"VIP: {vip} ({(totalPresentes > 0 ? (vip * 100.0 / totalPresentes) : 0):F2}%) | {MAX_VIP - vip} ingressos disponíveis\n";
        resumo += $"Prioritario: {pri} ({(totalPresentes > 0 ? (pri * 100.0 / totalPresentes) : 0):F2}%) | {MAX_PRIORITARIO - pri} ingressos disponíveis\n";
        resumo += $"Comum: {com} ({(totalPresentes > 0 ? (com * 100.0 / totalPresentes) : 0):F2}%) | {MAX_COMUM - com} ingressos disponíveis";

        Console.Clear();
        Console.WriteLine("===== RESUMO DO EVENTO =====");
        Console.WriteLine(resumo);

        if (!string.IsNullOrEmpty(ultimoNomeEntrada))
        {
            Console.WriteLine($"\nÚltimo espectador que entrou:");
            Console.WriteLine($"Nome: {ultimoNomeEntrada} | Idade: {ultimaIdadeEntrada} | Nº Ingresso: {ultimoNumEntrada} | Tipo: {ultimoTipoEntrada}");
        }

        if (!string.IsNullOrEmpty(ultimoNomeSaida))
        {
            Console.WriteLine($"\nÚltimo espectador que saiu:");
            Console.WriteLine($"Nome: {ultimoNomeSaida} | Idade: {ultimaIdadeSaida} | Nº Ingresso: {ultimoNumSaida} | Tipo: {ultimoTipoSaida}");
        }

        EscreverSaida(resumo);

        Console.WriteLine("\nAperte Enter");
        Console.ReadLine();
    }

    static void ListarEspectadores()
    {
        Console.Clear();
        Console.WriteLine("===== LISTA DE ESPECTADORES PRESENTES =====");

        string[] categorias = { "comum", "prioritario", "vip" };

        foreach (string categoria in categorias)
        {
            Console.WriteLine($"\nCategoria: {categoria.ToUpper()}");
            bool encontrou = false;

            for (int i = 0; i < totalEntradas; i++)
            {
                if (!string.IsNullOrEmpty(nomes[i]) && tipos[i] == categoria)
                {
                    Console.WriteLine($"Nome: {nomes[i]} | Idade: {idades[i]} | Ingresso: {numerosIngresso[i]} | Tipo: {tipos[i]}");
                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum espectador presente nesta categoria.");
            }
        }

        Console.WriteLine("\nAperte Enter");
        Console.ReadLine();
    }

    static void CarregarDadosIniciais(out string cidade, out int vip, out int prioritario, out int comum)
    {
        string[] linhas = File.ReadAllLines("show_in.txt");
        cidade = linhas[0];
        vip = int.Parse(linhas[1]);
        prioritario = int.Parse(linhas[2]);
        comum = int.Parse(linhas[3]);
    }

    static void EscreverSaida(string conteudo)
    {
        File.WriteAllText("show_out.txt", conteudo);
    }
}