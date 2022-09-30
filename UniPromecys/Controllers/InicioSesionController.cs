using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniPromecys.Models;

namespace UniPromecys.Controllers
{
    public class InicioSesionController : Controller
    {
        public IActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(InicioSesionModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("InicioSesion", model);
                }
                //String connectionString = "Data Source=localhost;Initial Catalog=UniPromecys;Integrated Security=True";
                String connectionString = "Server=tcp:promecys.database.windows.net,1433;Initial Catalog=UniPromecys;Persist Security Info=False;User ID=unipromecys;Password=Isela170599@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                String JsonResultado = "";
                SqlConnection cnn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();
                //DataTable dataTable = new DataTable();
                DataSet ds = new DataSet();
                SqlDataAdapter sqlDA;

                cmd.CommandText = "EXEC Cuenta.prInicioSesion @UserName,@Password";
                cmd.Parameters.AddWithValue("@UserName", model.Usuario);
                cmd.Parameters.AddWithValue("@Password", model.Contrasena);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    JsonResultado = ds.Tables[0].AsEnumerable().Select(h => h.Field<String>("Datos")).FirstOrDefault();
                }

                Resultado resultado = JsonConvert.DeserializeObject<Resultado>(JsonResultado);
                Boolean Exito = resultado.Exito;
                String Descripcion = resultado.Descripcion;

                

                cnn.Close();

                if (Exito)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Resultado = Descripcion;
                    return View("InicioSesion", model);
                }
                //  return RedirectToAction("Principal", "Principal", new { SesionActiva = true });
            }
            catch (Exception e)
            {
                String Descripcion = "Ha ocurrido un error";
                ViewBag.Resultado = Descripcion;
                return View("InicioSesion",model);
            }
        }
    }
}