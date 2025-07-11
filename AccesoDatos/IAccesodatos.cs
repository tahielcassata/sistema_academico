namespace sistema_academico.AccesoDatos
{
    public interface IAccesoDatos<T>
    {
        List<T> Leer();
        void Guardar(List<T> lista);
    }
}



