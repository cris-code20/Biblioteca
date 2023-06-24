using System;


namespace Biblioteca.Application.Datos
{
    public abstract class DtoBase
    {
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }
    }
}
