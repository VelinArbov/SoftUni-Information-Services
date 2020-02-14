

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SIS.MVCFramework
{
    public class IdentityUser<T>
    {
        [Key]
        public T Id { get; set; }


        [MaxLength(20), Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
