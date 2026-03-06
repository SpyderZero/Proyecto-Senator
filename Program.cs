using Principal;
using Database;

namespace MiPrimeraApp
{
    class Program
    {
        static void Main()
        {
            int menu = 0;
            List<string> Lista = new List<string>();
            Dictionary<string, List<string>> Restaurantes_Primerhorario = new Dictionary<string, List<string>>();

            Restaurantes_Primerhorario.Add("Ember", ProyectoPrincipal.listado("Ember", Lista));
            Restaurantes_Primerhorario.Add("Zao", ProyectoPrincipal.listado("Zao", Lista));
            Restaurantes_Primerhorario.Add("Grappa", ProyectoPrincipal.listado("Grappa", Lista));
            Restaurantes_Primerhorario.Add("Larimar", ProyectoPrincipal.listado("Larimar", Lista));
            Dictionary<string, List<string>> Restaurantes_Segundohorario = new Dictionary<string, List<string>>();

            Restaurantes_Segundohorario.Add("Ember", ProyectoPrincipal.listado("Ember", Lista));
            Restaurantes_Segundohorario.Add("Zao", ProyectoPrincipal.listado("Zao", Lista));
            Restaurantes_Segundohorario.Add("Grappa", ProyectoPrincipal.listado("Grappa", Lista));
            Restaurantes_Segundohorario.Add("Larimar", ProyectoPrincipal.listado("Larimar", Lista));


            do
            {
            Console.WriteLine("Bienvenido al sistema de reservaciones Senator. \n ¿Que acción desea realizar? \n 1. Realizar una reservación \n 2. Eliminar una reservación \n 3. Chequear los espacios disponibles \n 4. Cerrar el programa");
            menu = int.Parse(Console.ReadLine()!);
                switch (menu)
            {
                case 1:
                ProyectoPrincipal.Reservation_Program(Restaurantes_Primerhorario, Restaurantes_Segundohorario, Lista);
                break;
                case 2:
                ProyectoPrincipal.eliminar_reserva(Restaurantes_Primerhorario, Restaurantes_Segundohorario);
                break;
                case 3:
                ProyectoPrincipal.checar_cupos(Restaurantes_Primerhorario, Restaurantes_Segundohorario);
                break;
            }
            }while (menu != 4);

        }
    }
}