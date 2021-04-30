using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using datos;
using modelo;

using Northwind;

namespace Northwind
{
    public partial class Form1 : Form
    {
        List<Producto> productos = new List<Producto>();
        List<Cliente> clientes = new List<Cliente>();
        List<Producto> comprados = new List<Producto>();
        List<Pvendido> vendidos = new List<Pvendido>();

        DaoProductos DaoPro;
        DaoEmpleado daoEmpleado;
        DaoCliente DaoCliente;

        public Form1()
        {

            InitializeComponent();
            daoEmpleado = new DaoEmpleado();
            DaoCliente = new DaoCliente();
            DaoPro = new DaoProductos();
            clientes = DaoCliente.obtenerTodos();
            productos = DaoPro.obtenerTodos();
            carga();
            dgbVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgbVenta.MultiSelect = false;
            dgbVenta.ReadOnly = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Conexion.conectar())
            {
                MessageBox.Show("Conectado");
            }
            else
            {
                MessageBox.Show("No conectado");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public void carga()
        {
            for (int i = 0; i < productos.Count; i++)
            {
                cbProducto.Items.Add(productos[i].Nombre);

            }
            for (int i = 0; i < clientes.Count; i++)
            {
                cbCliente.Items.Add(clientes[i].Nombre);

            }

            txtEmpleado.Text = daoEmpleado.obtenerUno(1).Nombre;


        }
        String CantidadDeUnidad = "";
        double Prec = 0;
        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < productos.Count; i++)
            {
                if (cbProducto.Items[cbProducto.SelectedIndex].Equals(productos[i].Nombre))
                {
                    txtPrecio.Text = "" + DaoPro.obtenerUno(productos[i].Id).Precio;
                    Prec= double.Parse(""+DaoPro.obtenerUno(productos[i].Id).Precio);
                    CantidadDeUnidad = "" + DaoPro.obtenerUno(productos[i].Id).Cantidad;
                    //txtCantidad.Text = "" + DaoPro.obtenerUno(productos[i].Id).Cantidad;
                    MessageBox.Show("Cantidad: "+ CantidadDeUnidad);
                    break;
                }

            }



        }
        int cantidadDeceada = 0;
        double total = 0; 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cantidadDeceada = int.Parse(txtCantidad.Text);
           int CantduEntera=int.Parse(CantidadDeUnidad);

            if (cantidadDeceada > CantduEntera)
            {





                notificacion();




            }else
            {
                MessageBox.Show("Agregado");
                CantduEntera = CantduEntera - cantidadDeceada;
                MessageBox.Show("Cantidad restante: "+ CantduEntera);
                total = total + (Prec * cantidadDeceada);
                txtTotal.Text = "" + total;
                double subtotal = double.Parse(txtPrecio.Text) * int.Parse(txtCantidad.Text);


                Pvendido nuevo= new Pvendido(DaoPro.obtenerUno(productos[cbProducto.SelectedIndex].Id).Nombre, double.Parse(txtPrecio.Text),int.Parse(txtCantidad.Text),subtotal);
                vendidos.Add(nuevo);
                comprados.Add(DaoPro.obtenerUno(productos[cbProducto.SelectedIndex].Id));

                dgbVenta.DataSource =vendidos ;
                

            }
        }
        double DineroRecibido = 0;
        double Cambio = 0;
        public void recibido()
        {
            DineroRecibido = double.Parse(txtRecibido.Text);
            Cambio = DineroRecibido - total;
                txtCambio.Text = ""+Cambio;
            if (DineroRecibido < total)
            {
                MessageBox.Show("Te falta dinero hijo");
            }
            
            
            
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            recibido();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            
        }

        public void notificacion()
        {
            
            Alerta.Text = "Cantidad Insuficiente";
            Alerta.BalloonTipTitle = "Alerta";
            Alerta.BalloonTipText = "¿Desea añadir solo la existencia actual?";
            Alerta.BalloonTipIcon = ToolTipIcon.Warning;
            Alerta.Visible=true;

            Alerta.ShowBalloonTip(0);

        }
    }
}
