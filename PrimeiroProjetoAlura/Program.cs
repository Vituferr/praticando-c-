//ScreenSound
string msgDeBoasVindas = "Boas vindas ao ScreenSound";
//List<string> listaDasBandas = new List<string> { "Slipknot", "MC Poze do Rodo", "Michael Jackson"}; 

Dictionary<string,List<int>> BandasRegistradas = new Dictionary<string,List<int>>();
BandasRegistradas.Add("Linkin Park", new List<int> { 10, 9, 8 });
BandasRegistradas.Add("The Beatles", new List<int> { 2, 5, 9 ,10 });

void exibirLogo()
{
    Console.WriteLine(@"
    █▀▀ █▀▀ █▀▀█ █▀▀ █▀▀ █▀▀▄ 　 █▀▀ █▀▀█ █░░█ █▀▀▄ █▀▀▄ 
    ▀▀█ █░░ █▄▄▀ █▀▀ █▀▀ █░░█ 　 ▀▀█ █░░█ █░░█ █░░█ █░░█ 
    ▀▀▀ ▀▀▀ ▀░▀▀ ▀▀▀ ▀▀▀ ▀░░▀ 　 ▀▀▀ ▀▀▀▀ ░▀▀▀ ▀░░▀ ▀▀▀░ 
");
    Console.WriteLine(msgDeBoasVindas);
}

void ExibirMenu()
{
    exibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.WriteLine("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaN = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaN)
    {
        case 1: RegistrarBanda(); 
            break;
        case 2: MostrasBandaRegistrada(); 
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMediaDaBanda(); 
            break;
        case -1: Console.WriteLine("Até mais, espero que volte. :) "); 
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    BandasRegistradas.Add(nomeDaBanda,new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();

}
void MostrasBandaRegistrada()
    {
    Console.Clear();
    ExibirTituloDaOpcao("Lista de Bandas");
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    foreach (string banda in BandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void AvaliarUmaBanda()
{
    // Digite a banda a avaliar
    // Se existir uma banda >> atribuir a nota.
    // Se não, volta pro menu principal.

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda.");
    Console.Write("Digite a banda que deseja avaliar: ");
    string nomedaBanda = Console.ReadLine()!;
    if (BandasRegistradas.ContainsKey(nomedaBanda))
    {
        Console.Write("Qual a nota que a banda merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        BandasRegistradas[nomedaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomedaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirMenu();
    } else {
        Console.WriteLine($"A Banda {nomedaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }

}

void ExibirMediaDaBanda()
{
    // Saber qual banda exibir a nota
    // Exibir a média.
    Console.Clear();
    ExibirTituloDaOpcao("Media de notas");
    Console.Write("Digite qual banda você quer verificar a nota: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (BandasRegistradas.ContainsKey(nomeDaBanda))
    {

        List<int> mediaDaNota = BandasRegistradas[nomeDaBanda];
        Console.WriteLine($"A media de nota da banda {nomeDaBanda} é de {mediaDaNota.Average()}");
        /* double notaBanda = BandasRegistradas[nomeDaBanda].Average();
        Console.WriteLine($"{nomeDaBanda} possui uma nota de {notaBanda} ");
        */
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal. ");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
        
    } else {
        Console.WriteLine("A banda não foi encontrada");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }


}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

ExibirMenu();