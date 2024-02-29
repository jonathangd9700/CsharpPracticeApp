using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Discos
    {

        public int id { get; set; }

        public string titulo { get; set; }

        public int cantidadCanciones { get; set; }

        public string urlImagenTapa {  get; set; }

        public Estilos Edicion { get; set; }
        public Estilos TipoEdicion { get; set; }

    }
}
