using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniPromecys.Models.Asignatura;
using static UniPromecys.Models.AccionesControlador;
using static UniPromecys.Models.Enum;

namespace UniPromecys.Controllers
{
    public class AsignaturaController : BaseController
    {
        private List<AsignaturaItemModel> Listado()
        {
            var listado = new List<AsignaturaItemModel> {
                new AsignaturaItemModel{
                    Id = 1,
                    Nombre = "Asignatura 1",
                    CodigoInterno = "ASIG-001",
                    Descripcion = "Descripcion de Asignatura" ,
                    FechaCreacion = DateTime.Today
                },
                new AsignaturaItemModel{
                 Id = 2,
                    Nombre = "Asignatura 2",
                    CodigoInterno = "ASIG-002",
                    Descripcion = "Descripcion de Asignatura 2" ,
                    FechaCreacion = DateTime.Today},
                new AsignaturaItemModel {
                 Id = 3,
                    Nombre = "Asignatura 3",
                    CodigoInterno = "ASIG-003",
                    Descripcion = "Descripcion de Asignatura 3" ,
                    FechaCreacion = DateTime.Today
                },
                new AsignaturaItemModel{
                    Id = 1,
                    Nombre = "Asignatura 1",
                    CodigoInterno = "ASIG-001",
                    Descripcion = "Descripcion de Asignatura" ,
                    FechaCreacion = DateTime.Today
                },
                new AsignaturaItemModel{
                 Id = 4,
                    Nombre = "Asignatura 2",
                    CodigoInterno = "ASIG-002",
                    Descripcion = "Descripcion de Asignatura 2" ,
                    FechaCreacion = DateTime.Today},
                new AsignaturaItemModel {
                 Id = 5,
                    Nombre = "Asignatura 3",
                    CodigoInterno = "ASIG-003",
                    Descripcion = "Descripcion de Asignatura 3" ,
                    FechaCreacion = DateTime.Today
                },
                new AsignaturaItemModel{
                    Id = 6,
                    Nombre = "Asignatura 1",
                    CodigoInterno = "ASIG-001",
                    Descripcion = "Descripcion de Asignatura" ,
                    FechaCreacion = DateTime.Today
                },
                new AsignaturaItemModel{
                 Id = 7,
                    Nombre = "Asignatura 2",
                    CodigoInterno = "ASIG-002",
                    Descripcion = "Descripcion de Asignatura 2" ,
                    FechaCreacion = DateTime.Today},
                new AsignaturaItemModel {
                 Id = 8,
                    Nombre = "Asignatura 3",
                    CodigoInterno = "ASIG-003",
                    Descripcion = "Descripcion de Asignatura 3" ,
                    FechaCreacion = DateTime.Today
                },
                new AsignaturaItemModel{
                    Id = 9,
                    Nombre = "Asignatura 1",
                    CodigoInterno = "ASIG-001",
                    Descripcion = "Descripcion de Asignatura" ,
                    FechaCreacion = DateTime.Today
                },
                new AsignaturaItemModel{
                 Id = 10,
                    Nombre = "Asignatura 2",
                    CodigoInterno = "ASIG-002",
                    Descripcion = "Descripcion de Asignatura 2" ,
                    FechaCreacion = DateTime.Today},
                new AsignaturaItemModel {
                 Id = 11,
                    Nombre = "Asignatura 3",
                    CodigoInterno = "ASIG-003",
                    Descripcion = "Descripcion de Asignatura 3" ,
                    FechaCreacion = DateTime.Today
                }
            };

            return listado;
        }
        public IActionResult Administrar()
        {
          

            var modelo = new AsignaturaAdminModel
            {
                ListadoAsignaturas = Listado()
            };

            return View("Administrar", modelo);
        }

        public IActionResult RegistrarAsignatura()
        {
            var modelo = new AsignaturaItemModel();
            modelo.Accion = Acciones.Nuevo.ToString();
            return View("RegistrarAsignatura",modelo);
        }

        [HttpPost]
        public IActionResult GuardarAsignatura(AsignaturaItemModel asignaturaItemModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("RegistrarAsignatura");
                }

                Alert("Asignatura guardada con éxito", NotificationType.success);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }

            return RedirectToAction("Administrar");
        }

        public IActionResult Editar(Int32 IdAsignatura)
        {
            var modelo = new AsignaturaItemModel();
            var Encontrado = Listado().FirstOrDefault(x => x.Id == IdAsignatura);
            modelo = Encontrado;
            modelo.Accion = Acciones.Editar.ToString();
            return View("RegistrarAsignatura", modelo);
        }

        [HttpGet]
        public IActionResult Eliminar(Int32 IdAsignatura)
        {
            Alert("Asignatura Eliminada con éxito", NotificationType.success);
            //return RedirectToAction("Administrar");
            var modelo = new AsignaturaAdminModel
            {
                ListadoAsignaturas = Listado()
            };

            return View("Administrar", modelo);
        }
    }
}