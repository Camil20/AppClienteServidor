using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ServerApp.Models
{
    public partial class Factura
    {
        public Factura()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        [Key]
        public int FacturaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty("Facturas")]
        public virtual Cliente Cliente { get; set; }
        [InverseProperty(nameof(FacturaDetalle.Factura))]
        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
