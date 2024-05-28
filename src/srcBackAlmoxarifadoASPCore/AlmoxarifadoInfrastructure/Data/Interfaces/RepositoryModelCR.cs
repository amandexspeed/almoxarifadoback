using AlmoxarifadoDomain.ClassesAbstratas;
using System.Reflection;
using System.Security.Cryptography;

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

            return _context.Set<T>().Select(r => r.ShallowCopy()).ToList();

        }
        public virtual T ObterRegistroPorId(int id)
        {
            return _context.Set<T>()
                   .Select(r => r.ShallowCopy())
                   .ToList().First(x => gerarChave(x).ContainsValue(id));

            //.ToList().First(x => x?.ID_GRU == id);

        }

        public virtual T CriarRegistro(T Registro)
        {

            _context.Set<T>().Add(Registro);
            _context.SaveChanges();
            return Registro;

        }

        private Dictionary<string, object> gerarChave(T minhaInstancia)
        {
            Dictionary<string, object> keys = new Dictionary<string, object>();
            var propriedades = typeof(T).GetProperties();

            foreach (var propriedade in propriedades)
            {
                bool isKey = propriedade.GetCustomAttribute<KeyDB>() != null;

                if (isKey)
                {
                    var valor = propriedade.GetValue(minhaInstancia);
                    keys[propriedade.Name] = valor != null ? valor : 0;
                }
            }
            return keys;

        }



    }

}

