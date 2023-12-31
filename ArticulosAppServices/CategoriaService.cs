﻿using ArticulosAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArticulosAppServices
{
    public class CategoriaService
    {
        private readonly AccesoDatos db = new AccesoDatos();

        public List<Categoria> GetAll() 
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                db.setQuery("SELECT C.Id AS Id, C.Descripcion AS Descripcion FROM CATEGORIAS C");

                db.executeSelectionQuery();

                Categoria categoria;
                int id;
                string descripcion;

                while (db.Reader.Read())
                {
                    id = (int) db.Reader["Id"];
                    descripcion = (string)db.Reader["Descripcion"];

                    categoria = new Categoria(id, descripcion);
                    categorias.Add(categoria);
                }

                return categorias;
            } 
            catch (Exception ex)
            {
                throw new Exception("Error en al obtener la lista de categorias de la base de datos", ex);
            } 
            finally
            {
                db.closeConnection();
            }
        }

        public void Add(Categoria categoria)
        {
            try
            {
                db.setQuery("INSERT INTO CATEGORIAS (Descripcion) VALUES (@descripcion)");
                db.setParams("@descripcion", categoria.Description);

                db.executeActionQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar una categoria a la base de datos", ex);
            }
            finally
            {
                db.closeConnection();
            }
        }

        public void Update(Categoria categoria)
        {
            try
            {
                db.setQuery("UPDATE CATEGORIAS SET Descripcion = @descripcion WHERE Id = @id");
                db.setParams("@descripcion", categoria.Description);
                db.setParams("@id", categoria.Id);

                db.executeActionQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar una categoria en la base de datos", ex);
            }
            finally
            {
                db.closeConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                db.setQuery("DELETE FROM CATEGORIAS WHERE Id = @id");
                db.setParams("@id", id);

                db.executeActionQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar una categoria de la base de datos", ex);
            }
            finally
            {
                db.closeConnection();
            }
        }

        public Categoria GetById(int idCategoria)
        {
            int id;
            string descripcion;

            try
            {
                db.setQuery($"SELECT C.Id AS Id, C.Descripcion AS Descripcion FROM CATEGORIAS C WHERE C.Id = {idCategoria}");

                db.executeSelectionQuery();

                if (db.Reader.Read())
                {
                    id = (int)db.Reader["Id"];
                    descripcion = (string)db.Reader["Descripcion"];

                    return new Categoria(id, descripcion);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener una categoria de la base de datos", ex);
            }
            finally
            {
                db.closeConnection();
            }
        }

        public List<Categoria> GetByFilter(string criterio, string filtro)
        {
            List<Categoria> list = new List<Categoria>();

            try
            {
                string consulta = "SELECT C.Id AS Id, C.Descripcion AS Descripcion FROM CATEGORIAS C WHERE ";

                switch (criterio)
                {
                    case "Descripcion comienza con":
                        consulta += $"C.Descripcion LIKE '{filtro}%'";
                        break;
                    case "Descripcion contiene":    
                        consulta += $"C.Descripcion LIKE '%{filtro}%'";
                        break;
                    case "Descripcion termina con":
                        consulta += $"C.Descripcion LIKE '%{filtro}'";
                        break;
                }

                db.setQuery(consulta);

                db.executeSelectionQuery();

                while (db.Reader.Read())
                {
                    int id = (int)db.Reader["Id"];
                    string descripcion = (string)db.Reader["Descripcion"];

                    list.Add(new Categoria(id, descripcion));
                }

                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener una categoria filtrada de la base de datos", ex);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
