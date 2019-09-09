using System;
using System.Drawing;
using System.Collections.Generic;
using AForge.Imaging;
using AForge.Math.Geometry;

namespace lineasCirculosStatico
{
    public class HoughMap
    {
        //========= Variable auxiliare Comunes
        //Indices para facilitar busquedas, no tienen importancia en el algoritmo
        private int iX0 = 0;
        private int iX1 = 1;
        private int iY0 = 2;
        private int iY1 = 3;
        private int dXY = 4;
        //Parametros estaticos de la imagen, para no realizar llamada en varios
        //metodos
        private int ancho = 0;
        private int alto = 0;
        int centerX = 0;
        int centerY = 0;
        /// <summary>
        /// Imagen resultado con el reconocimiento de lineas y circulos
        /// </summary>
        public Bitmap imgResultado;
        /// <summary>
        /// Representacion binaria de la imagen, lo valores de la matriz en cero
        /// indican que el pixel no tiene informacion para procesar
        /// </summary>
        private int[,] imgBin;
        /// <summary>
        /// Espacio de hough para lineas
        /// </summary>
        public int[,] espacioHoughLinea { get; set; }
        /// <summary>
        /// Almacena los elementos del espacio de hough para lineas con cantidad de votos
        /// mayores a la tolerancia definida al procesar la imagen
        /// </summary>
        private HashSet<Tuple<int, int>> maxLineas;

        /// <summary>
        /// Almacena 2 puntos con mayor distancia entre si, que representan
        /// una linea de un elemento del espacio de hough para lineas
        /// </summary>
        private Dictionary<Point, int[]> houghLineas;

