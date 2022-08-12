using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_Parcial2_Colchones
{
    class Colchon
    {
        private int codigo;

        public int pCodigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string nombre;

        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private double precio;

        public double pPrecio
        {
            get { return precio; }
            set { precio = value; }
        }
        private int marca;


        public int pMarca
        {
            get { return marca; }
            set { marca = value; }
        }

        public Colchon()
        {
            this.codigo = 0;
            this.nombre = "";
            this.precio = 0;
            this.marca = 0;
        }

        public Colchon(int codigo, string nombre, double precio, int marca)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.marca = marca;
        }

        public override string ToString()
        {
            return codigo + " - " + nombre + " - " + precio;
        }
    }
}
