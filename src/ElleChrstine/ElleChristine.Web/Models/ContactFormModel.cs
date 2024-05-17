using System.ComponentModel.DataAnnotations;

namespace RVAGutterPros.Web.Models
{
    public class ContactFormInputModel
    {
        public ContactFormInputModel()
        {
            Name = string.Empty;
            Subject = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Message = string.Empty;
        }


        [Required(ErrorMessage = $"{nameof(Name)} is required")]
        [StringLength(100, ErrorMessage = $"Max length for {nameof(Name)} is 100 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = $"Max length for {nameof(Subject)} is 200 characters.")]
        public string Subject { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = $"Max length for {nameof(Email)} is 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = $"Max length for {nameof(Phone)} is 20 characters.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = $"Max length for {nameof(Message)} is 2000 characters.")]
        public string Message { get; set; }
    }
}
