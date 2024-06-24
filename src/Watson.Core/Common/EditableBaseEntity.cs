using System;

namespace Watson.Core.Common
{
    public abstract class EditableBaseEntity
    {
        public virtual Guid Id { get; set; }
        public string CreatedBy { get; set; } = "";
        public DateTime CreatedDateUTC { get; set; }
        public string LastUpdatedBy { get; set; } = "";
        public DateTime LastUpdatedDateUTC { get; set; }
    }
}
