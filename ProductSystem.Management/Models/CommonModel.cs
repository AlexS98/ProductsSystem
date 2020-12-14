using System;

namespace ProductSystem.Management.Models
{
    public class CommonModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }

        public void Init()
        {
            Id = Id == new Guid() ? Guid.NewGuid() : Id;
            CreateDate = DateTimeOffset.UtcNow;
            UpdateDate = DateTimeOffset.UtcNow;
        }
    }
}