namespace Domain;

public class HorarioDisponivel
{
    public int Id { get; set; }    
    public int IdMedico { get; set; }
    public DateTime DataHoraConsulta { get; set; }    
    public decimal ValorConsulta { get; set; }
}