using System;
using System.Collections;
using OpenTK.Graphics.OpenGL;

namespace Proyecto
{
    public class Escenario : IObjeto
    {
        private Hashtable Coleccion;

        public Escenario()
        {
            Coleccion = new Hashtable();
        }

        public void Agregar(string llave, Objeto objeto)
        {
            try
            {
                Coleccion.Add(llave, objeto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Cambiar(string llave, Objeto objeto)
        {
            if (Coleccion.ContainsKey(llave))
            {
                Coleccion[llave] = objeto;
            }
        }
        
        public void Eliminar(string llave)
        {
            if (Coleccion.ContainsKey(llave))
            {
                Coleccion.Remove(llave);
            }
        }
        
        public ICollection ObtenerColeccion()
        {
            return Coleccion.Values;
        }
        
        public Objeto ObtenerObjeto(string llave)
        {
            if (Coleccion.ContainsKey(llave))
            {
                return (Objeto) Coleccion[llave];
            }
            return null;
        }

        public void Rotar(float angle, float x, float y, float z)
        {
            GL.Rotate(angle, x, y, z);
        }

        public void Trasladar(float x, float y, float z)
        {
            GL.Translate(x, y, z);
        }

        public void Escalar(float x, float y, float z)
        {
            GL.Scale(x, y, z);
        }

        public void Dibujar()
        {
            ICollection Valores = Coleccion.Values;
            foreach (Objeto objeto in Valores)
            {
                objeto.Dibujar();
            }
        }
    }
}