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
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
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

        private void obtenerImagen(out Bitmap img)
        {
            img = new Bitmap(pbInput.Image);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap bmp2 = null;
            Invoke(new Action(() => obtenerImagen(out bmp2)));

            // Convertir a escala de grises
            Bitmap imgProcesada = Grayscale.CommonAlgorithms.RMY.Apply(bmp2);
            // Aplicar filtros
            CannyEdgeDetector borde = new CannyEdgeDetector();
            borde.ApplyInPlace(imgProcesada);

            // Obtener los centros de la imagen
            int w2 = imgProcesada.Width / 2;
            int h2 = imgProcesada.Height / 2;
            //Definir transformada
            HoughLineTransformation lineTransform = new HoughLineTransformation();
            // Aplicar deteccion de lineas
            lineTransform.ProcessImage(imgProcesada);
            // Obtener lineas con intensidad relativa
            HoughLine[] lines = lineTransform.GetLinesByRelativeIntensity(0.35);

            // locate objects using blob counter
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(imgProcesada);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            // Creamos un bitmap en blanco
            Bitmap tempBitmap = new Bitmap(imgProcesada.Width, imgProcesada.Height);

            // Obtenemos sus graficos para modificarlo
            using (Graphics g = Graphics.FromImage(tempBitmap))
            {
                //Dibujamos la imagen original
                g.DrawImage(imgProcesada, 0, 0);

                //Dibujamos las lineas y circulos
                foreach (HoughLine line in lines)
                {
                    // obtener radio y theta de la linea
                    int r = line.Radius;
                    double t = line.Theta;

                    // Verificar si la linea esta en la parte baja de la imagen
                    if (r < 0)
                    {
                        t += 180;
                        r = -r;
                    }

                    // convertir gradoa radianes
                    t = (t / 180) * Math.PI;

                    double x0 = 0, x1 = 0, y0 = 0, y1 = 0;

                    if (line.Theta != 0)
                    {
                        // line no vertical
                        x0 = -w2; // punto mas a la izquierda
                        x1 = w2;  // punto mas a la derecha

                        // Calcular los valores correspondientes
                        y0 = (-Math.Cos(t) * x0 + r) / Math.Sin(t);
                        y1 = (-Math.Cos(t) * x1 + r) / Math.Sin(t);
                    }
                    else
                    {
                        // linea vertical
                        x0 = line.Radius;
                        x1 = line.Radius;

                        y0 = h2;
                        y1 = -h2;
                    }

                    // dibujar la linea en la imagen
                    g.DrawLine(Pens.Red, ((int)x0 + w2), (h2 - (int)y0), ((int)x1 + w2), (h2 - (int)y1));
                }

                AForge.Math.Geometry.SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
                for (int i = 0, n = blobs.Length; i < n; i++)
                {
                    List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);

                    AForge.Point center;
                    float radius;

                    if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                    {
                        g.DrawEllipse(new Pen(Color.Green, 2),
                            (int)(center.X - radius),
                            (int)(center.Y - radius),
                            (int)(radius * 2),
                            (int)(radius * 2));
                    }
                }

            }
            mostrarImagen(tempBitmap);
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

        private void nudIP1_ValueChanged(object sender, EventArgs e)
        {
            url = "http://" + obtenerIP() + "/mjpegfeed?640x480";
            log("Stream url: " + url);
        }
    }
}
