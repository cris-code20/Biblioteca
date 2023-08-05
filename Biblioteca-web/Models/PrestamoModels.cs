namespace Biblioteca_web.Models
{
	public class PrestamoModels
	{
		public int IdPrestamo{ get; set; }
		public int IdEstadoPrestamo { get; set; }
		public int IdLibro { get; set; }
		public int IdLector { get; set; }
		public string? Codigo { get; set; }
		public DateTime FechaDevolucion { get; set;}
		public DateTime FechaConfirmacionDevolucion { get; set; }
		public DateTime EstadoEntregado { get; set; }	
		public DateTime EstadoRecibido { get; set; }
	}
}
