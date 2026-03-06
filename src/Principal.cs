using Database;
using System;
using System.Collections.Generic;
using System.Xml;

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

            List<string> listarestaurantes = nombres_restaurantes(diccionario1);

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
        public static List<string> nombres_restaurantes (Dictionary<string, List<string>> listanombres)
        {
            List<string> lista = listanombres.Keys.ToList();
            return lista;
        }
        public static void eliminar_reserva (Dictionary<string, List<string>> dic1, Dictionary<string, List<string>> dic2)
        {
            int restaurante_eliminar = 0;
            string salir = "";
            List<string> listanombres = nombres_restaurantes(dic1);
            int horario = 0;
            bool confirmacion = false;
            Console.WriteLine("Sentimos que tenga que cancelar su reservación \n ¿En cual de nuestros restaurantes hizo su reservación?");
            do
            {
                for (int i = 0; i <= 3; i++)
                    {
                        Console.WriteLine($"{i + 1}. {listanombres[i]}");
                    }
                try 
                    {
                        restaurante_eliminar = int.Parse(Console.ReadLine()!); 
                    }
                catch (Exception)
                    {
                        Console.WriteLine("Comando no reconocido. . .");
                        continue;
                    }
            Console.WriteLine("¿En que horario agendó su reservación? \n - Horario 1: 6:00 PM a 8:00 PM \n - Horario 2: 8:00 PM a 10:00 PM \n Digite 1 u 2 según su elección");

                try 
                    {
                        horario = int.Parse(Console.ReadLine()!); 
                    }
            catch (Exception)
                    {
                        Console.WriteLine("Comando no reconocido. . .");
                        continue;
                    }
            Console.WriteLine("¿A nombre de quien fue agendada la reservación?");
            string nombre = Console.ReadLine()!;
            if (horario == 1)
            {
                confirmacion = confirmar_reservacion(dic1, nombre, listanombres[restaurante_eliminar - 1]);
                switch (confirmacion)
                {
                    case true:
                    dic1[listanombres[restaurante_eliminar - 1]].Remove(nombre);
                    Console.WriteLine("Reservación anulada con éxito");
                    break;
                    case false:
                    Console.WriteLine($"No existe ninguna reservación a nombre de {nombre} en {listanombres[restaurante_eliminar - 1]}");
                    break;
                }
            }
            else if (horario == 2)
            {
                confirmacion = confirmar_reservacion(dic2, nombre, listanombres[restaurante_eliminar - 1]);
                switch (confirmacion)
                {
                    case true:
                    dic2[listanombres[restaurante_eliminar - 1]].Remove(nombre);
                    Console.WriteLine("Reservación anulada con éxito");
                    break;
                    case false:
                    Console.WriteLine($"No existe ninguna reservación a nombre de {nombre} en {listanombres[restaurante_eliminar - 1]}");
                    break;
                }
            }
            Console.WriteLine("¿Desea eliminar alguna otra reservación?");
            salir = Console.ReadLine()!;
            }while(salir == "Si" && salir == "si");
        }
        public static bool confirmar_reservacion (Dictionary<string, List<string>> diccionario, string nombre, string Restaurante)
        {
            bool confirmar = diccionario[Restaurante].Contains(nombre);
            return confirmar;
        }
        public static void checar_cupos (Dictionary<string, List<string>> dic1, Dictionary<string, List<string>> dic2)
        {
            int horario = 0;
            int restaurante_chequeo = 0;
            int cupos = 0;
            string confirmacion = "";
            List<string> listanombres = nombres_restaurantes(dic1);
            {Console.WriteLine("¿En que horario desea revisar su reservación? \n - Horario 1: 6:00 PM a 8:00 PM \n - Horario 2: 8:00 PM a 10:00 PM \n Digite 1 u 2 según su elección");
            try 
                {
                    horario = int.Parse(Console.ReadLine()!); 
                }
            catch (Exception)
                {
                    Console.WriteLine("Comando no reconocido. . .");
                    continue;
                }
            Console.WriteLine("Seleccione uno de nuestros restaurantes disponibles en el horario indicado");
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine($"{i + 1}. {listanombres[i]}");
            }
            restaurante_chequeo = int.Parse(Console.ReadLine()!);
            if (restaurante_chequeo >= 5)
                {
                    Console.WriteLine("Comando no reconocido. . .");
                    continue;
                }
            if (horario == 1)
                {
                    int reservaciones = dic1[listanombres[restaurante_chequeo - 1]].Count;
                    cupos = dic1[listanombres[restaurante_chequeo - 1]].Capacity - reservaciones;
                }
            else if (horario == 2)
                {
                    int reservaciones = dic2[listanombres[restaurante_chequeo - 1]].Count;
                    cupos = dic2[listanombres[restaurante_chequeo - 1]].Capacity - reservaciones;
                }
            else
                {
                    Console.WriteLine("Comando no reconocido. . .");
                    continue;
                }
            Console.WriteLine($"En {listanombres[restaurante_chequeo - 1]} hay disponibles {cupos} cupos en el horario seleccionado \n ¿Desea chequear alguna otra reservación?");
            confirmacion = Console.ReadLine()!;
            if (confirmacion != "Si" && confirmacion != "si")
                {
                    Console.WriteLine("Comando no reconocido");
                    break;
                }
            }while (confirmacion != "No" && confirmacion != "no");
            Console.WriteLine("Regresando al inicio. . . ");
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
            bool resultado = false;


            int conteo = lista[val1].Count;

            if (val1 == "Larimar" && conteo <= 2)
            {
                resultado = false;
            }
            else if (val1 == "Grappa" && conteo <= 1)
            {
                resultado = false;
            }
            else if (val1 == "Zao" && conteo <= 3)
            {
                resultado = false;
            }
            else if (val1 == "Ember" && conteo <= 2)
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }
            

            return resultado;
        }
        public static List<string> listado (string restaurante, List<string> Capacidad)
        {
            Capacidad = new List<string>();
            if (restaurante == "Ember")
            {
                Capacidad.Capacity = 3;
            }
            else if (restaurante == "Zao")
            {
                Capacidad.Capacity = 4;
            }
            else if (restaurante == "Grappa")
            {
                Capacidad.Capacity = 2;
            }    
            else if (restaurante == "Larimar")
            {
                Capacidad.Capacity = 3;
            }

            return Capacidad;
        }
    }
}
