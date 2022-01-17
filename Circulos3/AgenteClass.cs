using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Circulos3
{
    public class AgenteClass
    {
        Vertex Vertex_Actual;
        Edge Edge_Actual;
        int actualEdgeIndex;
        int id;
        int Vel;
        double angle;
        List<double> angleL;

       
        public AgenteClass()
        {

        }
        public AgenteClass(Vertex v, int Id)
        {
            Vertex_Actual = v;
            id = Id;
            this.angle= 0;
            Vel = 5;
            actualEdgeIndex = 0;
            Edge_Actual = null;
        }
        public AgenteClass(Vertex v, int Id, double angle)
        {
            Vertex_Actual = v;
            id = Id;
            this.angle= angle;
            Vel = 2;
            actualEdgeIndex = 0;
            Edge_Actual = null;
        }
        //public void walk(Vertex Bait)
        //{
        //    if(Vertex_Actual != null)
        //    {
        //        selectEdge(Bait);
        //    }
        //    if ((actualEdgeIndex + Vel) < Edge_Actual.getpL().Count)
        //    {
        //        actualEdgeIndex += Vel;

        //    }
        //    else
        //    {
        //        Vertex_Actual = Edge_Actual.GetOrigen();
        //        Rastro r = new Rastro(id);
        //        Vertex_Actual.setRastro();
        //    }
        //}
        //public void selectEdge(Vertex bait)
        //{
        //    List<Edge> eLAux = new List<Edge>();
        //    Edge edge_aux = Vertex_Actual.GetEdgeL()[0];
        //    foreach (Edge e in Vertex_Actual.GetEdgeL())
        //    {
        //        if (e.GetOrigen().searchRastro(id) < edge_aux.GetOrigen().searchRastro(id))
        //        {
        //            edge_aux = e;
        //        }
        //    }
        //    eLAux.Add(edge_aux);
        //    foreach (Edge e in Vertex_Actual.GetEdgeL())
        //    {
        //        if (edge_aux.GetOrigen().searchRastro(id) == e.GetOrigen().searchRastro(id))
        //        {
        //            eLAux.Add(e);
        //        }
        //    }
        //    angle = calAngleBait(bait);
        //    double angleEdge;
        //    double anglemin = 360;
        //    foreach (Edge e in  eLAux)
        //    {
        //        angleEdge = calAngleVer(e.GetOrigen());
        //        if (Math.Abs(angle-angleEdge) < anglemin)
        //        {
        //            anglemin = Math.Abs(angle-angleEdge);
        //            Edge_Actual = e;
        //        }
        //    }
        //    Vertex_Actual = null;

        //}
        //public double calAngleVer(Vertex v)
        //{
        //    int x_VA = Vertex_Actual.GetX();
        //    int y_VA = Vertex_Actual.GetY();
        //    int x_VF = v.GetX();
        //    int y_VF = v.GetY();
        //    double angulo = Math.Atan2(y_VF-y_VA,x_VF-x_VA) * 180 / Math.PI;

        //    if (angulo <= 0)
        //    {
        //        angulo = Math.Abs(angulo);
        //    }
        //    else
        //    {
        //        angulo = 360 - angulo;
        //    }
        //    return angulo;
        //}
        //public double calAngleBait(Vertex bait)
        //{
        //    int x_VA = Vertex_Actual.GetX();
        //    int y_VA = Vertex_Actual.GetY();
        //    int x_bait = bait.GetX();
        //    int y_bait = bait.GetY();

        //    double angulo = Math.Atan2(y_bait-y_VA,x_bait-x_VA) * 180 / Math.PI;

        //    if (angulo <=0)
        //    {
        //        angulo = Math.Abs(angulo);
        //    }
        //    else
        //    {
        //        angulo = 360 - angulo;
        //    }
        //    return angulo;
        //}



        public Vertex getVertex_Actual()
        {
            return Vertex_Actual;
        }
        public Edge getEdge_Actual()
        {
            return Edge_Actual;
        }
        public int getActualEdgeIndex()
        {
            return actualEdgeIndex;
        }
        public int getVel()
        {
            return Vel;
        }
        public int getId()
        {
            return id;
        }
        public double getAngle()
        {
            return angle;
        }
        public void setIndexEdgeActual(int indexActual)
        {
            this.actualEdgeIndex = indexActual;
        }
        public void setVel(int vel)
        {
            this.Vel = vel;
        }
        public void setEdge_Actual(Edge e)
        {
            this.Edge_Actual = e;
        }
        public void setAngle(double angle)
        {
            this.angle = angle;
        }
        public void setVertex_Actual(Vertex v)
        {
            this.Vertex_Actual = v;
        }
        public List<double> getAngleList()
        {
            return angleL;
        }
        public void setangleList(List<double>aL)
        {
        	angleL=aL;
        }
    }



//######################################################
    public class Rastro
    {
        int id;
        int count;
        public Rastro(int id)
        {
            this.id = id;
            count = 0;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }
        public void setCount(int count)
        {
            this.count = count;
        }
        public int getCount()
        {
            return count;
        }
    }
}
