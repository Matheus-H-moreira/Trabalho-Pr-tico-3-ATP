class program
{
    static void ConfigVetor(ref string[] nomes, ref int[] idades, ref int[] numIngressos)
    {
        for (int i = 0; i < nomes.Length; i++)
        {
            nomes[i] = "";
            idades[i] = 0;
            numIngressos[i] = 0;
        }
    }
    static void EntradaEspectador(ref int contadorComum, ref string[] nomeComum, ref int[] idadeComum, ref int[] numIngressoComum, ref int contadorPrioritario, ref string[] nomePrioritario, ref int[] idadePrioritario, ref int[] numIngressoPrioritario, ref int contadorVIP, ref string[] nomeVIP, ref int[] idadeVIP, ref int[] numIngressoVIP)
    {
        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("----------MENU----------");
            System.Console.WriteLine("1. Ingresso Comum");
            System.Console.WriteLine("2. Ingresso Prioritário");
            System.Console.WriteLine("3. Ingresso VIP");
            System.Console.WriteLine("4. Sair");
            System.Console.WriteLine("------------------------");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ConfigEntradaEspectador(ref contadorComum, ref nomeComum, ref idadeComum, ref numIngressoComum);
                    break;

                case 2:
                    ConfigEntradaEspectador(ref contadorPrioritario, ref nomePrioritario, ref idadePrioritario, ref numIngressoPrioritario);
                    break;

                case 3:
                    ConfigEntradaEspectador(ref contadorVIP, ref nomeVIP, ref idadeVIP, ref numIngressoVIP);
                    break;

                case 4:
                    System.Console.WriteLine("Saindo[Aperte Enter]");
                    Console.ReadLine();
                    return;

                default:
                    System.Console.WriteLine("Opcão inválida[Aperte Enter]");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ConfigEntradaEspectador(ref int i, ref string[] nomes, ref int[] idades, ref int[] numIngressos)
    {
        int posicaoIngresso = 0;

        if (i > nomes.Length)
        {
            System.Console.WriteLine("Limite de ingressos atingidos");
            return;
        }

        Console.Write("Nome do espectador: ");
        string nome = Console.ReadLine();
        Console.Write("Idade do espectador: ");
        int idade = int.Parse(Console.ReadLine());
        int numIngresso;
        do
        {
            Console.Write("Número do ingresso (4 dígitos): ");
            numIngresso = int.Parse(Console.ReadLine());

            if (numIngresso < 1000 || numIngresso > 9999)
            {
                Console.WriteLine("Número inválido. Digite um número de 4 dígitos.");
            }
        } while (numIngresso < 1000 || numIngresso > 9999);

        for (int j = 0; j < nomes.Length; j++)
        {
            if (idades[j] == 0)
            {
                posicaoIngresso = j;
                break;
            }
        }

        nomes[posicaoIngresso] = nome;
        idades[posicaoIngresso] = idade;
        numIngressos[posicaoIngresso] = numIngresso;
        i++;

        System.Console.WriteLine("Entrada realizada com sucesso! [Aperte Enter]");
        Console.ReadLine();
    }
    static void SaidaEspectador(ref int contadorComum, ref string[] nomeComum, ref int[] idadeComum, ref int[] numIngressoComum, ref int contadorPrioritario, ref string[] nomePrioritario, ref int[] idadePrioritario, ref int[] numIngressoPrioritario, ref int contadorVIP, ref string[] nomeVIP, ref int[] idadeVIP, ref int[] numIngressoVIP)
    {
        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("----------MENU----------");
            System.Console.WriteLine("1. Ingresso Comum");
            System.Console.WriteLine("2. Ingresso Prioritário");
            System.Console.WriteLine("3. Ingresso VIP");
            System.Console.WriteLine("4. Sair");
            System.Console.WriteLine("------------------------");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ConfigSaidaEspectador(ref contadorComum, ref nomeComum, ref idadeComum, ref numIngressoComum);
                    break;

                case 2:
                    ConfigSaidaEspectador(ref contadorPrioritario, ref nomePrioritario, ref idadePrioritario, ref numIngressoPrioritario);
                    break;

                case 3:
                    ConfigSaidaEspectador(ref contadorVIP, ref nomeVIP, ref idadeVIP, ref numIngressoVIP);
                    break;

                case 4:
                    System.Console.WriteLine("Saindo[Aperte Enter]");
                    Console.ReadLine();
                    return;

                default:
                    System.Console.WriteLine("Opcão inválida[Aperte Enter]");
                    Console.ReadLine();
                    break;

            }
        }
    }
    static void ConfigSaidaEspectador(ref int i, ref string[] nomes, ref int[] idades, ref int[] numIngressos)
    {
        int posicaoIngresso = 0, numIngresso;

        do
        {
            Console.Write("Número do ingresso (4 dígitos): ");
            numIngresso = int.Parse(Console.ReadLine());

            if (numIngresso < 1000 || numIngresso > 9999)
            {
                Console.WriteLine("Número inválido. Digite um número de 4 dígitos.");
            }
        } while (numIngresso < 1000 || numIngresso > 9999);

        for (int j = 0; j < numIngressos.Length; j++)
        {
            if (numIngresso == numIngressos[j])
            {
                posicaoIngresso = j;
                break;
            }
        }

        nomes[posicaoIngresso] = "";
        idades[posicaoIngresso] = 0;
        numIngressos[posicaoIngresso] = 0;
        i--;

        System.Console.WriteLine("Saída realizada com sucesso! [Aperte Enter]");
        Console.ReadLine();
    }
    static void Main()
    {
        const int ingressoComum = 50, ingressoPrioritario = 30, ingressoVIP = 20;
        string[] nomeComum = new string[ingressoComum], nomePrioritario = new string[ingressoPrioritario], nomeVIP = new string[ingressoVIP];
        int[] idadeComum = new int[ingressoComum], idadePrioritario = new int[ingressoPrioritario], idadeVIP = new int[ingressoVIP];
        int[] numIngressoComum = new int[ingressoComum], numIngressoPrioritario = new int[ingressoPrioritario], numIngressoVIP = new int[ingressoVIP];
        int contadorComum = 0, contadorPrioritario = 0, contadorVIP = 0;

        ConfigVetor(ref nomeComum, ref idadeComum, ref numIngressoComum);
        ConfigVetor(ref nomePrioritario, ref idadePrioritario, ref numIngressoPrioritario);
        ConfigVetor(ref nomeVIP, ref idadeVIP, ref numIngressoVIP);

        System.Console.WriteLine("----------MENU----------");
        System.Console.WriteLine("1. Entrada de espectador");
        System.Console.WriteLine("2. Saída de espectador");
        System.Console.WriteLine("3. Consultar ingressos disponíveis");
        System.Console.WriteLine("4. Exibir resumo do evento");
        System.Console.WriteLine("5. Listar todos os espectadores");
        System.Console.WriteLine("6. Sair");
        System.Console.WriteLine("------------------------");
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                EntradaEspectador(ref contadorComum, ref nomeComum, ref idadeComum, ref numIngressoComum, ref contadorPrioritario, ref nomePrioritario, ref idadePrioritario, ref numIngressoPrioritario, ref contadorVIP, ref nomeVIP, ref idadeVIP, ref numIngressoVIP);
                break;

            case 2:
                SaidaEspectador(ref contadorComum, ref nomeComum, ref idadeComum, ref numIngressoComum, ref contadorPrioritario, ref nomePrioritario, ref idadePrioritario, ref numIngressoPrioritario, ref contadorVIP, ref nomeVIP, ref idadeVIP, ref numIngressoVIP);
                break;
        }
    }
}
