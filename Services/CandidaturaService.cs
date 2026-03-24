using ControleCandidaturas.Models;

namespace ControleCandidaturas.Services;

public class CandidaturaService
{
    private List<Candidatura> lista = new();

    public void Adicionar(Candidatura c)
    {
        lista.Add(c);
    }

    public List<Candidatura> Listar()
    {
        return lista;
    }
}