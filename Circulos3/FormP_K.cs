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
    public partial class FormP_K : Form
    {
        Grafo GrafoOriginal;
        Bitmap GrafoOriginalBmp;
        Bitmap CopiaGrafo;
        Bitmap A1;
        Bitmap A2;
        Bitmap Band;
        Bitmap animation;
        Bitmap copiaAmbos;
        bool banderAKORP;
        bool banderA1KORP;
        List<Edge> EdgeL = new List<Edge>();
        Kruskal krus;
        Prim prim;
        Point Escalado;
        int idForPrim;
        //Vertex Agente1;
        //Vertex Agente2;
        Vertex vertexDes1;
        Vertex vertexDes2;
        Vertex vFPrim;
        AgenteClass a1= new AgenteClass();
        AgenteClass a2= new AgenteClass();
        List<Vertex> camino = new List<Vertex>();
        List<Vertex> camino2 = new List<Vertex>();
        List<Edge> edgeVisited1= new List<Edge>();
        Graphics gra;
        // List<Edge> edgeVisiteda2= new List<Edge>();
        bool bandagent= false;

        public FormP_K(Bitmap imageGrafoP, Grafo grafop)
        {
            InitializeComponent();
            GrafoOriginal = grafop;
            GrafoOriginalBmp = imageGrafoP;
        }

        private void FormP_K_Load(object sender, EventArgs e)
        {
        	pictureBoxImage.BackgroundImageLayout=ImageLayout.Zoom;
        	pictureBoxImage.BackgroundImage= GrafoOriginalBmp;
        	copiaAmbos = new Bitmap (GrafoOriginalBmp);
        	animation = new Bitmap(GrafoOriginalBmp.Width, GrafoOriginalBmp.Height);
        	gra= Graphics.FromImage(animation);
        	
            foreach (Vertex v in GrafoOriginal.GetVertexL())
            {
                foreach (Edge edge in v.GetEdgeL())
                {
                    EdgeL.Add(edge);
                }
            }
            CopiaGrafo = new Bitmap(GrafoOriginalBmp);
            //pictureBoxImage.Image = GrafoOriginalBmp;
            A1 = new Bitmap("A1.png");
            A2 = new Bitmap("A2.png");
            Band = new Bitmap("band.png");
            pictureBoxA1.Image= A1;
            pictureBoxA2.Image= A2;
            MosDFSA1.Visible=false;
            MosDFSA2.Visible=false;
            buttonMosKrus.Visible=false;
            buttonMosPrim.Visible=false;
            buttonMovKrus.Visible=false;
            buttonMovPrim.Visible=false;
            buttonDraw2.Visible=false;
            numericUpDownAgent1.Visible=false;
            numericUpDownAgent2.Visible=false;
            movKruskalA2.Visible=false;
            MovPrimA2.Visible=false;
            labelA1.Visible=false;
            labela2.Visible=false;
            pictureBoxA1.Visible=false;
            pictureBoxA2.Visible=false;
            Animation.Visible=false;
            listBoxSubArbol.Visible=false;
            listBoxDFS.Visible=false;
            listBoxARM.Visible=false;
            
         }
        
        void PictureBoxImageMouseClick(object sender, MouseEventArgs e)
		{
			
			double h_heightP, w_WidthP;
            double h_heightI, w_WidthI;
            double h_escalado, w_escalado, min;
            Vertex aux;
            Vertex v = new Vertex();
            double incrementox, incrementoy;
            w_WidthP = pictureBoxImage.Width;
            h_heightP = pictureBoxImage.Height;
            w_WidthI = CopiaGrafo.Width;
            h_heightI = CopiaGrafo.Height;
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
            }else{
	            if(e.Button == MouseButtons.Middle){
            		gra.Clear(Color.Transparent);
            		drawCircleAgente(aux);
            		drawS(aux);
                    vFPrim = aux;
                    pictureBoxImage.Image = animation;
            		idForPrim= aux.GetId();
            	}
            	if(!bandagent){
            	if( e.Button ==MouseButtons.Left){
            		if(banderaa1==0){
            			a1 = new AgenteClass(aux,1);
            			DrawAgent1(aux);
            			pictureBoxImage.Image = animation;
            			banderaa1=1;
            			labelA1.Visible=true;
            			buttonMovKrus.Visible=true;
            			buttonMovPrim.Visible=true;
            			numericUpDownAgent1.Visible=true;
            			numericUpDownAgent1.Minimum=2;
            			pictureBoxA1.Visible=true;
            			Animation.Visible=true;
            			listBoxDFS.Visible=true;
            			MosDFSA1.Visible=true;
            	}else{
            			a2 = new AgenteClass(aux,2);
            			DrawAgent2(aux);
            			pictureBoxImage.Image = animation;
            			banderaa1=0;
            			labela2.Visible=true;
            			pictureBoxA2.Visible=true;
            			numericUpDownAgent2.Visible=true;
            			numericUpDownAgent2.Minimum=2;
            			movKruskalA2.Visible=true;
            			MovPrimA2.Visible=true;
            			MosDFSA2.Visible=true;
            		}
            	}
            	if(e.Button == MouseButtons.Right){
            		if(banderad1 == 0){
            			vertexDes1 = aux;
            			DrawDestino(vertexDes1);
            			pictureBoxImage.Image = animation;
            			banderad1=1;
            			
            			
            		}else{
            			vertexDes2 = aux;
            			DrawDestino2(vertexDes2);
            			pictureBoxImage.Image = animation;
            			banderad1 =0;
            		}
            		
            		}
            	}
            }
		}
        bool banderaK=false;
        bool banderaP=false;
        
        private void ButtonPrim_Click(object sender, EventArgs e)
        {
        	 
        	if(idForPrim!=0){
                //prim = new Prim(idForPrim,EdgeL,GrafoOriginal,CopiaGrafo);
                prim = new Prim(vFPrim, CopiaGrafo, GrafoOriginal);
                mostrardataprim();
            idForPrim=0;
            banderaP =true;
        	}else{
        		MessageBox.Show("No se puede crear prim");
        	}
			listBoxSubArbol.Visible=true;
            listBoxARM.Visible=true;
            buttonMosPrim.Visible=true;
            buttonDraw2.Visible=true;
        }
        private void ButtonKruskal_Click(object sender, EventArgs e)
        {
            krus = new Kruskal( EdgeL, GrafoOriginal, CopiaGrafo);
            mostrardatakrus();
             listBoxSubArbol.Visible=true;
            listBoxARM.Visible=true;
             buttonMosKrus.Visible=true;
             banderaK =true;
        }
        public List<Vertex> buscar_A(List<List<Vertex>> vL, Vertex vBuscado){
        	foreach(List<Vertex> verl in vL){
        		foreach(Vertex v in verl){
        			if(v== vBuscado){
        				return verl;
        			}
        		}
        	}
        	return null;
        }
