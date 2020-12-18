using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Matematica.Test
{
    [TestClass]
    public class CompresorTest
    {
        [TestMethod]
        public void CuandoAplicoHuffmanTamañoFinalMenorQueTamañoInicial()
        {
            var cadenaSinComprimir = "EXTENUANTE";
            var tamañoInicial = cadenaSinComprimir.Length * sizeof(char);

            var compresor = new Compresor();
            BitArray cadenaComprimida = compresor.Huffman(cadenaSinComprimir);

            Assert.IsNotNull(cadenaComprimida);
            Assert.IsTrue(cadenaComprimida.Length > 0);
            Assert.IsTrue(cadenaComprimida.Length < tamañoInicial);
        }
    }
}
