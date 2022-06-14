String nombre, apodo;

Console.Write("Ingrese el nombre de su pj: ");
nombre = Console.ReadLine();
Console.Write("Ingrese el apodo de pj: ");
apodo = Console.ReadLine();

Personaje pj = new Personaje();
pj.setPersonaje2(nombre, apodo, 80);
pj.getInformacionPersonaje();
