using ArbolBusBin;

ArbolBB ar = new ArbolBB();
ar.Agrega(7);
ar.Agrega(4);
ar.Agrega(10);
ar.Agrega(1);
ar.Agrega(6);
ar.Agrega(9);
ar.Agrega(12);

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
