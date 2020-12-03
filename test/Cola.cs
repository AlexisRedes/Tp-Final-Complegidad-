﻿using System;
using System.Collections.Generic;

namespace DeepSpace
{

	public class Cola<T>
	{

		
		private List<T> datos = new List<T>();
	
		public void encolar(T elem) {
			this.datos.Add(elem);
		}
	
		public T desencolar() {
			T temp = this.datos[0];
			this.datos.RemoveAt(0);
			return temp;
		}
		
		public T tope() {
			return this.datos[0]; 
		}
		
		public bool esVacia() {
			return this.datos.Count == 0;
			}
		public int cantElementos(){
			int cantDatos=0;
			foreach (var i in datos) {
				cantDatos=+1;
			}
			return cantDatos;
		}
	}
}
