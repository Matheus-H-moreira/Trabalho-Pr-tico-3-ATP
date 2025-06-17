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
                    ConfigEspectador(ref contadorComum, ref nomeComum, ref idadeComum, ref numIngressoComum);
                    break;

                case 2:
                    ConfigEspectador(ref contadorPrioritario, ref nomePrioritario, ref idadePrioritario, ref numIngressoPrioritario);
                    break;

                case 3:
                    ConfigEspectador(ref contadorVIP, ref nomeVIP, ref idadeVIP, ref numIngressoVIP);
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

    static void ConfigEspectador(ref int i, ref string[] nomes, ref int[] idades, ref int[] numIngressos)
    {
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

        nomes[i] = nome;
        idades[i] = idade;
        numIngressos[i] = numIngresso;
        i++;
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

    }
}
