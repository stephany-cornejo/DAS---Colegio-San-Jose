using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ColegioSanJose.Models;
using ColegioSanJose.Models.DB;
using ColegioSanJose.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ColegioSanJose.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ColegioSanJoseContext _context;

    public HomeController(ILogger<HomeController> logger, ColegioSanJoseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Expediente> off = new List<Expediente>();
        using (var bd = new Models.DB.ColegioSanJoseContext())
        {
            off = (from t in bd.Expedientes
               select new Expediente
                       
            {
            ExtpedienteId = t.ExtpedienteId,
            Alumno = new Alumno { Nombre = t.Alumno.Nombre + " " + t.Alumno.Apellido},
            Materia = new Materia { NombreMateria = t.Materia.NombreMateria },
            NotaFinal = t.NotaFinal,
            Observaciones = t.Observaciones
            }).ToList();

            }
            return View(off);
        }

    public ActionResult NuevoExpediente()
    {
            
        using (var db = new ColegioSanJoseContext())
        {
            var alumnos = db.Alumnos.Select(a => new { a.AlumnoId, Name = a.Nombre + " " + a.Apellido }).ToList();
            var materias = db.Materia.Select(m => new { m.MateriaId, m.NombreMateria }).ToList();

            ViewBag.Alumnos = new SelectList(alumnos, "AlumnoId", "Name");
            ViewBag.Materias = new SelectList(materias, "MateriaId", "NombreMateria");
        }
        return View();
    }

    [HttpPost]
    public ActionResult NuevoExpediente(ExpedienteCreateViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                using (ColegioSanJoseContext db = new ColegioSanJoseContext())
                {
                    // Verificar si ya existe un registro con el mismo alumno y materia
                    var expedienteExistente = db.Expedientes
                        .FirstOrDefault(e => e.AlumnoId == model.AlumnoId && e.MateriaId == model.MateriaId);

                    if (expedienteExistente != null)
                    {
                        ModelState.AddModelError("", "Registro ya existente. Edite o cree uno nuevo.");
                        
                        // Cargar los datos para los dropdowns nuevamente
                        var alumnos = db.Alumnos.Select(a => new { a.AlumnoId, Name = a.Nombre + " " + a.Apellido }).ToList();
                        var materias = db.Materia.Select(m => new { m.MateriaId, m.NombreMateria }).ToList();

                        ViewBag.Alumnos = new SelectList(alumnos, "AlumnoId", "Name");
                        ViewBag.Materias = new SelectList(materias, "MateriaId", "NombreMateria");
                        
                        return View(model);
                    }

                    var expediente = new Expediente
                    {
                        AlumnoId = model.AlumnoId,
                        MateriaId = model.MateriaId,
                        NotaFinal = model.NotaFinal,
                        Observaciones = model.Observaciones
                    };

                    db.Expedientes.Add(expediente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } 
            }
            else
            {
                using (var db = new ColegioSanJoseContext())
                {
                    var alumnos = db.Alumnos.Select(a => new { a.AlumnoId, Name = a.Nombre + " " + a.Apellido }).ToList();
                    var materias = db.Materia.Select(m => new { m.MateriaId, m.NombreMateria }).ToList();

                    ViewBag.Alumnos = new SelectList(alumnos, "AlumnoId", "Name");
                    ViewBag.Materias = new SelectList(materias, "MateriaId", "NombreMateria");
                }
                return View(model);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IActionResult Editar(int id)
    {
        Expediente model = new Expediente();

        using (ColegioSanJoseContext db = new ColegioSanJoseContext())
        {
            var oTabla = db.Expedientes.Include(e => e.Alumno).Include(e => e.Materia).FirstOrDefault(e => e.ExtpedienteId == id);
            if (oTabla == null)
            {
                return NotFound();  
            }
            model.ExtpedienteId = oTabla.ExtpedienteId;
            model.Alumno = new Alumno
            {
                Nombre = oTabla.Alumno.Nombre,
                Apellido = oTabla.Alumno.Apellido,
                Grado = oTabla.Alumno.Grado,
                FechaNacimiento = oTabla.Alumno.FechaNacimiento
            };
            model.Materia = new Materia
            {
                NombreMateria = oTabla.Materia.NombreMateria,
                Docente = oTabla.Materia.Docente
            };
                model.NotaFinal = oTabla.NotaFinal;
                model.Observaciones = oTabla.Observaciones;
            }
            return View("EditarExpediente", model);
        }

    [HttpPost]
    public IActionResult Actualizar(Expediente model)
    {
        try
        {
            using (ColegioSanJoseContext db = new ColegioSanJoseContext())
            {
                var viewnew = db.Expedientes.FirstOrDefault(e => e.ExtpedienteId == model.ExtpedienteId);

                if (viewnew != null)
                {
                    viewnew.NotaFinal = model.NotaFinal;
                    viewnew.Observaciones = model.Observaciones;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult Eliminar(int d)
    {
        Expediente model = new Expediente();

        using (ColegioSanJoseContext db = new ColegioSanJoseContext())
        {
            try
            {
                var oTabla = db.Expedientes.Find(d);
                if (oTabla != null)
                {
                    db.Expedientes.Remove(oTabla);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        return Redirect("/Home/");
    }
    public IActionResult Estadisticas()
    {
        using (var db = new ColegioSanJoseContext())
        {
                
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
