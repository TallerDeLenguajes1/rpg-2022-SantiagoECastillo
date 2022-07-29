
string salir = "n";
int opcion;

do{
    Console.WriteLine("---- MENU ----");
    Console.WriteLine("1- JUGAR");
    Console.WriteLine("2- SALIR");
    Console.WriteLine("Elija una opcion: ");
    opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            juego();
            break;
        case 2:
            Console.WriteLine("Seguro que desea salir ? (s/n)");
            salir = Console.ReadLine();
            break;        
        default:
            Console.WriteLine("Opicion no valida");
            break;
    }
}while(salir != "s");
Console.WriteLine("Usted salio del juego");



void juego(){
    /*
    List<Personaje> ListaDeCombatientes = new List<Personaje>();
    
    Console.WriteLine("----SELECCION DE PERSONAJE----");
    //se crean los 10 personajes para la batalla
    for(int i=0; i<11; i++){ //son 11 personaje para quedar 10 en lista para las 10 batallas
        Personaje pj = new Personaje();
        
        //Se muestran los 3 primeros personajes para elegir
        if(i<3){
            Console.WriteLine("\n--Luchador {0}--", i+1);
            pj.obtenerInformacionPersonaje();
        }
        
        ListaDeCombatientes.Add(pj);
    }    
    
    Console.WriteLine("Desea usar el luchador numero: ");
    int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
    while(opcionSeleccionada<0 || opcionSeleccionada>3){
        Console.WriteLine("Ingrese una opcion valida");
        
        Console.WriteLine("Desea usar el luchador numero: ");
        opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
    
    }

    Personaje pjSeleccionado = new Personaje();
    pjSeleccionado = ListaDeCombatientes[opcionSeleccionada-1];
    ListaDeCombatientes.RemoveAt(opcionSeleccionada-1); //se elimina el personaje de la lista para no pelear con el mismo
    */
    Personaje pj1 = new Personaje();
    Personaje pj2 = new Personaje();
    
    combate(pj1, pj2); 

    Console.WriteLine("\n\nSalud resultadonte " + pj1.Salud);

}

// REVISAR, NO FUNCIONA
void combate(Personaje pj1, Personaje pj2){
    int turnos = 0;
    //defino aqui las variables para no redefinirla en el while
    double poderDeDisparos; 
    double efectividadDeDisparo;
    double valorDeAtaque;
    double poderDeDefenza;
    double dañoProvocado;
    double maximoDañoProvocable = 50000;
    
    Console.WriteLine("----COMIENZA EL COMBATE----");
    Random rand = new Random();
    /*//PRUEBA
        Console.WriteLine("--ATACA PJ1--");
        double poderDeDisparos = (pj1.Destreza * pj1.Fuerza * pj1.Nivel); //
        Console.WriteLine("PDD: " + poderDeDisparos);

        double efectividadDeDisparo = rand.Next(1, 101);
        Console.WriteLine("EDD: " + efectividadDeDisparo);

        double valorDeAtaque = (poderDeDisparos * efectividadDeDisparo); 
        Console.WriteLine("VA: " + valorDeAtaque);
        
        double poderDeDefenza = (pj2.Armadura * pj2.Velocidad);
        Console.WriteLine("PD: " + poderDeDefenza);
        
        double dañoProvocado = (((valorDeAtaque * efectividadDeDisparo) - poderDeDefenza) / maximoDañoProvocable) * 100;
        Console.WriteLine("DP: " + dañoProvocado);
        
        pj2.Salud =(int)(pj2.Salud - dañoProvocado);
        Console.WriteLine("SALUD: " + pj2.Salud);

    */

        
    while(turnos < 3){
        Console.WriteLine("Turno: " + (turnos+1));

        if(pj1.Salud > 0){ //Controla que el personaje este vivo para poder atacar
            
            Console.WriteLine("--ATACA PJ1--");
            poderDeDisparos = (pj1.Destreza * pj1.Fuerza * pj1.Nivel); 
            efectividadDeDisparo = rand.Next(1, 101);
            valorDeAtaque = (poderDeDisparos * efectividadDeDisparo); //quite el /100 para evitar numero negativos
            poderDeDefenza = (pj2.Armadura * pj2.Velocidad);
            dañoProvocado = (((valorDeAtaque * efectividadDeDisparo) - poderDeDefenza) / maximoDañoProvocable) * 100;
            pj2.Salud = pj2.Salud - dañoProvocado;

            Console.WriteLine("Daño provocado :" + dañoProvocado);
            Console.WriteLine("Salud de pj2 :" + pj2.Salud);

        }

        if(pj2.Salud > 0){

            Console.WriteLine("--ATACA PJ2--");
            poderDeDisparos = (pj2.Destreza * pj2.Fuerza * pj2.Nivel);
            efectividadDeDisparo = rand.Next(1, 101);
            valorDeAtaque = (poderDeDisparos * efectividadDeDisparo);
            poderDeDefenza = (pj1.Armadura * pj1.Destreza);
            dañoProvocado = (((valorDeAtaque * efectividadDeDisparo) - poderDeDefenza) / maximoDañoProvocable) * 100;
            pj1.Salud = pj1.Salud - dañoProvocado;

            Console.WriteLine("Daño provocado :" + dañoProvocado);
            Console.WriteLine("Salud de pj1 :" + pj1.Salud);
        }

        //Control de salud de personajes
        if(pj1.Salud > 0 && pj2.Salud > 0){
            turnos++;
            Console.ReadKey();        
        }else{
            if(pj1.Salud < 0){
                Console.WriteLine(pj1.Nombre + " Murio a manos de " + pj2.Nombre);
                Console.WriteLine("GAME OVER");    
                turnos = 3;
            }else{
                Console.WriteLine(pj2.Nombre + " Murio a manos de " + pj1.Nombre);
                Console.WriteLine("FELICIDADES, pasas a la siguiente ronda");
                turnos = 3;
            }
        }

    }
    
    //CASO AMBOS VIVOS
    if(pj1.Salud > 0 && pj2.Salud > 0){
        Console.WriteLine("Ambos combatientes quedaron con vida");
        Console.WriteLine("Veamos quien recibivio menos daño");
        Console.WriteLine("Y el ganador del combate es.......");

        if(pj1.Salud > pj2.Salud){
            Console.WriteLine(pj1.Nombre);
            Console.WriteLine("FELICIDADES, pasas a la siguiente ronda");
        }else{
            Console.WriteLine(pj2.Nombre);
            Console.WriteLine("GAME OVER");    
        }
    }
    return;
}





