using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace STARK
{
    public class BaseDatos
    {
        public int id { set; get; }
        public string comando { set; get; }
        public string accion { set; get; }
        public string respuesta { set; get; }

        public BaseDatos(int _id, string cmd, string act, string resp)
        {
            id = _id;
            comando = cmd;
            accion = act;
            respuesta = resp;
        }
    }

    public class DataBase<T>
    {
        public List<T> comandos = new List<T>();
        string ruta;

        public DataBase(string r)
        {
            ruta = r;
        }

        public void CargarComandos(string ruta)
        {
            try
            {
                string archivo = string.Empty;
                archivo = File.ReadAllText(ruta,Encoding.GetEncoding("utf-8"));
                comandos = JsonConvert.DeserializeObject<List<T>>(archivo);
            }
            catch
            {
                System.Windows.MessageBox.Show("No se encuentra la base de datos.");
            }
        }

        public void GuardarComandos(string nueva_ruta)
        {
           string texto = JsonConvert.SerializeObject(comandos);
            File.WriteAllText(nueva_ruta, texto);
        }

        public void InsertarComandos(T new_cmd, byte x)
        {
            switch (x)
            {
                case 0:
                    CargarComandos(@"Base_Datos\CmdSociales.json");
                    comandos.Add(new_cmd);
                    GuardarComandos(@"Base_Datos\CmdSociales.json");
                    break;
                case 1:
                    CargarComandos(@"Base_Datos\CmdCarpetas.json");
                    comandos.Add(new_cmd);
                    GuardarComandos(@"Base_Datos\CmdCarpetas.json");
                    break;
                case 2:
                    CargarComandos(@"Base_Datos\CmdAplicaciones.json");
                    comandos.Add(new_cmd);
                    GuardarComandos(@"Base_Datos\CmdAplicaciones.json");
                    break;
                case 3:
                    CargarComandos(@"Base_Datos\CmdPaginasWebs.json");
                    comandos.Add(new_cmd);
                    GuardarComandos(@"Base_Datos\CmdPaginasWebs.json");
                    break;
            }
        }

        public void ActualizarComandos(List<BaseDatos> list, int x)
        {
            string texto;
            switch (x)
            {            
                case 0:
                    texto = string.Empty;
                    texto = JsonConvert.SerializeObject(list);
                    File.WriteAllText(@"Base_Datos\CmdSociales.json", texto);
                    break;
                case 1:
                    texto = string.Empty;
                    texto = JsonConvert.SerializeObject(list);
                    File.WriteAllText(@"Base_Datos\CmdCarpetas.json", texto);
                    break;
                case 2:
                    texto = string.Empty;
                    texto = JsonConvert.SerializeObject(list);
                    File.WriteAllText(@"Base_Datos\CmdAplicaciones.json", texto);
                    break;
                case 3:
                    texto = string.Empty;
                    texto = JsonConvert.SerializeObject(list);
                    File.WriteAllText(@"Base_Datos\CmdPaginasWebs.json", texto);
                    break;
            }
        }

        public void EliminarComandos()
        {

        }
    }
}