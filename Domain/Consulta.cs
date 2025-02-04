using System.Text.Json.Serialization;

namespace Domain;

public class Consulta
{
    [JsonIgnore]
    public int Id { get; set; }    
    public int IdMedico { get; set; }
    public int IdPaciente { get; set; }    
    public int IdHorarioDisponivel {  get; set; }
    
    [JsonIgnore]
    public bool? IsAceita {  get; set; }
}