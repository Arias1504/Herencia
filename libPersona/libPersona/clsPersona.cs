using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using libInstitucion;

namespace libPersona
{
    public abstract class clsPersona : clsInstitucion
    {
        #region "Atributos protegidos"
        protected string strDocumento;
        protected string strApellido;
        protected string strTelefono;
        protected string strGenero;
        protected float fltSalario;
        protected string strError;
        protected string strRpta;
        #endregion

        #region "Propiedades"
        public string Documento
        {
            get { return strDocumento; }
            set { strDocumento = value; }
        }
        public string Apellido
        {
            get { return strApellido; }
            set { strApellido = value; }
        }
        public string Telefono
        {
            get { return strTelefono; }
            set { strTelefono = value; }
        }
        public string Genero
        {
            get { return strGenero; }
            set { strGenero = value; }
        }
        public float Salario
        {
            get { return fltSalario; }
            set { fltSalario = value; }
        }
        public string Error
        {
            get { return strError; }
        }
        public string Respuesta
        {
            get { return strRpta; }
            set { strRpta = value; }
        }
        #endregion
    }

    public class clsAdministrativo: clsPersona
    {
        #region "Atributos"
        private string strArea;
        private string strCargo;
        private string strExtension;
        #endregion

        #region "Constructor"
        public clsAdministrativo()
        {
            strNombre = string.Empty;
            strDireccion = string.Empty;
            strDocumento = string.Empty;
            strApellido = string.Empty;
            strTelefono = string.Empty;
            strGenero = string.Empty;
            fltSalario = 0;
            strArea = string.Empty;
            strCargo = string.Empty;
            strExtension = string.Empty;
        }
        public clsAdministrativo(string name, string address, string ID, string lastname, string phone, string genre, float salary, string zona, string position, string ext)
        {
            strNombre = name;
            strDireccion = address;
            strDocumento = ID;
            strApellido = lastname;
            strTelefono = phone;
            strGenero = genre;
            fltSalario = salary;
            strArea = zona;
            strCargo = position;
            strExtension = ext;
        }
        #endregion

        #region "Propiedades"
        public string Area
        {
            get { return strArea; }
            set { strArea = value; }
        }
        public string Cargo
        {
            get { return strCargo; }
            set { strCargo = value; }
        }
        public string Extension
        {
            get { return strExtension; }
            set { strExtension = value; }
        }
        #endregion

