using System.Text.Json.Serialization;

namespace Domain;

public class Consulta
{
    [JsonIgnore]
    public int Id { get; set; }    
    public int IdMedico { get; set; }
    public int IdPaciente { get; set; }    
    public int IdHorarioDisponivel {  get; set; }        
    public bool? IsAceita {  get; set; }    
    public bool? IsCancelada { get; set; }    
    public string? Justificativa { get; set; }

    public Consulta(int idMedico,int idPaciente, int IdHorarioDisponivel) { 
        this.IdMedico = idMedico;
        this.IdPaciente = idPaciente;
        this.IdHorarioDisponivel = IdHorarioDisponivel;       
    }
}