using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoTestes
{
    public class UnitTest1
    {
        [Fact]
        public void TestShallowCopy()
        {

            Grupo g1 = new Grupo
            {

                ID_GRU = 1,
                NOME_GRU = "A",
                SUGESTAO_GRU = "B",

            };

            Grupo g2 = (Grupo)g1.ShallowCopy();

            Assert.Equal(g1.ID_GRU, g2.ID_GRU);
            Assert.Equal(g1.NOME_GRU,g2.NOME_GRU);
            Assert.Equal(g1.SUGESTAO_GRU, g2.SUGESTAO_GRU);

        }
    }
}