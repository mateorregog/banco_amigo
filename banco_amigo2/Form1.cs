using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banco_amigo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool deposito,retiro = false;
        double monto_movimiento = 0;
      
        private void button4_Click(object sender, EventArgs e)
        {
            
            SqlConnection conexion = new SqlConnection("server=PC-YOVANY; database=banco_amigo; integrated security=true");
            conexion.Open();
            String ID = textBox8.Text;
            double saldo = 0;
            string cadena = "insert into cliente(ID,saldo) values('" + ID + "','" + saldo + "')";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro guardado");
            textBox8.Text = "";
            textBox1.Focus();
            conexion.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=PC-YOVANY; database=banco_amigo; integrated security=true");
            conexion.Open();
            MessageBox.Show("Servidor conectado");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                textBox8.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                button2.Enabled = true;
                button3.Enabled = true;     
        }

        private void button2_Click(object sender, EventArgs e)
        {
                button3.Enabled = false;
                deposito = true;
                textBox4.Enabled = false;
                textBox6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (deposito)
            {
                textBox3.Text = textBox2.Text;
                monto_movimiento = double.Parse(textBox2.Text);
                SqlConnection conexion = new SqlConnection("server=PC-YOVANY; database=banco_amigo; integrated security=true");
                conexion.Open();
                String ID = textBox1.Text;
                double saldo = 0;
                string cadena = "SELECT * FROM cliente WHERE ID = @ID";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.Add("@ID", SqlDbType.Int);
                comando.Parameters["@ID"].Value = ID;
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    textBox5.Text = registro["saldo"].ToString();
                    saldo = double.Parse(registro["saldo"].ToString());
                }
                else
                {
                    MessageBox.Show("El registro no existe");
                }
                saldo = monto_movimiento + saldo;
                textBox7.Text = saldo.ToString();
                conexion.Close();
            }
            else if (retiro)
            {
                {
                    textBox4.Text = textBox2.Text;
                    monto_movimiento = double.Parse(textBox2.Text);
                    SqlConnection conexion = new SqlConnection("server=PC-YOVANY; database=banco_amigo; integrated security=true");
                    conexion.Open();
                    String ID = textBox1.Text;
                    double saldo = 0;
                    string cadena = "SELECT * FROM cliente WHERE ID = @ID";
                    SqlCommand comando = new SqlCommand(cadena, conexion);
                    comando.Parameters.Add("@ID", SqlDbType.Int);
                    comando.Parameters["@ID"].Value = ID;
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        textBox6.Text = registro["saldo"].ToString();
                        saldo = double.Parse(registro["saldo"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("El registro no existe");
                    }
                    saldo = saldo - monto_movimiento;
                    textBox7.Text = saldo.ToString();
                    conexion.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                button2.Enabled = false;
                retiro = true;
                textBox3.Enabled = false;
                textBox5.Enabled = false;
        }
    }
}

