using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Entities
{
    public abstract class Entity 
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public void SetIsActive(bool value)
        {
            IsActive = value;
        }
    }
}
