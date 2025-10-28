using ProyectoNotas.Clases;
using ProyectoNotas.UoW;
using System;
using System.Windows.Forms;

namespace ProyectoNotas.Formularios
{
    public partial class frmRegistrarNotaCmd : Form
    {
        private UnidadDeTrabajo _unidad = new UnidadDeTrabajo();
        private int _id;

        public frmRegistrarNotaCmd(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmRegistrarNotaCmd_Load(object sender, EventArgs e)
        {
            var estudiante = _unidad.Estudiantes.ObtenerPorId(_id);
            if (estudiante != null)
            {
                txtNombre.Text = estudiante.Nombre;
                txtCodigo.Text = estudiante.Codigo;
                txtLaboratorio.Text = estudiante.Laboratorio.ToString();
                txtParcial.Text = estudiante.Parcial.ToString();
                txtAsistencia.Text = estudiante.Asistencia.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var estudiante = new Estudiante
            {
                Id = _id,
                Nombre = txtNombre.Text.ToUpper(),
                Codigo = txtCodigo.Text.ToUpper(),
                Laboratorio = Convert.ToDecimal(txtLaboratorio.Text),
                Parcial = Convert.ToDecimal(txtParcial.Text),
                Asistencia = Convert.ToDecimal(txtAsistencia.Text)
            };
            estudiante.NotaFinal = (estudiante.Laboratorio * 0.5m) + (estudiante.Parcial * 0.4m) + (estudiante.Asistencia * 0.1m);
            _unidad.Estudiantes.Actualizar(estudiante);
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de eliminar este estudiante?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                _unidad.Estudiantes.Eliminar(_id);
                Close();
            }
        }
    }
}

/// Leonardo Israel Quintanilla Vasquez 
/// U20241478
