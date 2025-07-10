﻿using sistema_academico.AccesoDatos;
using sistema_academico.Repositorios;
using System.Text.Json;

namespace sistema_academico.Repositorio
{
    public class RepositorioCrudJson<T> : IRepositorio<T> where T : class
    {
        private readonly IAccesoDatos<T> _accesoDatos;
        public RepositorioCrudJson(IAccesoDatos<T> acceso)
        {
            _accesoDatos = acceso;
        }
        public List<T> ObtenerTodos()
        {
            return _accesoDatos.Leer();
        }
        public void Guardar(List<T> lista)
        {
            _accesoDatos.Guardar(lista);
        }
        public int ObtenerNuevoId(List<T> lista)
        {
            int maxid = 0;
            foreach (var item in lista)
            {
                var propiedadId = typeof(T).GetProperty("Id");
                int id = (int)propiedadId.GetValue(item);

                if (id > maxid)
                {
                    maxid = id;
                }
            }
            return maxid + 1;
        }
        public void Agregar(T entidad)
        {
            var lista = ObtenerTodos();
            int nuevoId = ObtenerNuevoId(lista);
            var propiedadId = typeof(T).GetProperty("Id");
            propiedadId.SetValue(entidad, nuevoId);
            lista.Add(entidad);
            Guardar(lista);
        }
        private T? BuscarEnListaPorId(List<T> lista, int id)
        {
            var propiedadId = typeof(T).GetProperty("Id");
            foreach (var item in lista)
            {
                int valorId = (int)propiedadId.GetValue(item);

                if (valorId == id)
                {
                    return item;
                }
            }
            return null;
        }
        public T? BuscarPorId(int id)
        {
            var lista = ObtenerTodos();
            return BuscarEnListaPorId(lista, id);
        }
        public void EliminarPorId(int id)
        {
            var lista = ObtenerTodos();
            var itemEliminar = BuscarEnListaPorId(lista, id);
            if (itemEliminar != null)
            {
                lista.Remove(itemEliminar);
                Guardar(lista);
            }
        }
        public void Editar(T entidadNueva)
        {
            var lista = ObtenerTodos();
            var propiedadId = typeof(T).GetProperty("Id");
            int id = (int)propiedadId.GetValue(entidadNueva);
            var entidadExistente = BuscarEnListaPorId(lista, id);

            if (entidadExistente != null)
            {
                ActualizarPropiedades(entidadExistente, entidadNueva);
                Guardar(lista);
            }
        }
        private void ActualizarPropiedades(T entidadExistente, T entidadNueva)
        {
            var propiedades = typeof(T).GetProperties();
            foreach (var propiedad in propiedades)
            {
                if (propiedad.Name == "Id")
                {
                    continue;
                }

                var nuevoValor = propiedad.GetValue(entidadNueva);
                propiedad.SetValue(entidadExistente, nuevoValor);
            }
        }
    }
}

