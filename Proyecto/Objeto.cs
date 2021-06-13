using System;
using System.Collections;
using OpenTK.Graphics.OpenGL;

namespace Proyecto
{
    public abstract class Objeto : IObjeto
    {
        private Hashtable _coleccion;

        protected Objeto()
        {
            _coleccion = new Hashtable();
        }

        public void Agregar(string llave, Pieza pieza)
        {
            try
            {
                _coleccion.Add(llave, pieza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Cambiar(string llave, string pieza)
        {
            if (_coleccion.ContainsKey(llave))
            {
                _coleccion[llave] = pieza;
            }
        }

        public void Eliminar(string llave)
        {
            if (_coleccion.ContainsKey(llave))
            {
                _coleccion.Remove(llave);
            }
        }

        public ICollection ObtenerColeccion()
        {
            return _coleccion.Values;
        }

        public Pieza ObtenerObjeto(string llave)
        {
            if (_coleccion.ContainsKey(llave))
            {
                return (Pieza) _coleccion[llave];
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
            ICollection valores = _coleccion.Values;
            foreach (Pieza pieza in valores)
            {
                pieza.Dibujar();
            }
        }
    }
}