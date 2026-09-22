namespace Act_2_Problemas;

public sealed class Ejercicio2 : IEjercicio
{
    public string Nombre => "Ejercicio 2 - Fibonacci recursivo";

    public string Ejecutar(string entrada)
    {
        if (!int.TryParse(entrada.Trim(), out var cantidad) || cantidad < 1)
        {
            return "Ingresa la cantidad de términos, comenzando desde 1.";
        }

        if (cantidad > 40)
        {
            return "Ingresa una cantidad entre 1 y 40 para mantener práctica la recursión.";
        }

        var terminos = Enumerable.Range(0, cantidad)
            .Select(indice => CalcularFibonacci(indice));

        return $"Primeros {cantidad} términos:\r\n{string.Join(", ", terminos)}";
    }

    private static long CalcularFibonacci(int indice)
    {
        return indice <= 1
            ? indice
            : CalcularFibonacci(indice - 1) + CalcularFibonacci(indice - 2);
    }
}