        #region "Metodos privados"
        private bool Validar()
        {
            if (strNombre == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strDireccion == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strDocumento == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strApellido == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strTelefono == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strGenero == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (fltSalario == 0)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strArea == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strCargo == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strExtension == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            return true;
        }
        #endregion

        #region "Metodos publicos"
        public override bool Registrar()
        {
            StreamWriter sw = new StreamWriter("Admin.txt", true);
            try
            {
                if (!Validar())
                    return false;

                sw.WriteLine(Nombre + ";" + Direccion + ";" + Documento + ";" + Apellido + ";" + Telefono + ";" + Genero + ";" + Salario + ";" + Area + ";" + Cargo + ";" + Extension);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }

        public override bool Consultar()
        {
            try
            {
                string strPath = @"Admin.txt";
                int intCant = 0;
                string strLinea;
                string[] vectorLinea;
                string strDoc;
                intCant = File.ReadAllLines(strPath).Length;
                if (intCant <= 0)
                {
                    strError = "Sin registros";
                    return false;
                }
                StreamReader Archivo = new StreamReader(@strPath);
                while ((strLinea = Archivo.ReadLine()) != null)
                {
                    vectorLinea = strLinea.Split(';');
                    strDoc = vectorLinea[2];
                    if (strDoc == strDocumento.ToString())
                    {
                        strNombre = vectorLinea[0];
                        strApellido = vectorLinea[1];
                        strDocumento = vectorLinea[2];
                        strDireccion = vectorLinea[3];
                        strTelefono = vectorLinea[4];
                        strGenero = vectorLinea[5];
                        fltSalario = Convert.ToSingle(vectorLinea[6]);
                        strArea = vectorLinea[7];
                        strCargo = vectorLinea[8];
                        strExtension = vectorLinea[9];
                        break;
                    }
                }
                strError = "Sin registros";
                Archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }

        public override bool Resumen()
        {
            try
            {
                string strPath = @"Admin.txt";
                int intCant = 0;
                string strLinea;
                string[] vL;
                intCant = File.ReadAllLines(strPath).Length;
                if (intCant <= 0)
                {
                    strError = "Sin registros";
                    return false;
                }
                StreamReader Archivo = new StreamReader(@strPath);
                while ((strLinea = Archivo.ReadLine()) != null)
                {
                    vL = strLinea.Split(';');
                    strRpta += vL[0] + ", " + vL[1] + ", " + vL[2] + ", " + vL[3] + ", " + vL[4] + ", " + vL[5] + ", " + vL[6] + ", " + vL[7] + ", " + vL[8] + ", " + vL[9] + "<br>";
                }
                Archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }
        #endregion
    }

    public class clsDocente : clsPersona
    {
        #region "Atributos"
        private string strTipo;
        private string strCategoria;
        private float fltHoras;
        #endregion

        #region "Constructor"
        public clsDocente()
        {
            strNombre = string.Empty;
            strDireccion = string.Empty;
            strDocumento = string.Empty;
            strApellido = string.Empty;
            strTelefono = string.Empty;
            strGenero = string.Empty;
            fltSalario = 0;
            strTipo = string.Empty;
            strCategoria = string.Empty;
            fltHoras = 0;
        }
        public clsDocente(string name, string address, string ID, string lastname, string phone, string genre, float salary, string type, string category, float time)
        {
            strNombre = name;
            strDireccion = address;
            strDocumento = ID;
            strApellido = lastname;
            strTelefono = phone;
            strGenero = genre;
            fltSalario = salary;
            strTipo = type;
            strCategoria = category;
            fltHoras = time;
        }
        #endregion

        #region "Propiedades"
        public string Tipo
        {
            get { return strTipo; }
            set { strTipo = value; }
        }
        public string Categoria
        {
            get { return strCategoria; }
            set { strCategoria = value; }
        }
        public float Horas
        {
            get { return fltHoras; }
            set { fltHoras = value; }
        }
        #endregion

        #region "Metodos privados"
        private bool Validar()
        {
            if (strNombre == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strDireccion == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strDocumento == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strApellido == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strTelefono == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strGenero == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (fltSalario == 0)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strTipo == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strCategoria == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (fltHoras == 0)
            {
                strError = "Ingrese un valor";
                return false;
            }
            return true;
        }
        #endregion

        #region "Metodos publicos"
        public override bool Registrar()
        {
            StreamWriter sw = new StreamWriter("Docente.txt", true);
            try
            {
                if (!Validar())
                    return false;

                sw.WriteLine(Nombre + ";" + Apellido + ";" + Documento + ";" + Direccion + ";" + Telefono + ";" + Genero + ";" + Salario + ";" + Tipo + ";" + Categoria + ";" + Horas);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }

        public override bool Consultar()
        {
            try
            {
                string strPath = @"Docente.txt";
                int intCant = 0;  
                string strLinea;  
                string[] vectorLinea;  
                string strDoc;
                intCant = File.ReadAllLines(strPath).Length;  
                if (intCant <= 0)
                {
                    strError = "Sin registros";
                    return false;
                }
                StreamReader Archivo = new StreamReader(@strPath); 
                while ((strLinea = Archivo.ReadLine()) != null) 
                {
                    vectorLinea = strLinea.Split(';');
                    strDoc = vectorLinea[2]; 
                    if (strDoc == strDocumento.ToString())
                    {
                        strNombre = vectorLinea[0];
                        strApellido = vectorLinea[1];
                        strDocumento = vectorLinea[2];
                        strDireccion = vectorLinea[3];
                        strTelefono = vectorLinea[4];
                        strGenero = vectorLinea[5];
                        fltSalario = Convert.ToSingle(vectorLinea[6]);
                        strTipo = vectorLinea[7];
                        strCategoria = vectorLinea[8];
                        fltHoras = Convert.ToSingle(vectorLinea[9]);
                        break;
                    }
                }
                strError = "Sin registros";
                Archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }

        public override bool Resumen()
        {
            try
            {
                string strPath = @"Docente.txt";
                int intCant = 0;
                string strLinea;
                string[] vL;
                intCant = File.ReadAllLines(strPath).Length;
                if (intCant <= 0)
                {
                    strError = "Sin registros";
                    return false;
                }
                StreamReader Archivo = new StreamReader(@strPath);
                while ((strLinea = Archivo.ReadLine()) != null)
                {
                    vL = strLinea.Split(';');
                    strRpta += vL[0] + ", " + vL[1] + ", " + vL[2] + ", " + vL[3] + ", " + vL[4] + ", " + vL[5] + ", " + vL[6] + ", " + vL[7] + ", " + vL[8] + ", " + vL[9] + "<br>";
                }
                Archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }
        #endregion
    }

    public class clsEstudiante : clsPersona
    {
        #region "Atributos"
        private string strCarne;
        private string strPrograma;
        #endregion

        #region "Constructor"
        public clsEstudiante()
        {
            strNombre = string.Empty;
            strDireccion = string.Empty;
            strDocumento = string.Empty;
            strApellido = string.Empty;
            strTelefono = string.Empty;
            strGenero = string.Empty;
            strCarne = string.Empty;
            strPrograma = string.Empty;
        }
        public clsEstudiante(string name, string address, string ID, string lastname, string phone, string genre, string carnet, string program)
        {
            strNombre = name;
            strDireccion = address;
            strDocumento = ID;
            strApellido = lastname;
            strTelefono = phone;
            strGenero = genre;
            strCarne = carnet;
            strPrograma = program;
        }
        #endregion

        #region "Propiedades"
        public string Carne
        {
            get { return strCarne; }
            set { strCarne = value; }
        }
        public string Programa
        {
            get { return strPrograma; }
            set { strPrograma = value; }
        }
        #endregion

        #region "Metodos privados"
        private bool Validar()
        {
            if (strNombre == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strDireccion == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strDocumento == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strApellido == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strTelefono == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strGenero == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strCarne == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            if (strPrograma == string.Empty)
            {
                strError = "Ingrese un valor";
                return false;
            }
            return true;
        }
        #endregion

        #region "Metodos publicos"
        public override bool Registrar()
        {
            StreamWriter sw = new StreamWriter("Estudiante.txt", true);
            try
            {
                if (!Validar())
                    return false;

                sw.WriteLine(Nombre + ";" + Apellido + ";" + Documento + ";" + Direccion + ";" + Telefono + ";" + Genero + ";" + Carne + ";" + Programa);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }

        public override bool Consultar()
        {
            try
            {
                string strPath = @"Estudiante.txt";
                int intCant = 0;
                string strLinea;
                string[] vectorLinea;
                string strDoc;
                intCant = File.ReadAllLines(strPath).Length;
                if (intCant <= 0)
                {
                    strError = "Sin registros";
                    return false;
                }
                StreamReader Archivo = new StreamReader(@strPath);
                while ((strLinea = Archivo.ReadLine()) != null)
                {
                    vectorLinea = strLinea.Split(';');
                    strDoc = vectorLinea[2];
                    if (strDoc == strDocumento.ToString())
                    {
                        strNombre = vectorLinea[0]; 
                        strApellido = vectorLinea[1];
                        strDocumento = vectorLinea[2];
                        strDireccion = vectorLinea[3];
                        strTelefono = vectorLinea[4];
                        strGenero = vectorLinea[5];
                        strCarne = vectorLinea[6];
                        strPrograma = vectorLinea[7];
                        break;
                    }  
                }
                strError = "Sin registros";
                Archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }

        public override bool Resumen()
        {
            try
            {

                string strPath = @"Estudiante.txt";
                int intCant = 0;
                string strLinea;
                string[] vL;
                intCant = File.ReadAllLines(strPath).Length;
                if (intCant <= 0)
                {
                    strError = "Sin registros";
                    return false;
                }
                StreamReader Archivo = new StreamReader(@strPath);
                while ((strLinea = Archivo.ReadLine()) != null)
                {
                    vL= strLinea.Split(';');
                    strRpta += vL[0] + ", " + vL[1] + ", " + vL[2] + ", " + vL[3] + ", " + vL[4] + ", " + vL[5] + ", " + vL[6] + ", " + vL[7] + "<br>";
                }
                Archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }
        #endregion
    }
}
