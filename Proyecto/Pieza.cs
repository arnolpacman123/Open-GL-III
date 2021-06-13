using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Proyecto
{
    public class Pieza : IObjeto
    {
        
        private float dx;
        private float dy;
        private float dz;
        
        private float cx;
        private float cy;
        private float cz;
        
        public float Dx
        {
            get => dx;
            set => dx = value;
        }

        public float Dy
        {
            get => dy;
            set => dy = value;
        }

        public float Dz
        {
            get => dz;
            set => dz = value;
        }

        public float Cx
        {
            get => cx;
            set => cx = value;
        }

        public float Cy
        {
            get => cy;
            set => cy = value;
        }

        public float Cz
        {
            get => cz;
            set => cz = value;
        }

        protected Pieza(float dx, float dy, float dz, float cx, float cy, float cz)
        {
            this.dx = dx;
            this.dy = dy;
            this.dz = dz;
            
            this.cx = cx;
            this.cy = cy;
            this.cz = cz;
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

        public virtual void Dibujar()
        {
        }
    }
}