        /// <summary>
        /// Espacio de hough para circunferencias
        /// </summary>
        public int[,] espacioHoughCirc { get; set; }
        /// <summary>
        /// Almacena los elementos del espacio de hough para circunferencias con cantidad de votos
        /// mayores a la tolerancia definida al procesar la imagen
        /// </summary>
        private HashSet<Tuple<int, int>> maxCirc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origen">Imagen que se desea procesar</param>
        public HoughMap(Bitmap origen)
        {
            imgBin = obtenerMatrizBinaria(origen);
            ancho = imgBin.GetLength(0);
            alto = imgBin.GetLength(1);
            centerX = ancho / 2;
            centerY = alto / 2;
            imgResultado = new Bitmap(origen);
        }
        /// <summary>
        /// Obtiene la representacion binaria de <paramref name="img"/> usada para halla es espacio de hough.
        /// </summary>
        /// <param name="img">La imagen a procesar ya debe haber pasado por algun filtro
        /// de deteccion de bordes</param>
        /// <returns>Matriz con valores binarios que representa a <paramref name="img"/> donde los valores 
        /// en la posicion (x,y) que este en cero indican que el pixel (x,y) de <paramref name="img"/> no tiene 
        /// informacion para procesar</returns>
        private int[,] obtenerMatrizBinaria(Bitmap img)
        {
            int[,] matrizBinaria = new int[img.Width, img.Height];
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color c = img.GetPixel(i, j);
                    if (c.R != 0 && c.G != 0 && c.B != 0)
                    {
                        matrizBinaria[i, j] = 1;
                    }
                }
            }
            return matrizBinaria;
        }
        /// <summary>
        /// Agrega o modifica al conjunto de lineas encontradas con el parametro
        /// <paramref name="rhoTheta"/> dependiendo si el punto (<paramref name="x"/>,<paramref name="y"/>)
        /// genera una linea de mayor longitud que la actual
        /// </summary>
        /// <param name="rhoTheta">Elemento del espacio de hough</param>
        /// <param name="x">Nueva componenete en x del punto a analisar</param>
        /// <param name="y">Nueva componenete en y del punto a analisar</param>
        private void agregarPuntoLinea(Point rhoTheta, int x, int y)
        {
            if (houghLineas.ContainsKey(rhoTheta))
            {
                int[] linea = houghLineas[rhoTheta];
                int d0 = distancia(x, y, houghLineas[rhoTheta][iX0], houghLineas[rhoTheta][iY0]);
                if (linea[dXY] >= 0)
                {
                    int d1 = distancia(x, y, houghLineas[rhoTheta][iX1], houghLineas[rhoTheta][iY1]);
                    if (d0 > d1)
                    {
                        if (d0 > linea[dXY])
                        {
                            linea[iX1] = x;
                            linea[iY1] = y;
                            linea[dXY] = d0;
                        }
                    }
                    else
                    {
                        if (d1 > houghLineas[rhoTheta][dXY])
                        {
                            linea[iX0] = x;
                            linea[iY0] = y;
                            linea[dXY] = d1;
                        }
                    }
                }
                else
                {
                    linea[iX1] = x;
                    linea[iY1] = y;
                    linea[dXY] = d0;
                }
            }
            else
            {
                int[] aux = new int[5];
                aux[iX0] = x;
                aux[iY0] = y;
                aux[dXY] = -1;
                houghLineas.Add(rhoTheta, aux);
            }
        }
        /// <summary>
        /// Obtiene la distancia entre 2 puntos (<paramref name="x0"/>, <paramref name="y0"/>)
        /// y (<paramref name="x1"/>,<paramref name="y1"/>)
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        private int distancia(int x0, int y0, int x1, int y1)
        {
            int xV = x0 - x1;
            int yV = y0 - y1;
            return xV * xV + yV * yV;
        }

        /// <summary>
        /// Aplica metodo de Hough para detectar lineas.
        /// </summary>
        /// <param name="tolerancia">Minimo de puntos coincidentes en un linea</param>
        public void ProcesarLineas(int tolerancia)
        {
            int maxTheta = 180;
            int maxRho = (int)(Math.Sqrt(ancho * ancho + alto * alto) + 1);
            int houghHeight = (int)(Math.Sqrt(2) * Math.Max(ancho, alto)) / 2;
            int doubleHeight = houghHeight * 2;
            int houghHeightHalf = houghHeight / 2;
            int houghWidthHalf = maxTheta / 2;

            espacioHoughLinea = new int[maxRho, maxTheta];

            // Escaneamos cada pixel de la imagen--+
            for (int y = 0; y < alto; y++)                 //|
            {                                                //|
                for (int x = 0; x < ancho; x++)//<-------------+
                {
                    if (imgBin[x, y] != 0)//Si el el pixel es negro lo ignoramos.
                    {
                        // Determinamos el espacio de hough para lineas.
                        // Puede variar de -90 a 90 grados.
                        for (int theta = 0; theta < maxTheta; theta++)
                        {
                            /// Calcula el valor rho para los parametros establecidos
                            /// de acuero a la representacion polar de la linea
                            double rad = theta * Math.PI / 180;
                            double sin = ((x - centerX) * Math.Cos(rad));
                            double cos = ((y - centerY) * Math.Sin(rad));
                            int rho = (int)(sin + cos);

                            // get rid of negative value
                            rho += houghHeight;

                            // Si el valor del radio esta entre 1 y el double del alto
                            if ((rho > 0) && (rho <= maxRho))
                            {
                                agregarPuntoLinea(new Point(rho, theta), x, y);
                                espacioHoughLinea[rho, theta]++;
                                //Si existen una cantidad de puntos mayores a la tolerancia establecida
                                //se agrega a la lista de lineas a dibujar
                                if (espacioHoughLinea[rho, theta] > tolerancia)
                                {
                                    Tuple<int, int> aux = new Tuple<int, int>(rho, theta);
                                    maxLineas.Add(aux);
                                }
                            }
                        }
                    }
                }
            }
            dibujarLineas();
        }

        public void Procesar(int tolerancia)
        {
            if (imgBin != null)
            {
                //Inicializamos los espacios de hough y los mas botados
                houghLineas = new Dictionary<Point, int[]>();
                maxLineas = new HashSet<Tuple<int, int>>();
                //Procesamos para lineas
                ProcesarLineas(tolerancia);
                //Procesamos para circunferencias
                ProcesarCir();
            }
        }

        public void ProcesarCir()
        {
            // locate objects using blob counter
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(imgResultado);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            // create Graphics object to draw on the image and a pen
            Graphics g = Graphics.FromImage(imgResultado);
            Pen pPen = new Pen(Color.Green, 4);
            // check each object and draw circle around objects, which
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            // are recognized as circles
            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                List<AForge.IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);

                AForge.Point center;
                float radius;

                if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                {
                    g.DrawEllipse(pPen,
                        (int)(center.X - radius),
                        (int)(center.Y - radius),
                        (int)(radius * 2),
                        (int)(radius * 2));
                }
            }

            pPen.Dispose();
            g.Dispose();
        }
        /// <summary>
        /// Accion a tomar cuando se encuentre un pixel parate de una linea
        /// </summary>
        /// <param name="x">Componenete en x del pixel a analisar</param>
        /// <param name="y">Componenete en y del pixel a analisar</param>
        /// <returns></returns>
        public bool plotLinea(int x, int y)
        {
            imgResultado.SetPixel(x, y, Color.Red);
            return true;
        }
        /// <summary>
        /// Funcion a que dibuja las lineas encontradas en la imagen de resultado.
        /// </summary>
        private void dibujarLineas()
        {
            foreach (Tuple<int, int> rhoTheta in maxLineas)
            {
                Point linea = new Point(rhoTheta.Item1, rhoTheta.Item2);
                Bresenham.Line(houghLineas[linea][iX0], houghLineas[linea][iY0], houghLineas[linea][iX1], houghLineas[linea][iY1], plotLinea);
            }
        }
        /// <summary>
        /// Aplica metodo de Hough para detectar lineas y circunferencias.
        /// </summary>
        /// <param name="tolerancia">Minimo de puntos coincidentes en un linea</param>
        
    }
}
