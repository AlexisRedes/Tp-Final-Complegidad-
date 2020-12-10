
using System;
using System.Collections;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		
		
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			ArrayList list = new ArrayList();
			list = preordenCaminoIA(list, arbol);
			int distancia = list.Count-1;
			string dist = distancia.ToString();
			
			return "La distancia desde la raiz hasta el nodo mas cercano a la IA es: "+dist;
		}


		public String Consulta2( ArbolGeneral<Planeta> arbol)
        {
            Cola<ArbolGeneral<Planeta>> q = new Cola<ArbolGeneral<Planeta>>();
            q.encolar(arbol);
            int nivel = 0;
            String mensaje = "";
            while (!q.esVacia()){
            	int elementos = q.cantElementos();
                nivel++;
                int cantidadPorNivel = 0;
                while (elementos-- > 0){
                    ArbolGeneral<Planeta> nodoActual = q.desencolar();

                    if (nodoActual.getDatoRaiz().Poblacion() > 10){
                        cantidadPorNivel++;
                    }
                    foreach(ArbolGeneral<Planeta> hijo in nodoActual.getHijos()){
                        q.encolar(hijo);
                    }
                }
                mensaje += "Nivel " + nivel + ": "+cantidadPorNivel+"\n";
            }
            return mensaje;
        }


		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> q = new Cola<ArbolGeneral<Planeta>>();
            q.encolar(arbol);
            int nivel = 0;
            String mensaje = "";
            while (!q.esVacia()){
            	int elementos = q.cantElementos();
                nivel++;
                int cantidad =0;
                int total = 0;
                while (elementos-- > 0){
                    ArbolGeneral<Planeta> nodoActual = q.desencolar();
                   	total = total + nodoActual.getDatoRaiz().Poblacion();
                   	cantidad++;
                    foreach(ArbolGeneral<Planeta> hijo in nodoActual.getHijos()){
                        q.encolar(hijo);
                    }
                }
                double promedio = total/cantidad;
                mensaje +="\n"+"\n"+"\n"+ "Nivel " + nivel + ": "+promedio+"\n";
            }
            return mensaje;
		}
		
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			if(!arbol.getDatoRaiz().EsPlanetaDeLaIA()){
				ArrayList lista= new ArrayList();
				lista = preordenCaminoIA(lista, arbol);
				Planeta origen= (Planeta)lista[lista.Count-1];
				Planeta destino= (Planeta)lista[lista.Count-2];
				return new Movimiento(origen, destino);
			}
			else{
				ArrayList lista= new ArrayList();
				lista = preordenCaminoJugador(lista, arbol);
				int a=0, b=1;
				Planeta origen = (Planeta)lista[a];
				Planeta destino = (Planeta)lista[b]; 
				for (int i = 0; i < lista.Count; i++) {
						Planeta elegido = (Planeta)lista[i];
						Planeta elegidoMasUno = (Planeta)lista[i+1];
						if (elegido.EsPlanetaDeLaIA() && !elegidoMasUno.EsPlanetaDeLaIA()) {
							return new Movimiento(elegido, elegidoMasUno);
						}
					
				}
				
				return new Movimiento(origen, destino);
			}
		}
			
		public ArrayList preordenCaminoIA(ArrayList lista, ArbolGeneral<Planeta> arbol) {
			Planeta planeta= arbol.getDatoRaiz();
			lista.Add(planeta);
			if(planeta.EsPlanetaDeLaIA()){
				return lista;
			}
			else{
				foreach(ArbolGeneral<Planeta> i in arbol.getHijos()){
				 	ArrayList lista2 = preordenCaminoIA(lista,i);
				 	if(lista2!=null)
				 		return lista2;
						lista.RemoveAt(lista.Count-1);
			}
		}
			
		return null;	
	}
			public ArrayList preordenCaminoJugador(ArrayList lista, ArbolGeneral<Planeta> arbol) {
			Planeta planeta= arbol.getDatoRaiz();
			lista.Add(planeta);
			if(planeta.EsPlanetaDelJugador()){
				return lista;
			}
			else{
				foreach(ArbolGeneral<Planeta> i in arbol.getHijos()){
				 	ArrayList lista2 = preordenCaminoJugador(lista,i);
				 	if(lista2!=null)
				 		return lista2;
						lista.RemoveAt(lista.Count-1);
			}
		}
			
		return null;	
	}
		
			
		}
	}

