using System.Globalization;

namespace Act_2_Problemas;

public sealed class Ejercicio4 : IEjercicio
{
    private static readonly (int Centavos, string Descripcion)[] Denominaciones =
    {
        (10000, "100 pesos"),
        (5000, "50 pesos"),
        (2000, "20 pesos"),
        (1000, "10 pesos"),
        (500, "5 pesos"),
        (100, "1 peso"),
        (50, "50 centavos"),
        (20, "20 centavos"),
        (1, "1 centavo")
    };

    public string Nombre => "Ejercicio 4 - Cambio mínimo";

    public string Ejecutar(string entrada)
    {
        var valores = entrada.Split(new[] { ' ', ',', ';', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (valores.Length != 2 || !TryParseMoney(valores[0], out var precio) || !TryParseMoney(valores[1], out var pago))
        {
            return "Ingresa precio y pago separados por espacio, coma o punto y coma. Ejemplo: 73.26; 100";
        }

        var cambio = pago - precio;
        if (cambio < 0)
        {
            return $"Faltan {Math.Abs(cambio) / 100m:N2} pesos para completar el pago.";
        }

        var resultado = new List<string> { $"Cambio: {cambio / 100m:N2} pesos" };
        foreach (var denominacion in Denominaciones)
        {
            var cantidad = cambio / denominacion.Centavos;
            cambio %= denominacion.Centavos;
            resultado.Add($"{cantidad} {(cantidad == 1 ? "moneda" : "monedas")} de {denominacion.Descripcion}");
        }

        return string.Join("\r\n", resultado);
    }

    private static bool TryParseMoney(string texto, out int centavos)
    {
        if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out var cantidad) || cantidad < 0)
        {
            centavos = 0;
            return false;
        }

        cantidad = decimal.Round(cantidad * 100, 0, MidpointRounding.AwayFromZero);
        if (cantidad > int.MaxValue)
        {
            centavos = 0;
            return false;
        }

        centavos = (int)cantidad;
        return true;
    }
}
