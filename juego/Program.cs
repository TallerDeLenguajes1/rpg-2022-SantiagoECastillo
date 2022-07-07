
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

    Console.WriteLine("--Escoja su Personaje--");
    Personaje pj1 = new Personaje();
    Personaje pj2 = new Personaje();
    
    pj1.getInformacionPersonaje();
    pj2.getInformacionPersonaje();

    Console.WriteLine("Presine enter para comenzar el juego");
    Console.ReadKey();
    //combate(pj1, pj2);

}

// REVISAR, NO FUNCIONA
void combate(Personaje pj1, Personaje pj2){
    Random rand = new Random();
    int turnos = 0;
    double maximoDañoProvocable = 50000;
    Console.WriteLine("----COMIENZA EL COMBATE----");
    
    /*PRUEBA
        Console.WriteLine("--ATACA PJ1--");
        double poderDeDisparos = (pj1.Destreza * pj1.Fuerza * pj1.Nivel); //
        Console.WriteLine("PDD: " + poderDeDisparos);

        double efectividadDeDisparo = rand.Next(1, 101);
        Console.WriteLine("EDD: " + efectividadDeDisparo);

        double valorDeAtaque = (poderDeDisparos * efectividadDeDisparo) / 100; 
        Console.WriteLine("VA: " + valorDeAtaque);
        
        double poderDeDefenza = (pj2.Armadura * pj2.Velocidad);
        Console.WriteLine("PD: " + poderDeDefenza);
        
        double dañoProvocado = ((valorDeAtaque  - poderDeDefenza) / maximoDañoProvocable) * 100;
        Console.WriteLine("DP: " + dañoProvocado);
        
        pj2.Salud = pj2.Salud - dañoProvocado;
        Console.WriteLine("SALUD: " + pj2.Salud);

    */
    
    while(turnos != 3){
        Console.WriteLine("Turno: " + (turnos+1));

        Console.WriteLine("--ATACA PJ1--");
        double poderDeDisparos = (pj1.Destreza * pj1.Fuerza * pj1.Nivel); 
        double efectividadDeDisparo = rand.Next(1, 101);
        double valorDeAtaque = (poderDeDisparos * efectividadDeDisparo) / 100; //agregue aqui el /100
        double poderDeDefenza = (pj2.Armadura * pj2.Velocidad);
        double dañoProvocado = (((valorDeAtaque * efectividadDeDisparo) - poderDeDefenza) / maximoDañoProvocable) * 100;
        pj2.Salud = pj2.Salud - dañoProvocado;

        Console.WriteLine("Daño provocado :" + dañoProvocado);
        Console.WriteLine("Salud de pj2 :" + pj2.Salud);

        Console.WriteLine("--ATACA PJ2--");
        poderDeDisparos = (pj2.Destreza * pj2.Fuerza * pj2.Nivel);
        efectividadDeDisparo = rand.Next(1, 101);
        valorDeAtaque = (poderDeDisparos * efectividadDeDisparo) / 100;
        poderDeDefenza = (pj1.Armadura * pj1.Destreza);
        dañoProvocado = (((valorDeAtaque * efectividadDeDisparo) - poderDeDefenza) / maximoDañoProvocable) * 100;
        pj1.Salud = pj1.Salud - dañoProvocado;

        Console.WriteLine("Daño provocado :" + dañoProvocado);
        Console.WriteLine("Salud de pj1 :" + pj1.Salud);
        turnos++;
        Console.ReadKey();
    }

    if(pj1.Salud > pj2.Salud || pj2.Salud == 0){
        Console.WriteLine("GANADOR: PJ1");
    }else{
        Console.WriteLine("GANADOR: PJ2");
    }
    return;
}