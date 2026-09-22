namespace Act_2_Problemas;

public sealed class Ejercicio5 : IEjercicio
{
    public string Nombre => "Ejercicio 5 - Torres de Hanói";

    public string Ejecutar(string entrada)
    {
        if (!int.TryParse(entrada.Trim(), out var discos) || discos < 1)
        {
            return "Ingresa un número de discos mayor o igual a uno.";
        }

        if (discos > 15)
        {
            return "Ingresa como máximo 15 discos para mantener legible la lista de movimientos.";
        }

        var movimientos = new List<string>();
        ResolverHanói(discos, 'A', 'C', 'B', movimientos);
        return $"Movimientos necesarios: {movimientos.Count}\r\n\r\n{string.Join("\r\n", movimientos)}";
    }

    private static void ResolverHanói(int discos, char origen, char destino, char auxiliar, List<string> movimientos)
    {
        if (discos == 0)
        {
            return;
        }

        ResolverHanói(discos - 1, origen, auxiliar, destino, movimientos);
        movimientos.Add($"Mover disco {discos} de {origen} a {destino}");
        ResolverHanói(discos - 1, auxiliar, destino, origen, movimientos);
    }
}
