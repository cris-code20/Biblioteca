using System;

namespace Biblioteca.Application.Dtos
{
    public abstract class DtoBase
    {
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }

    }
}