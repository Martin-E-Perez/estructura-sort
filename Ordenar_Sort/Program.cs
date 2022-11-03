using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OrdenarSort
{
	class Program
	{
		
		public static List<int> numeros = new List<int>();
		
		
		public static void Main(string[] args)
		{
			Stopwatch tiempo = new Stopwatch();
			Class1 Num = new Class1();
			List<int> NumAzar = Num.NumRand(10000);

			
			for (int i = 0; i < 5; i++) {
				
				Console.WriteLine("****************************");
				
				numeros.Clear();
				numeros.AddRange(NumAzar);
				
				tiempo.Restart();
				tiempo.Start();
						
				if (i==0) {
					Console.WriteLine("Bubble Sort");
					BubbleSort();		
				}
				if (i==1) {
					Console.WriteLine("Insertion Sort");
					InsertionSort();		
				}
				if (i==2) {
					Console.WriteLine("selection sort");
					selectionSort();
				}
				if (i==3) {
					Console.WriteLine("merge Sort");	
					mergeSort(numeros);
				}
				if (i==4) {
					Console.WriteLine("quick Sort");	
					QuickSort(0, numeros.Count - 1);
				}
				
				tiempo.Stop();
				Console.WriteLine("tiempo de demora ={0}",tiempo.Elapsed.TotalMilliseconds);
				Console.WriteLine();
			}


			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static void intercambio(int a, int b)
		{
			int temp = numeros[a];
			numeros[a] = numeros[b];
			numeros[b] = temp;
		}
		
		public static void recorrer()
		{
			foreach (var element in numeros) {
				Console.Write("{0}, ",element);
			}
			Console.WriteLine();
		}
		
		public static void BubbleSort()
		{
			int Cant = numeros.Count;
			
			for (int i = 1; i < Cant; i++) 
			{	
				
				for (int j = 0; j < Cant-i; j++)
				{
					
					if (numeros[j]>numeros[j+1])
					{
						intercambio(j,j+1);
					}

					
				}
				
			}
		}
		
		
		public static void InsertionSort()
		{
			int cant = numeros.Count;
			int dato, posAgujero;
			
			for (int i = 1; i < cant; i++) {
				
				dato = numeros[i];
				
				posAgujero = i;
				
								
				while (posAgujero>0 && numeros[posAgujero-1]>dato)
				{
					numeros[posAgujero] = numeros[posAgujero - 1];
					posAgujero = posAgujero - 1;
				}
				numeros[posAgujero] = dato;
				
			}
			
		}
		
		public static void selectionSort()
		{
			
			int cant = numeros.Count;
			int indiceMinimo;
			
			for (int i = 0; i < cant - 1; i++)
			{
				indiceMinimo = i;
							
				for (int j = i; j < cant; j++)
				{
					
					if (numeros[j]<numeros[indiceMinimo]) {
						indiceMinimo = j;
					}
				}
				
				intercambio(i, indiceMinimo);
			}
		}
		
		public static List<int> mergeSort (List<int> Lista)
		{
			
			int cant = Lista.Count;
			
			if (cant <2 ){
				return Lista;
			}
			
			int mitad = cant/2;
			
			List<int> ListIzq = new List<int>();
			List<int> ListDer = new List<int>();
			
			for (int i = 0; i < mitad; i++) {
				ListIzq.Add(Lista[i]);
			}
			
			for (int i = mitad; i < cant; i++) {
				ListDer.Add(Lista[i]);
			}
			
			
			
			List<int> tempIzq = mergeSort(ListIzq);
			List<int> tempDer = mergeSort(ListDer);
			
			List<int> listaOrdenada = merge(tempIzq, tempDer);
			
			
			return listaOrdenada;
			
		}
		
		public static List<int> merge(List<int> listaIzq, List<int> listaDer)
		{
			List<int> unida = new List<int>();
			
			int indiceIzq = 0;
			int indiceDer = 0;
			
			int cantIzq = listaIzq.Count;
			int cantDer = listaDer.Count;
			
			while (indiceDer<cantDer && indiceIzq<cantIzq) 
			{
				
				if(listaIzq[indiceIzq]<=listaDer[indiceDer])
				{
					unida.Add(listaIzq[indiceIzq]);
					indiceIzq++;
				}
				else
				{
					unida.Add(listaDer[indiceDer]);
					indiceDer++;
				}
			}
			while (indiceIzq<cantIzq) {
				
				unida.Add(listaIzq[indiceIzq]);
				indiceIzq++;
			}
			
			while (indiceDer<cantDer) {
				
				unida.Add(listaDer[indiceDer]);
				indiceDer++;
			}
			
			
			return unida;	
			
		}
		
		public static int Particion(int pInicio, int pFin)
	    {
			int pivote = 0;
			int iPivote = 0;
			int n = 0;
			
			pivote = numeros[pFin];
			
			iPivote = pInicio;
			
			for (n = pInicio; n < pFin; n++) {
				if (numeros[n] <= pivote)
			    {
					intercambio(n, iPivote);
					iPivote++;
				}
			}
			intercambio(iPivote, pFin);
			
			return iPivote;
			
		 }
		
		public static void QuickSort(int pInicio, int pFin)
	    {
			int iPivote = 0;
			
			if (pInicio >= pFin) {
				return;
			}
			
			iPivote=Particion(pInicio, pFin);
			
			QuickSort(pInicio, iPivote -1);
			QuickSort( iPivote + 1, pFin);
			
		}
		
			
		
	
		
		
			
		
		
	}
}