using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Data.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.Active = true;
            this.CreatedAt = DateTime.UtcNow;
        }


        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public void Update()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }


        public void Delete()
        {
            this.Active = false;
            this.DeletedAt = DateTime.UtcNow;
        }
    }
}
