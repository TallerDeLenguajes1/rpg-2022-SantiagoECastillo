public class Personaje{
    String nombre;
    String apodo;
    private DateTime fechaNacimiento;
    private int edad;
    private double salud;
    Caracteristicas atributos = new Caracteristicas();

    public Personaje(){
        nombre = "";
        apodo = "";
        Random rand = new Random();
        edad = rand.Next(20,301);
        salud = 100;
    }

    public void setPersonaje2(String nombre, String apodo, int edad){
        this.nombre = nombre;
        this.apodo = apodo;
        this.edad = edad;
    }

    public void getInformacionPersonaje(){
        Console.WriteLine("--------INFORMACION-------");
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Apodo: " + apodo);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Salud: " + salud);
        atributos.getAtributos();
    }
}