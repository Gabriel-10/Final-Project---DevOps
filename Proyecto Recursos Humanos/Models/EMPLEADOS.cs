
namespace Proyecto_Recursos_Humanos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class EMPLEADOS
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        [MaxLength(length: 13)]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [MaxLength(length: 12)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }
        public Nullable<int> Id_Departamento { get; set; }
        public Nullable<int> Id_Cargo { get; set; }

        [Required(ErrorMessage = "El campo Fecha de ingreso es obligatorio.")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public System.DateTime Fecha_De_Ingreso { get; set; }
        public int Salario { get; set; } 
        public virtual CARGOS CARGOS { get; set; }
        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }
    }
}
