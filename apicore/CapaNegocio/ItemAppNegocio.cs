using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelos;
using CapaDatos;

namespace CapaNegocio
{
    public class ItemAppNegocio
    {
        public List<ItemApp> GetListaItems(int idapp)
        {
            List<ItemApp> litem = new List<ItemApp>();
            List<ItemApp> lsubitem = new List<ItemApp>();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"select * from newlafarnet.item_apps where app_id = " + idapp + @" and tipo = 'm';");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos  de la consulta de la base de datos");

                foreach (DataRow item in dt.Rows)
                {
                    ItemApp ia = new ItemApp
                    {
                        id = Convert.ToInt32(item["id"]),
                        url = (item["url"]).ToString(),
                        icon = (item["icon"]).ToString(),
                        app_id = Convert.ToInt32(item["app_id"]),
                        itemName = (item["itemName"]).ToString(),
                        tipo = (item["tipo"]).ToString(),
                        id_mother = Convert.ToInt32(item["id_mother"]),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"]),
                        items = this.GetListaSubItems(Convert.ToInt32(item["id"]))
                    };
                    litem.Add(ia);
                }
                return litem;
            }
            catch (Exception ex)
            {
                return litem;
            }
        }

        public List<ItemApp> GetListaSubItems(int iditem)
        {
            List<ItemApp> litem = new List<ItemApp>();
            List<ItemApp> lsubitem = new List<ItemApp>();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"select * from newlafarnet.item_apps where id_mother = " + iditem + @" and tipo = 'c';");
                DataTable dt = consulta.EjecutarConsulta(Parametros.ConexionBDMySQL());
                if (dt.Rows.Count <= 0)
                    throw new Exception("No trajo datos  de la consulta de la base de datos");

                foreach (DataRow item in dt.Rows)
                {
                    ItemApp ia = new ItemApp
                    {
                        id = Convert.ToInt32(item["id"]),
                        url = (item["url"]).ToString(),
                        icon = (item["icon"]).ToString(),
                        app_id = Convert.ToInt32(item["app_id"]),
                        itemName = (item["itemName"]).ToString(),
                        tipo = (item["tipo"]).ToString(),
                        id_mother = Convert.ToInt32(item["id_mother"]),
                        usuario_creacion = (item["usuario_creacion"]).ToString(),
                        fecha_creacion = Convert.ToDateTime(item["fecha_creacion"]),
                        usuario_modificacion = (item["usuario_modificacion"]).ToString(),
                        fecha_modificacion = Convert.ToDateTime(item["fecha_modificacion"])
                    };
                    litem.Add(ia);
                }
                return litem;
            }
            catch (Exception ex)
            {
                return litem;
            }
        }
    }
}
