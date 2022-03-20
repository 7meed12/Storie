
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
    }
}
