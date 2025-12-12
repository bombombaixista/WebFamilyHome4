using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using WebFamilyHome.Models; // <- garante que Group seja encontrado

namespace WebFamilyHome.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public string NomeCompleto { get; set; } = string.Empty;

        // Agora opcional
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
