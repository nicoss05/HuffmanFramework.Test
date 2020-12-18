using System.Collections;
using System.Collections.Generic;

namespace Matematica
{
    public class Compresor
    {
        public BitArray Huffman(string cadenaSinComprimir)
        {
            // Lista de nodos
            var frecuencia = CalcularFrecuencia(cadenaSinComprimir);
            frecuencia = OrdenarAscendente(frecuencia);

            while (frecuencia.Count > 1)
            {
                var nuevoNodo = new Nodo
                {
                    HijoIzquierdo = ExtraerValorMinimo(frecuencia),
                    HijoDerecho = ExtraerValorMinimo(frecuencia)
                };
                nuevoNodo.Frecuencia = nuevoNodo.HijoIzquierdo.Frecuencia + nuevoNodo.HijoDerecho.Frecuencia;
                Insertar(frecuencia, nuevoNodo);
            }

            return CrearBitArray(cadenaSinComprimir, frecuencia[0]);
        }

        private BitArray CrearBitArray(string data, Nodo nodo)
        {
            var acumulador = string.Empty;
            foreach (var caracterActual in data)
            {
                var camino = string.Empty;
                Camino(nodo, caracterActual, ref camino);
                acumulador += camino;
            }

            return TransformarBitArray(acumulador);
        }

        private BitArray TransformarBitArray(string cadenaCerosUnos)
        {
            var resultado = new BitArray(cadenaCerosUnos.Length);
            for (int i = 0; i < cadenaCerosUnos.Length; i++)
            {
                if (cadenaCerosUnos[i] == '0')
                    resultado[i] = false;
                else
                    resultado[i] = true;
            }
            return resultado;
        }

        private bool Camino(Nodo nodo, char caracterActual, ref string camino)
        {
            if (nodo.Clave == caracterActual)
                return true;
            
            if (nodo.HijoIzquierdo != null)
            {
                var caminoIzquierdo = camino + "0";
                if (Camino(nodo.HijoIzquierdo, caracterActual, ref caminoIzquierdo))
                {
                    camino = caminoIzquierdo;
                    return true;
                }
            }

            if (nodo.HijoIzquierdo != null)
            {
                var caminoDerecho = camino + "1";
                if (Camino(nodo.HijoIzquierdo, caracterActual, ref caminoDerecho))
                {
                    camino = caminoDerecho;
                    return true;
                }
            }

            return false;
        }

        private void Insertar(List<Nodo> nodos, Nodo nuevoNodo)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].Frecuencia > nuevoNodo.Frecuencia)
                {
                    nodos.Insert(i, nuevoNodo);
                    return;
                }
            }
        }

        private Nodo ExtraerValorMinimo(List<Nodo> frecuencia)
        {
            var minimo = frecuencia[0];
            frecuencia.RemoveAt(0);
            return minimo;
        }

        private List<Nodo> OrdenarAscendente(List<Nodo> frecuencia)
        {
            frecuencia.Sort();
            return frecuencia;
        }

        private List<Nodo> CalcularFrecuencia(string data)
        {
            List<Nodo> nodos = new List<Nodo>();
            for (int i = 0; i < data.Length; i++)
            {
                int posicion = EstaEnPosicion(nodos, data[i]);
                if (posicion == -1)
                {
                    nodos.Add(new Nodo(data[i], 1));
                }
                else
                {
                    nodos[posicion].Frecuencia++;
                }
            }
            return nodos;
        }

        private int EstaEnPosicion(List<Nodo> nodos, char clave)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].Clave == clave)
                    return i;
            }
            return -1;
        }
    }
}