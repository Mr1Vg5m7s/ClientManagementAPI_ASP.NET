using System.ComponentModel.DataAnnotations;


namespace ClientManagementAPI.Model
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Marka { get; set; } = string.Empty;

        [StringLength(20)]
        public string Color { get; set; } = string.Empty;

        [StringLength(20)]
        public string GOSNubmer { get; set; } = string.Empty;

        public DateTime RegistrationDate { get; set; }
    }

}
