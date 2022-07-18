using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication10
{
    class Comenzar
    {
        private int opcion;
        private Agenda agenda;

        public Comenzar()
        {
            agenda = new Agenda();
            opcion = 0;
        }

        /**
         * Metodo que inicia el proceso de nuestra agenda, desplega un menu con diferentes opciones, hasta que se ingrese 6
         * saldra del proceso.
         * */
        public void iniciar()
        {
            do
            {

                this.imprimirMenu();
                this.setOpcion(int.Parse(Console.ReadLine()));

                switch (this.getOpcion())
                {
                    case 1:
                        Console.WriteLine("---Insertar New Registro---");
                        Console.WriteLine("Dame un nombre");
                        Persona persona = new Persona();
                        persona.setNombre(Console.ReadLine());
                        Console.WriteLine("Dame un numero");
                        persona.setNumero(Console.ReadLine());
                        this.agenda.agregar(persona);
                        this.agenda.serealizar();

                        break;

                    case 2:
                         Console.WriteLine("---Buscar un Registro---");
                         Console.WriteLine("Dame el nombre a buscar");
                         this.getAgenda().buscar(Console.ReadLine());

                        break;
                    
                    case 3:

                        Console.WriteLine("---eliminar un registro---");
                         Console.WriteLine("Dame el nombre a eliminar");
                         this.getAgenda().eliminar(Console.ReadLine());
                         
                         this.agenda.serealizar();

                        break;

                    case 4:

                         Console.WriteLine("---Modificar un Registro---");
                         this.getAgenda().mostrar();
                 break;
                    case 5:

                         Console.WriteLine("---Mostrar Archivo---");
                         this.getAgenda().desealizar();

                        break;

                }
                

            } while (this.getOpcion() != 6);
        }

        public void imprimirMenu()
        {
            Console.WriteLine("---Menu---");
            Console.WriteLine("1 Insertar New Registro");
            Console.WriteLine("2 Buscar un Registro");
            Console.WriteLine("3 Eliminar Registro");
            Console.WriteLine("4 Modificar Registro");
            Console.WriteLine("5 Opciones");
            Console.WriteLine("6 Salir");
        }
        public int getOpcion()
        {
            return this.opcion;

        }
        public void setOpcion(int opcion)
        {
            this.opcion = opcion;
        }

        public Agenda getAgenda()
        {
            return this.agenda;

        }

        public void setAgenda(Agenda agenda)
        {
            this.agenda = agenda;
        }


    }
}
