using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerilogLogging.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
    }
}
