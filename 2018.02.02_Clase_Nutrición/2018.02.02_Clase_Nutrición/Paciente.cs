using _2018._02._02_Clase_Nutrición.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2018._02._02_Clase_Nutrición
{
    public partial class Paciente : Form
    {
        public Paciente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<TipoDocumento>
                tiposDocumento = new List<TipoDocumento>();

            tiposDocumento.Add(new TipoDocumento()
            {
                Id = 1,
                Nombre = "Cédula de ciudadanía"
            });

            tiposDocumento.Add(new TipoDocumento()
            {
                Id = 2,
                Nombre = "Tarjeta de Identidad"
            });

            cboTipoDocumento.DataSource = tiposDocumento;
            cboTipoDocumento.DisplayMember = "Nombre";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //// declaro una variable de error
            //bool errores = false; si la genero en donde tengo return reemplazo por errores= true;

            

            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                erpMensaje.SetError(txtNombre, "El nombre es obligatorio");

                return;
            }

            else
            {
                erpMensaje.SetError(txtNombre, "");
            }

            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                MessageBox.Show("El documento es obligatorio");

                return;
            }

            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento debe ser menor a la fecha actual");

                return;
            }


            Entidades.Paciente paciente = new Entidades.Paciente();
            paciente.PrimerNombre = txtNombre.Text;
            paciente.NumeroDocumento = Convert.ToInt64(txtNumeroDocumento.Text); //convertir el cuadro de texto a long
            paciente.FechaNacimiento = dtpFechaNacimiento.Value;
            paciente.TipoDocumento = (TipoDocumento)cboTipoDocumento.SelectedItem;
            // cboTipoDocumento.SelectedItem as TipoDocumento ( en vez de (TipoDocumento)cboTipoDocumento.SelectedItem;)

            Control.ControlPaciente controlPaciente = new Control.ControlPaciente();
            controlPaciente.IngresarPaciente(paciente);

            MessageBox.Show("Paciente ingresado exitosamente");


        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Paciente_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int) e.KeyChar == 8 || (int) e.KeyChar >= 48 && (int) e.KeyChar <= 59 ))

            {
                e.Handled = true;
            }
        }

        private void dtpFechaNacimiento_Validating(object sender, CancelEventArgs e)
        {
            if (dtpFechaNacimiento.Value > DateTime.Now)

            {
                erpMensaje.SetError(dtpFechaNacimiento,
                    "La fecha de nacimiento debe ser menor a la fecha actual");
            }

            else
            {
                erpMensaje.SetError(dtpFechaNacimiento, string.Empty);
            }
        }
    }
}
