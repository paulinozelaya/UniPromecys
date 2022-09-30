using Microsoft.AspNetCore.Mvc;
using UniPromecys.Models.Asignatura;
using UniPromecys.Models.Estudiante;
using static UniPromecys.Models.AccionesControlador;
using static UniPromecys.Models.Enum;

namespace UniPromecys.Controllers
{
    public class EstudianteController : BaseController
    {
        private List<EstudianteItemModel> Listado()
        {
            var listado = new List<EstudianteItemModel> {
                new EstudianteItemModel{
                    Id = 1,
                    PrimerNombre = "Isela",
                    SegundoNombre = "del Rosario",
                    PrimerApellido = "Ramos" ,
                    SegundoApellido = "Mercado",
                    NombreCompleto = "Isela del Rosario Ramos Mercado",
                    Carnet = "2016-100P",
                    IdSolvencia = 1,
                    Solvencia = "20% Descuento"
                }
            };

            return listado;
        }

        public IActionResult Administrar()
        {


            var modelo = new EstudianteAdminModel
            {
                ListadoEstudiantes = Listado()
            };

            return View("Administrar", modelo);
        }

        public IActionResult RegistrarEstudiante()
        {
            var modelo = new EstudianteItemModel();
            modelo.Accion = Acciones.Nuevo.ToString();
            return View("RegistrarEstudiante", modelo);
        }

        [HttpPost]
        public IActionResult GuardarEstudiante(EstudianteItemModel estudianteItemModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("RegistrarEstudiante");
                }

                Alert("Estudiante guardado con éxito", NotificationType.success);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }

            return RedirectToAction("Administrar",estudianteItemModel);
        }

        public IActionResult Editar(Int32 IdEstudiante)
        {
            var modelo = new EstudianteItemModel();
            var Encontrado = Listado().FirstOrDefault(x => x.Id == IdEstudiante);
            modelo = Encontrado;
            modelo.Accion = Acciones.Editar.ToString();
            return View("RegistrarEstudiante", modelo);
        }

        [HttpGet]
        public IActionResult Eliminar(Int32 IdEstudiante)
        {
            Alert("Estudiante Eliminado con éxito", NotificationType.success);
            //return RedirectToAction("Administrar");
            var modelo = new EstudianteAdminModel
            {
                ListadoEstudiantes = Listado()
            };

            return View("Administrar", modelo);
        }
    }
}
