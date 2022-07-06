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

    public Personaje(){
        nombre = "";//para evitar la advertencia a null
        apodo = "";
        Random rand = new Random();
        edad = rand.Next(20,301);
        salud = 100;
        velocidad = rand.Next(1, 11);
        destreza = rand.Next(1, 6);
        fuerza = rand.Next(1, 11);
        armadura = rand.Next(1, 11);
        nivel = rand.Next(1,11);
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
        Console.WriteLine("Salud: " + salud);
        Console.WriteLine("Salud: " + velocidad);
        Console.WriteLine("Salud: " + destreza);
        Console.WriteLine("Salud: " + fuerza);
        Console.WriteLine("Salud: " + armadura);


    }
}