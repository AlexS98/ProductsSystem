using System;

namespace ProductsSystem.Auth.Models
{
    public abstract class CommonModel
    {
        public Guid Id { get; set; }    
        public DateTimeOffset? CreateDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
    }
}