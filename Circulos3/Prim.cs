/*
 * Created by SharpDevelop.
 * User: manue
 * Date: 19/11/2019
 * Time: 12:19 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Circulos3
{
    /// <summary>
    /// Description of Prim.
    /// </summary>
    public class Prim
    {
        Bitmap PrimBitmap;
        double PesoT;
        List<List<Vertex>> subGrafos = new List<List<Vertex>>();
        List<Edge> prometedorL;
       // List<List<Edge>> subEdge = new List<List<Edge>>();

        public Prim(Vertex origen, Bitmap grafo, Grafo gra)
        {
            PrimBitmap = grafo; // le agrego el bitmap asl bitmap de prim 
            subGrafos.Clear();
            Vertex vertexActual = origen;
            List<Edge> candidatas = new  List<Edge>();  // aristas candidatas
            List<Vertex> vVisited = new List<Vertex>(); // lista de vertices visitados
            List<Vertex> vVisiteds = new List<Vertex>();// lista de vertices visitados para crear el subgrafo
            prometedorL = new List<Edge>();  // resevo espacio para la listas de aristas de prometedor
            vVisited.Add(origen); // agrego el vertice origen a los dos al visitados y al visitados para el subgrafo
            vVisiteds.Add(origen);
            sacarCandidatas(origen,candidatas); // sacar candidatas del vertice en el que se esta analizando
            while (vVisited.Count != gra.GetVertexL().Count) // mientras que no se hayan visitad todos los vertices
            {
                Edge EdgeAuxiliar; // edge sirve para almacenar la arista con menor peso de las candidatas hasta el momento
                EdgeAuxiliar = candidataMenor(vertexActual, candidatas, vVisited); // saca la candidata de menor peso dentro de la lista, se compara, con los vertices visitados
                if (EdgeAuxiliar != null) // si si se a encontrado la arista que conecta al nuevo vertice, se entra al ciclo
                {
                    vertexActual = EdgeAuxiliar.GetOrigen(); // en esta parte nos movemos haci otro punto, el destino de la arista puesto que el origen ya se encuentra en la lista
                    vVisited.Add(vertexActual); // agregamos el vertice destino a las dos listas 
                    vVisiteds.Add(vertexActual); 
                    prometedorL.Add(EdgeAuxiliar); // y agrego la arista que encontre a prometedor
                    sacarCandidatas(vertexActual, candidatas); // sacar candidatas  toma las aristas del vertice en el que me encuentro,  y las agrega a la lista de candidatas
                }
                else//si las aristas que se encuentran en candidatas, tienen como origen, algun vertice de visitados retorna nul pero aun no termina de agregarse todos los vertices asi que conectamos otro
                {
                    Vertex vertexaux = new Vertex(); // vertexaux me permite gua rdar un vertice que no se encuentra dentro de visitados y asi expandir mi lista de candidatas
                     vertexaux=BuscarIsla(vVisited,gra); // buscarisla, busca el primer vertice que no se encuentre dentro de mi lista de visitados
                    if (vertexaux!= null) // si ya se encontro uno entra al if 
                    {
                        List<Vertex> temp = new List<Vertex>(vVisiteds);// se crea una lista de vertices temporal la cual almacenara los vertices visitados hasta el momento
                        subGrafos.Add(temp); // dicha lista la guardo como un subgrafo
                        vVisiteds.Clear();// limpro la lista auxiliar de visitados para comensar a armar otro arbol
                        vertexActual = vertexaux; // mi vertice actual sera el vertice auxiliar que encontre
                        vVisited.Add(vertexActual);// lo agrego a las dos listas de visitados 
                        vVisiteds.Add(vertexaux);
                        sacarCandidatas(vertexActual, candidatas);// saco las aristas del vertice que no se habia tocado, y las meto como candidatas
                    }
                }
            }
            drawPrim(); // dibujo todas mis aristas
            calculatePeso(); // y se calcula el peso final
        }
        public Vertex BuscarIsla(List<Vertex> vVisitados, Grafo gra)
        {
            foreach (Vertex v in gra.GetVertexL()) // el primer vertice que no se encuentre en mi lista de visitados lo retorno 
            {
                if (!vVisitados.Contains(v)) //la primera que no se encuentra en contains
                {
                    return v;
                }
            }
            return null;
        }
        public Edge candidataMenor(Vertex vertexActual, List<Edge> candidatas, List<Vertex> vVisited)
        {
            bool banderaIf = false;
            Edge e = new Edge(vertexActual, vertexActual, double.MaxValue);
            foreach (Edge ed in candidatas) // de cada asrista dentro de mi candidatas revisosi la arista contiene mi vertice origen y no contiene el destino
            {                               // 
               if (  (vVisited.Contains(ed.GetDestino())) && (!vVisited.Contains(ed.GetOrigen())) )
              // if(buscarinVisited(ed.GetDestino(),vVisited) && !buscarinVisited(ed.GetOrigen(),vVisited))
                {
                    if (ed.GetPeso() < e.GetPeso())//  en cuanto encuentre la primera menor maracara la bandera como verdadero y guardara la arista, asi hasta haber analizafdo todaslas aristas
                    {
                        e = ed;
                        banderaIf = true;
                    }

                }
            }
            if (banderaIf)  // cuando la bandera fue verdadero, entonces si se encontro una menor
            {
                candidatas.Remove(e); // la remuevo de las candidatas
                return e; // regreso  la arista que encontre
            }
            else
            {
                return null;    // regreso null si ninguna arista, tinen com destino  un nuevo vertice
            }
        }

        public void sacarCandidatas(Vertex v, List<Edge> candidatas)
        {
            foreach (Edge e in v.GetEdgeL())
            {
                candidatas.Add(e);
            }
        }



        /*        public bool buscarinVisited(Vertex b, List<Vertex> vVisited)
        {
            foreach (Vertex v in vVisited)
            {
                if (b==v)
                {
                    return true;
                }
            }
            return false;
        }*/

        /*public Prim(int origen, List<Edge> edgeL,Grafo graph, Bitmap BMP)
		{
			PrimBitmap = new Bitmap(BMP);
			subGrafos.Clear();
			subEdge.Clear();
			List<Edge> candidates = new List<Edge>(edgeL);
			List<Edge> prometedor = new List<Edge>();
			List<int> visited = new List<int>();
			List<Vertex> visitedV = new List<Vertex>();
			PesoT=0;
			
			visited.Add(origen);
			visitedV.Add(graph.GetVertexL()[origen-1]);
			
			List<Edge> temp = new List<Edge>();
			
			while(visited.Count <graph.GetVertexL().Count){
				Edge e = new Edge();
				e= menor(visited, candidates);
				if(e.GetPeso()==float.MaxValue){
					List<Vertex> aux = new List<Vertex>(visitedV);
					subGrafos.Add(aux);
					int ari = BuscarIsla(visited,candidates,graph.GetVertexL(),visitedV);
					visited.Add(ari);
					visitedV.Add(graph.GetVertexL()[ari]);
					
					List<Edge> auxtem = new List<Edge>(temp);
					subEdge.Add(auxtem);
					temp.Clear();
					continue;
				} 
				prometedor.Add(e);
				temp.Add(e);
				if(visited.Contains(e.GetDestino().GetId())){
					visited.Add(e.GetOrigen().GetId());
					visitedV.Add(e.GetOrigen());
				}else {
					visited.Add(e.GetDestino().GetId());
					visitedV.Add(e.GetDestino());
				}
			}
			subGrafos.Add(visitedV);
			subEdge.Add(temp);
			prometedorL= new List<Edge>(prometedor);
			drawPrim();
			calculatePeso();
			
			
			
		}*/
        public List<List<Vertex>> getSubgraph(){
			return subGrafos;
		}
        
		public void drawPrim(){
			Graphics g = Graphics.FromImage(PrimBitmap);
            Color c = Color.FromArgb(125, 241, 9, 9);
            Pen p = new Pen(c,10);
            for(int i = 0 ; i < prometedorL.Count ; i++){
            	g.DrawLine(p,prometedorL[i].GetDestino().GetPoint(), prometedorL[i].GetOrigen().GetPoint());
			}
		}
		public void drawPrim(Bitmap copiaunida){
			Graphics g = Graphics.FromImage(copiaunida);
            Color c = Color.FromArgb(125, 241, 9, 9);
            Pen p = new Pen(c,10);
            for(int i = 0 ; i < prometedorL.Count ; i++){
            	g.DrawLine(p,prometedorL[i].GetDestino().GetPoint(), prometedorL[i].GetOrigen().GetPoint());
			}
		}
        
		void calculatePeso(){
			foreach(Edge e in prometedorL){
				PesoT += e.GetPeso();
			}
		}
        
        /*
		 Edge menor(List<int> prometedor, List<Edge> candidates){
			
			Edge e_min = new Edge(prometedor[0],prometedor[0], float.MaxValue);
			bool cumple;
			foreach(Edge e in candidates){
				cumple= false;
				if((prometedor.Contains(e.GetOrigen().GetId())&& !prometedor.Contains(e.GetDestino().GetId()))||(!prometedor.Contains(e.GetOrigen().GetId())&& prometedor.Contains(e.GetDestino().GetId()))){
					cumple = true;
				}
				if(cumple && e.GetPeso() <= e_min.GetPeso()){
					e_min= e;
				}
			}
			if(e_min.GetPeso() != float.MaxValue){
				candidates.Remove(e_min);
			}
			return e_min;
		}*/
		public Bitmap getBitmap(){
			return PrimBitmap;
		}
		public double getPeso(){
			return PesoT;
		}
		public List<Edge> getPrometedor(){
			return prometedorL;
		}
	       /* int BuscarIsla(List<int> visitados, List<Edge> a, List<Vertex> gr, List<Vertex> visited){
			 visited.Clear(); //POR CADA ISLA DEBEMOS DE LIMPIAR LISTA DE VERTICES VISITADOS POR CADA NUEVO SUBGRAFO
            if (visitados.Count < gr.Count)
            {
                for (int i = 1; i <= a.Count; i++)
                {
                	if (!visitados.Contains(a[i].GetDestino().GetId()))
                    {
                    	//SI VISITADOS NO CONTIENE EL IDENTIFICADOR DEL VERTICE ORIGEN DE LA ARISTA EN LA POSICION [i]
                    	return a[i].GetDestino().GetId(); /* ENTONCES ME RETORNA EL IDENTIFICADOR DEL VERTICE ORIGEN DE ESA ARISTA
                        						 *  (YA QUE EL VERTICE NO HA SIDO TOCADO)
                    }
                }
            }
            return -1;
			
		}*/
        
	}
}
