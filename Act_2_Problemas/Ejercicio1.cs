namespace Act_2_Problemas;

public sealed class Ejercicio1 : IEjercicio
{
    public string Nombre => "Ejercicio 1 - Factorial recursivo";

    public string Ejecutar(string entrada)
    {
        if (!int.TryParse(entrada.Trim(), out var numero) || numero < 0)
        {
            return "Ingresa un número entero mayor o igual a cero.";
        }

        if (numero > 20)
        {
            return "Ingresa un número entre 0 y 20 para evitar desbordamiento.";
        }

        return $"{numero}! = {CalcularFactorial(numero)}";
    }

    private static long CalcularFactorial(int numero)
    {
        return numero <= 1 ? 1 : numero * CalcularFactorial(numero - 1);
    }
}
