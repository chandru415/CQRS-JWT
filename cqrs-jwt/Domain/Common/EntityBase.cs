using System;

namespace Domain.Common
{
    public abstract class EntityBase : AuditableEntity
    {
        public Guid Id { get; set; }
    }
}
