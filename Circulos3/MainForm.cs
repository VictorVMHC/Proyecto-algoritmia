/*
 * Created by SharpDevelop.
 * User: manue
 * Date: 04/09/2019
 * Time: 10:56 p. m.
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
	/// Description of MainForm.
	/// </summary>
	/// 
	
	
	
	public partial class MainForm : Form
	{
		Bitmap original;
		Bitmap copia;
		Bitmap copia2;
		List<Circle> Cl;
		Grafo grafo;
		Bitmap copiaGrafo;
        bool banderagrafo= false;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
	
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
        private void MainForm_Load(object sender, EventArgs e)
        {
            tabControlelements.Enabled = false;
        }
        // **************************************Boton para cargar la imagen***************************************************
        void CargarClick(object sender, EventArgs e)
		{
			int bandera =0;
			pictureBoxA.Image=null;
			listBoxC.DataSource=null;
			pictureBoxO.Image=null;
			while(bandera==0){
			bandera=0;
			OpenFileDialog imagen =new OpenFileDialog();
			imagen.Filter="Imagenes .png o .bmp|*.png;*.bmp";
            banderagrafo = false;
			if(imagen.ShowDialog()==DialogResult.OK){
			original=new Bitmap(imagen.FileName);
			copia=new Bitmap(imagen.FileName);
			copia2=new Bitmap(imagen.FileName);
			pictureBoxO.Image=original;
			tabControlelements.Enabled=true;
			bandera=1;
			
			}
			else{
				DialogResult r= MessageBox.Show("Puede no hayas seleccionado una imagen,deseas intentar de nuevo","Error",MessageBoxButtons.YesNo);
				if(r==DialogResult.No) bandera=1;
			
				}
			}
		}
// **************************************Etapa 1***************************************************
// **************************************Boton analizar***************************************************
		void AnalizaClick(object sender, EventArgs e)
		{
			FindCircles();
			listBoxC.DataSource=Cl;
			
		}
// **************************************Buscar circulos***************************************************
		void FindCircles(){
			 Cl = new List<Circle>();
			//copia=new Bitmap(original);
			int x_izq,y_sup; // cordenadas X y Y del primer punto
			int x_centro; // cordenada del centro en x y ya igual a y_sup
			int x_der, y_inf; //cordenada de x al otro extremo de x_izq y y_inferir igual para marcar la coordenada
			int y_centro; //se saca la cordenada del centro con y_sup y y_inf
			int radio;// radio del circulo
			int id=1;
			//int cor_y=copia.Height;
			//int cor_x=copia.Width;
			for(int y=0; y<copia.Height-1;y++){
				for(int x=0; x<copia.Width-1;x++){
					if(isBlack(copia.GetPixel(x,y))){
						x_izq=x_der=x; //se ubica x en el primer pixel
						y_sup=y_inf=y;// se ubica y en el primer pixel
						
						while(!isWhite(copia.GetPixel(x_der, y_sup)))
							x_der++; //se cicla x_der para saber hasta donde llega el circulo
						x_der--;
						x_centro=(x_der-x_izq)/2; // se saca el centro del circulo
						x_centro=x_izq+x_centro;
						
						while(!isWhite(copia.GetPixel(x_centro,y_inf)))
							y_inf++; //se cicla para encontrar el punto medio inferior
						y_inf--;
						radio=(y_inf-y_sup)/2; //se saca el sentro en y
						y_centro=y_sup+radio;
						
						if(validateCircle(x_centro, y_centro, radio)){
							drawCircle(x_centro, y_sup, y_inf);
							Circle c=new Circle();
							c.AddCircle(x_centro,y_centro,radio,id);
							Cl.Add(c);
							drawCenter(x_centro,y_centro);
						id++;
						}else if(!validateCircle(x_centro, y_centro, radio))
							drawOval(x_centro,y_sup,y_inf);	
					}
				}
			}
			
			if(id!=1){
			pictureBoxA.Image=copia2;
			listBoxC.DataSource=null;
			
			}else{
				Bitmap sinCirculo =new Bitmap("Sin_circulos.png");
				listBoxC.DataSource=null;
				pictureBoxA.Image=sinCirculo;
			}

			
		}
        // **************************************Etapa 2***************************************************************		
        // **************************************Boton para el grafo***************************************************
        void FindCirclesg()
        {
            Cl = new List<Circle>();
            //copia=new Bitmap(original);
            int x_izq, y_sup; // cordenadas X y Y del primer punto
            int x_centro; // cordenada del centro en x y ya igual a y_sup
            int x_der, y_inf; //cordenada de x al otro extremo de x_izq y y_inferir igual para marcar la coordenada
            int y_centro; //se saca la cordenada del centro con y_sup y y_inf
            int radio;// radio del circulo
            int id = 1;
            //int cor_y=copia.Height;
            //int cor_x=copia.Width;
            for (int y = 0; y < copia.Height - 1; y++)
            {
                for (int x = 0; x < copia.Width - 1; x++)
                {
                    if (isBlack(copia.GetPixel(x, y)))
                    {
                        x_izq = x_der = x; //se ubica x en el primer pixel
                        y_sup = y_inf = y;// se ubica y en el primer pixel

                        while (!isWhite(copia.GetPixel(x_der, y_sup)))
                            x_der++; //se cicla x_der para saber hasta donde llega el circulo
                        x_der--;
                        x_centro = (x_der - x_izq) / 2; // se saca el centro del circulo
                        x_centro = x_izq + x_centro;

                        while (!isWhite(copia.GetPixel(x_centro, y_inf)))
                            y_inf++; //se cicla para encontrar el punto medio inferior
                        y_inf--;
                        radio = (y_inf - y_sup) / 2; //se saca el sentro en y
                        y_centro = y_sup + radio;

                        if (validateCircle(x_centro, y_centro, radio))
                        {
                            drawCircle(x_centro, y_sup, y_inf);
                            Circle c = new Circle();
                            c.AddCircle(x_centro, y_centro, radio, id);
                            Cl.Add(c);
                            id++;
                        }
                        else if (!validateCircle(x_centro, y_centro, radio))
                            drawOval(x_centro, y_sup, y_inf);
                    }
                }
            }

            if (id != 1)
            {
                pictureBoxA.Image = copia2;
                listBoxC.DataSource = null;

            }
            else
            {
                Bitmap sinCirculo = new Bitmap("Sin_circulos.png");
                listBoxC.DataSource = null;
                pictureBoxA.Image = sinCirculo;
            }


        }
        void ButtonGrafoClick(object sender, EventArgs e)
		{
            banderagrafo = true;
			FindCirclesg();
			copiaGrafo= new Bitmap(copia2);
			grafo= new Grafo(Cl);
			
			grafo.CrearAristas(copiaGrafo);
			grafo.DrawEdge(copiaGrafo);
			grafo.DrawLabel(copiaGrafo);  
			//grafo.ClosestPairPoints(copiaGrafo);
			pictureBoxA.Image=copiaGrafo;
			treeViewGR.Nodes.Clear();
			TreeViewGRM();
			numericUpDownListCircle.Maximum=Cl.Count-1;
			numericUpDownListCircle.Minimum=1;
		}
// **************************************Boton para eliminar un vertice***************************************************
		void ButtonDeleteVertexClick(object sender, EventArgs e)
		{
			Circle aux= new Circle();
			aux=FindCircleInList((int)numericUpDownListCircle.Value);
			Cl.Remove(aux);
			listBoxC.DataSource=Cl;
			copiaGrafo=new Bitmap(copia2);
			DrawCircleG(copiaGrafo,aux);
			grafo.SetGrafo(Cl);
			grafo.CrearAristas(copiaGrafo);
			grafo.DrawEdge(copiaGrafo);
			grafo.DrawLabel(copiaGrafo); 
			pictureBoxA.Image=copiaGrafo;
			treeViewGR.Nodes.Clear();
			TreeViewGRM();
			numericUpDownListCircle.Maximum=Cl.Count-1;
			numericUpDownListCircle.Minimum=1;
		}
// **************************************Pintar circulos del grafo de blanco para el boton de eliminar***************************************************
		void DrawCircleG(Bitmap copiaC, Circle v){
			int x_centro2=v.GetX();
			int y_sup=v.GetY()-(v.GetRadio()+5);
			int y_inf=v.GetY()+(v.GetRadio()+5);
			for(int i=y_sup; i<=y_inf;i++){
				x_centro2=v.GetX();
				while(!isWhite(copiaC.GetPixel(x_centro2,i))){
					copiaC.SetPixel(x_centro2,i,Color.White);
					x_centro2--;
				}
				x_centro2=v.GetX()+1;
				while(!isWhite(copiaC.GetPixel(x_centro2,i))){
					copiaC.SetPixel(x_centro2,i,Color.White);
					x_centro2++;
				}
				
			}
		}
// **************************************Agrefar aristas al treeview***************************************************
		public void TreeViewGRM(){
			foreach(Vertex v in grafo.GetVertexL()){
				TreeNode[] Array=new TreeNode[v.GetEdgeL().Count];
				int i=0;
				foreach(Edge e in v.GetEdgeL()){
					TreeNode subNode =new TreeNode(e.ToString());
					Array[i] = subNode;
					i++;
				}
				TreeNode vertex =new TreeNode(v.ToString(),Array);
				treeViewGR.Nodes.Add(vertex);
			}
		}
// **************************************Busca un circulo por id***************************************************
		public Circle FindCircleInList(int idFind){
			foreach(Circle c in Cl){
				if(c.GetId()==idFind)
					return c;
			}
			return null;
		}
// **************************************Eliminar ovalos***************************************************
		void drawOval(int x_centro, int y_sup, int y_inf){
			int x_centro2=x_centro;
			for(int i=y_sup; i<=y_inf;i++){
				x_centro2=x_centro;
				while(!isWhite(copia2.GetPixel(x_centro2,i))){
					copia2.SetPixel(x_centro2,i,Color.White);
					copia.SetPixel(x_centro2,i,Color.White);
					x_centro2--;
				}
				x_centro2=x_centro+1;
				while(!isWhite(copia2.GetPixel(x_centro2,i))){
					copia2.SetPixel(x_centro2,i,Color.White);
					copia.SetPixel(x_centro2,i,Color.White);
					x_centro2++;
				}
				
			}
		
		}
// **************************************valioda si el circulo encontrado en realidad es un circulo***************************************************		 
		bool validateCircle(int x, int y, int radio){
			int r1,x2;// variables axiliares para saber si es circulo
			x2=x;
			while(!isWhite(copia.GetPixel(x2,y)))
				x2++;
			x2--;
			r1=x2-x;
					if(r1>= radio-10){
						if(r1<= radio+10){
							return true;
						}
					}
			
			return false;
		}
// **************************************Pinta el circulo con cordenadas del centro superior***************************************************
		 void drawCircle(int x_centro, int y_sup, int y_inf){
			int x_centro2=x_centro;
			for(int i=y_sup; i<=y_inf;i++){
				x_centro2=x_centro;
				while(!isWhite(copia.GetPixel(x_centro2,i))){
					copia.SetPixel(x_centro2,i,Color.White);
					x_centro2--;
				}
				x_centro2=x_centro+1;
				while(!isWhite(copia.GetPixel(x_centro2,i))){
					copia.SetPixel(x_centro2,i,Color.White);
					x_centro2++;
				}
			}	
		}
// **************************************Pinta rojo los centros de los circulos encontrados***************************************************
		void drawCenter(int x_c, int y_c){
		 //copia2 = new Bitmap(original);
		 
			for(int y=y_c-5; y <= y_c+5 ; y++){
				for(int x = x_c-5 ; x <= x_c+5 ; x++){
					copia2.SetPixel(x,y,Color.Red);
				}
			}	
			
		}
// **************************************Validaciones de colores blanco y negro**************************************************
		public static bool isBlack(Color color){
			if(color.R==color.G)
				if(color.G==color.B)
					if(color.B<=238)
						return true;
			return false;
			
		}
		public static bool isWhite(Color color){
			if(color.R==255)
				if(color.G==255)
					if(color.B==255)
						return true;
			return false;
		}
// **************************************Boton para ordenar la lista de circulos***************************************************
		void ButtonOrdenarCClick(object sender, EventArgs e)
		{
			BubbleSort();
			listBoxC.DataSource=null;
			listBoxC.DataSource=Cl;
		}
// **************************************Ordena la lista de circulos***************************************************
		void BubbleSort(){
			for(int i = 0; i < Cl.Count; i++){
				for( int j = 0; j < Cl.Count - 1; j++){
					if(Cl[j].GetRadio() < Cl[j+1].GetRadio()){
						Circle ctem=new Circle();	
						ctem.SetCircle(Cl[j+1]);
					Cl[j+1]=Cl[j];
					Cl[j]=ctem;	
					}
				}
			}
		}
// **************************************boton llama al metodo del grafo para obtener el par de puntos mas cercanos***************************************************
		void ButtonClosestPPClick(object sender, EventArgs e)
		{
			pictureBoxA.Image=grafo.ClosestPairPoints(copiaGrafo);
		}
// **************************************Boton para ordenar el grafo con bubblesort ***************************************************
		void ButtonBubblegrClick(object sender, EventArgs e)
		{
			grafo.BubbleSortGR();
			treeViewGR.Nodes.Clear();
			TreeViewGRM();
		}

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!banderagrafo)
            {
                MessageBox.Show("No se creo el grafo");
            } else
            if (grafo.GetVertexL().Count <= 1)
            {
                MessageBox.Show("Puede que solo haya 1 o 0 vertices no es posible crear agentes ni señuelos, por favor selecciona otra imagen");

            }
            else {
                Agente agen = new Agente(copiaGrafo, grafo);
                agen.ShowDialog();
                agen.Dispose();
            }
        }

        private void Prim_Kruskal_Click(object sender, EventArgs e)
        {
            if (!banderagrafo)
            {
                MessageBox.Show("No se creo el grafo");
            }
            else
            if (grafo.GetVertexL().Count <= 1)
            {
                MessageBox.Show("Puede que solo haya 1 o 0 vertices no es posible crear agentes ni señuelos, por favor selecciona otra imagen");

            }
            else
            {
                FormP_K formPK = new FormP_K(copiaGrafo, grafo);
                formPK.ShowDialog();
            }

        }

        private void ButtonForDijkstra_Click(object sender, EventArgs e)
        {
            if (!banderagrafo)
            {
                MessageBox.Show("No se creo el grafo");
            }
            else
            if (grafo.GetVertexL().Count <= 1)
            {
                MessageBox.Show("Puede que solo haya 1 o 0 vertices no es posible crear agentes ni señuelos, por favor selecciona otra imagen");

            }
            else
            {
               
                FormDijkstra formD = new FormDijkstra(copiaGrafo, grafo);
                formD.ShowDialog();
                //formD.Dispose();
                GC.Collect();
            }

        }
    }// Curly bracket OF MAIN
}
