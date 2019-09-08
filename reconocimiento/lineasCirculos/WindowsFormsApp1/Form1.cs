using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MJPEGStream stream;
        Bitmap bmp;

        bool Ingreso = false;
        bool Hay2Circulos = false;

        int tiempoGiro;

        public Form1()
        {
            InitializeComponent();
            string url = "http://" + obtenerIP() + "/mjpegfeed?640x480";
            stream = new MJPEGStream(url);
            stream.NewFrame += streamNewFrame;
            tiempoGiro = 2000;
        }

        private string obtenerIP() {
            string ip = $"{nudIP1.Value.ToString()}.{nudIP2.Value.ToString()}.{nudIP3.Value.ToString()}.{nudIP4.Value.ToString()}:{nudPort.Value.ToString()}";
            return ip;
        }

        private void streamNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bmp = (Bitmap)eventArgs.Frame.Clone();
            pbInput.Image = bmp;

            if (!Ingreso)
            {
                backgroundWorker1.RunWorkerAsync(bmp);
                Ingreso = true;
            }
        }

        delegate void pasarImagen(Bitmap Mapa);

        private void mostrarImagen(Bitmap Mapa)
        {
            pbProcesado.Image = Mapa;
        }

        delegate void Pasar_Datos(List<string> Datos);

        private void Mostrar_Datos(List<string> Datos)
        {
            if (Datos.Count == 2)
            {
                string[] Datos1 = Datos[0].Split('-');
                lbl_C1X.Text = Datos1[0];
                lbl_C1Y.Text = Datos1[1];
                lbl_Radio1.Text = Datos1[2];

                string[] Datos2 = Datos[1].Split('-');
                lbl_C2X.Text = Datos2[0];
                lbl_C2Y.Text = Datos2[1];
                lbl_Radio2.Text = Datos2[2];
                Hay2Circulos = true;
            }
            else
            {
                Hay2Circulos = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap bmp2 = (Bitmap)e.Argument;

            //bmp2 = Escala_Grises_Borde((Bitmap)ImgReducida.Clone());
            bmp2 = MostrarAzul(bmp2);

            List<string> Datos = Procesar_Circulos(bmp2);

            Pasar_Datos pd = new Pasar_Datos(Mostrar_Datos);
            this.Invoke(pd, Datos);

            pasarImagen pa = new pasarImagen(mostrarImagen);
            this.Invoke(pa, bmp2);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Hay2Circulos)
            {
                //Hacer que el carro gire avance y vuelva a girar
                if (float.Parse(lbl_Radio1.Text) - float.Parse(lbl_Radio2.Text) > 2)
                {
                    double radio1 = double.Parse(lbl_Radio1.Text);
                    double Distancia1 = 4.5 * 0.22 / radio1 / 100;

                    //lbl_DistanciaCirculo1.Text = Distancia1.ToString();

                    double radio2 = double.Parse(lbl_Radio2.Text);
                    double Distancia2 = 4.5 * 0.22 / radio2 / 100;
                    //lbl_DistanciaCirculo2.Text = Distancia2.ToString();


                    double Tiempo = Math.Abs(Distancia1 - Distancia2) / 5;

                    Pasar_Distancias pa = new Pasar_Distancias(Mostrar_Distancia);
                    string a = Distancia1.ToString() + "-" + Distancia2.ToString();

                    this.Invoke(pa, a);

                    //giro a la derecha
                    serialPort1.Write("d");
                    System.Threading.Thread.Sleep(tiempoGiro);

                    //avanzar
                    serialPort1.Write("w");
                    System.Threading.Thread.Sleep(Convert.ToInt32(Tiempo * 1000));

                    //giro a la izquierda
                    tiempoGiro += 500;
                    serialPort1.Write("a");
                    System.Threading.Thread.Sleep(tiempoGiro);

                }
                else
                {
                    serialPort1.Write("w");
                }
            }

            backgroundWorker1.Dispose();
            backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync(bmp);
        }

        //video
        private void buIniciar_Click(object sender, EventArgs e)
        {
            stream.Start();
        }

        private void buTerminar_Click(object sender, EventArgs e)
        {
            stream.Stop();
        }

        public Bitmap MostrarAzul(Bitmap Mapa)
        {
            Bitmap AuxMapa = Mapa;
            for (int x = 1; x < AuxMapa.Width - 1; x++)
            {
                for (int y = 1; y < AuxMapa.Height - 1; y++)
                {
                    Color oc = AuxMapa.GetPixel(x, y);
                    Color nc = Color.FromArgb(oc.A, 0, 0, oc.B);

                    if ((oc.B > 100) && (oc.G < 100) && (oc.R < 100))
                    {
                        nc = Color.FromArgb(oc.A, 0, 0, 255);
                    }
                    else if ((oc.R > 100) && (oc.G < 100) && (oc.B < 100))
                    {
                        nc = Color.FromArgb(oc.A, 255, 0, 0);
                    }
                    else
                    {
                        nc = Color.FromArgb(oc.A, 0, 0, 0);
                    }

                    AuxMapa.SetPixel(x, y, nc);
                }
            }
            return AuxMapa;
        }

        public List<string> Procesar_Circulos(Bitmap BMP)
        {

            List<string> Datos = new List<string>();

            Rectangle RECTANGULO = new Rectangle(0, 0, BMP.Width, BMP.Height);
            BitmapData BMPDATOS = BMP.LockBits(RECTANGULO, ImageLockMode.ReadWrite, BMP.PixelFormat);

            Bitmap A = new Bitmap(BMP.Width, BMP.Height);

            ColorFiltering FILTRO = new ColorFiltering();

            FILTRO.Red = new IntRange(0, 100);
            FILTRO.Green = new IntRange(0, 100);
            FILTRO.Blue = new IntRange(0, 100);

            FILTRO.FillOutsideRange = false;
            FILTRO.ApplyInPlace(BMPDATOS);

            //BUSCA LOS ELEMENTOS
            BlobCounter ELEMENTOS = new BlobCounter();
            ELEMENTOS.FilterBlobs = true;
            ELEMENTOS.MinHeight = 5; //ALTURA MINIMA
            ELEMENTOS.MinWidth = 5;

            ELEMENTOS.ProcessImage(BMPDATOS);

            Blob[] ELEMENTOSINFO = ELEMENTOS.GetObjectsInformation();
            BMP.UnlockBits(BMPDATOS);

            SimpleShapeChecker BUSCADOR = new SimpleShapeChecker(); //PARA DETERMINAR LA FORMA DE LOS ELEMENTOS ENCONTRADOS
            Graphics DIBUJO = Graphics.FromImage(BMP);//PARA DIBUJAR LOS ELEMENTOS
            Graphics DIBUJO2 = Graphics.FromImage(A);

            Pen CIRCULOS = new Pen(Color.Black, 5); //CIRCULOS
            Pen TRIANGULOS = new Pen(Color.Black, 5); //TRIANGULOS
            Pen CUADRILATEROS = new Pen(Color.Black, 5); //CUADRILATEROS
            Pen TRAZO = new Pen(Color.Red); //'PARA SEÑALIZAR LAS FORMAS


            for (int i = 0; i < ELEMENTOSINFO.Length; i++)
            {

                System.Collections.Generic.List<AForge.IntPoint> PUNTOS = ELEMENTOS.GetBlobsEdgePoints(ELEMENTOSINFO[i]);//'OBTIENE LOS PUNTOS DE LA FORMA
                AForge.Point CENTRO = new AForge.Point(); //'CENTRO DEL CIRCULO
                float RADIO = new float(); //'RADIO DEL CIRCULO

                if (BUSCADOR.IsCircle(PUNTOS, out CENTRO, out RADIO))//
                {//'SI ES UN CIRCULO....
                    DIBUJO.DrawEllipse(CIRCULOS, (int)Math.Round(CENTRO.X - RADIO), (int)Math.Round(CENTRO.Y - RADIO), (int)Math.Round(RADIO * 2), (int)Math.Round(RADIO * 2));// 'DIBUJA EL CIRCULO
                    DIBUJO2.DrawEllipse(CIRCULOS, (int)Math.Round(CENTRO.X - RADIO), (int)Math.Round(CENTRO.Y - RADIO), (int)Math.Round(RADIO * 2), (int)Math.Round(RADIO * 2));// 'DIBUJA EL CIRCULO

                    Datos.Add(CENTRO.X + "-" + CENTRO.Y + "-" + RADIO);
                }
            }

            //Mostrar_Imagen A
            pasarImagen pa = new pasarImagen(mostrarImagen);
            this.Invoke(pa, A);

            return Datos;
        }
    }
}
