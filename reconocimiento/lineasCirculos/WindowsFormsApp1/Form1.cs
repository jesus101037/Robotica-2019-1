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
        string url;
        bool Hay2Circulos = false;

        int tiempoGiro;

        public Form1()
        {
            InitializeComponent();
            url = "http://" + obtenerIP() + "/mjpegfeed?640x480";
            log("Stream url: " + url);
            stream = new MJPEGStream(url);
            stream.NewFrame += streamNewFrame;
        }

        private void log(string mensaje) {
            rtbConsole.AppendText("\r\n" + mensaje);
            rtbConsole.ScrollToCaret();
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

        delegate void pasarDatos(List<string> Datos);

        private void mostrarDatos(List<string> Datos)
        {
            if (Datos.Count == 2)
            {
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

            pasarDatos pd = new pasarDatos(mostrarDatos);
            this.Invoke(pd, Datos);

            pasarImagen pa = new pasarImagen(mostrarImagen);
            this.Invoke(pa, bmp2);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            

            backgroundWorker1.Dispose();
            backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync(bmp);
        }

        //video
        private void buIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                log("Iniciando stream... ");
                stream = new MJPEGStream(url);
                stream.NewFrame += streamNewFrame;
                stream.Start();
            }
            catch (Exception err)
            {
                log(err.Message);
            }
            finally
            {
                log("Stream iniciado");
            }
        }

        private void buTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                log("Deteniendo stream... ");
                stream.Stop();
            }
            catch (Exception err)
            {
                log(err.Message);
            }
            finally
            {
                log("Stream detenido");
            }
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

        private void nudIP1_ValueChanged(object sender, EventArgs e)
        {
            url = "http://" + obtenerIP() + "/mjpegfeed?640x480";
            log("Stream url: " + url);
        }
    }
}
