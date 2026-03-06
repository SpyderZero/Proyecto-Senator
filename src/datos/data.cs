using System;
using System.Collections.Generic;

namespace Database

{
    public class Data
    {
        public static void Datos(string Selec, int Horario, string Nombre, Dictionary<string, List<string>> dic, List<string> Lista)
        {

            dic[Selec].Add(Nombre);
            //cambia el orden, primero horarios y luego restaurantes. Entonces introduce los nombres de las reservaciones segun el horario y restaurante hasta que cada list se llene
        }
        public static Dictionary<string, List<string>> RestaurantesNombres()
        {
            Dictionary<string, List<string>> Restaurantes = new Dictionary<string, List<string>>();

            Restaurantes.Add("Ember", null!);
            Restaurantes.Add("Zao", null!);
            Restaurantes.Add("Grappa", null!);
            Restaurantes.Add("Larimar", null!);

            return Restaurantes;
        }
        
        public static List<string> lista2 (string restaurante)
        {
            List<string> Horario2 = new List<string>();

            if (restaurante == "Ember")
            {
                Horario2 = new List<string>(3);
                Horario2.Capacity = 3;
            }
            else if (restaurante == "Zao")
            {
                Horario2 = new List<string>(4);
                Horario2.Capacity = 4;
            }
            else if (restaurante == "Grappa")
            {
                Horario2 = new List<string>(2);
                Horario2.Capacity = 2;
            }    
            else if (restaurante == "Larimar")
            {
                Horario2 = new List<string>();
                Horario2.Capacity = 3;
            }

            return Horario2;
        }
        public static bool confirmacion_cupos (int cupos, string restaurante_cupos)
        {
            bool resultado = false;
            if (restaurante_cupos == "Larimar" && cupos <= 2)
            {
                resultado = false;
            }
            else if (restaurante_cupos == "Grappa" && cupos <= 1)
            {
                resultado = false;
            }
            else if (restaurante_cupos == "Zao" && cupos <= 3)
            {
                resultado = false;
            }
            else if (restaurante_cupos == "Ember" && cupos <= 2)
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }
            return resultado;
        }
    }
}