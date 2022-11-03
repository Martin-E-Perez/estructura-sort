using System;
using System.Collections.Generic;

namespace OrdenarSort
{
	public class Class1
	{
		//public Class1()
		//{
		//}
		
		public List<int> NumRand(int a)
		{
			Random rdn = new Random();
			List<int> listaNum = new List<int>();
			
			for (int i = 0; i < a; i++) {
				int aleatorio = rdn.Next(0,100);
				listaNum.Add(aleatorio);
			}
			
			return listaNum;
		}
		
		
	}
	
	
	
	
	
	
}
