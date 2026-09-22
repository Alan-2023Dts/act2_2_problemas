namespace Act_1_Figuras;

public sealed class Rectangulo : IFigura
{
    public Rectangulo(double baseRectangulo, double altura)
    {
        BaseRectangulo = baseRectangulo;
        Altura = altura;
    }

    public string Nombre => "Rectángulo";

    public double BaseRectangulo { get; }

    public double Altura { get; }

    public double CalcularArea() => BaseRectangulo * Altura;
}

public sealed class Triangulo : IFigura
{
    public Triangulo(double baseTriangulo, double altura)
    {
        BaseTriangulo = baseTriangulo;
        Altura = altura;
    }

    public string Nombre => "Triángulo";

    public double BaseTriangulo { get; }

    public double Altura { get; }

    public double CalcularArea() => (BaseTriangulo * Altura) / 2.0;
}

public sealed class Circulo : IFigura
{
    public Circulo(double radio)
    {
        Radio = radio;
    }

    public string Nombre => "Círculo";

    public double Radio { get; }

    public double CalcularArea() => Math.PI * Radio * Radio;
}