
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
    
    Console.WriteLine("\nDesea usar el luchador numero: ");
    int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
    while(opcionSeleccionada<0 || opcionSeleccionada>3){
        Console.WriteLine("Ingrese una opcion valida");
        
        Console.WriteLine("Desea usar el luchador numero: ");
        opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
    
    }

    Personaje pjSeleccionado = new Personaje();
    pjSeleccionado = ListaDeCombatientes[opcionSeleccionada-1];
    ListaDeCombatientes.RemoveAt(opcionSeleccionada-1); //se elimina el personaje de la lista para no pelear con el mismo

    Personaje copiaPersonajeSeleccionado = new Personaje();
    copiaPersonajeSeleccionado = pjSeleccionado;

    int cantidadCombates =0;
    while(cantidadCombates < ListaDeCombatientes.Count()){
        Console.WriteLine("----------RONDA {0}--------", cantidadCombates+1);
        Console.WriteLine("----COMIENZA EL COMBATE----");
        combate(pjSeleccionado, ListaDeCombatientes[cantidadCombates]);
        if(pjSeleccionado.Salud > 0){
            cantidadCombates++;
        }else{
            cantidadCombates = ListaDeCombatientes.Count() + 1;
        }
    }


    Console.WriteLine("Desea guardar su historial de combates? (s/n): ");
    string respuesta = Console.ReadLine();
    if(respuesta == "s"){
        HelperArchivos.guardarHistorial(pjSeleccionado, )
        
    }else{
        Console.WriteLine("No se guardo el historial");
    }
}

 
void combate(Personaje pj1, Personaje pj2){
    int turnos = 0;
    //defino aqui las variables para no redefinirla en el while
    double poderDeDisparos; 
    double efectividadDeDisparo;
    double valorDeAtaque;
    double poderDeDefenza;
    double dañoProvocado;
    double maximoDañoProvocable = 50000;
    
    Random rand = new Random();
        
    while(turnos < 3){
        Console.WriteLine("Turno: " + (turnos+1));

        if(pj1.Salud > 0){ //Controla que el personaje este vivo para poder atacar
            
            Console.WriteLine("---ATACAS---");
            poderDeDisparos = (pj1.Destreza * pj1.Fuerza * pj1.Nivel); 
            efectividadDeDisparo = rand.Next(1, 101);
            valorDeAtaque = (poderDeDisparos * efectividadDeDisparo); //quite el /100 para evitar numero negativos
            poderDeDefenza = (pj2.Armadura * pj2.Velocidad);
            dañoProvocado = (((valorDeAtaque * efectividadDeDisparo) - poderDeDefenza) / maximoDañoProvocable) * 100;
            
            Console.WriteLine(pj1.Nombre + " realiza su ataque");
            if(dañoProvocado > 120.0){
                Console.WriteLine("Pero FALLA en el intento");
            }else{
                pj2.Salud = pj2.Salud - dañoProvocado;
                Console.WriteLine("Daño provocado :" + dañoProvocado);
                Console.WriteLine("Salud de {0} : {1}", pj2.Nombre, pj2.Salud);
            }
        }
        
        Console.ReadKey();
        
        if(pj2.Salud > 0){

            Console.WriteLine("---DEFIENDES---");
            poderDeDisparos = (pj2.Destreza * pj2.Fuerza * pj2.Nivel);
            efectividadDeDisparo = rand.Next(1, 101);
            valorDeAtaque = (poderDeDisparos * efectividadDeDisparo);
            poderDeDefenza = (pj1.Armadura * pj1.Destreza);
            dañoProvocado = (((valorDeAtaque * efectividadDeDisparo) - poderDeDefenza) / maximoDañoProvocable) * 100;
            
            Console.WriteLine(pj2.Nombre + " realiza su ataque");
            if(dañoProvocado > 200.0){
                Console.WriteLine("Pero FALLA en el intento");
            }else{
                pj1.Salud = pj1.Salud - dañoProvocado;
                Console.WriteLine("Daño provocado :" + dañoProvocado);
                Console.WriteLine("Salud de {0} : {1}", pj1.Nombre, pj1.Salud);
            }
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
        Console.WriteLine("\nFin de este encuentro");
        Console.WriteLine("Ambos combatientes quedaron con vida");
        Console.WriteLine("Veamos quien recibivio menos daño");
        Console.WriteLine("Y el ganador del combate es.......");

        if(pj1.Salud > pj2.Salud){
            Console.WriteLine(pj1.Nombre);
            Console.WriteLine("FELICIDADES, pasas a la siguiente ronda");
        }else{
            Console.WriteLine(pj2.Nombre);
            pj1.Salud = 0;
            Console.WriteLine("GAME OVER");    
        }
    }
    return;
}





