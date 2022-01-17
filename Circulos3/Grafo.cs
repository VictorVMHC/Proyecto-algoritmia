/*
 * Created by SharpDevelop.
 * User: manue
 * Date: 22/09/2019
 * Time: 12:33 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Circulos3
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	/// 
	//################## clase grafo ############
	public class Grafo
	{
		List<Vertex> vertexL=new List<Vertex>();
		
		public Grafo()
		{
		}
		public Grafo(List<Circle> cL){
			foreach(Circle c in cL){
				Vertex v= new Vertex(c);
				vertexL.Add(v);
			}
		}
		public void SetGrafo(List<Circle> cL){
			vertexL.Clear();
			foreach(Circle c in cL){
				Vertex v= new Vertex(c);
				vertexL.Add(v);
			}
		}
		public List<Vertex> GetVertexL(){
			return vertexL;
		}
		public void CrearAristas(Bitmap copia){
			int x1, x2;
			int y1, y2;
			double x_aux,y_aux;
			int desp;
			double m,b;
			double disE;
			int id=1;
			
            
            int band2 = 0;
			
			for(int i=0; i <vertexL.Count;i++){
				x1=vertexL[i].GetX();
				y1=vertexL[i].GetY();
				for(int j=0; j< vertexL.Count; j++){
					x2=vertexL[j].GetX();
					y2=vertexL[j].GetY();
                    List<Point> pointToL = new List<Point>();
                    if(x1 == x2 && y1 == y2)
                    {
                        band2 = 3;
                    }
                    if (x1 == x2)
                    {
                        if (y1 < y2)
                        {
                            desp = 1;
                        }
                        else
                        {
                            desp = -1;
                        }
                        x_aux = x1;
                        y_aux = y1;
                        for (; y_aux != y2; y_aux += desp)
                        {
                            Point p = new Point((int)Math.Round(x_aux), (int)Math.Round(y_aux));
                            pointToL.Add(p);
                            if (((MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 0))
                            {
                                band2++;
                            }
                            else
                            if (((!MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (!MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 1))
                            {
                                band2++;
                            }
                            else
                            if (((MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 2))
                            {
                                band2++;
                            }
                            else
                            if (band2 > 2)
                            {
                                break;
                            }
                        }
                    }
                    else if (y1 == y2)
                    {
                        if (x1 < x2)
                        {
                            desp = 1;
                        }
                        else
                        {
                            desp = -1;
                        }
                        x_aux = x1;
                        y_aux = y1;
                        for (; x_aux != x2; x_aux += desp)
                        {
                            Point p = new Point((int)Math.Round(x_aux), (int)Math.Round(y_aux));
                            pointToL.Add(p);
                            if (((MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 0))
                            {
                                band2++;
                            }
                            else
                            if (((!MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (!MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 1))
                            {
                                band2++;
                            }
                            else
                            if (((MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 2))
                            {
                                band2++;
                            }
                            else
                            if (band2 > 2)
                            {
                                break;
                            }
                        }


                    }
                    else
                    {

                        m = ((double)y2 - (double)y1) / ((double)x2 - (double)x1); // calcula la pendiente
                        b = y1 - (m * x1);      //calcula el incremento en y;
                        if (m < 1 && m > -1)
                        {
                            if (x1 < x2)
                                desp = 1;
                            else
                                desp = -1;
                            x_aux = x1;
                            for (; x_aux != x2; x_aux += desp)
                            {
                                y_aux = x_aux * m + b;
                                Point p = new Point((int)Math.Round(x_aux), (int)Math.Round(y_aux));
                                pointToL.Add(p);

                                if (((MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 0))
                                {
                                    band2++;
                                }
                                else
                                if (((!MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (!MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 1))
                                {
                                    band2++;
                                }
                                else
                                if (((MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 2))
                                {
                                    band2++;
                                }
                                else
                                if (band2 > 2)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (y1 < y2)
                            {
                                desp = 1;
                            }
                            else
                            {
                                desp = -1;
                            }
                            y_aux = y1;
                            for (; y_aux != y2; y_aux += desp)
                            {

                                x_aux = (y_aux - b) / m;
                                Point p = new Point((int)Math.Round(x_aux), (int)Math.Round(y_aux));
                                pointToL.Add(p);
                                if (((MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 0))
                                {
                                    band2++;
                                }
                                else
                                 if (((!MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (!MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 1))
                                {
                                    band2++;
                                }
                                else
                                 if (((MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux)), (int)(Math.Round(y_aux))))) || (MainForm.isWhite(copia.GetPixel((int)(Math.Round(x_aux) + 1), (int)(Math.Round(y_aux)))))) && (band2 == 2))
                                {
                                    band2++;
                                }
                                else
                                 if (band2 > 2)
                                {
                                    break;
                                }
                            }
                        }
                    }
					
					if(band2==2){
						disE=Math.Sqrt(Math.Pow((y2-y1),2)+Math.Pow((x2-x1),2));
						Edge Edge =new Edge(vertexL[i],vertexL[j],disE,id, pointToL);

						vertexL[i].SetEdgeL(Edge);
						id++;
					}
                    band2 = 0;
				}
			}
		}
		public void DrawEdge(Bitmap copia){
			foreach(Vertex v in vertexL){
				foreach(Edge edge in v.GetEdgeL()){
					Graphics g=Graphics.FromImage(copia);
					g.DrawLine(Pens.Blue,edge.GetDestino().GetPoint(), edge.GetOrigen().GetPoint());
				}	
			}
			
		}
		public void DrawCircleG(Bitmap copia, Vertex v){
			int x_centro2=v.GetX();
			int y_sup=v.GetY()-(v.GetR()+5);
			int y_inf=v.GetY()+(v.GetR()+5);
			for(int i=y_sup; i<=y_inf;i++){
				x_centro2=v.GetX();
				while(!MainForm.isWhite(copia.GetPixel(x_centro2,i))){
					copia.SetPixel(x_centro2,i,Color.White);
					x_centro2--;
				}
				x_centro2=v.GetX()+1;
				while(!MainForm.isWhite(copia.GetPixel(x_centro2,i))){
					copia.SetPixel(x_centro2,i,Color.White);
					x_centro2++;
				}
				
			}
		}

        public Bitmap ClosestPairPoints(Bitmap copia)
        {
            if (vertexL.Count > 1)
            {
                double disEmi;
                double disAux;
                Vertex aux, aux2;
                int iv = 0, jv = 0;
                Bitmap CPPbmp = new Bitmap(copia);
                disEmi = Math.Sqrt(Math.Pow((vertexL[1].GetY() - vertexL[0].GetY()), 2) + Math.Pow((vertexL[1].GetX() - vertexL[0].GetX()), 2));
                Math.Abs(disEmi);
                for (int i = 0; i < vertexL.Count; i++)
                {
                    for (int j = 0; j < vertexL.Count; j++)
                    {
                        if (i != j)
                        {
                            disAux = Math.Sqrt(Math.Pow((vertexL[j].GetY() - vertexL[i].GetY()), 2) + Math.Pow((vertexL[j].GetX() - vertexL[i].GetX()), 2));
                            Math.Abs(disAux);
                            if (disEmi >= disAux)
                            {
                                disEmi = disAux;
                                iv = i;
                                jv = j;
                            }
                        }
                    }
                }
                aux = vertexL[iv];
                aux2 = vertexL[jv];
                DrawCircleY(CPPbmp, aux);
                DrawCircleY(CPPbmp, aux2);
                return CPPbmp;
            }
            else
                MessageBox.Show("El grafo tiene un solo vertice no hay otro circulo para comparar", "Un solo circulo",MessageBoxButtons.OK);
            return copia;
		}
		public void DrawCircleY(Bitmap Closest, Vertex v ){
			Graphics g = Graphics.FromImage(Closest);
			g.FillEllipse(Brushes.YellowGreen, v.GetX()-1-v.GetR(), (v.GetY()-v.GetR())-2, (v.GetR()*2)+2, (v.GetR()*2)+4);
			
		}
		public void DrawCircleW(Bitmap bmpAnalisis,Vertex v)
		{
			Graphics g = Graphics.FromImage(bmpAnalisis);
			g.FillEllipse(Brushes.White, v.GetX()-1-v.GetR(), (v.GetY()-v.GetR())-2, (v.GetR()*2)+2, (v.GetR()*2)+4);
		}
		public void DrawCircleB(Bitmap bmpAnalisis, Vertex v)
		{
			Graphics g = Graphics.FromImage(bmpAnalisis);
			g.FillEllipse(Brushes.Black, v.GetX()-1-v.GetR(), (v.GetY()-v.GetR())-2, (v.GetR()*2)+2, (v.GetR()*2)+4);
		}
		public void DrawLabel(Bitmap copia){
			string id;
			Graphics g =Graphics.FromImage(copia);
			
				foreach(Vertex v in vertexL){
				
				id=v.GetId().ToString();
				int r=v.GetR();
				int tam=r;
				int tam2=(r*2);
				RectangleF R=new RectangleF(v.GetX()-(r)+(r/4),v.GetY()-(r*2)+(r+(r/4)),tam2,tam2);
				g.DrawString(id,new Font("Arial",tam),Brushes.YellowGreen,R);
			}	
		}
		public void BubbleSortGR(){
			for(int i=0; i<vertexL.Count;i++){ //2n+1
				for(int j=0; j<vertexL.Count-1; j++){//2n+1
					if(vertexL[j].GetR()<vertexL[j+1].GetR()){//3
						Vertex aux =new Vertex(vertexL[j+1]);
						vertexL[j+1]=vertexL[j];
						vertexL[j]=aux;
					}
				}
			}
		}
	}
	
	
	
	//################# Vertex ###################
	public class Vertex{
		Point p;
		int id;
		int radio;
		List<Edge> edgeL;
        List<Rastro> rL = new List<Rastro>();
        public int searchRastro(int id)
        {
            foreach (Rastro r in rL)
            {
                if (r.getId()==id)
                {
                    return r.getCount();
                }

            }
            return -1;
        }

        public void setRastro(Rastro r)
        {
            rL.Add(r);
        }
        public List<Rastro> getRastro()
        {
            return rL;
        }
		
		public Vertex(){
			
		}
		public Vertex(Vertex v){
			this.p=v.GetPoint();
			this.id=v.GetId();
			this.radio=v.GetR();
			this.edgeL=v.GetEdgeL();
		}
		public Vertex(Circle c){
			p.X=c.GetX();
			p.Y=c.GetY();
			id=c.GetId();
			radio=c.GetRadio();
			edgeL=new List<Edge>();
            rL = new List<Rastro>();
		}
		public int GetX(){
			return p.X;
		}
		public int GetY(){
			return p.Y;
		}
		public int GetId(){
			return id;
		}
		public int GetR(){
			return radio;
		}
		public void SetEdgeL(Edge edge){
			edgeL.Add(edge);
		}
		public List<Edge> GetEdgeL(){
			return edgeL;
		}
		public Point GetPoint(){
			return p;
		}
		public override string ToString()
		{
			return string.Format("[Vertex P={0}, Id={1}, Radio={2}]", p, id, radio);
		}

		
	}
	//################ Edge #####################
	public class Edge{
		Vertex destino;
		Vertex origen;
		double peso;
		int id;
		int idOrigen;
		int idDestino;
        List<Point> pL;

		public Edge(){
			
		}
        public Edge(int idorigen, int idDestino,double peso){
        	this.idDestino= idDestino;
        	this.idOrigen= idorigen;
        	this.peso= peso;
        }
        public Edge(Vertex o, Vertex d, double peso)
        {
            origen = o;
            destino = d;
            this.peso = peso;

        }
		public Edge(Vertex destino, Vertex origen, double peso,int id, List<Point> p){
			this.destino=destino;
			this.origen=origen;
			this.peso=peso;
			this.id=id;
            this.pL = p;
		}
		public Vertex GetDestino(){
			return destino;
		}
		public Vertex GetOrigen(){
			return origen;
		}
		public Double GetPeso(){
			return peso;
		}
		public override string ToString()
		{
			return string.Format("[Edge Id={3}, Destino={1}, Origen={0}, Peso={2}, Cantidad de puntos={4}]", destino.GetId(), origen.GetId(), (int)Math.Round(peso), id, pL.Count);
		}
        public List<Point> getpL()
        {
            return pL;
        }

		
	}
    
}
