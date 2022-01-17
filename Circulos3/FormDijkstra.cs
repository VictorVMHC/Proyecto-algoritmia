using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Circulos3
{
    public partial class FormDijkstra : Form
    {
        Bitmap GrafoOriginalBmp;
        Bitmap animation;
        Bitmap agenteVisual;
        AgenteClass agente;
        Grafo graph;
        Point Escalado;
        Vertex origen;
        Vertex destino;
        Graphics gra;
        List<ElementoDijkstra> solucion ;
        List<Vertex> recorrido = new List<Vertex>();
        bool banderaorigen= false;
        bool banderaDestino = false;
        List<Edge> camino = new List<Edge>();
        public FormDijkstra(Bitmap grafoBmp, Grafo graph)
        {
            InitializeComponent();
            GrafoOriginalBmp = new Bitmap(grafoBmp);
            this.graph = graph;
        }
        public void prosesingImage()
        {
            for (int i = 0 ; i < GrafoOriginalBmp.Width; i++ )
            {
                for (int j = 0; j <GrafoOriginalBmp.Height; j++)
                {
                    if (isWhite(GrafoOriginalBmp.GetPixel(i,j)) )
                    {
                        GrafoOriginalBmp.SetPixel(i, j, Color.Transparent);
                    }
                    else
                    {
                        GrafoOriginalBmp.SetPixel(i,j, Color.White);
                    }
                }
            }
        }
        public  bool isWhite(Color color)
        {
            if (color.R == 255)
                if (color.G == 255)
                    if (color.B == 255)
                        return true;
            return false;
        }
        private void FormDijkstra_Load(object sender, EventArgs e)
        {
            pictureBoxGrafoBmp.BackgroundImageLayout = ImageLayout.Zoom;
            
            animation = new Bitmap(GrafoOriginalBmp.Width, GrafoOriginalBmp.Height);
            gra = Graphics.FromImage(animation);
            agenteVisual = new Bitmap("A1.png");
            adornoagente.Image = agenteVisual;
            controlOfSpeed.Visible = false;
            adornoagente.Visible = false;
            button1.Visible = false;
            listBoxSolucion.Visible = false;
            label1.Visible = false;
            prosesingImage();
            pictureBoxGrafoBmp.BackgroundImage = GrafoOriginalBmp;


            // dijkstra(graph.GetVertexL()[0]);


        }
        public void dijkstra(Vertex origen)
        {
            List<ElementoDijkstra> candidatos = new List<ElementoDijkstra>(); // candidatos almacenara todos los vertices de mi grafo
            List<ElementoDijkstra> prometedor = new List<ElementoDijkstra>(); // prometedor almacenara solo los vertices que sean definitivos
            InicializaDijkstra(candidatos,origen,prometedor); // inicializo dijkstra metiendo todos los vertices del grafo como nuevos elementos dijkstra
            int index=0;
            ElementoDijkstra v_D = new ElementoDijkstra();
            while (candidatos.Count != 0 ){// como voy a estar sacando candidatos, el while termina hasta que ya no haya candidatos
                v_D = seleccionaDefinitivo(candidatos, prometedor[index]); //cuando se haya seleccionada el definitivo, se habra salculado los pesos de candidat que tenga como destino la el destino de la arista
                                                                           //regreso el elemento que haya tenido menor peso acumulado
                prometedor.Add(v_D);                                       //se agrega este definitivo
                index++;                                                   //se aumenta el index para evaluar el siguiente definitivo que agrege
            }
            solucion = new List<ElementoDijkstra>(prometedor);              // una vez que salga del while prometedor ya sera mi solucion
            listBoxSolucion.DataSource=solucion;                            // muestro solucion
        }
        public ElementoDijkstra seleccionaDefinitivo(List<ElementoDijkstra> candidatos, ElementoDijkstra v_D)
        {
            foreach (Edge e in v_D.getDestino().GetEdgeL())// por cada arista de el v_padre buscar los destinos a los cuales puede llegar
            {
                foreach (ElementoDijkstra ed in candidatos) // por cada elemento de ed en candiatos se buscara el elemento destino de la arista
                {
                    if (e.GetOrigen() == ed.getDestino()) // si se encuentra el elemento destino 
                    {
                        if (ed.getPesoAcumulado() > v_D.getPesoAcumulado() + e.GetPeso()) // revisa si el peso que tiene es mayor al que ya tenia, si es asi lo actualiza
                        {
                            ed.setPesoAcumulado(v_D.getPesoAcumulado() + e.GetPeso()); // actualiza el peso
                            ed.setPadre(v_D.getDestino()); // actualiza el padre del cual viene
                        }
                        break; // se para la busqueda puesto a que ya lo encontro
                    }
                }
            }
            candidatos.Sort((x,y) => x.getPesoAcumulado().CompareTo(y.getPesoAcumulado())); // ordeno la lista de candidatos de menor a mayor 
            ElementoDijkstra aux = new ElementoDijkstra();
            aux = candidatos[0]; // como la lista esta ordenada, el primer elemento sera el menor
            aux.setDefinitivo(true);
            candidatos.Remove(candidatos[0]); // elimino el vertice o elemento, puesto a que ya lo he analizado
            return aux; //retorno aux ya que este sera el siguiente elemento definitivo
        }
        public void InicializaDijkstra(List<ElementoDijkstra> candidatos, Vertex origen, List<ElementoDijkstra> prome)
        {
            ElementoDijkstra elementoaux; // elemento dijkstra auxiliar
            foreach (Vertex v in graph.GetVertexL())// itero en cada vertice de mi grafo
            {
                if (origen == v) // aqui encuentro el origen lo vuelvo definitivo
                {
                    elementoaux = new ElementoDijkstra(0, true, v, v);// agrego un peso de 0, muestro que ya es definitivo
                    prome.Add(elementoaux); //agrego este elemento a prometedor y no a candidatos
                }
                else  // si no es el origen lo agrego a candidatos
                {
                    elementoaux = new ElementoDijkstra(double.PositiveInfinity, false, null, v);// si no es el origen entonces se crean como elementos con un peso infinito para que que el primer peso que se le meta
                                                                                                 // sea menor
                    candidatos.Add(elementoaux);// lo agrego a candidatas
                }
            }
        }

        public void Search(Vertex destino)
        {
                recorrido.Clear();// recorrido en mi lista de verices por donde debo pasar
                ElementoDijkstra auxialiar = new ElementoDijkstra(double.PositiveInfinity, false, null, null);
                foreach (ElementoDijkstra ed in solucion)// for para buscar cul es el vertice destino dentro de la solucion
                {
                    if (ed.getDestino() == destino) // si se encuentra el verice destino auxiliar sera igual a este
                                                      // todos los vertices en mi solucion tienen un destino pero solos los que no perteneces al subgrafo tienen un padre nulo
                    {
                        auxialiar = ed;
                    }
                }
                Vertex vAux;
            if (auxialiar.getPadre() != null) // evaluo si el padre es nulo o no
            {
                do
                {
                    recorrido.Add(auxialiar.getDestino()); // desde la primera iteracion se agrega por que auxya es uno de los elementos del recorrido
                    vAux = auxialiar.getPadre(); // se saca el padre del elemento en el cual voy
                    foreach (ElementoDijkstra ed in solucion) // ahora busco el padre dentro de la solucion
                    {
                        if (ed.getDestino() == vAux) // si encuentra el padre auxiliar pasa a ser mi vertice actual
                        {
                            auxialiar = ed; // encontramos el padre y lo agregamos
                        }

                    }
                } while (auxialiar.getPesoAcumulado() != 0); //cuando aux llegue a un peso acumulado de 0 significa que ya se ha llegado al origen
                recorrido.Add(auxialiar.getDestino());//agrego el ultimo elemento que almaceno auxiliar puesto a que no se alcanzo a introduci  
                recorrido.Reverse(); // seleaplica reverse por que hice el recorrido partiendo desde un vertice destino a un origen no de un origen al destino 
                listBoxSolucion.DataSource = recorrido;
                drawCamino();
                DrawAgente(agente.getVertex_Actual());
                pictureBoxGrafoBmp.Image = animation;
            }
            else
            {
                MessageBox.Show("no se puede acceder al elemento el grafo es no conexo");
            }
        }

        public void drawCamino()
        {
            camino.Clear();
            gra.Clear(Color.Transparent);
            for (int i = 0 ; i < recorrido.Count - 1 ; i++)
            {
                foreach (Edge e in recorrido[i].GetEdgeL())
                {
                    if (e.GetOrigen() == recorrido[i+1])
                    {
                        camino.Add(e);
                        drawEdge(e);
                    }
                }
            }
        }
        public void drawEdge(Edge e) {
            Color c = Color.FromArgb(125, 11, 39, 243);
            Pen p = new Pen(c, 10);
                gra.DrawLine(p, e.GetDestino().GetPoint(), e.GetOrigen().GetPoint());
        }

 

        private void PictureBoxGrafoBmp_MouseMove(object sender, MouseEventArgs e)
        {
            double h_heightP, w_WidthP;
            double h_heightI, w_WidthI;
            double h_escalado, w_escalado, min;
            Vertex aux;
            Vertex v = new Vertex();
            double incrementox, incrementoy;
            w_WidthP = pictureBoxGrafoBmp.Width;
            h_heightP = pictureBoxGrafoBmp.Height;
            w_WidthI = GrafoOriginalBmp.Width;
            h_heightI = GrafoOriginalBmp.Height;
            w_escalado = w_WidthP / w_WidthI;
            h_escalado = h_heightP / h_heightI;
            min = Math.Min(w_escalado, h_escalado);
            incrementox = min == w_escalado ? 0 : (w_WidthP - (min * w_WidthI)) / 2.0;
            incrementoy = min == h_escalado ? 0 : (h_heightP - (min * h_heightI)) / 2.0;

            Escalado.X = (int)((e.X - incrementox) / min);
            Escalado.Y = (int)((e.Y - incrementoy) / min);


            aux = detectVertex(Escalado.X, Escalado.Y);
            if(aux != null && banderaorigen == true && aux != origen && !banderaDestino)
            {
                listBoxSolucion.DataSource = null;
                Search(aux);
            }
        }
        public Vertex detectVertex(int x, int y)
        {
            int d;
            foreach (Vertex v in graph.GetVertexL())
            {

                d = (int)Math.Round(Math.Abs(Math.Sqrt(Math.Pow((x - v.GetX()), 2) + Math.Pow((y - v.GetY()), 2))));
                if (d <= v.GetR())
                {
                    return v;
                }
            }
            return null;
        }
        bool bandanimation=true;
        List<Edge> caminoCopia;
        private void Button1_Click(object sender, EventArgs e)
        {
            bandanimation = true;
            banderaDestino = false;
            caminoCopia = new List<Edge>(camino); 

            agente.setVel((int)(controlOfSpeed.Value));
            while (bandanimation)
            {
                gra.Clear(Color.Transparent);
                walk();
                drawCaminoforWalk();
                pictureBoxGrafoBmp.Refresh();
            }
            origen = agente.getVertex_Actual();
            dijkstra(origen);
        }
        public void walk()
        {
   
                if (agente.getEdge_Actual() == null)
                {
                    if (caminoCopia.Count != 0)
                    {
                        agente.setEdge_Actual(caminoCopia[0]);
                        caminoCopia.Remove(caminoCopia[0]);
                    }
                    else
                    {
                        DrawAgente(agente.getVertex_Actual());
                        bandanimation = false;
                    }
                }
                else
                {
                    if (agente.getActualEdgeIndex() + agente.getVel() >= agente.getEdge_Actual().getpL().Count)
                    {
                        agente.setVertex_Actual(agente.getEdge_Actual().GetOrigen());
                        agente.setEdge_Actual(null);
                        agente.setIndexEdgeActual(0);
                    }
                    else
                    {
                        agente.setIndexEdgeActual(agente.getActualEdgeIndex() + agente.getVel());
                        DrawAgente(agente.getEdge_Actual().getpL()[agente.getActualEdgeIndex() ]);
                    }
                }
        }
        public void drawCaminoforWalk()
        {
            foreach (Edge e in camino)
            {
                drawEdge(e);
            }
        }
        public void DrawAgente(Point v)
        {
            gra.FillEllipse(Brushes.Green, v.X - 10, v.Y - 10, 20, 20);
        }

        private void PictureBoxGrafoBmp_MouseClick(object sender, MouseEventArgs e)
        {

            double h_heightP, w_WidthP;
            double h_heightI, w_WidthI;
            double h_escalado, w_escalado, min;
            Vertex aux;
            Vertex v = new Vertex();
            double incrementox, incrementoy;
            w_WidthP = pictureBoxGrafoBmp.Width;
            h_heightP = pictureBoxGrafoBmp.Height;
            w_WidthI = GrafoOriginalBmp.Width;
            h_heightI = GrafoOriginalBmp.Height;
            w_escalado = w_WidthP / w_WidthI;
            h_escalado = h_heightP / h_heightI;
            min = Math.Min(w_escalado, h_escalado);
            incrementox = min == w_escalado ? 0 : (w_WidthP - (min * w_WidthI)) / 2.0;
            incrementoy = min == h_escalado ? 0 : (h_heightP - (min * h_heightI)) / 2.0;

            Escalado.X = (int)((e.X - incrementox) / min);
            Escalado.Y = (int)((e.Y - incrementoy) / min);


            aux = detectVertex(Escalado.X, Escalado.Y);
            if (aux != null)
            {
                if (e.Button == MouseButtons.Left) {
                    gra.Clear(Color.Transparent);
                    pictureBoxGrafoBmp.Image = animation;
                    dijkstra(aux);
                    origen = aux;
                    banderaorigen = true;
                    agente = new AgenteClass(aux,1);
                    DrawAgente(agente.getVertex_Actual());
                    controlOfSpeed.Visible = true;
                    adornoagente.Visible = true;
                    //banderaDestino = true;
                    listBoxSolucion.Visible = true;
                    label1.Visible = true;
                    controlOfSpeed.Minimum = 5;
                }
                if (e.Button == MouseButtons.Right && banderaorigen)
                {
                    pictureBoxGrafoBmp.Image = animation;
                    DrawDestino(aux);
                    banderaDestino = true;
                    button1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un vertice");
            }

        }
        public void DrawAgente(Vertex v)
        {
            gra.FillEllipse(Brushes.Green, v.GetX() - 10, v.GetY() - 10, 20, 20);
        }
        public void DrawDestino(Vertex v)
        {
            gra.FillRectangle(Brushes.Magenta, v.GetX() - 10, v.GetY() - 10, 20, 20);
        }
    }
   /*public void dijkstra(Vertex origen)
    {
        List<ElementoDijkstra> Elementos = new List<ElementoDijkstra>(); // lista de elementos de dijkstra, contendra si es un elemento definitivo
        solucion.Clear(); // limpio la soluccion para dar paso a una nueva
        ElementoDijkstra edd; // utilizo un elemento auxiliar del cual creare todos los vertices del grafo como elementos de dijkstra
        foreach (Vertex v in graph.GetVertexL()) // crea a partir de cada elemento del grafo un elemento de dijkstra
        {
            edd = new ElementoDijkstra(double.PositiveInfinity, false, null, v); // los creo con un doble infinito puesto a que no se sabe aun cuanto pesara hasta que llegue a ellos
                                                                                 // los creo falso, por que ninguno es definitivo aun, ninguno tine un padre asi que esta nulos 
                                                                                 // los agrego como destino a todos puesto a que eso son
            Elementos.Add(edd);
        }
        foreach (ElementoDijkstra ed in Elementos) //for para encontrar el elemento origen elegido
        {
            if(ed.getDestino() == origen)// si se encuentra lo agrega a la solucio
            {
                ed.setPesoAcumulado(0); // se le da un peso de cero por que no tiene arista para llegar a el 
                ed.setPadre(ed.getDestino()); // el padre en este caso lo tengo como igual al destino puesto a que no tiene un padre
                ed.setDefinitivo(true); // ya que es el primero es definitivo
                solucion.Add(ed); // lo agrego a la solucion
                Elementos.Remove(ed); // y lo remuevo de elementos para ya no contarlo al buscar el siguiente
                break;
            }
        }
        int indice = 0;
        ElementoDijkstra actual;
        ElementoDijkstra auxiliar;
        while (Elementos.Count!=0) // cauando ya no hay elementos para tomar termina el while
        {
            actual = solucion[indice];
            indice++;
            foreach (Edge e in actual.getDestino().GetEdgeL())
            {
                foreach (ElementoDijkstra ed in Elementos)
                {
                    if (ed.getDestino() == e.GetOrigen())
                    {
                        auxiliar = ed;
                        if (auxiliar.getPesoAcumulado() > actual.getPesoAcumulado() + e.GetPeso())
                        {
                            ed.setPesoAcumulado(actual.getPesoAcumulado() + e.GetPeso());
                            ed.setPadre(actual.getDestino());
                        }
                        break;
                    }
                }
            }
            Elementos.Sort((x, y) => x.getPesoAcumulado().CompareTo(y.getPesoAcumulado()));
            solucion.Add(Elementos[0]);
            Elementos.Remove(Elementos[0]);
        }
        listBoxSolucion.DataSource = solucion;
    }*/
}
