using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Circulos3
{
    class Kruskal
    {
        Bitmap KruskalBmp;
        double pesoT;
        List<Edge> prometedorL = new List<Edge>();
        List<List<Vertex>> subGraph = new List<List<Vertex>>();
        Kruskal()
        {

        }
        public Kruskal(List<Edge> EdgeL, Grafo gra, Bitmap bmp)
        {
            KruskalBmp = new Bitmap(bmp); // asigno el bitmap al bitmap de kruskal
            prometedorL.Clear();// se limpian las listas por si se ha generaro antes la generacion de Kruskal
            subGraph.Clear(); // de igual forma
            List<List<Vertex>> componenteConexa = new List<List<Vertex>>(); //lista de componentes conexas
            List<Edge> candidatas = new List<Edge>(EdgeL); // candidatas sera igual a la edge list que le pase puesto a que todas son candidatas
            // ordeno mi Edge List
            candidatas.Sort((x, y) => x.GetPeso().CompareTo(y.GetPeso())); // sort ordena una lista, la funcion compare, regresa un valor si es menor mayo o igual
            // creo cada vertice del grafo como una componente conexa
            foreach (Vertex v in gra.GetVertexL())
            {
                List<Vertex> aux = new List<Vertex>(); // creo una lista auxiliar
                aux.Add(v);                             // guardo en la posicion primera el vertice del grafo 
                componenteConexa.Add(aux); // una vez guiardado, se agrega la lista con el verice solo como un componente conexo
            }
            // iterare por todas mis canditas
            int indexCandidatas = 0; // para saber en que index o que candidata es la que se esta analizando
            int cc_1, cc_2; // el componente origen y destino de la arista analizada
            while (indexCandidatas < candidatas.Count)// si el  indice de las candidata es mayr es por que ya se hn revisado todas
            {
                Edge e = new Edge();
                e = candidatas[indexCandidatas];// primer candidata (arista a analizar) 
                cc_1 = BuscaCCde(e.GetDestino(),componenteConexa); // se busca en que componente conexa se encuentrra su origen 
                cc_2 = BuscaCCde(e.GetOrigen(),componenteConexa); // se busca en que componente conexa se encuentra su destino 
                if (cc_1 != cc_2) // si el origen y el destino se encuentra en el mismo componente conexo no se agrega la arista a prometedor
                {
                    prometedorL.Add(e);// si el origen y el destino se encuentra en distintos componentes se agrega a prometedor
                    componenteConexa[cc_1].AddRange(componenteConexa[cc_2]); // al componente del origen se le agregara el componente del destino
                    componenteConexa.RemoveAt(cc_2); // se remueve el componente destino puesto que ya se encuentra dentro de otro
                }
                indexCandidatas++; // se aumenta el contador para seguir con otra arista
            }
            subGraph = componenteConexa;//la lista de componentes, equivale a todos los arboles
            DrawKrusKal(); // para finalizar dibujo todas las aristas 
        }
        public int BuscaCCde(Vertex vB, List<List<Vertex>> componenteConexa)
        {
            int indexOfCc=0;
            foreach (List<Vertex> vl in componenteConexa) // itero por toda la lista de componentes conexas 
            {
                foreach (Vertex v in vl) // itero por cada elemento de la componente conexa
                {
                    if (vB == v) // si el elemento que busco coincide con algun elemento de una lista de componentes conexos 
                    {
                        return indexOfCc;// guardo el indice de la lista de componentes conexas
                    }
                }
                indexOfCc++;// aumento mi indice para saber en que componente conexa me encuentro
            }
            return indexOfCc;
        }

       
        public List<List<Vertex>> getSubGrafo(){
        	return subGraph;
        }
        public double getPeso(){
        	return pesoT;
        }
        public void DrawKrusKal()
        {
            Graphics g = Graphics.FromImage(KruskalBmp);
            Color c = Color.FromArgb(125, 11, 39, 243);
            Pen p = new Pen(c,10);
            for (int i = 0 ; i < prometedorL.Count ; i++) {
                g.DrawLine(p, prometedorL[i].GetDestino().GetPoint(),prometedorL[i].GetOrigen().GetPoint());
            }
        }
         public void DrawKrusKal(Bitmap copiaunida)
        {
            Graphics g = Graphics.FromImage(copiaunida);
            Color c = Color.FromArgb(125, 11, 39, 243);
            Pen p = new Pen(c,10);
            for (int i = 0 ; i < prometedorL.Count ; i++) {
                g.DrawLine(p, prometedorL[i].GetDestino().GetPoint(),prometedorL[i].GetOrigen().GetPoint());
            }
        }
        public void calculatePeso()
        {
            foreach (Edge e in prometedorL)
            {
                pesoT += e.GetPeso();
            }
        }
        public Bitmap getBitmap()
        {
            return KruskalBmp;
        }
        public List<Edge> getPrometedor(){
        	return prometedorL;
        }
    }
}



