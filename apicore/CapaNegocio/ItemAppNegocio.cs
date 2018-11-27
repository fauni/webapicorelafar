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
        public List<ItemApp> GetListaItems(int idrol)
        {
            List<ItemApp> litem = new List<ItemApp>();
            List<ItemApp> lsubitem = new List<ItemApp>();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"select * from newlafarnet.item_apps i
                    inner join newlafarnet.item_rol ir on i.id = ir.id_item_app
                    where ir.id_rol = "+idrol+@" and tipo = 'm';");
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
                        items = this.GetListaSubItems(idrol, Convert.ToInt32(item["id"]))
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

        public List<ItemApp> GetListaSubItems(int idrol, int id_mother)
        {
            List<ItemApp> litem = new List<ItemApp>();
            List<ItemApp> lsubitem = new List<ItemApp>();
            try
            {
                ConsultaMySql consulta = new ConsultaMySql(@"select * from newlafarnet.item_apps i
                    inner join newlafarnet.item_rol ir on i.id = ir.id_item_app
                    where ir.id_rol = "+idrol+@" and tipo = 'c' and i.id_mother = "+id_mother+@";");
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
