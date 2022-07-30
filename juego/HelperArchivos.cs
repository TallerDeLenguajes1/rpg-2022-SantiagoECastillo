using System;
using System.Collections.Generic;
using System.IO;

public class HelperArchivos{
    public static void guardarHistorial(Personaje pjSelecciando, int cantidadDeBatallas){
        
        string rutaDeHistorial = @"C:\Users\santiago\Desktop\Facultad\Taller_de_lenguaje_1\JuegoDeRol\rpg-2022-SantiagoECastillo\juego\Historial.csv";

        if(!File.Exists(rutaDeHistorial)){
            File.Create("Historial.csv");
        }else{
            
            using(StreamWriter SW = new StreamWriter(rutaDeHistorial, true)){
                string historiaDeCombates = pjSelecciando.Nombre + pjSelecciando.Salud + Convert.ToString(cantidadDeBatallas) + DateTime.Now.ToShortDateString();
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

                    Console.WriteLine(informacion[0] + " - " + informacion[1] + " - " + informacion[2] + " -  {0}", informacion[3]);
                    Console.WriteLine("-----------------------------------");
                } 
                SR.Close();
            }
        }
    }  

}