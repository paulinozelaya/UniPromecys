namespace UniPromecys.Models.Estudiante
{
    public class EstudianteItemModel : FormViewModel
    {
        public int Id { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto { get; set; }

        public string Carnet { get; set; }

        public int IdSolvencia { get; set; }

        public string Solvencia { get; set; }
    }
}
