using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPersona;
using System.IO;

namespace appUniversidad
{
    public partial class WebFormUniversidad : System.Web.UI.Page
    {
        #region "Variables globales"
        static int intPer;
        static string strDoc;
        #endregion

        #region "Metodos Propios"
        private void Mensaje(string texto)
        {
            this.lblMensaje.Text = texto;
        }

        private void LimpiarDatos()
        {
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtGenero.Text = string.Empty;
            this.txtSalario.Text = null;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Por 1ra vez.
            {
                intPer = 1;
                this.txtNombre.Focus();
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string Nom, Dir, Ape, Doc, Tel, Gen;
            float Sal;
            try
            {
                switch (intPer)
                {
                    case 1:
                        Nom = this.txtNombre.Text;
                        Dir = this.txtDireccion.Text;
                        Doc = this.txtDocumento.Text;
                        Ape = this.txtApellido.Text;
                        Tel = this.txtTelefono.Text;
                        Gen = this.txtGenero.Text;
                        Sal = Convert.ToSingle(this.txtSalario.Text);
                        string Ar = this.txtArea.Text;
                        string Car = this.txtCargo.Text;
                        string Ext = this.txtExtension.Text;

                        clsAdministrativo Admin = new clsAdministrativo(Nom, Dir, Doc, Ape, Tel, Gen, Sal, Ar, Car, Ext);
                        if (!Admin.Registrar())
                        {
                            Mensaje("Error, " + Admin.Error);
                            Admin = null;
                            this.txtNombre.Focus();
                            return;
                        }
                        Mensaje("Grabado con exito");
                        LimpiarDatos();
                        this.txtArea.Text = string.Empty;
                        this.txtCargo.Text = string.Empty;
                        this.txtExtension.Text = string.Empty;
                        break;
                    case 2:
                        Nom = this.txtNombre.Text;
                        Dir = this.txtDireccion.Text;
                        Doc = this.txtDocumento.Text;
                        Ape = this.txtApellido.Text;
                        Tel = this.txtTelefono.Text;
                        Gen = this.txtGenero.Text;
                        Sal = Convert.ToSingle(this.txtSalario.Text);
                        string Tip = this.txtTipo.Text;
                        string Cat = this.txtCategoria.Text;
                        float Hor = Convert.ToSingle(this.txtHoras.Text);

                        clsDocente Docente = new clsDocente(Nom, Dir, Doc, Ape, Tel, Gen, Sal, Tip, Cat, Hor);
                        if (!Docente.Registrar())
                        {
                            Mensaje("Error, " + Docente.Error);
                            Admin = null;
                            this.txtNombre.Focus();
                            return;
                        }
                        Mensaje("Grabado con exito");
                        LimpiarDatos();
                        this.txtTipo.Text = string.Empty;
                        this.txtCategoria.Text = string.Empty;
                        this.txtHoras.Text = null;
                        break;
                    default:
                        Nom = this.txtNombre.Text;
                        Dir = this.txtDireccion.Text;
                        Doc = this.txtDocumento.Text;
                        Ape = this.txtApellido.Text;
                        Tel = this.txtTelefono.Text;
                        Gen = this.txtGenero.Text;
                        string Carnet = this.txtCarne.Text;
                        string Programa = this.txtPrograma.Text;

                        clsEstudiante Estudiante = new clsEstudiante(Nom, Dir, Doc, Ape, Tel, Gen, Carnet, Programa);
                        if (!Estudiante.Registrar())
                        {
                            Mensaje("Error, " + Estudiante.Error);
                            Admin = null;
                            this.txtNombre.Focus();
                            return;
                        }
                        Mensaje("Grabado con exito");
                        LimpiarDatos();
                        this.txtCarne.Text = string.Empty;
                        this.txtPrograma.Text = string.Empty;
                        break;
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error en ejecución -> " + ex.Message);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            intPer = this.rblPersona.SelectedIndex + 1;
            this.pnlAdmin.Visible = false;
            this.pnlDocente.Visible = false;
            this.pnlEstudiante.Visible = false;

            switch (intPer)
            {
                case 1:
                    this.pnlAdmin.Visible = true;
                    this.txtArea.Focus();
                    break;
                case 2:
                    this.pnlDocente.Visible = true;
                    this.txtTipo.Focus();
                    break;
                default:
                    this.pnlEstudiante.Visible = true;
                    this.txtCarne.Focus();
                    break;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string Document;

            Document = txtBuscar.Text;

            if (rblPersona.SelectedIndex == 0)
            {
                strDoc = txtBuscar.Text;

                clsAdministrativo ad = new clsAdministrativo();
                ad.Documento = strDoc;
                ad.Consultar();
                this.txtDocumento.Text = ad.Documento;
                this.txtApellido.Text = ad.Apellido;
                this.txtNombre.Text = ad.Nombre;
                this.txtTelefono.Text = ad.Telefono;
                this.txtDireccion.Text = ad.Direccion;
                this.txtGenero.Text = ad.Genero;
                this.txtSalario.Text = Convert.ToString(ad.Salario);
                this.txtArea.Text = ad.Area;
                this.txtCargo.Text = ad.Cargo;
                this.txtExtension.Text = ad.Extension;
                
            }
            if(rblPersona.SelectedIndex == 1)
            {
                strDoc = txtBuscar.Text;

                clsDocente dc = new clsDocente();
                dc.Documento = strDoc;
                dc.Consultar();
                this.txtDocumento.Text = dc.Documento;
                this.txtApellido.Text = dc.Apellido;
                this.txtNombre.Text = dc.Nombre;
                this.txtTelefono.Text = dc.Telefono;
                this.txtDireccion.Text = dc.Direccion;
                this.txtGenero.Text = dc.Genero;
                this.txtTipo.Text = dc.Tipo;
                this.txtCategoria.Text = dc.Categoria;
                this.txtHoras.Text = Convert.ToString(dc.Horas);
                this.txtSalario.Text = Convert.ToString(dc.Salario);
            }
            if (rblPersona.SelectedIndex == 2)
            {
                strDoc = txtBuscar.Text;

                clsEstudiante est = new clsEstudiante();
                est.Documento = strDoc;
                est.Consultar();
                this.txtDocumento.Text = est.Documento;
                this.txtApellido.Text = est.Apellido;
                this.txtNombre.Text = est.Nombre;
                this.txtTelefono.Text = est.Telefono;
                this.txtDireccion.Text = est.Direccion;
                this.txtGenero.Text = est.Genero;
                this.txtCarne.Text = est.Carne;
                this.txtPrograma.Text = est.Programa;
            }
        }

        protected void btnResumen_Click(object sender, EventArgs e)
        {
            if (rblPersona.SelectedIndex == 0)
            {
                clsAdministrativo adm = new clsAdministrativo();
                adm.Resumen();
                this.lblMensaje.Text = adm.Respuesta;
            }
            if (rblPersona.SelectedIndex == 1)
            {
                clsDocente dc = new clsDocente();
                dc.Resumen();
                this.lblMensaje.Text = dc.Respuesta;
            }
            if (rblPersona.SelectedIndex == 2)
            {
                clsEstudiante est = new clsEstudiante();
                est.Resumen();
                this.lblMensaje.Text = est.Respuesta;
            }
        }
    }
}