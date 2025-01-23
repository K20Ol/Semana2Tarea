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

namespace _01_Mi_Primera_Vez.Presentacion.Usuarios
{
    public partial class frmUsuarios : Form
    {

     
        public frmUsuarios(bool Nuevo)
        {
            InitializeComponent(); 
            cls_pais clsPaises = new cls_pais();
            cmbPais.DataSource = clsPaises.leer();
            cmbPais.DisplayMember = "Detalle";
            cmbPais.ValueMember = "IdPais";


            if (Nuevo) { btnEditar.Visible = false; btnGuardar.Visible = true; }
            else { btnEditar.Visible = true; btnGuardar.Visible = false; }
        }
        string idUser;
        public frmUsuarios(dto_usuarios usuario)
        {
            InitializeComponent();

            cls_pais clsPaises = new cls_pais();
            cmbPais.DataSource = clsPaises.leer();
            cmbPais.DisplayMember = "Detalle";
            cmbPais.ValueMember = "IdPais";


            btnEditar.Visible = true;
            btnGuardar.Visible = false;
             idUser = usuario.idUsuario.ToString();
            txtCedula.Text = usuario.Cedula;
            txtNombres.Text = usuario.Nombres;
            txtDireccion.Text = usuario.Direccion;
            txtTelefono.Text = usuario.Telefono;
            cmbPais.SelectedValue = usuario.idPais;


        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cls_usuarios clsUsuarios = new cls_usuarios();
                dto_usuarios user = new dto_usuarios();
                user.Cedula = txtCedula.Text;
                user.Nombres = txtNombres.Text;
                user.Direccion = txtDireccion.Text;
                user.Telefono = txtTelefono.Text;
                user.idPais = (int)cmbPais.SelectedValue;

                if (clsUsuarios.insertar(user))
                {
                    MessageBox.Show("Usuario registrado correctamente.");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                cls_usuarios clsUsuarios = new cls_usuarios();
                dto_usuarios user = new dto_usuarios();
                user.idUsuario = int.Parse(idUser);
                user.Cedula = txtCedula.Text;
                user.Nombres = txtNombres.Text;
                user.Direccion = txtDireccion.Text;
                user.Telefono = txtTelefono.Text;
                user.idPais = (int)cmbPais.SelectedValue;

                if (clsUsuarios.modificar(user))
                {
                    MessageBox.Show("Usuario modificado correctamente.");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el usuario: " + ex.Message);
            }
        }
    }
}
