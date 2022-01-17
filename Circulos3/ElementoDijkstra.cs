using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Circulos3
{
    public class ElementoDijkstra
    {
        Vertex destino;
        Vertex padre;
        double pesoAcumulado;
        bool definitivo;
        public ElementoDijkstra()
        {

        }
        public ElementoDijkstra(double peso, bool d, Vertex padre, Vertex destino)
        {
            this.destino = destino;
            this.padre = padre;
            this.definitivo = d;
            this.pesoAcumulado = peso;
        }
        //############Getters##################
        public Vertex getPadre()
        {
            return padre;
        }
        public Vertex getDestino()
        {
            return destino;
        }
        public double getPesoAcumulado()
        {
            return pesoAcumulado;
        }
        public bool getDefinitivo()
        {
            return definitivo;
        }

    //#################Setters ####################3
        public void setPadre(Vertex padre)
        {
            this.padre = padre;
        }
        public void setDestino(Vertex destino)
        {
            this.destino = destino;
        }
        public void setDefinitivo(bool definitivo)
        {
            this.definitivo = definitivo;
        }
        public void setPesoAcumulado(double pesoAcumulado)
        {
            this.pesoAcumulado = pesoAcumulado;
        }

        public override string ToString()
        {
            return string.Format("padre:{0}  destino:{1}  peso:{2}   ",padre, destino.GetId(),pesoAcumulado);
        }
    }
}
