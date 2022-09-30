﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniPromecys.Models.Asignatura
{
    public class AsignaturaItemModel : FormViewModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? CodigoInterno { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
