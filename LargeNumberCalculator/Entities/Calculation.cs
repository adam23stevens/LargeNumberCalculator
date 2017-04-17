using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Calculation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private long Key { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Result { get; set; }
        public string Operand { get; set; }
        public DateTime LogTime { get; set; }
    }
}
