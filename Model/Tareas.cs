using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Application;
public class Tareas
{
    [Key]
    public int IdTarea { get; set; }
    public required string NombreTarea { get; set; }
    public required string DescripcionTarea { get; set; }
    public required string Autor { get; set; }
}