//##########################################################################################
        List<Edge> edgeVisited= new List<Edge>();
        
        public bool dfsForKruskal(Vertex vActual)
        {        	
        	camino.Add(vActual);    //    			
        	if(vActual == vertexDes1){
        		return true;
        	}else{
        		foreach(Edge e in vActual.GetEdgeL()){
        			if(searchE(e) && !searchEinVisited(e)){	
        			
        			    edgeVisited.Add(e);
	        			if(dfsForKruskal(e.GetOrigen())){
	        				return true;
        			    }else{
        				    edgeVisited.Add(e);
        				    camino.Add(vActual);
        			    }        				
        			}
        		}		
        	}
        	return false;
        }
        public bool dfsForPrim(Vertex vActual)
        {        	
        	camino.Add(vActual);        			
        	if(vActual == vertexDes1){
        		return true;
        	}else{
        		foreach(Edge e in vActual.GetEdgeL()){
        			if(searchEForPrim(e) && !searchEinVisitedForPrim(e)){	        			
        				edgeVisited.Add(e);
	        			if(dfsForPrim(e.GetOrigen())){
	        				return true;
        				}else{
        					edgeVisited.Add(e);
        					camino.Add(vActual);
        				}        				
        			}
        		}		
        	}
        	return false;
        }
        public bool searchEForPrim(Edge eb){
        	foreach(Edge e in prim.getPrometedor()){
        		if((eb.GetDestino() == e.GetDestino() && eb.GetOrigen() == e.GetOrigen()) || (eb.GetOrigen() == e.GetDestino() && eb.GetDestino() == e.GetOrigen())){
        			return true;
        		}		     		
        	}
        	return false;
        }
        public bool searchEinVisitedForPrim(Edge eb){
        	foreach(Edge e in edgeVisited){
        		if((eb.GetDestino() == e.GetDestino() && eb.GetOrigen() == e.GetOrigen()) || (eb.GetOrigen() == e.GetDestino() && eb.GetDestino() == e.GetOrigen())){
        			return true;
        		}     		
        	}
       	 return false; 	
       }
        
        public bool searchEinVisited(Edge eb){
        	foreach(Edge e in edgeVisited){
        		if((eb.GetDestino() == e.GetDestino() && eb.GetOrigen() == e.GetOrigen()) || (eb.GetOrigen() == e.GetDestino() && eb.GetDestino() == e.GetOrigen())){
        			return true;
        		}		     		
        	}
        return false;
        	
        }
      /*  public bool searchV(Vertex v){
        	foreach(Vertex vc in camino){
        		if(vc == v){return true;}
        		
        	}
        	return false;
        }*/
      
        public bool searchE(Edge eb){
        	foreach(Edge e in krus.getPrometedor()){
        		if((eb.GetDestino() == e.GetDestino() && eb.GetOrigen() == e.GetOrigen()) || (eb.GetOrigen() == e.GetDestino() && eb.GetDestino() == e.GetOrigen())){
        			return true;
        		}
        			     		
        	}
        return false;
        }
