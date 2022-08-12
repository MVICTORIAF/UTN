using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TUP_PI_Parcial2_Colchones
{

    public partial class frmColchones : Form
    {
        bool nuevo = true;
        AccesoDatos oBD = new AccesoDatos();
        List<Colchon> lColchones = new List<Colchon>(); //lista dinamica para n Productos

        public frmColchones()
        {
            InitializeComponent();
        }

        private void frmColchones_Load(object sender, EventArgs e)
        {
         
            cargarCombo(cboMarca, "Marcas");
            cargarLista(lstColchones, "Colchones");
           
        }
        //-------------------------------------------------------------METODOS PRINCIPALES-------------------------------------
      
        private void cargarLista(ListBox lista, string nombreTabla)
        {

            lColchones.Clear();
            oBD.leerBD("SELECT * FROM " + nombreTabla);
            while (oBD.pLector.Read())
            {
                Colchon c = new Colchon();
            
                if (!oBD.pLector.IsDBNull(0))
                    c.pCodigo = oBD.pLector.GetInt32(0);
                if (!oBD.pLector.IsDBNull(1))
                    c.pNombre = oBD.pLector.GetString(1);
                if (!oBD.pLector.IsDBNull(2))
                    c.pMarca = oBD.pLector.GetInt32(2);
                if (!oBD.pLector.IsDBNull(3))
                    c.pPrecio = oBD.pLector.GetDouble(3);
            

                lColchones.Add(c);
            }
            oBD.desconectar();
            lista.Items.Clear();
            for (int i = 0; i < lColchones.Count; i++)
            {
                lista.Items.Add(lColchones[i].ToString());
            }
            lista.SelectedIndex = 0;
        }

        private void cargarCombo(ComboBox combo, string nombreTabla)
        {

            DataTable tabla = oBD.consultarBD("SELECT * FROM " + nombreTabla + " ORDER BY 2");
            combo.DataSource = tabla;
            combo.ValueMember = tabla.Columns[0].ColumnName; //"idMarca"
            combo.DisplayMember = tabla.Columns[1].ColumnName; //"nombreMarca"
            combo.DropDownStyle = ComboBoxStyle.DropDownList;

        }
      
        //-----------------------------------------------METODOS SECUNDARIOS----------------------------------------------------
      

        private void habilitar(bool x)
        {
            txtCodigo.Enabled = x;
            txtNombre.Enabled = x;
            cboMarca.Enabled = x;
            txtPrecio.Enabled = x;
            btnNuevo.Enabled = !x;
            btnGuardar.Enabled = x;
            btnSalir.Enabled = !x;
            lstColchones.Enabled = !x;

        }


        private void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cboMarca.SelectedIndex = -1;
            txtPrecio.Text = "";
        }

        //hacer 

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "") //obligo al usuario a cargar algo 
            {
                MessageBox.Show("Debe ingresar un codigo");
                return;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un Nombre");
                return;
            }
            if (cboMarca.SelectedIndex < 0) // obliga al usuario a cargar algo en el combobox
            {
                MessageBox.Show("Debe ingresar un codigo");
                return;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Debe ingresar un Precio");
                return;
            }
            try //probar 
            {
                int codigo = Convert.ToInt32(txtCodigo.Text); //comvertir a entero
                double precio = Convert.ToDouble(txtPrecio.Text); //comvertir a doble 

            }

            catch (Exception) //atrapar y no me frena el programa 
            {
                MessageBox.Show("El precio o el codigo es erroneo");
                return;
            }

            Colchon c = new Colchon();
            c.pCodigo = int.Parse(txtCodigo.Text); //bien 
            c.pNombre = txtNombre.Text; //bien 
            c.pMarca = (int)cboMarca.SelectedValue; //bien 
            c.pPrecio = double.Parse(txtPrecio.Text); //bien 

            if (nuevo)
            {
                string insertSQL = $"INSERT INTO Colchones VALUES ({c.pCodigo},'{c.pNombre}',{c.pMarca},{c.pPrecio})";

                oBD.actualizarBD(insertSQL);
                cargarLista(lstColchones, "Colchones");
            }
            else
            {
                string updateSql2 = $"UPDATE Colchones SET ({c.pCodigo},'{c.pNombre}',{c.pMarca},{c.pPrecio}' where codigo = {c.pCodigo})";

                oBD.actualizarBD(updateSql2);
                cargarLista(lstColchones, "Colchones");
                nuevo = true;
            }

            habilitar(false);
            limpiar();

            btnGuardar.Enabled = false;//me deshabilitar el boton guardar despues de guardar
            MessageBox.Show("Operacion Exitosa");

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
                   "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            habilitar(true);
            limpiar();
            txtCodigo.Focus();
        }

        private void lstColchones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarCampos(lstColchones.SelectedIndex);
        }

        private void cargarCampos(int posicion)
        {
            txtCodigo.Text = lColchones[posicion].pCodigo.ToString();
            txtNombre.Text = lColchones[posicion].pNombre;
            cboMarca.SelectedValue = lColchones[posicion].pMarca;
            txtPrecio.Text = lColchones[posicion].pPrecio.ToString();
        }
    }
}


