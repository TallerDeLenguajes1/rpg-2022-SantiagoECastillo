public class Personaje{
    private String nombre;
    private String apodo;
    private DateTime fechaNacimiento;
    private int edad;
    private double salud;
    private double velocidad;
    private double destreza;
    private double fuerza;
    private int nivel;
    private double armadura;

    public double Salud { get => salud; set => salud = value; }
    public double Velocidad { get => velocidad; set => velocidad = value; }
    public double Destreza { get => destreza; set => destreza = value; }
    public double Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public double Armadura { get => armadura; set => armadura = value; }

    public Personaje(){
        nombre = "";//para evitar la advertencia a null
        apodo = "";
        Random rand = new Random();
        edad = rand.Next(20,301);
        Salud = 100;
        Velocidad = rand.Next(1, 11);
        Destreza = rand.Next(1, 6);
        Fuerza = rand.Next(1, 11);
        Armadura = rand.Next(1, 11);
        Nivel = rand.Next(1,11);
    }

    public void setPersonaje(String nombre, String apodo){
        this.nombre = nombre;
        this.apodo = apodo;
    }

    public void getInformacionPersonaje(){
        Console.WriteLine("--------INFORMACION-------");
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Apodo: " + apodo);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Salud: " + Salud);
        Console.WriteLine("Nivel: " + Nivel);
        Console.WriteLine("Fuerza: " + Fuerza);
        Console.WriteLine("Velocidad: " + Velocidad);
        Console.WriteLine("Destreza: " + Destreza);
        Console.WriteLine("Armadura: " + Armadura);
    }
}