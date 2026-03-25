using ControleCandidaturas.Models;
using System.Text.Json;

namespace ControleCandidaturas.Services;

public class CandidaturaService
{
    private List<Candidatura> lista = new();
    private string caminhoArquivo = "dados.json";

    public CandidaturaService()
    {
        Carregar();
    }

    public void Adicionar(Candidatura c)
    {
        lista.Add(c);
        Salvar();
    }

    public List<Candidatura> Listar()
    {
        return lista;
    }

    public void AtualizarStatus(int index, string novoStatus)
    {
        if (index >= 0 && index < lista.Count)
        {
            lista[index].Status = novoStatus;
            Salvar();
        }
    }

    public void Remover(int index)
    {
        if (index >= 0 && index < lista.Count)
        {
            lista.RemoveAt(index);
            Salvar();
        }
    }

    private void Salvar()
    {
        var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminhoArquivo, json);
    }

    private void Carregar()
    {
        if (File.Exists(caminhoArquivo))
        {
            var json = File.ReadAllText(caminhoArquivo);
            lista = JsonSerializer.Deserialize<List<Candidatura>>(json) ?? new List<Candidatura>();
        }
    }
}