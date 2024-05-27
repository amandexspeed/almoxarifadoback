using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IRepositoryCRUD<T>
    {

        List<T> ObterTodos();
        T ObterRegistroPorId(int id);
        T CriarRegistro(T Registro);
        T DeletarRegistroPorId(int id);
        T UpdateRegistro(T Registro);

    }
}
