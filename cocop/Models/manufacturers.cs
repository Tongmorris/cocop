using System.ComponentModel.DataAnnotations;//Key
using System.ComponentModel.DataAnnotations.Schema;//Auto Increment
namespace cocop.Models
{
    public class manufacturers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string Title { get; set; }
    }
}
