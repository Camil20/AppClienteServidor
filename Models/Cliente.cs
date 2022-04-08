using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ServerApp.Models
{
    [Index(nameof(Cedula), Name = "UQ__Clientes__B4ADFE3817D74A03", IsUnique = true)]
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        [Key]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(13)]
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        [StringLength(30)]
        public string Sector { get; set; }
        [StringLength(30)]
        public string Ciudad { get; set; }
        [StringLength(30)]
        public string Provincia { get; set; }
        [StringLength(30)]
        public string Telefono { get; set; }
        [Required]
        [Column("Correo_Electronico")]
        [StringLength(50)]
        public string CorreoElectronico { get; set; }
        [Column(TypeName = "image")]
        public byte[] Fotografia { get; set; }

        [StringLength(255)]
        public string RutaFoto { get; set; }
        

        [InverseProperty(nameof(Factura.Cliente))]
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
