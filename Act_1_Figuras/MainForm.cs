using System.Globalization;

namespace Act_1_Figuras;

public sealed class MainForm : Form
{
    private readonly ComboBox figuraComboBox = new();
    private readonly Label primerValorLabel = new();
    private readonly Label segundoValorLabel = new();
    private readonly TextBox primerValorTextBox = new();
    private readonly TextBox segundoValorTextBox = new();
    private readonly Button calcularButton = new();
    private readonly Label resultadoLabel = new();
    private readonly FigurePreviewPanel vistaPrevia = new();

    public MainForm()
    {
        Text = "Cálculo de áreas";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(760, 520);
        ClientSize = new Size(960, 620);
        BackColor = Color.FromArgb(247, 247, 247);
        Font = new Font("Segoe UI", 10F);

        var tituloLabel = new Label
        {
            Text = "Calculadora de áreas",
            AutoSize = true,
            Font = new Font(Font.FontFamily, 16F, FontStyle.Bold),
            ForeColor = Color.Black,
            Dock = DockStyle.Top,
            Height = 38
        };

        var subtituloLabel = new Label
        {
            Text = "Usa una interfaz común para distintas figuras",
            AutoSize = true,
            ForeColor = Color.FromArgb(90, 90, 90),
            Dock = DockStyle.Top,
            Height = 34
        };

        var figuraLabel = new Label
        {
            Text = "Figura",
            AutoSize = true,
            ForeColor = Color.FromArgb(70, 70, 70),
            Dock = DockStyle.Top,
            Height = 26
        };

        figuraComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        figuraComboBox.Items.AddRange(new object[] { "Rectángulo", "Triángulo", "Círculo" });
        figuraComboBox.SelectedIndex = 0;
        figuraComboBox.Dock = DockStyle.Top;
        figuraComboBox.Height = 34;
        figuraComboBox.SelectedIndexChanged += (_, _) => ActualizarCampos();

        primerValorLabel.Margin = new Padding(0, 24, 0, 4);
        primerValorLabel.AutoSize = true;
        primerValorLabel.ForeColor = Color.FromArgb(70, 70, 70);

        primerValorTextBox.Dock = DockStyle.Top;
        primerValorTextBox.Height = 34;
        primerValorTextBox.TextChanged += (_, _) => ActualizarVistaPrevia();

        segundoValorLabel.Margin = new Padding(0, 18, 0, 4);
        segundoValorLabel.AutoSize = true;
        segundoValorLabel.ForeColor = Color.FromArgb(70, 70, 70);

        segundoValorTextBox.Dock = DockStyle.Top;
        segundoValorTextBox.Height = 34;
        segundoValorTextBox.TextChanged += (_, _) => ActualizarVistaPrevia();

        calcularButton.Text = "Calcular área";
        calcularButton.Dock = DockStyle.Top;
        calcularButton.Height = 42;
        calcularButton.Margin = new Padding(0, 28, 0, 0);
        calcularButton.BackColor = Color.Black;
        calcularButton.ForeColor = Color.White;
        calcularButton.FlatStyle = FlatStyle.Flat;
        calcularButton.FlatAppearance.BorderSize = 0;
        calcularButton.Click += (_, _) => CalcularArea();

        resultadoLabel.AutoSize = true;
        resultadoLabel.Font = new Font(Font.FontFamily, 10F, FontStyle.Bold);
        resultadoLabel.ForeColor = Color.Black;
        resultadoLabel.Margin = new Padding(0, 18, 0, 0);

        var controlesPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 9,
            Padding = new Padding(28),
            BackColor = Color.White
        };
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38));
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        controlesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        controlesPanel.Controls.Add(tituloLabel, 0, 0);
        controlesPanel.Controls.Add(subtituloLabel, 0, 1);
        controlesPanel.Controls.Add(figuraLabel, 0, 2);
        controlesPanel.Controls.Add(figuraComboBox, 0, 3);
        controlesPanel.Controls.Add(primerValorLabel, 0, 4);
        controlesPanel.Controls.Add(primerValorTextBox, 0, 5);
        controlesPanel.Controls.Add(segundoValorLabel, 0, 6);
        controlesPanel.Controls.Add(segundoValorTextBox, 0, 7);
        controlesPanel.Controls.Add(calcularButton, 0, 8);

        var resultadoPanel = new Panel { Dock = DockStyle.Bottom, Height = 42, BackColor = Color.White, Padding = new Padding(28, 8, 28, 0) };
        resultadoPanel.Controls.Add(resultadoLabel);
        resultadoLabel.Dock = DockStyle.Fill;

        var izquierdaPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
        izquierdaPanel.Controls.Add(resultadoPanel);
        izquierdaPanel.Controls.Add(controlesPanel);

        vistaPrevia.Dock = DockStyle.Fill;
        vistaPrevia.Margin = new Padding(16, 0, 0, 0);
        vistaPrevia.BackColor = Color.White;

        var contenidoPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
            Padding = new Padding(28),
            BackColor = Color.FromArgb(247, 247, 247)
        };
        contenidoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42));
        contenidoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58));
        contenidoPanel.Controls.Add(izquierdaPanel, 0, 0);
        contenidoPanel.Controls.Add(vistaPrevia, 1, 0);

        Controls.Add(contenidoPanel);

        ActualizarCampos();
    }

    private void ActualizarCampos()
    {
        var figuraSeleccionada = figuraComboBox.SelectedItem?.ToString() ?? string.Empty;

        if (figuraSeleccionada == "Círculo")
        {
            primerValorLabel.Text = "Radio";
            segundoValorLabel.Text = string.Empty;
            segundoValorLabel.Visible = false;
            segundoValorTextBox.Visible = false;
        }
        else
        {
            primerValorLabel.Text = figuraSeleccionada == "Triángulo" ? "Base" : "Base";
            segundoValorLabel.Text = "Altura";
            segundoValorLabel.Visible = true;
            segundoValorTextBox.Visible = true;
        }

        primerValorTextBox.Text = string.Empty;
        segundoValorTextBox.Text = string.Empty;
        resultadoLabel.Text = string.Empty;
        ActualizarVistaPrevia();
    }

    private void CalcularArea()
    {
        if (!TryReadPositiveDouble(primerValorTextBox.Text, out var primerValor))
        {
            MostrarError("Ingresa un valor válido y mayor que cero.");
            return;
        }

        var figuraSeleccionada = figuraComboBox.SelectedItem?.ToString() ?? string.Empty;
        IFigura figura;

        if (figuraSeleccionada == "Círculo")
        {
            figura = new Circulo(primerValor);
        }
        else
        {
            if (!TryReadPositiveDouble(segundoValorTextBox.Text, out var segundoValor))
            {
                MostrarError("Ingresa un segundo valor válido y mayor que cero.");
                return;
            }

            figura = figuraSeleccionada == "Triángulo"
                ? new Triangulo(primerValor, segundoValor)
                : new Rectangulo(primerValor, segundoValor);
        }

        resultadoLabel.Text = $"Área: {figura.CalcularArea().ToString("N2", CultureInfo.CurrentCulture)}";
        ActualizarVistaPrevia();
    }

    private void ActualizarVistaPrevia()
    {
        var figuraSeleccionada = figuraComboBox.SelectedItem?.ToString() ?? string.Empty;
        var primerValor = TryReadPositiveDouble(primerValorTextBox.Text, out var primerResultado) ? primerResultado : 1;
        var segundoValor = TryReadPositiveDouble(segundoValorTextBox.Text, out var segundoResultado) ? segundoResultado : 1;
        vistaPrevia.Actualizar(figuraSeleccionada, primerValor, segundoValor);
    }

    private static bool TryReadPositiveDouble(string text, out double value)
    {
        return double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) && value > 0;
    }

    private void MostrarError(string message)
    {
        MessageBox.Show(this, message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}

internal sealed class FigurePreviewPanel : Panel
{
    private string figura = "Rectángulo";
    private double primerValor = 1;
    private double segundoValor = 1;

    public FigurePreviewPanel()
    {
        DoubleBuffered = true;
        BorderStyle = BorderStyle.FixedSingle;
        ResizeRedraw = true;
    }

    public void Actualizar(string nombreFigura, double nuevoPrimerValor, double nuevoSegundoValor)
    {
        figura = nombreFigura;
        primerValor = nuevoPrimerValor;
        segundoValor = nuevoSegundoValor;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        e.Graphics.Clear(Color.White);

        using var titleFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        using var captionFont = new Font("Segoe UI", 9F);
        using var dimensionFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        using var textBrush = new SolidBrush(Color.FromArgb(70, 70, 70));
        using var dimensionPen = new Pen(Color.FromArgb(100, 100, 100), 1.2F);
        using var figureBrush = new SolidBrush(Color.FromArgb(36, 150, 243));
        using var figurePen = new Pen(Color.FromArgb(13, 71, 161), 2.5F);

        e.Graphics.DrawString("Vista previa", titleFont, Brushes.Black, 24, 22);
        e.Graphics.DrawString("Las proporciones reflejan tus medidas", captionFont, textBrush, 24, 50);

        var area = new RectangleF(28, 94, Math.Max(80, ClientSize.Width - 56), Math.Max(100, ClientSize.Height - 128));
        var escala = CalcularEscala(area);

        if (figura == "Círculo")
        {
            var diameter = (float)(primerValor * 2 * escala);
            diameter = Math.Min(diameter, Math.Min(area.Width - 44, area.Height - 44));
            var circle = new RectangleF(area.X + (area.Width - diameter) / 2, area.Y + (area.Height - diameter) / 2, diameter, diameter);
            e.Graphics.FillEllipse(figureBrush, circle);
            e.Graphics.DrawEllipse(figurePen, circle);
            DibujarTextoCentrado(e.Graphics, $"r = {primerValor:N2}", dimensionFont, Color.White, circle);
            DibujarCota(e.Graphics, circle.Left, circle.Right, circle.Bottom + 18, $"diámetro {primerValor * 2:N2}", dimensionFont, dimensionPen);
            return;
        }

        var width = (float)(primerValor * escala);
        var height = (float)(segundoValor * escala);
        width = Math.Min(width, area.Width - 64);
        height = Math.Min(height, area.Height - 64);
        var left = area.X + (area.Width - width) / 2;
        var top = area.Y + (area.Height - height) / 2;

        if (figura == "Triángulo")
        {
            var points = new[]
            {
                new PointF(left, top + height),
                new PointF(left + width, top + height),
                new PointF(left + width / 2, top)
            };
            e.Graphics.FillPolygon(figureBrush, points);
            e.Graphics.DrawPolygon(figurePen, points);
            DibujarTextoCentrado(e.Graphics, $"{primerValor:N2} x {segundoValor:N2}", dimensionFont, Color.White, new RectangleF(left, top + height / 3, width, height / 3));
        }
        else
        {
            e.Graphics.FillRectangle(figureBrush, left, top, width, height);
            e.Graphics.DrawRectangle(figurePen, left, top, width, height);
            DibujarTextoCentrado(e.Graphics, $"{primerValor:N2} x {segundoValor:N2}", dimensionFont, Color.White, new RectangleF(left, top, width, height));
        }

        DibujarCota(e.Graphics, left, left + width, top + height + 18, $"base {primerValor:N2}", dimensionFont, dimensionPen);
        DibujarCotaVertical(e.Graphics, left + width + 18, top, top + height, $"altura {segundoValor:N2}", dimensionFont, dimensionPen);
    }

    private float CalcularEscala(RectangleF area)
    {
        var ancho = figura == "Círculo" ? primerValor * 2 : primerValor;
        var alto = figura == "Círculo" ? primerValor * 2 : segundoValor;
        return (float)Math.Min((area.Width - 64) / ancho, (area.Height - 64) / alto);
    }

    private static void DibujarTextoCentrado(Graphics graphics, string text, Font font, Color color, RectangleF bounds)
    {
        using var brush = new SolidBrush(color);
        var size = graphics.MeasureString(text, font);
        graphics.DrawString(text, font, brush, bounds.X + (bounds.Width - size.Width) / 2, bounds.Y + (bounds.Height - size.Height) / 2);
    }

    private static void DibujarCota(Graphics graphics, float start, float end, float y, string text, Font font, Pen pen)
    {
        graphics.DrawLine(pen, start, y, end, y);
        graphics.DrawLine(pen, start, y - 5, start, y + 5);
        graphics.DrawLine(pen, end, y - 5, end, y + 5);
        graphics.DrawString(text, font, Brushes.Black, (start + end) / 2 - graphics.MeasureString(text, font).Width / 2, y + 6);
    }

    private static void DibujarCotaVertical(Graphics graphics, float x, float start, float end, string text, Font font, Pen pen)
    {
        graphics.DrawLine(pen, x, start, x, end);
        graphics.DrawLine(pen, x - 5, start, x + 5, start);
        graphics.DrawLine(pen, x - 5, end, x + 5, end);
        graphics.DrawString(text, font, Brushes.Black, x + 6, (start + end) / 2 - font.Height / 2);
    }
}