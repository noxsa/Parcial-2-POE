using ProyectoNotas.Clases;
using ProyectoNotas.UoW;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoNotas.Formularios
{
    public partial class frmRegistrarNota : Form
    {
        private UnidadDeTrabajo _unidad = new UnidadDeTrabajo();

        public frmRegistrarNota()
        {
            InitializeComponent();
        }

        private void frmRegistrarNota_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text)
                || string.IsNullOrWhiteSpace(txtLaboratorio.Text) || string.IsNullOrWhiteSpace(txtParcial.Text)
                || string.IsNullOrWhiteSpace(txtAsistencia.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            decimal lab = Convert.ToDecimal(txtLaboratorio.Text);
            decimal par = Convert.ToDecimal(txtParcial.Text);
            decimal asi = Convert.ToDecimal(txtAsistencia.Text);

            if (lab < 0 || lab > 10 || par < 0 || par > 10 || asi < 0 || asi > 10)
            {
                MessageBox.Show("Las notas deben ser entre 0 y 10");
                return;
            }

            Estudiante estudiante = new Estudiante
            {
                Codigo = txtCodigo.Text.ToUpper(),
                Nombre = txtNombre.Text.ToUpper(),
                Laboratorio = lab,
                Parcial = par,
                Asistencia = asi,
                NotaFinal = (lab * 0.5m) + (par * 0.4m) + (asi * 0.1m)
            };

            _unidad.Estudiantes.Insertar(estudiante);
            Limpiar();
            CargarDatos();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            txtLaboratorio.Clear();
            txtParcial.Clear();
            txtAsistencia.Clear();
        }

        private void CargarDatos()
        {
            dgvRegistro.DataSource = _unidad.Estudiantes.ObtenerTodos().ToList();
        }

        private void dgvRegistro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvRegistro.Rows[e.RowIndex].Cells["Id"].Value);
                frmRegistrarNotaCmd form = new frmRegistrarNotaCmd(id);
                form.ShowDialog();
                CargarDatos();
            }
        }

        private void txtLaboratorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtParcial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtAsistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
        }
    }
}

/// Leonardo Israel Quintanilla Vasquez 
/// U20241478 
/// Autoevaluacion: 9
