using ArbolBusBin;

ArbolBB ar = new ArbolBB();
ar.Agrega(6);
ar.Agrega(4);
ar.Agrega(7);
ar.Agrega(3);
ar.Agrega(5);
ar.Agrega(8);

ar.ImprimePre();
Console.WriteLine("");
Console.WriteLine("");
ar.ImprimeIn();
Console.WriteLine("");
Console.WriteLine("");
ar.ImprimePost();
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("El mayor valor del árbol es: "+ar.MayorVal());
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Cantidad de nodos hoja: " + ar.ContarHojas());
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("¿Los números son consecutivos? " + (ar.SonConsecutivos()));