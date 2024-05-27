using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoTestesTDD
{
    public class TesteDadosCorretos
    {
        [Fact]
        public void TesteShallowCopy()
        {

            Grupo g = new Grupo();
            g.ID_GRU = 1;
            g.NOME_GRU = "Nome GRU";
            g.SUGESTAO_GRU = "Manifest starset";

            Grupo g2 = g.ShallowCopy();

            Assert.NotNull(g2);
            Assert.Equal(1, g2.ID_GRU);
            Assert.Equal("Nome GRU", g2.NOME_GRU);
            Assert.Equal("Manifest starset", g2.SUGESTAO_GRU);

        }
    }
}