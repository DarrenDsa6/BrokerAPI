using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerAPI.Models.Domain
{
    public class Broker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrokerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public long ContactNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public long Pincode { get; set; }

        [Required]
        public long AdhaarCard { get; set; }
    }
}
