using Poker.Controllers;

namespace Poker_Teste
{
    public class Mesa_Poker_Unit_Test
    {
        [Fact]
        public void Criar_uma_Mesa_de_Poker_Retornar_Table_Id()
        {
            // Arrange
            var num1 = 3;
            var num2 = 4;
            var valorEsperado = 7;

            // Act
            var soma = Calculo.Somar(num1, num2);

            // Assert
            Assert.Equal(valorEsperado, soma);
        }
        [Fact]
        public void Subtrair_DoisDouble_RetornaDouble()
        {
            // Arrange  
            var num1 = 7;
            var num2 = 5;
            var valorEsperado = 2;

            // Act  
            var subtracao = Calculo.Subtrair(num1, num2);

            //Assert  
            Assert.Equal(valorEsperado, subtracao);
        }
        [Fact]
        public void Multiplicar_DoisDouble_RetornaDouble()
        {
            // Arrange  
            var num1 = 9;
            var num2 = 8;
            var valorEsperado = 72;
            // Act  
            var mult = Calculo.Multiplicar(num1, num2);
            //Assert  
            Assert.Equal(valorEsperado, mult);
        }
        [Fact]
        public void Dividir_DoisDouble_RetornaDouble()
        {
            // Arrange  
            var num1 = 21;
            var num2 = 3;
            var valorEsperado = 7; 

            // Act  
            var div = Calculo.Dividir(num1, num2);

            //Assert  
            Assert.Equal(valorEsperado, div);
        }
    }
}
