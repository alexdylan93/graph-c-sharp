/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 11/02/2019
 * Time: 11:20 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace etapa_1
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo
	{	
		List<Vertice> listaVertice;
		public Grafo(){
			
		}
		
		public Grafo(List<Circle> lc)
		{
			int cont = 0;
			listaVertice = new List<Vertice>();
			foreach (Circle c in lc){
				Vertice v = new Vertice(c,cont);
				listaVertice.Add(v);
				cont++;
			}
			
		}
		
		
		public List<Vertice> getListaVertice(){
			return listaVertice;
		}
		
		
		
		public void clear(){
			listaVertice.Clear();
		}
		
		public List<Arista> inicializarRecorridoAnchura(Vertice inicial){
			List<Vertice> visitado = new List<Vertice>();
			Queue<Vertice> cola = new Queue<Vertice>();
			Queue<int> colaNivel = new Queue<int>();
			bool primeraHoja = true;
			colaNivel.Enqueue(1);
			int altura = 1;
			bool terminar = false;
			
			visitado.Add(inicial);
			cola.Enqueue(inicial);
			
			List<Arista> la = recorridoProfundidad(visitado,cola,colaNivel,ref primeraHoja,ref altura,ref terminar);
			
			if(terminar)
				return null;
			return la;
		}
		
		List<Arista> recorridoProfundidad(List<Vertice> visitados, Queue<Vertice> cola, Queue<int> colaNivel,ref bool primHoja, ref int altura, ref bool terminar){
			
			bool esHoja = true;
			List<Arista> la = new List<Arista>();
			if(terminar){
				return la;
			}
			if(cola.Count != 0){
				Vertice actual = cola.Dequeue();
				int nivelActual = colaNivel.Dequeue();
				foreach(Arista a in actual.getLA()){
					if(!visitados.Exists(e => e.getEtiqueta() == a.getDestino().getEtiqueta())){
						visitados.Add(a.getDestino());
						cola.Enqueue(a.getDestino());
						colaNivel.Enqueue(nivelActual+1);
						la.Add(a);
						esHoja = false; 
					}
				}
				if(!primHoja && esHoja){
						if(nivelActual != altura){
							terminar = true;
							return la;
						}
					}
					if(esHoja && primHoja){
						altura = nivelActual; 
						primHoja = false;
					}
				la.AddRange(recorridoProfundidad(visitados,cola,colaNivel,ref primHoja,ref altura, ref terminar));
			}
			return la;
		}
	}
	
	
	
	
	public class Vertice{
		Circle c;
		int etiqueta;
		List<Arista> listaArista;
		
		public Vertice(Circle c, int e){
			this.c = c;
			this.etiqueta = e;
			listaArista = new List<Arista>();
		}
		
		
		
		public void insertaArista(Vertice v_d, List<Point> lp, double p = 1){
			Arista a = new Arista(this,v_d,lp,p);
			listaArista.Add(a);
		}
		
		
		public List<Arista> getLA(){
			return listaArista;
		}
		
		public Arista getArista(Vertice d){
			foreach(Arista a in listaArista){
				if(a.getDestino().getEtiqueta() == d.getEtiqueta())
					return a;
			}
			return null;
		}
		
		public int getEtiqueta(){
			return etiqueta;
		}
		
		public Circle getCircle(){
			return c;
		}
		
		public void clearArista(){
			listaArista.Clear();
		}
	}
	
	
	public class Arista{
		Vertice destino;
		Vertice origen;
		double pond;
		List<Point> listaPuntos;
		 
		public Arista(Vertice o, Vertice d,List<Point> lp, double pond){
			origen = o;
			this.pond = pond;
			destino = d;
			
			listaPuntos = new List<Point>();
			
			foreach(Point po in lp){
				Point pn = new Point(po.X,po.Y);
				listaPuntos.Add(pn);
			}
		}
		
		public List<Point> getListPoint(){
			return listaPuntos;
		}
		
		public Vertice getDestino(){
			return destino;
		}
		
		public Vertice getOrigen(){
			return origen;
		}
		
		public double getPond(){
			return pond;
		}
		
		
	}
}
