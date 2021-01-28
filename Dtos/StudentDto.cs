using System.ComponentModel.DataAnnotations;

namespace Sbsc.API.Dtos
{
    public class StudentDto
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "You must specify a name between 5 and 20 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "You must specify a family name between 5 and 20 characters")]
        public string FamilyName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "You must specify an address between 10 and 50 characters")]
        public string Address { get; set; }
        [Required]
        public string CountryOfOrigin { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [Range(18, 25, ErrorMessage = "Student must be between 18 and 25 years old")]
        public int Age { get; set; }
        [Required]
        public bool Approved { get; set; }
        
    }
}