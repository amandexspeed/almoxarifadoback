using AlmoxarifadoDomain.ClassesAbstratas;


namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public abstract class RepositoryModelCR<T> where T:Modelo<T>
    {
        protected readonly ContextSQL _context;

        public RepositoryModelCR(ContextSQL context) {  
            _context = context; 
        }

        public virtual List<T> ObterTodos()
        {

            return _context.Set<T>()
                    .Select(r => r.ShallowCopy())
                    .ToList();

        }
        public virtual T ObterRegistroPorId(int id)
        {
            
            return _context.Set<T>()
                   .Select(r => r.ShallowCopy())
                   .ToList().First(x => x?.ID_GRU == id);

        }

        T CriarRegistro(T Registro);

    }
}
