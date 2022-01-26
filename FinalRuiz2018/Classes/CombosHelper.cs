using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalRuiz2018.Models;

namespace FinalRuiz2018.Classes
{
    public class CombosHelper:IDisposable
    {
        private static FinalRuiz2018DbContext db = new FinalRuiz2018DbContext();

        public void Dispose()
        {
            db.Dispose();
        }

        public static List<Nacionalidad> GetNacionalidades()
        {
            var nacionalidades = db.Nacionalidades.ToList();
            var defaultNacionalidad = new Nacionalidad
            {
                NacionalidadId = 0,
                Nombre = "[Seleccione la Nacionalidad]"
            };
            nacionalidades.Add(defaultNacionalidad);
            nacionalidades = nacionalidades.OrderBy(d => d.Nombre).ToList();
            return nacionalidades;
        }

        public static List<Estilo> GetEstilos()
        {
            var estilos = db.Estilos.ToList();
            var defaultEstilo = new Estilo
            {
                EstiloId = 0,
                Descripcion = "[Seleccione el Estilo]"
            };

            estilos.Add(defaultEstilo);
            estilos = estilos.OrderBy(d => d.Descripcion).ToList();
            return estilos;
        }

        public static List<Interprete> GetInterpretes()
        {
            var interpretes = db.Interpretes.ToList();
            var defaultInterprete = new Interprete
            {
                InterpreteId = 0,
                Apellido = "[Seleccione el Interprete]"
            };

            interpretes.Add(defaultInterprete);
            interpretes = interpretes.OrderBy(d => d.Apellido).ToList();
            return interpretes;
        }

        public static List<Categoria> GetCategorias()
        {
            var categorias = db.Categorias.ToList();
            var defaultCategoria = new Categoria
            {
                CategoriaId = 0,
                Descripcion = "[Seleccione la Categoria]"
            };
            categorias.Add(defaultCategoria);
            categorias = categorias.OrderBy(d => d.Descripcion).ToList();
            return categorias;
        }

        public static List<Genero> GetGeneros()
        {
            var generos = db.Generos.ToList();
            var defaultGenero = new Genero
            {
                GeneroId = 0,
                Descripcion = "[Seleccione el Género]"
            };
            generos.Add(defaultGenero);
            generos = generos.OrderBy(d => d.Descripcion).ToList();
            return generos;
        }

        public static List<TipoDvd> GetTiposDvds()
        {
            var tiposDvd = db.TiposDvd.ToList();
            var defaultTipo = new TipoDvd
            {
                TipoDvdId = 0,
                Nombre = "[Seleccione el Tipo de Dvd]"
            };
            tiposDvd.Add(defaultTipo);
            tiposDvd = tiposDvd.OrderBy(d => d.Nombre).ToList();
            return tiposDvd;
        }
    }
}