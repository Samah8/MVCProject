using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int  Id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50),MinLength(2)]
        public string Name { get; set; }

       // [Range(20,50)]
        [myValidation(ErrorMessage = "The Capacity Value non Valid")]
        public int   Capacity { get; set; }
    }

    class myValidation:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int x= (int)value;
            if (x > 50)
                return true;
            else
                return false;
        }
    }
}
