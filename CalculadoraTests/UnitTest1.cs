using Calculadora.Service;

namespace CalculadoraTests
{
    public class UnitTest1
    {

        public CaculadoraImp construirClasse() {

            string data = "02/02/2020";
            CaculadoraImp calc = new CaculadoraImp("02/02/2020");
            return calc;
        
        }
        
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2,3,5)]
        public void TesteSomar(int val1, int val2, int resultado)
        {
            //Arrange
            CaculadoraImp calc = new CaculadoraImp("02/02/2020");
           
            //Act
            int resultadoCalculadora = calc.somar(val1, val2);
            //Assert
            Assert.Equal(resultado, resultadoCalculadora);
        }
         [Theory]
       [InlineData(1, 2, 2)]
       [InlineData(4, 5, 20)]
       public void TesteMultiplicar(int n1, int n2, int resultado)
       {
           CaculadoraImp calc = new CaculadoraImp("02/02/2020");

           int resultadoCalculadora = calc.multiplicar(n1, n2);

           Assert.Equal(resultado, resultadoCalculadora);

       }

       [Theory]
       [InlineData(6, 2, 3)]
       [InlineData(4, 2, 2)]
       public void TesteDividir(int n1, int n2, int resultado)
       {
           CaculadoraImp calc = new CaculadoraImp("02/02/2020");

           int resultadoCalculadora = calc.dividir(n1, n2);

           Assert.Equal(resultado, resultadoCalculadora);

       }

       [Theory]
       [InlineData(2, 1, 1)]
       [InlineData(4, 4, 0)]
       public void TesteSubtrair(int n1, int n2, int resultado)
       {
           CaculadoraImp calc = new CaculadoraImp("02/02/2020");

           int resultadoCalculadora = calc.subtrair(n1, n2);

           Assert.Equal(resultado, resultadoCalculadora);

       }
       [Fact]
       public void TestarDivisaoPorZero() 
       {
           CaculadoraImp calc = new CaculadoraImp("02/02/2020");
           Assert.Throws<DivideByZeroException>(
               ()=>calc.dividir(3,0)
           );

       }

        [Fact]
        public void TestarHistorico()
        {
            CaculadoraImp calc = new CaculadoraImp("02/02/2020");

            calc.somar(1, 2);
            calc.somar(2, 8);
            calc.somar(3, 7);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count); // Isto irá passar se listahistorico tem exatamente 3 itens
        }
    }
}