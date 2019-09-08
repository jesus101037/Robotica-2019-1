using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace convolucion
{
    public partial class convInput : Form
    {
        /// <summary>
        /// Tamanio de la matriz de filtro
        /// </summary>
        int filtroN = 3;

        public convInput()
        {
            InitializeComponent();
            inicializar();
        }

        public void inicializar() {
            filtroN = 3;
            cbFiltroN.SelectedIndex = 0;
            pbOrigen.Image = pbOrigen.ErrorImage;
            pbFiltro.Image = pbFiltro.ErrorImage;
            inicializarFiltro();
        }
        public void inicializarFiltro() {
            for (int i = 0; i < filtroN; i++)
            {
                for (int j = 0; j < filtroN; j++)
                {
                    dgvFiltro[i, j].Value = 0;
                }
            }
        }

        /// <summary>
        /// Evalua que <paramref name="Valor"/> esta en el rango [0;255]
        /// </summary>
        /// <param name="Valor">Valor a evaluar</param>
        /// <returns></returns>
        public int analisisValor(int Valor) {
            if (Valor < 0)
            {
                Valor = 0;
            }
            else if (Valor > 255)
            {
                Valor = 255;
            }
            return Valor;
        }

        /// <summary>
        /// Aplica el operador de convolucion para un pixel en la posción central de <paramref name="subMatriz"/>
        /// con un filtro definido en <paramref name="filtro"/>.
        /// </summary>
        /// <param name="subMatriz">Sub matriz de la imagen del mismo tamanio que <paramref name="filtro"/></param>
        /// <param name="filtro"></param>
        /// <returns>Resultado de aplicar la convolucion entre <paramref name="subMatriz"/> y <paramref name="filtro"/></returns>
        public int convolucionPixel(int[,] subMatriz, double[,] filtro) {
            int resultado = 0;
            double parcial = 0;
            int longitud = subMatriz.GetLength(0);
            for (int i = 0; i < longitud; i++)
            {
                for (int j = 0; j < longitud; j++)
                {
                    parcial = parcial + subMatriz[i, j] * filtro[i, j];
                }
            }
            resultado = Convert.ToInt32(parcial);
            return analisisValor(resultado);
        }
        /// <summary>
        /// Obtienen una matriz de <paramref name="n"/>x<paramref name="n"/> que rodea al elemento
        /// pivot en la posicion (<paramref name="x"/>, <paramref name="y"/>) de <paramref name="matriz"/>
        /// </summary>
        /// <param name="matriz">Matriz origen</param>
        /// <param name="x">Coordenada en x del pivot</param>
        /// <param name="y">Coordenada en y del pivot</param>
        /// <param name="n">Tamanio de la matriz cuadrada, debe ser impar</param>
        /// <returns></returns>
        public int[,] obtenerSubmatriz(int[,] matriz, int x, int y, int n) {
            int[,] subMatriz = new int[n, n];
            int r = (n / 2);
            int maxX = matriz.GetLength(0);
            int maxY = matriz.GetLength(1);
            int xMin = 0;
            int yMin = 0;
            int xMax = 0;
            int yMax = 0;
            for (int i = 0; i < n; i++)
            {
                xMin = x + i - r;
                xMax = x + i + r;
                if (xMin >= 0 && xMax < maxX)
                {
                    for (int j = 0; j < n; j++)
                    {
                        yMin = y + j - r;
                        yMax = y + j + r;
                        if (yMin >= 0 && yMax < maxY)
                        {
                            subMatriz[i, j] = matriz[xMin, yMin];
                        }
                    }
                }
            }
            return subMatriz;
        }

        /// <summary>
        /// Aplica la operacion de convolución a cada pixel de cada canal RGB de la imagen
        /// <paramref name="img"/> con el filtro <paramref name="filtro"/>
        /// </summary>
        /// <param name="img">Imagen a la cual se desea aplicar el filtro</param>
        /// <param name="filtro">Filtro a aplicar a la imagen, debe ser una matriz impar</param>
        /// <returns></returns>
        public Bitmap aplicarFiltro(Bitmap img, double[,] filtro) {
            int n = filtro.GetLength(0);
            Bitmap imgR = new Bitmap(img.Width, img.Height);
            // Variables que contienen la posicion del pivot
            //int x, y;
            // Matrices q representa la imagen original en sistema RGB
            int[,] imaR = new int[img.Width, img.Height];
            int[,] imaG = new int[img.Width, img.Height];
            int[,] imaB = new int[img.Width, img.Height];
            // Matrices que contendra la imagen en sistema RGB despues de aplicar el filtro
            int[,] imaRR = new int[img.Width, img.Height];
            int[,] imaRG = new int[img.Width, img.Height];
            int[,] imaRB = new int[img.Width, img.Height];
            // Generamos las matrices con los valores de los canales RGB de la imagen.
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    Color oc = img.GetPixel(x, y);
                    imaR[x, y] = (int)(oc.R);
                    imaG[x, y] = (int)(oc.G);
                    imaB[x, y] = (int)(oc.B);
                }
            }

            for (int x = 0; x < img.Width - 1; x++)
            {
                
                for (int y = 0; y < img.Height - 1; y++)
                {

                    imaRR[x, y] = convolucionPixel(obtenerSubmatriz(imaR, x, y, n), filtro);
                    imaRG[x, y] = convolucionPixel(obtenerSubmatriz(imaG, x, y, n), filtro);
                    imaRB[x, y] = convolucionPixel(obtenerSubmatriz(imaB, x, y, n), filtro);

                    Color oc = img.GetPixel(x, y);

                    int colorR = analisisValor(imaRR[x, y]);
                    int colorG = analisisValor(imaRG[x, y]);
                    int colorB = analisisValor(imaRB[x, y]);
                    Color nc = Color.FromArgb(oc.A, colorR, colorG, colorB);

                    imgR.SetPixel(x, y, nc);
                }
            }
            return imgR;
        }

        public double[,] obtenerFiltro() {
            double[,] filtro = new double[filtroN, filtroN];
            for (int i = 0; i < filtroN; i++)
            {
                for (int j = 0; j < filtroN; j++)
                {
                    string aux = dgvFiltro[j, i].Value.ToString();
                    filtro[i, j] = double.Parse(aux);
                }
            }
            return filtro;
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

        private void aplicarFiltro_click(object sender, EventArgs e)
        {
            //pictureBox2 = new PictureBox();
            Bitmap im = (Bitmap)(pbOrigen.Image);
            pbFiltro.Image = aplicarFiltro(im, obtenerFiltro());
        }

        private void buCancelar_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void cbFiltroN_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroN = int.Parse(cbFiltroN.Items[cbFiltroN.SelectedIndex].ToString());
            dgvFiltro.ColumnCount = filtroN;
            dgvFiltro.RowCount = filtroN;
            inicializarFiltro();
        }
    }
}
