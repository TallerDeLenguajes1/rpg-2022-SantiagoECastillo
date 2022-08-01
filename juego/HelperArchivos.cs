using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class HelperArchivos{
    public static void guardarHistorial(Personaje pjSelecciando, int cantidadDeBatallas){
        
        string rutaDeHistorial = @"C:\Users\santiago\Desktop\Facultad\Taller_de_lenguaje_1\JuegoDeRol\rpg-2022-SantiagoECastillo\juego\Historial.csv";

        if(!File.Exists(rutaDeHistorial)){
            File.Create("Historial.csv");
        }else{
            
            using(StreamWriter SW = new StreamWriter(rutaDeHistorial, true)){
                string historiaDeCombates = pjSelecciando.Nombre + ";" + pjSelecciando.Salud + ";" + Convert.ToString(cantidadDeBatallas) + ";" + DateTime.Now.ToShortDateString();
                SW.WriteLine(historiaDeCombates);
                SW.Close();            
            }

        }
        
    } 

    public static void mostrarHistorial(){
        string rutaDeHistorial = @"C:\Users\santiago\Desktop\Facultad\Taller_de_lenguaje_1\JuegoDeRol\rpg-2022-SantiagoECastillo\juego\Historial.csv";

        if(!File.Exists(rutaDeHistorial)){
            Console.WriteLine("No hay ningun registro en el historial");
        }else{
            Console.WriteLine("----HISTORIAL DE COMBATES-------");

            using(StreamReader SR = new StreamReader(rutaDeHistorial)){
                
                var linea = SR.ReadLine();
                
                while(linea != null){
                    var informacion = linea.Split(";");

                    Console.WriteLine(informacion[0] + " - Salud: " + informacion[1] + " - Cantidad de combates: " + informacion[2] + " -  Fecha del combate: {0}", informacion[3]);
                    Console.WriteLine("-----------------------------------");

                    linea = SR.ReadLine();
                } 
                SR.Close();
            }
        }
    }  

    
    public void guardarPersonaje(string nombreDelArchivo, Personaje personajeAGuardar){

        var listaParaGuardarJugador = new List<Personaje>();
        listaParaGuardarJugador.Add(personajeAGuardar);

        string informacionAGuardar = JsonSerializer.Serialize(listaParaGuardarJugador);


        using(var archivo = new FileStream(nombreDelArchivo, FileMode.Append)){
            
            using(var strWriter = new StreamWriter(archivo)){
                strWriter.WriteLine("{0}", informacionAGuardar);
                strWriter.Close();
            }
        }
    }

    public static List<Personaje> leerGuardados(string nombreDelArchivo){
        
        var listadoPersonajesGuardados = new List<Personaje>();

        string documento;
        
        using(var abrirArchivo = new FileStream(nombreDelArchivo, FileMode.Open)){
            
            using(var strReader = new StreamReader(abrirArchivo)){
                documento = strReader.ReadToEnd();
                abrirArchivo.Close();
            }

        }

        listadoPersonajesGuardados = JsonSerializer.Deserialize<List<Personaje>>(documento); 

        return listadoPersonajesGuardados;
    }

}


 