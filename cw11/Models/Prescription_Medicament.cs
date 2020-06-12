using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw11.Models
{
    public class Prescription_Medicament
    {

        [ForeignKey("Prescription")]
        public int IdPrescription { get; set; }

        [ForeignKey("Medicament")]
        public int IdMedicament { get; set; }

        public int Dose { get; set; }
        [MaxLength(100)]
        public string? Details { get; set; }

        public virtual Prescription Prescription { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
