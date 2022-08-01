public class combate{
 
    //Creacion de los personajes a combatir
    public static List<Personaje> generarCombatientes(){
        List<Personaje> ListaDeCombatientes = new List<Personaje>();

        for(int i=0; i<11; i++){ //son 11 personaje para quedar 10 en lista para las 10 batallas
            Personaje pj = new Personaje();
            ListaDeCombatientes.Add(pj);
        }   

        return ListaDeCombatientes; 
    }

    //Funcion para la seleccion de personaje
    public static Personaje seleccionDePersonaje(List<Personaje> ListaDeCombatientes){
        
        for(int i=0; i<3; i++){
            ListaDeCombatientes[i].obtenerInformacionPersonaje();
        }

        
        Console.WriteLine("\nDesea usar el luchador numero: ");
        int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
        while(opcionSeleccionada<1 || opcionSeleccionada>3){
            Console.WriteLine("Ingrese una opcion valida");
            
            Console.WriteLine("Desea usar el luchador numero: ");
            opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
        
        }

        Personaje pjSeleccionado = new Personaje();
        pjSeleccionado = ListaDeCombatientes[opcionSeleccionada-1];
        ListaDeCombatientes.RemoveAt(opcionSeleccionada-1); //se elimina el personaje de la lista para no pelear con el mismo

        return pjSeleccionado;
    }

    public static void comenzarCombate(List<Personaje> ListaDeCombatientes, Personaje pjSeleccionado){

        //Se realiza la copia del personaje inicial para su guardado
        Personaje copiaPersonaje = (Personaje)pjSeleccionado.copia();

        int cantidadCombates = 0;
        while(cantidadCombates < ListaDeCombatientes.Count()){
            Console.WriteLine("\n----------RONDA {0}--------", cantidadCombates+1);
            Console.WriteLine("------{0} {1} VS {2} {3}------", pjSeleccionado.Nombre, pjSeleccionado.Apodo, ListaDeCombatientes[cantidadCombates].Nombre, pjSeleccionado.Apodo, ListaDeCombatientes[cantidadCombates].Apodo );
            Console.WriteLine("----COMIENZA EL COMBATE----");
            
            int turno = 0;
            
            while(turno < 3){
                
                Console.WriteLine("---ATACAS---");
                Acombatir(pjSeleccionado, ListaDeCombatientes[cantidadCombates]);
                
                Console.ReadKey();

                Console.WriteLine("---DEFIENDES---");
                Acombatir(ListaDeCombatientes[cantidadCombates], pjSeleccionado);
 
                if(pjSeleccionado.Salud > 0 && ListaDeCombatientes[cantidadCombates].Salud > 0){
                    turno++;    
                }else{
                    turno = 3;
                }
                
            }

            //Control para la siguiente ronda
            if(Resultado(pjSeleccionado, ListaDeCombatientes[cantidadCombates])){
                cantidadCombates++;
            }else{
                //Si el personaje murio, se procede a preguntar si quiere guardar el historial
                guardarHistorial(pjSeleccionado, cantidadCombates);
                guardadoPersonaje(copiaPersonaje);
                cantidadCombates = ListaDeCombatientes.Count();
            }
        }

        //En caso de ganar todos los combates
        if(pjSeleccionado.Salud > 0){
            guardarHistorial(pjSeleccionado, cantidadCombates);
            guardadoPersonaje(copiaPersonaje);
        }
    }

    public static bool Resultado(Personaje pjSeleccionado, Personaje enemigo){
        if(pjSeleccionado.Salud > 0 && enemigo.Salud > 0){
            Console.WriteLine("Al parecer ambos combatientes estan con vida");
            Console.WriteLine("Aquel que recibio menos daño pasara a la siguiete ronda");
            Console.WriteLine("Analizando el resultado el ganador es....");
            Console.ReadKey();
            if(pjSeleccionado.Salud > enemigo.Salud){            
                Console.Write(pjSeleccionado.Nombre + " ....Felicidades pasaste a la siguiente ronda");
                Console.ReadKey();
                return true;
            }else{
                Console.WriteLine(enemigo.Nombre);
                Console.WriteLine("Has perdido");
                Console.ReadKey();
                return false;
            }
        
        }else{
            if(pjSeleccionado.Salud > 0){
                Console.WriteLine(enemigo.Nombre + " " + enemigo.Apodo + " A muerto a manos de " + pjSeleccionado.Nombre + " " + pjSeleccionado.Apodo);    
                Console.WriteLine("Felicidades, pasas a la siguiente ronda");
                Console.ReadKey();
                return true;
            }else{
                Console.WriteLine(pjSeleccionado.Nombre + " " + pjSeleccionado.Apodo + " A muerto a manos de " + enemigo.Nombre + " " + enemigo.Apodo);
                Console.WriteLine("Has muerto, fin del juego");
                Console.ReadKey();
                return false;
            }
        }

    }

    public static void Acombatir(Personaje pjAtacante, Personaje pjDefenzor){
        Random rand = new Random();
        
        if(pjAtacante.Salud > 0){
            double maximoDañoProvocable = 1000000;
            
            double poderDeDisparos = (pjAtacante.Fuerza * pjAtacante.Destreza * pjAtacante.Nivel); 
            
            double efectividadDeDisparo = rand.Next(1, 101);
            
            double valorDeAtaque = (poderDeDisparos * efectividadDeDisparo);
            
            double poderDeDefenza = (pjDefenzor.Armadura * pjDefenzor.Velocidad);
            
            double dañoProvocado = (((valorDeAtaque * efectividadDeDisparo) - poderDeDefenza) / maximoDañoProvocable) * 100;
            
            Console.WriteLine(pjAtacante.Nombre + " Realiza su ataque");
            pjDefenzor.Salud = pjDefenzor.Salud - dañoProvocado;
            Console.WriteLine("Daño provocado: " + dañoProvocado);
            Console.WriteLine("Salud de {0} : {1}", pjDefenzor.Nombre, pjDefenzor.Salud);
        }    
    }

    public static void guardarHistorial(Personaje pjSeleccionado, int cantidadDeCombates){
        
        Console.WriteLine("Desea guardar su historial de combates? (s/n): ");
        string respuesta = Console.ReadLine();
        
        if(respuesta == "s"){
            guardarHistorial(pjSeleccionado, cantidadDeCombates);
            Console.WriteLine("Se guardo en el  historial");
        }else{
            Console.WriteLine("No se guardo el historial");
        }       
    }

    public static void guardadoPersonaje(Personaje personajeAGuardar){
        string archivoJson = "PersonajesGuardados.json";
        var manejadoArchivo = new HelperArchivos();
        
        //NO ME FUNCIONA
        //List<Personaje> listaDePersonajesGuardados2 = new List<Personaje>();
        //listaDePersonajesGuardados2 = manejadoArchivo.leerGuardados(archivoJson);
        
        //Se controla que el personaje usado no sea una que ya esta guardado, si no lo esta se pregunta si se lo quiere guardar
        //if(!(listaDePersonajesGuardados2.Contains(personajeAGuardar))){
            Console.WriteLine("Desea guardar su personaje? (s/n): ");
            string? respuesta = Console.ReadLine(); 
            
            if(respuesta == "s"){
                manejadoArchivo.guardarPersonaje(archivoJson, personajeAGuardar);
                Console.WriteLine("Se guardo en el  Personaje");
            }else{
                Console.WriteLine("No se guardo el Personaje");
            }
        //}
    }
    

    public static Personaje seleccionPersonajeGuardado(){
        string archivoJson = "PersonajesGuardados.json";
        var manejadoArchivo = new HelperArchivos();
        var listaDePersonajesGuardados = new List<Personaje>();
        Personaje pjSeleccionado = new Personaje();

        listaDePersonajesGuardados = manejadoArchivo.leerGuardados(archivoJson);

        for(int i=0; i<listaDePersonajesGuardados.Count(); i++){
            Console.WriteLine("--Personaje N{0}--", i+1);
            listaDePersonajesGuardados[i].obtenerInformacionPersonaje();
        }

        Console.WriteLine("\nPersonaje a usar: ");
        int opcion = Convert.ToInt32(Console.ReadLine());
        pjSeleccionado = listaDePersonajesGuardados[opcion-1];

        return pjSeleccionado;
    }
}