using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;

namespace lineasCirculosStatico
{
    public partial class input : Form
    {
        /// <summary>
        /// Tamanio de la matriz de filtro
        /// </summary>
        int filtroN = 3;
        HoughMap hough;

        public input()
        {
            InitializeComponent();
            inicializar();
        }

        public void inicializar() {
            pbOrigen.Image = pbOrigen.ErrorImage;
            pbFiltro.Image = pbFiltro.ErrorImage;
        }

        private void buscarImg_click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;...";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Seleccione image.";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Recuperar imagen.
                Bitmap image = new Bitmap(new Bitmap(dialog.FileName),pbOrigen.Width, pbOrigen.Height);
                pbOrigen.Image = image;
            }
        }

        private int[,] obtenerMatrizBinaria(Bitmap img) {
            int[,] matrizBinaria = new int[img.Width, img.Height];
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color c = img.GetPixel(i, j);
                    if (c.R != 0 && c.G != 0 && c.B != 0) {
                        matrizBinaria[i, j] = 1;
                    }
                }
            }
            return matrizBinaria;
        }

        private void procesar_click(object sender, EventArgs e)
        {
            // Convertir a escala de grises
            Bitmap origen = Grayscale.CommonAlgorithms.RMY.Apply((Bitmap)(pbOrigen.Image));
            // Aplicar filtros
            CannyEdgeDetector borde = new CannyEdgeDetector();
            borde.ApplyInPlace(origen);

            hough = new HoughMap(origen);
            hough.Procesar(125);
            pbFiltro.Image = hough.imgResultado;
        }

        private void buCancelar_Click(object sender, EventArgs e)
        {
            inicializar();
        }
    }
}
