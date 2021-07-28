using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Person")]
        public int EmployeeID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string JobEmail { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string JobPhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string JobPosition { get; set; }

        public virtual Person Person { get; set; }
    }
}