//############################################################################################################################
public bool dfsForKruskalA2(Vertex vActual){
        	
        	camino2.Add(vActual);
        			
        	if(vActual == vertexDes2){
        		return true;
        	}else{
        		foreach(Edge e in vActual.GetEdgeL()){

        			if(searchEA2(e) && !searchEinVisitedA2(e)){	
        			
        			edgeVisited1.Add(e);
	        			if(dfsForKruskalA2(e.GetOrigen())){
	        				return true;
        			}else{
        				edgeVisited1.Add(e);
        				camino2.Add(vActual);
        			    }        				
        			}
        		}		
        	}
        	return false;
        }
         public bool dfsForPrimA2(Vertex vActual){
        	
        	camino2.Add(vActual);
        			
        	if(vActual == vertexDes2){
        		return true;
        	}else{
        		foreach(Edge e in vActual.GetEdgeL()){
        			if(searchEForPrimA2(e) && !searchEinVisitedForPrimA2(e)){	        			
        				edgeVisited1.Add(e);
	        			if(dfsForPrimA2(e.GetOrigen())){
	        				return true;
        				}else{
        					edgeVisited1.Add(e);
        					camino2.Add(vActual);
        				}        				
        			}
        		}		
        	}
        	return false;
        }
        public bool searchEForPrimA2(Edge eb){
        	foreach(Edge e in prim.getPrometedor()){
        		if((eb.GetDestino() == e.GetDestino() && eb.GetOrigen() == e.GetOrigen()) || (eb.GetOrigen() == e.GetDestino() && eb.GetDestino() == e.GetOrigen())){
        			return true;
        		}		     		
        	}
        	return false;
        }
        public bool searchEinVisitedForPrimA2(Edge eb){
        	foreach(Edge e in edgeVisited1){
        		if((eb.GetDestino() == e.GetDestino() && eb.GetOrigen() == e.GetOrigen()) || (eb.GetOrigen() == e.GetDestino() && eb.GetDestino() == e.GetOrigen())){
        			return true;
        		}     		
        	}
       	 return false; 	
       }
       public bool searchEinVisitedA2(Edge eb){
        	foreach(Edge e in edgeVisited1){
        		if((eb.GetDestino() == e.GetDestino() && eb.GetOrigen() == e.GetOrigen()) || (eb.GetOrigen() == e.GetDestino() && eb.GetDestino() == e.GetOrigen())){
        			return true;
        		}		     		
        	}
        return false;
        	
        }
        public bool searchEA2(Edge eb){
        	foreach(Edge e in krus.getPrometedor()){
        		if((eb.GetDestino() == e.GetDestino() && eb.GetOrigen() == e.GetOrigen()) || (eb.GetOrigen() == e.GetDestino() && eb.GetDestino() == e.GetOrigen())){
        			return true;
        		}
        			     		
        	}
        return false;
        }
