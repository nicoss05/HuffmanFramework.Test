using System;
using System.Diagnostics.CodeAnalysis;

namespace Matematica
{
    internal class Nodo : IComparable<Nodo>
    {
        public Nodo()
        {
        }

        public Nodo(char clave, int frecuencia)
        {
            Clave = clave;
            Frecuencia = frecuencia;
        }

        public char Clave { get; set; }
        public int Frecuencia { get; set; }
        public Nodo HijoIzquierdo { get; set; }
        public Nodo HijoDerecho { get; set; }

        public int CompareTo([AllowNull] Nodo other)
        {
            return Frecuencia.CompareTo(other.Frecuencia);
        }
    }
}