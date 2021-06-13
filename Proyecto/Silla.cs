using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Proyecto
{
    public class Silla : Objeto
    {
        private float dx;
        private float dy;
        private float dz;

        private float cx;
        private float cy;
        private float cz;

        public Silla(float dx, float dy, float dz, float cx, float cy, float cz)
        {
            this.dx = dx;
            this.dy = dy;
            this.dz = dz;

            this.cx = cx;
            this.cy = cy;
            this.cz = cz;

            Agregar("asiento", new Asiento(dx, dy, dz, cx, cy, cz));
            Agregar("espaldar", new Espaldar(dx, dy, dz, cx, cy, cz));
            
            float width = dx * 0.1f;//recalculo del nuevo ancho de x
            float depth = dz * 0.1f;//recalculo del nuevo ancho de z
            float x = dx / 2;//recalculo del nuevo ancho respecto x
            float z = dz /2; //recalculo de la nueva profundidad respecto a z         

            Agregar("pata1", new Pata(width, dy, depth, cx - x + width, cy, cz - z + depth));
            Agregar("pata2", new Pata(width, dy, depth, cx - x + width, cy, cz + z - depth));
            Agregar("pata3", new Pata(width, dy, depth, cx + x - width, cy, cz + z - depth));
            Agregar("pata4", new Pata(width, dy, depth, cx + x - width, cy, cz - z + depth));
        }
    }

    public class Espaldar : Pieza
    {
        public Espaldar(float dx, float dy, float dz, float cx, float cy, float cz) : base(dx, dy, dz, cx, cy, cz)
        {
        }


        public override void Dibujar()
        {
            double width = Dx / 2;
            double height = Dy / 2;
            double depth = Dz / 2;


            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex3(Cx - width, Cy,      Cz - depth);
            GL.Vertex3(Cx - width, Cy + Dy, Cz - depth);
            GL.Vertex3(Cx - width, Cy + Dy, Cz + depth);
            GL.Vertex3(Cx - width, Cy,      Cz + depth);

            GL.End();
            base.Dibujar();
        }
    }

    public class Asiento : Pieza
    {
        public Asiento(float dx, float dy, float dz, float cx, float cy, float cz) : base(dx, dy, dz, cx, cy, cz)
        {
        }

        public override void Dibujar()
        {
            double width = Dx / 2;
            double height = Dy / 2;
            double depth = Dz / 2;


            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex3(Cx - width, Cy, Cz - depth);
            GL.Vertex3(Cx + width, Cy, Cz - depth);
            GL.Vertex3(Cx + width, Cy, Cz + depth);
            GL.Vertex3(Cx - width, Cy, Cz + depth);

            GL.End();
            base.Dibujar();
        }
    }

    public class Pata : Pieza
    {
        public Pata(float dx, float dy, float dz, float cx, float cy, float cz) : base(dx, dy, dz, cx, cy, cz)
        {
        }

        public override void Dibujar()
        {
            GL.Begin(PrimitiveType.Polygon);//plano1 frontal

            GL.Vertex3(Cx - Dx, Cy,      Cz + Dz);
            GL.Vertex3(Cx + Dx, Cy,      Cz + Dz);
            GL.Vertex3(Cx + Dx, Cy - Dy, Cz + Dz);
            GL.Vertex3(Cx - Dx, Cy - Dy, Cz + Dz);

            GL.End();

            GL.Begin(PrimitiveType.Polygon);//plano2 atras

            GL.Vertex3(Cx - Dx, Cy,      Cz - Dz);
            GL.Vertex3(Cx + Dx, Cy,      Cz - Dz);
            GL.Vertex3(Cx + Dx, Cy - Dy, Cz - Dz);
            GL.Vertex3(Cx - Dx, Cy - Dy, Cz - Dz);

            GL.End();


            GL.Begin(PrimitiveType.Polygon);//plano1 izquierda

            GL.Vertex3(Cx - Dx, Cy,      Cz + Dz);
            GL.Vertex3(Cx - Dx, Cy,      Cz - Dz);
            GL.Vertex3(Cx - Dx, Cy - Dy, Cz - Dz);
            GL.Vertex3(Cx - Dx, Cy - Dy, Cz + Dz);

            GL.End();

            GL.Begin(PrimitiveType.Polygon);//plano2 derecha

            GL.Vertex3(Cx + Dx, Cy,      Cz + Dz);
            GL.Vertex3(Cx + Dx, Cy,      Cz - Dz);
            GL.Vertex3(Cx + Dx, Cy - Dy, Cz - Dz);
            GL.Vertex3(Cx + Dx, Cy - Dy, Cz + Dz);

            GL.End();
            base.Dibujar();
        }
    }
}