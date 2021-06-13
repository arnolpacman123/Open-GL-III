using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace Proyecto
{
    class Pantalla : GameWindow
    {
        private Escenario Escenario;

        public Pantalla(int ancho, int alto, string titulo)
            : base(ancho, alto, GraphicsMode.Default, titulo)
        {
            Escenario = new Escenario();
            Escenario.Agregar("silla", new Silla(10, 10, 10, 0.0f, 5.0f, 0.0f));
        }

        protected override void OnResize(EventArgs e)
        {
            float aspectRatio = 1.0f;

            if ((Width > 0) && (Height > 0))
            {
                if (Width > Height)
                {
                    aspectRatio = Width / Height;
                }
                else if (Width < Height)
                {
                    aspectRatio = Height / Width;
                }
            }

            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), aspectRatio, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            //GL.Ortho(0.0, 50.0, 0.0, 50.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
            base.OnResize(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            GL.Translate(0.0, 0.0, -50.0);
            GL.Rotate(40.0, 1, 1, 0);
            
            Escenario.Rotar(-90.0f, 0, 1, 0);
            Escenario.Dibujar();
            
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnUnload(EventArgs e)
        {
            Escenario = null;
            base.OnUnload(e);
        }
    }
}