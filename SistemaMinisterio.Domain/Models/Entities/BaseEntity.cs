using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMinisterio.Domain.Models.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
