using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication10
{
   [Serializable()]
    class Agenda : ISerializable
    {
        private List<Persona> agenda;

       /**
        * Nuestro constructor inicializa nuestra agenda, y lee el archivo, para agregar a la lista los contactos antes guardados.
        * */
        public Agenda()
        {
            agenda = new List<Persona>();

            Stream stream;
            try
            {
                stream = File.Open("C:\\Users\\daniel\\Documents\\DocumentosC\\texto.txt", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                List<Persona> persona2 = (List<Persona>)bf.Deserialize(stream);
                foreach (Persona persona in persona2)
                {
                    this.agenda.Add(persona);
                 
                }
                bf.Serialize(stream, this.agenda);
                stream.Close();
            }
            catch (IOException)
            {

            }
        }

        /**
        * Deserialization constructor.
        * */
         public Agenda(SerializationInfo info, StreamingContext cont)
         {
             this.agenda = (List<Persona>)info.GetValue("agendaAgenda",typeof(List<Persona>));
         }

       
         /**
           * Serialization function.
           * */
        public void GetObjectData(SerializationInfo info, StreamingContext cont)
         {
             info.AddValue("agendaAgenda", this.agenda);
         }

        /**
         * Metodo que nos agrega contactos a nuestra agenda.
         * @param persona Contacto que se agrega.
         * */
        public void agregar(Persona persona)
        {
           
            agenda.Add(persona);
   
        }

       /**
        * Metodo que nos muestra en pantalla, todos nuestros contactos.
        * 
        * */
        public void mostrar()
        {
            foreach (Persona persona in agenda)
            {
                Console.WriteLine("Nombre: {0} \nNumero: {1} ",persona.getNombre(), persona.getNumero());
            }
        }


        /**
         * Metodo que escribe dentro del archivo por medio de Serialize.
         * 
         * */
         public void serealizar()
         {
             Stream stream;
             try
             {
                  stream = File.Open("C:\\Users\\daniel\\Documents\\DocumentosC\\texto.txt", FileMode.Create);
                 BinaryFormatter bf = new BinaryFormatter();
                 bf.Serialize(stream, this.agenda);
                 stream.Close();
             }
             catch (IOException)
             {

             }

         }

         /**
          * Metodo que nos ayuda a leer nuestro archivo por medio de Deserialize.
          * 
          * */
        public void desealizar()
         {

             Stream stream;
             try
             {
                 stream = File.Open("C:\\Users\\daniel\\Documents\\DocumentosC\\texto.txt", FileMode.Open);
                 BinaryFormatter bf = new BinaryFormatter();
                 List<Persona> persona2 = (List<Persona>)bf.Deserialize(stream);
                 foreach (Persona persona in persona2)
                 {
                     Console.WriteLine("Nombre: {0} \nNumero: {1}", persona.getNombre(), persona.getNumero());
                 }
                 bf.Serialize(stream, this.agenda);
                 stream.Close();
             }
             catch (IOException)
             {

             }

         }


        /**
         * Metodo que nos ayuda a saber si se encuentra un contacto con su nombre, este metodo lo usamos el el metodo
         * Buscar.
         * @param nombre Nombre a buscar dentro de la agenda.
         * @return Boolean Booleano si se encuntra es true, de lo contrario false.
         **/
        public Boolean esta(string nombre)
        {
            Boolean esta = false;

            foreach (Persona persona in agenda)
            {
                if (persona.getNombre().Equals(nombre.ToLower()))
                {
                    esta = true;
                    break;
                }
                else
                {
                    esta = false;
                }
            }

            return esta;
        }

       /**
        * Metodo que nos busca un contacto dentro de la agenda en base a su nombre.
        * @param nombre Nombre a buscar dentro de la agenda.
        * */
        public void buscar(string nombre)
        {
            
            if (this.esta(nombre.ToLower()))
            {
                foreach (Persona persona in agenda)
                {
                    if(persona.getNombre().Equals(nombre.ToLower()))
                    {
                        Console.WriteLine("Nombre: {0} \nNumero: {1} ", persona.getNombre(), persona.getNumero());
                    }
                }
               

            }
            else
            {
                Console.WriteLine("No se encontro contacto con el nombre de {0}.", nombre.ToLower());
            }


           // return persona;
        }

       /**
        * Metodo que elimina un contacto tomando en cuenta su nombre
        * @param nombre Nombre a buscar dentro de la agenda.
        * */

        public void eliminar(string nombre)
        {
            if (this.esta(nombre.ToLower()))
            {
                foreach (Persona persona in agenda)
                {
                    if (persona.getNombre().Equals(nombre.ToLower()))
                    {
                        this.getAgenda().Remove(persona);
                        Console.WriteLine("Se elimino");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontro contacto con el nombre {0} para eliminar.", nombre.ToLower());
            }
        }

       /**
        * GETs y SETs
        * */
        public List<Persona> getAgenda()
        {
            return this.agenda;
        }

        public void setAgenda(List<Persona> agenda)
        {
            this.agenda = agenda;

        }

    }
}
