using Database;

namespace Principal
{
    class ProyectoPrincipal
    {
        public static void Reservation_Program()
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
            Console.WriteLine("Bienvenido al sistema de reservaciones Senator. \n ¿A nombre de quien es la reservación?");
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

            List<string> listarestaurantes = Data.RestaurantesNombres().Keys.ToList();
            Dictionary<string, List<string>> Listado = Data.RestaurantesNombres();

            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine(listarestaurantes[i]);
            }
                do
                {
                    selec = Console.ReadLine()!;
                    switch (horario)
                    {
                        case 1:
                        Data.Datos(selec, horario, nombre, Listado, Lista1);
                        break;

                        case 2:
                        Data.Datos(selec, horario, nombre, Listado, Lista2);
                        break;
                    }
                    
                    busca = listarestaurantes.Contains(selec);
                    

                    if (busca == true)
                    {
                        confirmar = Confirmacion(selec, Listado, nombre, horario);
                    }
                    else
                    {
                        Console.WriteLine("Digite un restaurante válido");
                        selec = "Nulo";
                    }

                } while (selec == "Nulo");
            
            if (confirmar == false)
                {
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

            if (hora == 1)
            {
            int conteo = lista[val1].Count;

            verificado = Data.confirmacion_cupos(conteo, val1);
            }
            else if (hora == 2)
            {
                int conteo = lista[val1 + "2"].Count;

            verificado = Data.confirmacion_cupos(conteo, $"{val1}2");
            }
            

            return verificado;
        }
    }
}