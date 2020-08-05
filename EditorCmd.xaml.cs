using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Forms;

namespace STARK
{
    public partial class EditorCmd : Window
    {
        DataBase<BaseDatos> bd = new DataBase<BaseDatos>(@"Base_Datos\CmdSociales.json");
        byte id_bd = 0;
        private string tipo;
        public EditorCmd()
        {
            InitializeComponent();
            bd.CargarComandos(@"Base_Datos\CmdSociales.json");
        }

        private void MostrarComandos(List<BaseDatos> lista)
        {
            try
            {
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = lista;
                DataGridP.Columns[0].Visibility = Visibility.Hidden;
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MostrarComandos(bd.comandos);
        }

        private void BtnSociales_Click(object sender, RoutedEventArgs e)
        {
            bd = new DataBase<BaseDatos>(@"Base_Datos\CmdSociales.json");
            bd.CargarComandos(@"Base_Datos\CmdSociales.json");
            MostrarComandos(bd.comandos);
            id_bd = 0;
        }

        private void BtnCarpetas_Click(object sender, RoutedEventArgs e)
        {
            bd = new DataBase<BaseDatos>(@"Base_Datos\CmdCarpetas.json");
            bd.CargarComandos(@"Base_Datos\CmdCarpetas.json");
            MostrarComandos(bd.comandos);
            id_bd = 1;
        }

        private void BtnAplicaciones_Click(object sender, RoutedEventArgs e)
        {
            bd = new DataBase<BaseDatos>(@"Base_Datos\CmdAplicaciones.json");
            bd.CargarComandos(@"Base_Datos\CmdAplicaciones.json");
            MostrarComandos(bd.comandos);
            id_bd = 2;
        }

        private void BtnPaginasWebs_Click(object sender, RoutedEventArgs e)
        {
            bd = new DataBase<BaseDatos>(@"Base_Datos\CmdPaginasWebs.json");
            bd.CargarComandos(@"Base_Datos\CmdPaginasWebs.json");
            MostrarComandos(bd.comandos);
            id_bd = 3;
        }

        private void BtnInternos_Click(object sender, RoutedEventArgs e)
        {
            bd = new DataBase<BaseDatos>(@"Base_Datos\CmdInternos.json");
            bd.CargarComandos(@"Base_Datos\CmdInternos.json");
            MostrarComandos(bd.comandos);
            id_bd = 4;
        }

        private void BtnPuertoSerial_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("En algún momento habrá una característica por aquí.");
        }

        private void BtnIO_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNuevoComando_Click(object sender, RoutedEventArgs e)
        {
            if (BtnNuevoComando.Content.Equals("NUEVO COMANDO"))
            {
                Tbx_Comando.Visibility = Visibility.Visible;
                tbxAccion.Visibility = Visibility.Visible;
                BtnBuscar.Visibility = Visibility.Visible;
                TbxRespuesta.Visibility = Visibility.Visible;
                BtnNuevoComando.Content = "AGREGAR";
            }
            else if (Tbx_Comando.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("No se permiten comandos vacios", "Error de sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BaseDatos cmd = new BaseDatos(bd.comandos.Count + 1, Tbx_Comando.Text, tbxAccion.Text, TbxRespuesta.Text);
                bd.InsertarComandos(cmd, id_bd);
                Tbx_Comando.Text = "";
                tbxAccion.Text = "";
                TbxRespuesta.Text = "";
                Tbx_Comando.Visibility = Visibility.Hidden;
                tbxAccion.Visibility = Visibility.Hidden;
                BtnBuscar.Visibility = Visibility.Hidden;
                TbxRespuesta.Visibility = Visibility.Hidden;
                MostrarComandos(bd.comandos);
                BtnNuevoComando.Content = "NUEVO COMANDO";
            }
        }

        private void BtnEliminarComando_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("En algún momento habrá una característica por aquí.");
        }

        private void BtnImportar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExportar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == "Aplicaciones")
            {
                Microsoft.Win32.OpenFileDialog buscar_programa = new Microsoft.Win32.OpenFileDialog();
                buscar_programa.ShowDialog();
                tbxAccion.Text = buscar_programa.FileName.ToString();
            }
            else if (tipo == "Carpetas")
            {
                System.Windows.Forms.FolderBrowserDialog buscar_carpetas = new System.Windows.Forms.FolderBrowserDialog();
                buscar_carpetas.ShowDialog();
                tbxAccion.Text = buscar_carpetas.SelectedPath;
            }
        }

        private void DataGridP_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void DataGridP_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