//###########################################################################################################
        private void Label1_Click(object sender, EventArgs e)
        {

        }
        int banderaa1=0;
        int banderad1=0;
        //int banderaa2=0;
        //int banderad2=0;
        
        
        
		public void drawCircleAgente(Vertex v)
        {
			
            gra.FillEllipse(Brushes.Red, v.GetX() - 10, v.GetY() - 10, 20, 20);
           
        }
		public void drawS(Vertex v){
			
			gra.DrawString("B",new Font("arial",40),Brushes.Green, v.GetPoint());
		}
		public Vertex detectVertex(int x, int y)
        {
            int d;
            foreach (Vertex v in GrafoOriginal.GetVertexL()) {

                d = (int)Math.Round(Math.Abs(Math.Sqrt(Math.Pow((x - v.GetX()), 2) + Math.Pow((y - v.GetY()), 2))));
                if (d <= v.GetR())
                {
                    //Vertex aux = new Vertex(v);
                    return v;
                }
            }
            return null;
        }
		void ButtonMosPrimClick(object sender, EventArgs e)
		{
		
			mostrardataprim();
		}
		public void mostrardataprim()
		{
			pictureBoxImage.BackgroundImage = prim.getBitmap();
            labelPeso.Text= "peso de prim" + prim.getPeso();
			listBoxSubArbol.DataSource=null;
			listBoxARM.DataSource = prim.getPrometedor();
//			camino2.Clear();
//			edgeVisited1.Clear();
//			dfsForPrim(a2.getVertex_Actual());
			int count=1;
			listBoxSubArbol.Items.Clear();
			foreach(List<Vertex> vL in prim.getSubgraph()){
				listBoxSubArbol.Items.Add("Subarbol # "+count++);
				foreach(Vertex v in vL){
					listBoxSubArbol.Items.Add(v);
				}
			}
			
		}
		void ButtonMosKrusClick(object sender, EventArgs e)
		{
			mostrardatakrus();
	
		}
		public void mostrardatakrus(){
			 pictureBoxImage.BackgroundImage = krus.getBitmap();
             labelPeso.Text= "peso kruskal" + krus.getPeso();
             listBoxARM.DataSource=null;
             listBoxARM.DataSource = krus.getPrometedor();
            
            	int count=1;
            	listBoxSubArbol.Items.Clear();
            	foreach(List<Vertex> vL in krus.getSubGrafo()){
            		listBoxSubArbol.Items.Add("SubArbol"+ count++);
            		foreach(Vertex v in vL){
            			listBoxSubArbol.Items.Add(v);
            		}
            	}
			
		}
		void ListBoxARMSelectedIndexChanged(object sender, EventArgs e)
		{
	
		}
		void ButtonDraw2Click(object sender, EventArgs e)
		{
			krus.DrawKrusKal(copiaAmbos);
			prim.drawPrim(copiaAmbos);
			
			pictureBoxImage.BackgroundImage= copiaAmbos;
	
		}
		public void DrawAgent1(Vertex v){
			 gra.FillEllipse(Brushes.Green, v.GetX() - 10, v.GetY() - 10, 20, 20);
		}
		public void DrawAgent1(Point v){
			 gra.FillEllipse(Brushes.Green, v.X - 10, v.Y - 10, 20, 20);
		}
		
		public void DrawAgent2(Vertex v){
			 gra.FillEllipse(Brushes.Orange, v.GetX() - 10, v.GetY() - 10, 20, 20);
		}
		public void DrawAgent2(Point v){
			 gra.FillEllipse(Brushes.Orange, v.X - 10, v.Y - 10, 20, 20);
		}
		public void DrawDestino(Vertex v){
			gra.FillRectangle(Brushes.Green, v.GetX() - 10, v.GetY() - 10, 20, 20);
		}
		public void DrawDestino2(Vertex v){
			gra.FillRectangle(Brushes.Orange, v.GetX() - 10, v.GetY() - 10, 20, 20);
		}
		void ButtonMovKrusClick(object sender, EventArgs e)
		{
			banderAKORP=true;
		}
		void ButtonMovPrimClick(object sender, EventArgs e)
		{
			banderAKORP=false;
		}
		void MovKruskalA2Click(object sender, EventArgs e)
		{
			banderA1KORP=true;
	
		}
		void MovPrimA2Click(object sender, EventArgs e)
		{
			banderA1KORP=false;
	
		}
		void MosDFSA1Click(object sender, EventArgs e)
		{
			camino.Clear();
			edgeVisited.Clear();
			
			listBoxDFS.DataSource=null;
			if(banderaK){
			if(banderAKORP){
				dfsForKruskal(a1.getVertex_Actual());
				listBoxDFS.DataSource=edgeVisited;
					
				}}if(banderaP){
				if(!banderAKORP){
				dfsForPrim(a1.getVertex_Actual());
				
				listBoxDFS.DataSource=edgeVisited;
			}
			}
		}
		void MosDFSA2Click(object sender, EventArgs e)
		{
			camino2.Clear();
			edgeVisited1.Clear();
			listBoxDFS.DataSource=null;
			if(banderaK){
			if(banderA1KORP){
				dfsForKruskalA2(a2.getVertex_Actual());
				listBoxDFS.DataSource=camino2;
				
				}}if(banderaP){
				if(!banderA1KORP){
				dfsForPrimA2(a2.getVertex_Actual());
				listBoxDFS.DataSource=camino2;
				}
			}
		}
		bool bananimationa1=false;
		bool bananimationa2= false;
		int count1=0;
		int count2=0;
		bool vel;
		bool vel2;
		void AnimationClick(object sender, EventArgs e)
		{
			count1=0;
			count2=0;
			bananimationa1=false;
			bananimationa2=false;
			if(a1.getId ()==0){
				bananimationa1=true;
				a1.setVel((int)(numericUpDownAgent1.Value));
			}
			if(a2.getId ()==0){
				a2.setVel((int)(numericUpDownAgent2.Value));
				bananimationa2=true;
			}
			while(!bananimationa1 || !bananimationa2){
				gra.Clear(Color.Transparent);
				walk();
				pictureBoxImage.Refresh();
				
			}
	
		}
		public void walk(){
			if(a1!= null && !bananimationa1){

                if (!bananimationa1) {
                    if (a1.getEdge_Actual() == null) {
                        if (count1 > edgeVisited.Count - 1) {
                            bananimationa1 = true;
                        } else {
                            a1.setEdge_Actual(edgeVisited[count1]);
                            count1++;
                        }
                    }
                    if (count1 > edgeVisited.Count) {
                        bananimationa1 = true;
                    }
                    if (a1.getEdge_Actual() != null) {
                        if (a1.getVertex_Actual() == edgeVisited[count1 - 1].GetDestino()) {
                            if ((a1.getActualEdgeIndex() + a1.getVel()) >= a1.getEdge_Actual().getpL().Count) {
                                a1.setVertex_Actual(a1.getEdge_Actual().GetOrigen());
                                a1.setEdge_Actual(null);
                                a1.setIndexEdgeActual(0);
                            } else {
                                a1.setIndexEdgeActual(a1.getActualEdgeIndex() + a1.getVel());
                                DrawAgent1(a1.getEdge_Actual().getpL()[a1.getActualEdgeIndex() - a1.getVel()]);

                            }
                        } else {
                            if (a1.getEdge_Actual() != null) {
                                if (!vel) {

                                    a1.setIndexEdgeActual(a1.getEdge_Actual().getpL().Count);
                                    vel = true;
                                }
                                if (0 > (a1.getActualEdgeIndex() - a1.getVel())) {
                                    a1.setVertex_Actual(a1.getEdge_Actual().GetDestino());
                                    a1.setEdge_Actual(null);
                                    a1.setIndexEdgeActual(0);
                                    vel = false;
                                } else {
                                    a1.setIndexEdgeActual(a1.getActualEdgeIndex() - a1.getVel());
                                    DrawAgent1(a1.getEdge_Actual().getpL()[a1.getActualEdgeIndex()]);

                                }
                            }
                        }
                    }
                }
			}//brackets of agent one
				if(a2!= null && !bananimationa2){
				
				    if(!bananimationa2){
				        if(a2.getEdge_Actual() == null){
						    if(count2 > edgeVisited1.Count-1){
					             bananimationa2 =true;
						    }
                            else {
				                a2.setEdge_Actual(edgeVisited1[count2]);
				                count2++;
						    }
				        }      
					    if(count2 > edgeVisited1.Count){
					        bananimationa2 =true;
				        }
                        if (a2.getEdge_Actual() != null) {
                            if (a2.getVertex_Actual() == edgeVisited1[count2 - 1].GetDestino()) {
                                if ((a2.getActualEdgeIndex() + a2.getVel()) >= a2.getEdge_Actual().getpL().Count) {
                                    a2.setVertex_Actual(a2.getEdge_Actual().GetOrigen());
                                    a2.setEdge_Actual(null);
                                    a2.setIndexEdgeActual(0);
                                } else {
                                    a2.setIndexEdgeActual(a2.getActualEdgeIndex() + a2.getVel());
                                    DrawAgent2(a2.getEdge_Actual().getpL()[a2.getActualEdgeIndex() - a2.getVel()]);
                                }
                            }
                            else {
                                if (a2.getEdge_Actual() != null) {
                                    if (!vel2) {

                                        a2.setIndexEdgeActual(a2.getEdge_Actual().getpL().Count);
                                        vel2 = true;
                                    }
                                    if (0 > (a2.getActualEdgeIndex() - a2.getVel())) {
                                        a2.setVertex_Actual(a2.getEdge_Actual().GetDestino());
                                        a2.setEdge_Actual(null);
                                        a2.setIndexEdgeActual(0);
                                        vel2 = false;
                                    } else {
                                        a2.setIndexEdgeActual(a2.getActualEdgeIndex() - a2.getVel());
                                        DrawAgent2(a2.getEdge_Actual().getpL()[a2.getActualEdgeIndex()]);
                                    }
                                }
                            }
                        }
				    }
			    }			
		}//brackets brackets Of class walk
	
		
		
    }
}
