using System.ComponentModel.DataAnnotations;//Key
using System.ComponentModel.DataAnnotations.Schema;//Auto Increment
namespace cocop.Models
{
    public class devices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]// None Auto Increment
        public int id { get; set; }

        public string Title { get; set; }

        public string Processor { get; set; }

        public float Price { get; set; }

        public int Manufacturer_id { get; set; }
    }
}
