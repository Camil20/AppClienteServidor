using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ServerApp.Models
{
    [Table("FacturaDetalle")]
    public partial class FacturaDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int FacturaId { get; set; }
        public int ServicioId { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Cantidad { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }

        [ForeignKey(nameof(FacturaId))]
        [InverseProperty("FacturaDetalles")]
        public virtual Factura Factura { get; set; }
        [ForeignKey(nameof(ServicioId))]
        [InverseProperty("FacturaDetalles")]
        public virtual Servicio Servicio { get; set; }
    }
}
