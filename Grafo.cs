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
		
		public Grafo(List<Point> lp)
		{
			int cont = 0;
			listaVertice = new List<Vertice>();
			foreach (Point p in lp){
				Vertice v = new Vertice(c,cont);
				listaVertice.Add(v);
				cont++;
			}
			
		}
		
		
		public List<Vertice> getListaVertice(){
			return listaVertice;
		}
		
	}
	
	
	
	
	public class Vertice{
		Point p;
		int etiqueta;
		List<Arista> listaArista;
		
		public Vertice(Point p, int e){
			this.p = p;
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
