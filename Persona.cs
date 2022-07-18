using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ConsoleApplication10
{
    [Serializable()]
    class Persona : ISerializable
    {
        private string nombre;
        private string numero;

        public Persona()
        {

        }

        public Persona(string nombre, string numero)
        {
            this.nombre = nombre.ToLower();
            this.numero = numero.ToLower();
        }

        /**
       * Deserialization constructor.
       * */
        public Persona(SerializationInfo info, StreamingContext cont)
        {
            this.nombre = (string)info.GetValue("oniel",typeof(string));
            this.numero = (string)info.GetValue("11",typeof(string));

        }
        /**
           * Serialization function.
           * */
        public void GetObjectData(SerializationInfo info, StreamingContext cont)
        {
            info.AddValue("luis", this.nombre);
            info.AddValue("luis", this.numero);
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNumero()
        {
            return this.numero;
        }

        public void setNumero(string numero)
        {
            this.numero = numero;
        }
    }
}
