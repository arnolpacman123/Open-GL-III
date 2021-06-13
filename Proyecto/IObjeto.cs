namespace Proyecto
{
    public interface IObjeto
    {
        void Rotar(float angle, float x, float y, float z);
        void Trasladar(float x, float y, float z);
        void Escalar(float x, float y, float z);
        void Dibujar();
    }
}