/* public  Kruskal(List<Edge> EdgeL, Grafo grafo,Bitmap BMP)
        {
        	KruskalBmp = new Bitmap(BMP);
            pesoT = 0;
            List<Edge> candidates = new List<Edge>(EdgeL); // se le envia toda la lista de candidatas (aristas)
            List<Edge> prometedor = new List<Edge>(); // prometedor sera todas mis aristas con el menor peso
            List<List<Vertex>> CompCon = new List<List<Vertex>>();  // se crea una lista de lista de vertices la cual seran mis componentes conexas
         
            candidates.Sort((x, y) => x.GetPeso().CompareTo(y.GetPeso())); // acomodo mi lista de candidatos de menor a mayor 
            // se ordenan los candidatos (todas las aristas del grafo)
            for (int i =0; i< grafo.GetVertexL().Count; i++) // se crea un for para crear cada componente conexo
            {
                List<Vertex> Componente = new List<Vertex>();
                Componente.Add(grafo.GetVertexL()[i]);
                CompCon.Add(Componente);
            }
            int count = 0;
            int comp_1, comp_2;
            while (count < EdgeL.Count) // la accion terminara una vez que termine de revisarse las aristas
            {
                Edge e = new Edge();// creo una arista auxilia 

                e = candidates[count]; // como mi  lista de candidatas esta ordenada tomo la primer arista y aumento el contador para saber que ya tome la promera
                count++;
                comp_1 = 0;  // comp_1 guardara mi id del primer componente esto servira posteriormente
                comp_2 = 0; // de igual forma
                for (int i = 0; i < CompCon.Count; i++) // iteracion en cada componente conexo
                {
                    List<Vertex> aux = new List<Vertex>();  // se crea una lista de vertices auxiliar que almacenara mi primer componente conexa
                    aux = CompCon[i]; // se almacena 
                    for (int j = 0 ; j < CompCon[i].Count ; j++) // creo un for para recorre cada elemento del componente conexo en el que se encuentra
                    {
                    	if (e.GetDestino().GetId() == aux[j].GetId()) // si el origen, se encuentra en el componente conexo segun i
                        {
                            comp_1 = i;  // guardo el indice donde se encuentra el componente o elemento prigen
                        }
                    	if (e.GetOrigen().GetId() == aux[j].GetId()) // si el destino se encuentre en el componente conexo segun i
                        {
                            comp_2 = i; // guardo el indice donde se encuentra el componente conexo
                        }
                    }
                }
                if (comp_1 != comp_2) // si los dos indices son distintos, significa que estan en diferentes componentes o listas entonces si se puede agregar la arista a prometedor
                {                       // si los indices son iguales significa que estan en la misma componente conexa
                    prometedor.Add(e);// agrego la arista
                    CompCon[comp_1].AddRange(CompCon[comp_2]); // y uno las lista en donde se encuentran los componentes
                    CompCon.RemoveAt(comp_2); // removeAt remueve un elemento dando un indice, se dejo el componente donde encontre el origen
                }
            }
             prometedorL = prometedor;
            subGraph = CompCon;
            DrawKrusKal();
            calculatePeso(); 
        }
        */
