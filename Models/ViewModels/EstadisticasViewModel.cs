namespace ColegioSanJose.Models.ViewModels;

public class EstadisticasViewModel
{
    public int TotalAlumnos { get; set; }
    public int TotalMaterias { get; set; }
    public int TotalExpedientes { get; set; }
    public decimal PromedioGeneral { get; set; }
    public List<AlumnoPromedioViewModel> AlumnosPromedio { get; set; } = new List<AlumnoPromedioViewModel>();
}

public class AlumnoPromedioViewModel
{
    public string NombreCompleto { get; set; } = string.Empty;
    public decimal Promedio { get; set; }
}
