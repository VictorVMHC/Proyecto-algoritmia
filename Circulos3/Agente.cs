/*
 * Created by SharpDevelop.
 * User: manue
 * Date: 12/10/2019
 * Time: 09:58 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Circulos3
{
    /// <summary>
    /// Description of Agente.
    /// </summary>
    public partial class Agente : Form
    {
        Bitmap gragoBmp;
        Bitmap grafoBmpAnimar;
        Bitmap gragoBmpC;
        Grafo GRAFO;
        Grafo copia = new Grafo();
        Vertex vFBait;
        Point Escalado;
        int countFagente = 0;
        bool bandFbait = false;
        List<AgenteClass> agenteL;
        Graphics g;
        public Agente(Bitmap grafoB, Grafo G)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            this.gragoBmp = grafoB;
            this.GRAFO = G;
            this.copia = G;
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        private void Agente_Load(object sender, EventArgs e)
        {
            pictureBoxAgenteF.BackgroundImage = gragoBmp;
            pictureBoxAgenteF.BackgroundImageLayout = ImageLayout.Zoom;
            agenteL = new List<AgenteClass>();
            // toBait = new Point();
            gragoBmpC = new Bitmap(gragoBmp);
            grafoBmpAnimar = new Bitmap(gragoBmp.Width, gragoBmp.Height);
            g = Graphics.FromImage(grafoBmpAnimar);
            labelAgentes.Visible = false;
            numericUpDown1.Visible = false;
            buttonAgregar.Visible = false;

            // TreeViewGRM();
        }

        private void PictureBoxAgenteF_MouseClick(object sender, MouseEventArgs e)
        {
            double h_heightP, w_WidthP;
            double h_heightI, w_WidthI;
            double h_escalado, w_escalado, min;
            Vertex aux;
            Vertex v = new Vertex();
            double incrementox, incrementoy;
            w_WidthP = pictureBoxAgenteF.Width;
            h_heightP = pictureBoxAgenteF.Height;
            w_WidthI = gragoBmp.Width;
            h_heightI = gragoBmp.Height;
            w_escalado = w_WidthP / w_WidthI;
            h_escalado = h_heightP / h_heightI;
            min = Math.Min(w_escalado, h_escalado);
            incrementox = min == w_escalado ? 0 : (w_WidthP - (min * w_WidthI)) / 2.0;
            incrementoy = min == h_escalado ? 0 : (h_heightP - (min * h_heightI)) / 2.0;

            Escalado.X = (int)((e.X - incrementox) / min);
            Escalado.Y = (int)((e.Y - incrementoy) / min);


            aux = detectVertex(Escalado.X, Escalado.Y);
            if (aux == null)
            {
                MessageBox.Show("No se selecciono un vertice o no se encuentro el vertice");
            }
            else
            if (!existAgent(aux)) {
                if (e.Button == MouseButtons.Left)
                {
                    if (bandFbait == false) {
                        MessageBox.Show("Primero se requiere un señuelo");
                    } else
                    if (countFagente < GRAFO.GetVertexL().Count - 1)
                    {
                        AgenteClass agente = new AgenteClass(aux, countFagente, calAngle(aux, vFBait));
                        agenteL.Add(agente);
                        drawCircleAgente(agente.getVertex_Actual());
                        pictureBoxAgenteF.Refresh();
                        pictureBoxAgenteF.Image = grafoBmpAnimar;
                        countFagente++;
                    }
                    else
                    {
                        MessageBox.Show("No se pueden poner mas agentes en el grafo");
                    }
                }
                else
                {
                    if (!bandFbait)
                    {
                        vFBait = new Vertex(aux);
                        // toBait.X = vFBait.GetX();
                        //toBait.Y = vFBait.GetY();
                        drawCircleBait(vFBait);
                        if (agenteL.Count != 0) {
                            foreach (AgenteClass a in agenteL) {
                                a.setAngle(calAngle(a.getVertex_Actual(), vFBait));
                            }
                            foreach (Vertex ver in GRAFO.GetVertexL())
                            {
                                ver.getRastro().Clear();

                            }
                        }
                        pictureBoxAgenteF.Refresh();
                        pictureBoxAgenteF.Image = grafoBmpAnimar;
                        bandFbait = true;
                    }
                    else
                        MessageBox.Show("Ya hay un señuelo");
                }
            } else
            {
                MessageBox.Show("El vertice esta ocupado, elige otro");
            }

        }
        private void Animation_Click(object sender, EventArgs e)
        {
            AgenteClass a = new AgenteClass();
            if (bandFbait) {
                while (bandFbait) {
                    g.Clear(Color.Transparent);
                    a = walk();
                    pictureBoxAgenteF.Refresh();
                }
                g.Clear(Color.Transparent);
                foreach (AgenteClass ag in agenteL)
                {
                    drawCircleAgente(ag.getVertex_Actual());
                }
                pictureBoxAgenteF.Image = grafoBmpAnimar;
                MessageBox.Show("El agente # " + a.getId() + " se  ha comido a la presa");

            }
            else
            {
                MessageBox.Show("La animacion no ha podido iniciar: deve haber al menos un un señuelo y un agente");
            }
        }
        public bool existBait(Vertex p)
        {
            if (p.GetId()== vFBait.GetId() )
            {
                return true;
            }
            return false;
        }
        public bool existAgent(Vertex p)
        {
            foreach (AgenteClass a in agenteL)
            {
                if (a.getVertex_Actual().GetId() == p.GetId())
                {
                    return true;

                }
            }
            return false;
        }
        public AgenteClass walk() {

            foreach (AgenteClass a in agenteL)
            {

                if (a.getVertex_Actual().GetEdgeL().Count != 0)
                {

                    if (a.getEdge_Actual() == null)
                    {
                        a.setEdge_Actual(selectionEdge(a)); //n2
                    }
                    else
                       if (a.getVertex_Actual().GetPoint().X == vFBait.GetX() && a.getVertex_Actual().GetPoint().Y == vFBait.GetY())
                    {
                        a.setVel(a.getVel() + 2);
                        foreach (AgenteClass ag in agenteL)  //n
                        {
                            ag.setEdge_Actual(null);
                            ag.setIndexEdgeActual(0);

                        }
                        bandFbait = false;
                        return a;

                    }
                    else

                        if (a.getActualEdgeIndex() >= a.getEdge_Actual().getpL().Count - 1 || a.getActualEdgeIndex() + a.getVel() >= a.getEdge_Actual().getpL().Count - 1 && !(a.getVertex_Actual().GetPoint().X == vFBait.GetX() && a.getVertex_Actual().GetPoint().Y == vFBait.GetY()))
                    {

                        a.setVertex_Actual(a.getEdge_Actual().GetOrigen());
                        a.setEdge_Actual(null);
                        a.setIndexEdgeActual(0);

                        if (ExistRastro(a, a.getVertex_Actual()))
                        {
                            foreach (Vertex v in GRAFO.GetVertexL()) //n2
                            {
                                if (v.GetId() == a.getVertex_Actual().GetId())
                                {
                                    foreach (Rastro r in v.getRastro())
                                    {
                                        if (r.getId() == a.getId())
                                        {
                                            r.setCount(r.getCount() + 1);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Rastro r = new Rastro(a.getId());
                            foreach (Vertex v in GRAFO.GetVertexL()) //n
                            {
                                if (a.getVertex_Actual().GetId() == v.GetId())
                                    v.setRastro(r);
                            }
                        }

                    }

                    if (a.getEdge_Actual() != null)
                    {
                        a.setIndexEdgeActual(a.getActualEdgeIndex() + a.getVel());
                        drawCircleAgente(a.getEdge_Actual().getpL()[a.getActualEdgeIndex()]);
                        drawArrowAgente(a.getEdge_Actual().getpL()[a.getActualEdgeIndex()]);
                        drawCircleBait(vFBait);
                    }
                }
                pictureBoxAgenteF.Image = grafoBmpAnimar;
            }
            return null;

        }
        public Edge selectionEdge(AgenteClass a)
        {     
            List<Edge> eLAux = new List<Edge>();
            Edge edge_aux = a.getVertex_Actual().GetEdgeL()[0];
            foreach (Edge e in a.getVertex_Actual().GetEdgeL())
            {
                if (e.GetOrigen().searchRastro(a.getId()) < edge_aux.GetOrigen().searchRastro(a.getId()) )//&& e.GetOrigen().GetEdgeL().Count - 1 != e.GetOrigen().searchRastro(a.getId()))
                {
                    edge_aux = e;
                }
             
            }
         
            
            foreach (Edge e in a.getVertex_Actual().GetEdgeL())
            {
                if (edge_aux.GetOrigen().searchRastro(a.getId()) == e.GetOrigen().searchRastro(a.getId()) )// && e.GetOrigen().GetEdgeL().Count - 1 != e.GetOrigen().searchRastro(a.getId()))
                {
                    eLAux.Add(e);
                }
            }
            a.setAngle(calAngle(a.getVertex_Actual(), vFBait));
            double angleEdge;
            double anglemin = 360;
            Edge aux2 = new Edge();
            foreach (Edge e in eLAux)
            {
                angleEdge = CreateAngle(a, e.GetOrigen());
                if (Math.Abs(/*a.getAngle()*/angleEdge) <= anglemin)
                {
                    anglemin = Math.Abs(/*a.getAngle() -*/ angleEdge);
                    aux2 = e;
                }
            }
            //a.setVertex_Actual(null);
            return aux2;


            //double minimo = a.getAngleList()[0];
            //int count=0;
            //int count2 = 0;
            //foreach(Edge e in a.getVertex_Actual().GetEdgeL() ){
            //	if(e.GetOrigen().GetX()== vFBait.GetX()&& e.GetOrigen().GetY() == vFBait.GetY())
            //    {
            //		return e;
            //	}
            //}

            //foreach (double angle in a.getAngleList())
            //{
            //    if (angle >= 0.0 && angle <= 1)
            //    {
            //        return a.getVertex_Actual().GetEdgeL()[count2];
            //    }
            //    count2++;
            //}
            //foreach (double angle in a.getAngleList())
            //{
            //    if (minimo > angle)
            //    {
            //        minimo = angle;
            //    }
            //}
            //foreach (double angle in a.getAngleList())
            //{

            //    if (minimo == angle)
            //    {
            //        return a.getVertex_Actual().GetEdgeL()[count];
            //    }
            //    count++;
            //}
            //return null;
        }
        public double CreateAngle(AgenteClass a, Vertex v2)
        {
            double anguloaris;
            double angulomin=0;

                anguloaris = calAngle(a.getVertex_Actual(), v2);
                if (Math.Abs(a.getAngle() - anguloaris) >= 180)
                {
                    if (a.getAngle() > anguloaris)
                    {
                        angulomin = Math.Abs((a.getAngle() - anguloaris) - 360);
                        return angulomin;
                    }
                    else
                    {
                        angulomin = Math.Abs((anguloaris - a.getAngle()) - 360);
                        return angulomin;
                    }
                } else
                if (Math.Abs(a.getAngle() - anguloaris) <= 180) {
                    if (a.getAngle() > anguloaris)
                    {
                        angulomin = Math.Abs(a.getAngle() - anguloaris);
                        return angulomin;
                    }
                    else
                    {
                        angulomin = Math.Abs(anguloaris - a.getAngle());
                        return angulomin;
                    }

                } 
            return angulomin;
        }
        public double calAngle(Vertex v1, Vertex v2) {
            int x1 = v1.GetPoint().X, x2 = v2.GetPoint().X;
            int y1 = v1.GetPoint().Y, y2 = v2.GetPoint().Y;
            double the = Math.Atan2(y2 - y1, x2 - x1) * 180 / Math.PI;
            if (the <= 0) {
                the = Math.Abs(the);
            } else {
                the = 360 - the;
            }
            return the;
        }
        public Vertex detectVertex(int x, int y)
        {
            int d;
            foreach (Vertex v in GRAFO.GetVertexL()) {

                d = (int)Math.Round(Math.Abs(Math.Sqrt(Math.Pow((x - v.GetX()), 2) + Math.Pow((y - v.GetY()), 2))));
                if (d <= v.GetR())
                {
                    //Vertex aux = new Vertex(v);
                    return v;
                }
            }
            return null;
        }
        public void drawCircleAgente(Vertex v)
        {
            g.FillEllipse(Brushes.Coral, v.GetX() - 10, v.GetY() - 10, 20, 20);
        }
        public void drawCircleAgente(Point v)
        {
            g.FillEllipse(Brushes.Coral, v.X - 10, v.Y - 10, 20, 20);
        }
        public bool ExistRastro(AgenteClass a, Vertex v)
        {
            foreach (Rastro r in v.getRastro())
            {
                if (r.getId() == a.getId())
                {
                    return true;
                }
            }
            return false;

        }
        /*   public void walkAleatorio()
           {
               int random;
               foreach (AgenteClass a in agenteL)
               {
                   int i = a.getActualEdgeIndex();
                   if (a.getEdge_Actual() == null)
                   {

                       if (a.getVertex_Actual().GetEdgeL().Count != 0)
                       {
                           Random rand = new Random();
                           random = rand.Next(a.getVertex_Actual().GetEdgeL().Count - 1);
                           a.setEdge_Actual(a.getVertex_Actual().GetEdgeL()[random]);
                       }
                       else
                           break;

                   }else
                   if (a.getActualEdgeIndex() >= a.getEdge_Actual().getpL().Count-1|| a.getActualEdgeIndex()+a.getVel() >= a.getEdge_Actual().getpL().Count - 1)
                   {
                       Vertex v = new Vertex(a.getEdge_Actual().GetOrigen());
                       a.setVertex_Actual(v);
                       a.setEdge_Actual(null);
                       a.setIndexEdgeActual(0);
                   }
                   else if (a.getEdge_Actual() != null)
                   {
                       a.setIndexEdgeActual(i + a.getVel());
                       drawCircleAgente(a.getEdge_Actual().getpL()[a.getActualEdgeIndex()]);
                   }
                   pictureBoxAgenteF.Image = grafoBmpAnimar;

                }


           }*/

        public void drawCircleBait(Vertex v)
        {
            g.FillEllipse(Brushes.LavenderBlush, v.GetX() - 10, v.GetY() - 10, 20, 20);

        }
        //public void TreeViewGRM()
        //    {
        //        foreach (Vertex v in GRAFO.GetVertexL())
        //        {
        //            TreeNode[] Array = new TreeNode[v.GetEdgeL().Count];
        //            int i = 0;
        //            foreach (Edge e in v.GetEdgeL())
        //            {
        //                TreeNode subNode = new TreeNode(e.ToString());
        //                Array[i] = subNode;
        //                i++;
        //            }
        //            TreeNode vertex = new TreeNode(v.ToString(), Array);
        //            treeView1.Nodes.Add(vertex);
        //        }
        //}

        public void drawArrowAgente(Point b)
        {
            int bait_X = vFBait.GetX();
            int bait_Y = vFBait.GetY();
            int x_final = b.X;
            int y_final = b.Y;
            double deltaX = bait_X - x_final;
            double deltaY = bait_Y - y_final;
            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                float m = (float)deltaY / (float)deltaX;
                float factorB = b.Y - (m * b.X);

                if (deltaX < 0)
                {
                    deltaX = -1;
                }
                else
                {
                    deltaX = 1;
                }
                x_final += (int)deltaX * (15 * 2);
                y_final = (int)Math.Round(m * x_final + factorB);
            }
            else if (deltaY != 0)
            {
                float m = (float)deltaX / (float)deltaY;
                float factorB = b.X - (m * b.Y);

                if (deltaY < 0)
                {
                    deltaY = -1;
                }
                else
                {
                    deltaY = 1;
                }
                y_final += (int)deltaY * (15 * 2);
                x_final = (int)Math.Round(m * y_final + factorB);
            }
            g.DrawLine(Pens.Black, b.X, b.Y, x_final, y_final);

        }

        private void ButtonClean_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            pictureBoxAgenteF.Image = grafoBmpAnimar;
            agenteL.Clear();
            GRAFO = copia;
            countFagente = 0;
            bandFbait = false;
            vFBait = null;
            pictureBoxAgenteF.Image = grafoBmpAnimar;
            pictureBoxAgenteF.Refresh();
        }

        private void ButtonAleatorio_Click(object sender, EventArgs e)
        {
            if (bandFbait)
            {
                if (countFagente < GRAFO.GetVertexL().Count - 2)
                {
                    labelAgentes.Visible = true;
                    numericUpDown1.Visible = true;
                    buttonAgregar.Visible = true;
                    numericUpDown1.Maximum = GRAFO.GetVertexL().Count - 1 - countFagente;
                    numericUpDown1.Minimum = 1;
                    labelAgentes.Text = "Cantidad maxima de agentes: " + (GRAFO.GetVertexL().Count - 1 - countFagente);
                }
                else
                {
                    MessageBox.Show("La cantidad de agentes en el grafo esta al maximo");
                }

            } else
            {
                MessageBox.Show("Agrege primero un señuelo");
            }
        }

        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            bool agregado;
            int random;
            Vertex v;
            Random rand = new Random();
            for (int i = 0; i <= numericUpDown1.Value-1; i++)
            {
                agregado = false;
                while (!agregado)
                {
                    random = rand.Next(1,GRAFO.GetVertexL().Count+1);
                    v = SearchVertex(random);
                    if (!existAgent(v) && !existBait(v))
                    {
                        AgenteClass agente = new AgenteClass(v, countFagente, calAngle(v, vFBait));
                        agenteL.Add(agente);
                        drawCircleAgente(agente.getVertex_Actual());
                        pictureBoxAgenteF.Refresh();
                        pictureBoxAgenteF.Image = grafoBmpAnimar;
                        countFagente++;
                        labelAgentes.Visible = false;
                        numericUpDown1.Visible = false;
                        buttonAgregar.Visible = false;
                        agregado = true;
                    }
                }
            }
        }
        public Vertex SearchVertex(int id)
        {
            foreach (Vertex V in GRAFO.GetVertexL())
            {
                if (V.GetId()==id)
                {
                    return V;
                }
            }
            return null;
        }

    }
}
