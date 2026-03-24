using ControleCandidaturas.Models;
using ControleCandidaturas.Services;

var service = new CandidaturaService();

while (true)
{
    Console.WriteLine("\n1 - Adicionar");
    Console.WriteLine("2 - Listar");
    Console.WriteLine("0 - Sair");

    var op = Console.ReadLine();

    if (op == "1")
    {
        Console.Write("Empresa: ");
        string empresa = Console.ReadLine();

        Console.Write("Cargo: ");
        string cargo = Console.ReadLine();

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

        foreach (var c in lista)
        {
            Console.WriteLine($"{c.Empresa} - {c.Cargo} - {c.Status}");
        }
    }
    else if (op == "0")
    {
        break;
    }
}