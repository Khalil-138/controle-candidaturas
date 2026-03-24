namespace ControleCandidaturas.Models;

public class Candidatura
{
    public string Empresa { get; set; }
    public string Cargo { get; set; }
    public DateTime DataAplicacao { get; set; }
    public string Status { get; set; }
    public string Observacoes { get; set; }
}