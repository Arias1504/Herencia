using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libInstitucion
{
    public abstract class clsInstitucion
    {
        #region "Atributos protegidos"
        protected string strNombre;
        protected string strDireccion;
        #endregion

        #region "propiedades"
        public string Nombre
        {
            get { return strNombre; }
        }
        public string Direccion
        {
            get { return strDireccion; }
        }
        #endregion

        #region "Metodos publicos"
        public abstract bool Registrar();
        public abstract bool Consultar();
        public abstract bool Resumen();
        #endregion
    }
}
