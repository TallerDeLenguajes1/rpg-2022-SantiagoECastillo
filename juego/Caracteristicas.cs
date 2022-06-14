public class Caracteristicas{
    double velocidad;
    double destreza;
    double fuerza;
    int nivel;
    double armadura;

    public Caracteristicas(){
        Random valores = new Random();

        velocidad = valores.Next(1, 11);
        destreza = valores.Next(1,6);
        fuerza = valores.Next(1, 11);
        nivel = valores.Next(1, 11);
        armadura = valores.Next(1, 11);
    }

    public void getAtributos(){
        Console.WriteLine("Velocidad: " + velocidad);
        Console.WriteLine("Destreza: " + velocidad);
        Console.WriteLine("Fuerza: " + velocidad);
        Console.WriteLine("Nivel: " + velocidad);
        Console.WriteLine("Armadura: " + velocidad);

    }
}