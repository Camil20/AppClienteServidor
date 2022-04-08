using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ServerApp.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        [Key]
        public int ServicioId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(30)]
        public string Categoria { get; set; }

        [InverseProperty(nameof(FacturaDetalle.Servicio))]
        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
