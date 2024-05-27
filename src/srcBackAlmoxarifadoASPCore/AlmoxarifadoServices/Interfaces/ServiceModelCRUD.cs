using AlmoxarifadoDomain.ClassesAbstratas;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Interfaces
{
    public abstract class ServiceModelCRUD<T> where T : Modelo<T>
    {

        protected readonly RepositoryModelCR<T> _Repository;
        protected DTO<T> dto;

        public ServiceModelCRUD(RepositoryModelCR<T> repository)
        {
            _Repository = repository;
            dto = new DTO<T>();
        }

        public virtual T ObterRegistroPorID(int id)
        {
            return _Repository.ObterRegistroPorId(id);
        }

        public virtual List<DTO<T>> ObterTodos()
        {

            List<DTO<T>> dtos = new List<DTO<T>>();

            foreach (T registro in _Repository.ObterTodos())
            {
                dtos.Add(new(registro));
            }

            return dtos;

        }
        public virtual DTO<T> CriarRegistro(T n)
        {

            var registroSalvo = _Repository.CriarRegistro(
                    n.ShallowCopy()
            );

            return new(registroSalvo);

        }
    }
}
