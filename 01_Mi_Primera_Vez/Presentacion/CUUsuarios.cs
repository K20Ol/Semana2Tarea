using _01_Mi_Primera_Vez.Datos;
using _01_Mi_Primera_Vez.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class CUUsuarios : UserControl
    {
        public CUUsuarios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuarios.frmUsuarios frmUser = new Usuarios.frmUsuarios(true);
            frmUser.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CUUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                cls_usuarios usuarios = new cls_usuarios();
                List<dto_usuarios> listaUsuarios = usuarios.Leer();

                dgvDatos.DataSource = listaUsuarios;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dto_usuarios usuarioSeleccionado = (dto_usuarios)dgvDatos.Rows[e.RowIndex].DataBoundItem;
                Usuarios.frmUsuarios frmUser = new Usuarios.frmUsuarios(usuarioSeleccionado);
                frmUser.ShowDialog();
                cls_usuarios usuarios = new cls_usuarios();
                dgvDatos.DataSource = usuarios.Leer();
            }
        }
    }
}
