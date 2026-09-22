namespace Act_2_Problemas;

public interface IEjercicio
{
    string Nombre { get; }
    string Ejecutar(string entrada);
}
