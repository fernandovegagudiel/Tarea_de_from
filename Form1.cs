using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Clases;
using static WindowsFormsApp1.Clases.Crud;

namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    {
        Crud miCrud = new Crud();
      

        public Form1()
        {
            InitializeComponent();
        }

        private void button1saludar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola te saludo desde el formulario");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxCarnet_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text.Trim(); // obtener carnet del TextBox

            Crud crud = new Crud();
            Crud datos = crud.MostrarInformacion(carnet);

            // Asignar los valores obtenidos a los TextBox
            textBoxNombre.Text = datos.Nombre;
            comboBoxSeccion.Text = datos.Seccion;
            textBoxcorreo.Text = datos.Correo;

            CrudTareas cru = new CrudTareas();
            CrudTareas dato = cru.MostrarInformacion(carnet);

            // Asignar los valores obtenidos a los TextBox
            textBoxIdtarea.Text = dato.id_tarea;
            textBoxNota1.Text = dato.nota1;
            textBoxNota2.Text = dato.nota2;
            textBoxNota3.Text = dato.nota3;
            textBoxNota4.Text = dato.nota4;
           
        }

        private void textBoxseccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text.Trim();
            string nombre = textBoxNombre.Text.Trim();
            string seccion = comboBoxSeccion.Text.Trim();
            string correo = textBoxcorreo.Text.Trim();

            Crud crud = new Crud();
            string resultado = crud.InsertarInformacion(carnet, nombre, seccion, correo);

            string canet = textBoxCarnet.Text.Trim();
            string nota1 = textBoxNota1.Text.Trim();
            string nota2 = textBoxNota2.Text.Trim();
            string nota3 = textBoxNota3.Text.Trim();
            string nota4 = textBoxNota4.Text.Trim();

            CrudTareas cru = new CrudTareas();
            string resulta = cru.InsertarInformacion(carnet, nota1, nota2, nota3, nota4);
            

            MessageBox.Show(resultado,resulta);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text.Trim();

            if (string.IsNullOrEmpty(carnet))
            {
                MessageBox.Show("Por favor, ingrese un carnet.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Crud crud = new Crud();
            string resultado = crud.EliminarInformacion(carnet);

            MessageBox.Show(resultado, "RESULTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxCarnet.Clear();
            textBoxcorreo.Clear();
            textBoxNombre.Clear();
            comboBoxSeccion.Text = " ";
            textBoxIdtarea.Clear();
            textBoxNota1.Clear();
            textBoxNota2.Clear();
            textBoxNota3.Clear();
            textBoxNota4.Clear();


        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text.Trim();
            string nombre = textBoxNombre.Text.Trim();
            string seccion = comboBoxSeccion.Text.Trim();
            string correo = textBoxcorreo.Text.Trim();

            

            // Instancia de la clase donde está el método
            Crud conexion = new Crud(); // reemplaza con tu clase real

            string resultado = conexion.ActualizarInformacion(carnet, nombre, seccion, correo);

            MessageBox.Show(resultado);
        }

    

       

        private void buttonCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
