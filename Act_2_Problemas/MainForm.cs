namespace Act_2_Problemas;

public sealed class MainForm : Form
{
    private readonly ComboBox ejercicioComboBox = new();
    private readonly TextBox entradaTextBox = new();
    private readonly TextBox resultadoTextBox = new();
    private readonly List<IEjercicio> ejercicios = new()
    {
        new Ejercicio1(),
        new Ejercicio2(),
        new Ejercicio3(),
        new Ejercicio4(),
        new Ejercicio5()
    };

    public MainForm()
    {
        Text = "Act. 2 - Problemas";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(640, 420);
        ClientSize = new Size(800, 520);
        Font = new Font("Segoe UI", 10F);
        BackColor = Color.FromArgb(245, 245, 245);

        var tituloLabel = new Label
        {
            Text = "Ejercicios de problemas",
            AutoSize = true,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 42
        };

        var descripcionLabel = new Label
        {
            Text = "Selecciona un ejercicio y presiona Ejecutar para probarlo.",
            AutoSize = true,
            ForeColor = Color.FromArgb(85, 85, 85),
            Dock = DockStyle.Top,
            Height = 34
        };

        var ejercicioLabel = new Label
        {
            Text = "Ejercicio",
            AutoSize = true,
            Dock = DockStyle.Top,
            Height = 28
        };

        ejercicioComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ejercicioComboBox.Items.AddRange(ejercicios.Select(ejercicio => ejercicio.Nombre).ToArray());
        ejercicioComboBox.SelectedIndex = 0;
        ejercicioComboBox.Dock = DockStyle.Top;
        ejercicioComboBox.Height = 34;
        ejercicioComboBox.SelectedIndexChanged += (_, _) => ActualizarAyudaEntrada();

        var entradaLabel = new Label
        {
            Text = "Entrada",
            AutoSize = true,
            Dock = DockStyle.Top,
            Height = 28,
            Margin = new Padding(0, 18, 0, 0)
        };

        entradaTextBox.Multiline = true;
        entradaTextBox.ScrollBars = ScrollBars.Vertical;
        entradaTextBox.Dock = DockStyle.Fill;

        var ejecutarButton = new Button
        {
            Text = "Ejecutar ejercicio",
            AutoSize = true,
            Height = 40,
            Dock = DockStyle.Top,
            BackColor = Color.Black,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(0, 18, 0, 0)
        };
        ejecutarButton.FlatAppearance.BorderSize = 0;
        ejecutarButton.Click += (_, _) => EjecutarEjercicio();

        var resultadoLabel = new Label
        {
            Text = "Resultado",
            AutoSize = true,
            Dock = DockStyle.Top,
            Height = 28,
            Margin = new Padding(0, 18, 0, 0)
        };

        resultadoTextBox.Multiline = true;
        resultadoTextBox.ReadOnly = true;
        resultadoTextBox.ScrollBars = ScrollBars.Vertical;
        resultadoTextBox.BackColor = Color.White;
        resultadoTextBox.Dock = DockStyle.Fill;

        var formularioPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 9,
            Padding = new Padding(28),
            BackColor = Color.White
        };
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 46));
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 46));
        formularioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        formularioPanel.Controls.Add(tituloLabel, 0, 0);
        formularioPanel.Controls.Add(descripcionLabel, 0, 1);
        formularioPanel.Controls.Add(ejercicioLabel, 0, 2);
        formularioPanel.Controls.Add(ejercicioComboBox, 0, 3);
        formularioPanel.Controls.Add(entradaLabel, 0, 4);
        formularioPanel.Controls.Add(entradaTextBox, 0, 5);
        formularioPanel.Controls.Add(ejecutarButton, 0, 6);
        formularioPanel.Controls.Add(resultadoLabel, 0, 7);
        formularioPanel.Controls.Add(resultadoTextBox, 0, 8);

        Controls.Add(formularioPanel);
        ActualizarAyudaEntrada();
    }

    private void EjecutarEjercicio()
    {
        var indice = ejercicioComboBox.SelectedIndex;
        if (indice < 0 || indice >= ejercicios.Count)
        {
            return;
        }

        resultadoTextBox.Text = ejercicios[indice].Ejecutar(entradaTextBox.Text);
    }

    private void ActualizarAyudaEntrada()
    {
        entradaTextBox.PlaceholderText = ejercicioComboBox.SelectedIndex switch
        {
            0 => "Ejemplo: 5",
            1 => "Ejemplo: 8 términos",
            2 => "Ejemplo: 48; 18",
            3 => "Ejemplo: precio 73.26; pago 100",
            4 => "Ejemplo: 3 discos",
            _ => string.Empty
        };
    }
}
