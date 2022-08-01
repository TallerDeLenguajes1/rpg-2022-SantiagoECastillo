public class Personaje{
    private String tipo;
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
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }

    private string[] Nombres = {"Artoria", "Emiya", "Gilgamesh", "Medusa", "Angra", "Astolof", "Cú", "Gilles", "Jack", "Alejandro", "Spartacus"};

    //string[] Apodos = {""}
    
    private string[] Tipos = {"Saber", "Archer", "Lacer", "Caster", "Assasin", "Berserk", "Rider"};

    //El constructor vacio es el que genera toda la informacion del personaje
    public Personaje(){
        Random rand = new Random();
        tipo = Tipos[rand.Next(0, Tipos.Count())];
        Nombre =  Nombres[rand.Next(0, Nombres.Count())];
        Apodo = "";
        edad = rand.Next(20,301);
        Salud = 100;
        Velocidad = rand.Next(1, 11);
        Destreza = rand.Next(1, 6);
        Fuerza = rand.Next(1, 11);
        Armadura = rand.Next(1, 11);
        Nivel = rand.Next(1,11);
    }

    public void setPersonaje(String nombre, String apodo){
        this.Nombre = nombre;
        this.Apodo = apodo;
    }

    public void obtenerInformacionPersonaje(){
        Console.WriteLine("--------INFORMACION-------");
        Console.WriteLine("Tipo: " + tipo);
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Apodo: " + Apodo);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Salud: " + Salud);
        Console.WriteLine("Nivel: " + Nivel);
        Console.WriteLine("Fuerza: " + Fuerza);
        Console.WriteLine("Velocidad: " + Velocidad);
        Console.WriteLine("Destreza: " + Destreza);
        Console.WriteLine("Armadura: " + Armadura);
    }


    public object copia(){
        return MemberwiseClone();
    }
}
