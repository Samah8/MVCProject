using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50),MinLength(6)]
        public string Name { get; set; }

        public int DeptID { get; set; }

        [Required,StringLength(10,MinimumLength =3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [NotMapped]
        public string CPassword { get; set; }

        public string imgName { get; set; }
    }
}
