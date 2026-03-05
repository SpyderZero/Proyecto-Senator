using Database;
using System;
using System.Collections.Generic;

namespace Principal
{
    class ProyectoPrincipal
    {
        public static void Reservation_Program(Dictionary<string, List<string>> diccionario1, Dictionary<string, List<string>> diccionario2, List<string> Lista)
        {
            string nombre;
            int cantidad;
            int horario;
            string selec;
            string finalizar;
            bool confirmar = false;
            bool busca;
            List<string> Lista1 = new List<string>();
            List<string> Lista2 = new List<string>();

            do
            {
            Console.WriteLine("¿A nombre de quien es la reservación?");
            nombre = Console.ReadLine()!;
            
            if (nombre == "")
                {
                    Console.WriteLine("Debe digitar un nombre valido. . .");
                    continue;
                }

            Console.WriteLine("Indique para cuantas personas es su reservación");

            try
            {
                cantidad = int.Parse(Console.ReadLine()!);
                if (cantidad <= 0)
                    {
                        Console.WriteLine("Debe digitar un número valido. . .");
                        continue;
                    }
            }
            catch(Exception)
            {
                Console.WriteLine("Debe digitar un número valido. . .");
                continue;
            }

            Console.WriteLine("¿En que horario lo/s esperaremos? \n - Horario 1: 6:00 PM a 8:00 PM \n - Horario 2: 8:00 PM a 10:00 PM \n Digite 1 u 2 según su elección");

            try
            {
                horario = int.Parse(Console.ReadLine()!);
                if (horario != 1 && horario != 2 && horario >= 3)
                    {
                        Console.WriteLine("Debe digitar un número valido. . .");
                        continue;
                    }
            }
            catch(Exception)
            {
                Console.WriteLine("Debe digitar un número valido. . .");
                continue;
            }

            List<DateTime> listahorarios = horarios(horario);

            Console.WriteLine("Seleccione uno de nuestros restaurantes disponibles en el horario indicado para hacer su reservación:");

            List<string> listarestaurantes = diccionario1.Keys.ToList();

            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine(listarestaurantes[i]);
            }
                do
                {
                    selec = Console.ReadLine()!;
                    
                    busca = listarestaurantes.Contains(selec);
                    

                    if (busca == true && horario == 1)
                    {
                        confirmar = Confirmacion(selec, diccionario1, nombre, horario);
                    }
                    else if (busca == true && horario == 2)
                    {
                        confirmar = Confirmacion(selec, diccionario2, nombre, horario);
                    }
                    else
                    {
                        Console.WriteLine("Digite un restaurante válido");
                        continue;
                    }

                } while (selec == "Nulo");
            
            if (confirmar == false)
                {
                    switch (horario)
                    {
                        case 1:
                        diccionario1[selec].Add(nombre);
                        break;

                        case 2:
                        diccionario2[selec].Add(nombre);
                        break;
                    };

                    Console.WriteLine($"Su reservación es: \n En {selec} \n Entre las {listahorarios[0].ToString("HH:mm")} y {listahorarios[1].ToString("HH:mm")} \n Para {cantidad} Personas \n A nombre de: {nombre} \n //¿Desea hacer otra reservación?...");
                }
            else if (confirmar == true)
                {
                    Console.WriteLine($"Lo sentimos, pero los cupos en el horario seleccionado, en el Restaurante {selec} están llenos. \n Le encomiamos elegir otra de nuestras excelentes opciones \n //¿Desea hacer otra reservación?...");
                }
            
            finalizar = Console.ReadLine()!;

            if (finalizar == "No") break;
            if (finalizar == "no") break;
            if (finalizar == "Si") continue;
            if (finalizar == "si") continue;
            if (finalizar != "Si" && finalizar != "si")
                {
                    Console.WriteLine("Comando no reconocido, se repetirá el proceso de reservación en unos instantes. . .");
                }

            } while(nombre != "Finalizar");
        }

        public static void eliminar_reserva (Dictionary<string, List<string>> dic1, Dictionary<string, List<string>> dic2)
        {
            
        }
        public static void checar_cupos (Dictionary<string, List<string>> dic1, Dictionary<string, List<string>> dic2)
        {
            int horario = 0;
            int cupos = dic1["Grappa"].Count;

            horario = int.Parse(Console.ReadLine()!);

            Console.WriteLine(cupos);
        }
        public static List<DateTime> horarios (int valor)
        {
            List<DateTime> listahorarios = new List<DateTime>();
            DateTime hor1 = DateTime.Now;
            DateTime hor2 = DateTime.Now;
            
            if (valor == 1)
            {
                hor1 = new DateTime(2000, 1, 1, 18, 00, 00);
                hor2 = new DateTime(2000, 1, 1, 20, 00, 00);
            }
            else if (valor == 2)
            {
                hor1 = new DateTime(2000, 1, 1, 20, 00, 00);
                hor2 = new DateTime(2000, 1, 1, 22, 00, 00);
            }

            listahorarios.Add(hor1);
            listahorarios.Add(hor2);

            return listahorarios;
        }
        public static bool Confirmacion (String val1, Dictionary<string, List<string>> lista, string nombrereserva, int hora)
        {
            bool verificado = false;


            int conteo = lista[val1].Count;

            verificado = Data.confirmacion_cupos(conteo, val1);
            

            return verificado;
        }
    }
}