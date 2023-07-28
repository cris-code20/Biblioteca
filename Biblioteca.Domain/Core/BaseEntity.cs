

using System;

namespace Biblioteca.Domain.Core
{
    public abstract class BaseEntity
    {
       
        public BaseEntity()
        {
            this.CreationDate = DateTime.Now;
            this.Deleted = false;
        }

        public DateTime CreationDate { get; set;}
        public bool Deleted { get; set;}
        public int CreationUser { get; set;}
        public DateTime? ModifyDate { get; set;}
        public int? Usermod {get; set;}
        public int? UserDelete { get; set;}
        public DateTime? DeleteDate { get; set;}


    }
}
