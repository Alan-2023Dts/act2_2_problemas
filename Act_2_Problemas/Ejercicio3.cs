namespace Act_2_Problemas;

public sealed class Ejercicio3 : IEjercicio
{
    public string Nombre => "Ejercicio 3 - MCD recursivo";

    public string Ejecutar(string entrada)
    {
        var valores = entrada.Split(new[] { ' ', ',', ';', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (valores.Length != 2 || !int.TryParse(valores[0], out var primerNumero) || !int.TryParse(valores[1], out var segundoNumero))
        {
            return "Ingresa dos números enteros separados por espacio, coma o punto y coma.";
        }

        if (primerNumero == 0 && segundoNumero == 0)
        {
            return "Al menos uno de los números debe ser distinto de cero.";
        }

        return $"MCD({primerNumero}, {segundoNumero}) = {CalcularMcd(primerNumero, segundoNumero)}";
    }

    private static int CalcularMcd(int primerNumero, int segundoNumero)
    {
        primerNumero = Math.Abs(primerNumero);
        segundoNumero = Math.Abs(segundoNumero);
        return segundoNumero == 0
            ? primerNumero
            : CalcularMcd(segundoNumero, primerNumero % segundoNumero);
    }
}
