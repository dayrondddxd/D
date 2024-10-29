using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Application;
[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    private readonly DBContext context;
    public TareasController(DBContext dBContext){
        context = dBContext;
    }
    [HttpPost("AñadirTareas")]
    public async Task<IActionResult> AñadirTareas([FromBody]RegistrarTareas tareas){
        Tareas nuevaTarea = new Tareas{
            Autor = tareas.Autor,
            DescripcionTarea = tareas.DescripcionTarea,
            NombreTarea = tareas.NombreTarea
        };
        await context.Tareas.AddAsync(nuevaTarea);
        await context.SaveChangesAsync();
        return Ok("Tarea Añadida");
    }
    [HttpGet("ObtenerTareas")]
    public async Task<IActionResult> ObtenerTareas(){
        var tareas = await context.Tareas.ToListAsync();
        if(!tareas.Any()){
            return NotFound("No hay tareas");
        }
        return Ok(tareas);
    }
    [HttpGet("ObtenerTareasPorId/{id}")]
    public async Task<IActionResult> ObtenerTareasPorId(int id){
        var tareas = await context.Tareas.FindAsync(id);
        if(tareas == null){
            return NotFound("La tarea no existe");
        }
        return Ok(tareas);
    }
    [HttpPatch("ModificarTareas/{id}")]
    public async Task<IActionResult> ModificarTareas([FromBody] RegistrarTareas tareas , int id){
        var tarea = await context.Tareas.FindAsync(id);
        if(tarea == null){
            return NotFound("La tarea no existe");
        }
        tarea.Autor = tareas.Autor;
        tarea.DescripcionTarea = tareas.DescripcionTarea;
        tarea.NombreTarea = tareas.NombreTarea;
        context.Entry(tarea).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok("Tarea Modificada");
    }
    [HttpDelete("EliminarTareas/{id}")]
    public async Task<IActionResult> EliminarTareas(int id){
        var tareas = await context.Tareas.FindAsync(id);
        if(tareas == null){
            return NotFound("La tarea no existe");
        }
        context.Tareas.Remove(tareas);
        await context.SaveChangesAsync();
        return Ok("Tarea Eliminada");
    }

}