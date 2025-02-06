using System.Text.Json.Serialization;

namespace Domain;

public class ConsultaDTO
{
    [JsonIgnore]
    public int Id { get; set; }    
    public int IdMedico { get; set; }
    public int IdPaciente { get; set; }    
    public int IdHorarioDisponivel {  get; set; }    
    
}