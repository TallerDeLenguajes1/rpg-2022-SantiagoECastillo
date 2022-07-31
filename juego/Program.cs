
string salir = "n";
int opcion;

do{
    Console.WriteLine("---- MENU ----");
    Console.WriteLine("1- JUGAR");
    Console.WriteLine("2- Historial");
    Console.WriteLine("3- SALIR");
    Console.WriteLine("Elija una opcion: ");
    opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            juego();
            break;
        case 2:
            HelperArchivos.mostrarHistorial();
            break;
        case 3:
            Console.WriteLine("Seguro que desea salir ? (s/n)");
            salir = Console.ReadLine();
            break;        
        default:
            Console.WriteLine("Opicion no valida");
            break;
    }
}while(salir != "s");
Console.WriteLine("Usted salio del juego");


static void juego(){
    List<Personaje> ListaDeCombatientes = new List<Personaje>();

    ListaDeCombatientes = combate.generarCombatientes();

    Personaje pjSeleccionado = combate.seleccionDePersonaje(ListaDeCombatientes);

    combate.comenzarCombate(ListaDeCombatientes, pjSeleccionado);

    return;
}



