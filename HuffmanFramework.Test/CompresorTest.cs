using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Matematica.Test
{
    [TestClass]
    public class CompresorTest
    {
        [TestMethod]
        public void CuandoAplicoHuffmanTama�oFinalMenorQueTama�oInicial()
        {
            var cadenaSinComprimir = "EXTENUANTE";
            var tama�oInicial = cadenaSinComprimir.Length * sizeof(char);

            var compresor = new Compresor();
            BitArray cadenaComprimida = compresor.Huffman(cadenaSinComprimir);

            Assert.IsNotNull(cadenaComprimida);
            Assert.IsTrue(cadenaComprimida.Length > 0);
            Assert.IsTrue(cadenaComprimida.Length < tama�oInicial);
        }
    }
}
