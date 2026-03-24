using ControleCandidaturas.Models;
using ControleCandidaturas.Services;

var service = new CandidaturaService();

while (true)
{
    Console.WriteLine("\n1 - Adicionar");
    Console.WriteLine("2 - Listar");
    Console.WriteLine("3 - Atualizar status");
    Console.WriteLine("0 - Sair");

    var op = Console.ReadLine();

    if (op == "1")
    {
        Console.Write("Empresa: ");
        string empresa = Console.ReadLine() ?? "";

        Console.Write("Cargo: ");
        string cargo = Console.ReadLine() ?? "";

        var candidatura = new Candidatura
        {
            Empresa = empresa,
            Cargo = cargo,
            DataAplicacao = DateTime.Now,
            Status = "Enviado"
        };

        service.Adicionar(candidatura);
    }
    else if (op == "2")
    {
        var lista = service.Listar();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma candidatura cadastrada.");
            continue;
        }

        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"{i} - {lista[i].Empresa} - {lista[i].Cargo} - {lista[i].Status}");
        }
    }
    else if (op == "3")
    {
        var lista = service.Listar();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma candidatura cadastrada.");
            continue;
        }

        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"{i} - {lista[i].Empresa} - {lista[i].Status}");
        }

        Console.Write("Escolha o índice: ");

        if (!int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine("Índice inválido.");
            continue;
        }

        Console.Write("Novo status: ");
        string status = Console.ReadLine() ?? "";

        service.AtualizarStatus(index, status);

        Console.WriteLine("Status atualizado!");
    }
    else if (op == "0")
    {
        break;
    }
    else
    {
        Console.WriteLine("Opção inválida.");
    }
}