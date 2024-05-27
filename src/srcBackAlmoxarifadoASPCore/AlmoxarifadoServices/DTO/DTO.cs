using AlmoxarifadoDomain.ClassesAbstratas;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class DTO<T> where T : Modelo<T>
    {
        private dynamic getDTO { get; } = new ExpandoObject();
        private dynamic postDTO { get; } = new ExpandoObject();
        private static Dictionary<string, object> keys = new Dictionary<string, object>();
        private static Dictionary<string, object> computable = new Dictionary<string, object>();

        public DTO(T minhaInstancia) {

            gerarDTO(minhaInstancia);

        }

        public DTO()
        {

                gerarDTO();

        }

        public DynamicMetaObject DTOGet()
        {

            return getDTO;

        }

        public DynamicMetaObject DTOpost()
        {

            return postDTO;

        }

        private void gerarDTO(T minhaInstancia)
        {
            
            Dictionary<string, object> atributos = new Dictionary<string, object>();

            //pegando atributos...
            var propriedades = typeof(T).GetProperties();

            //testando e colocando no dicionário apropiado
            foreach (var propriedade in propriedades)
            {
                bool isKey = propriedade.GetCustomAttribute<KeyDB>() != null;
                bool isComputable = propriedade.GetCustomAttribute<KeyDB>() != null;

                if (isKey)
                    keys[propriedade.Name] = propriedade.GetValue(minhaInstancia);
                else
                    if (isComputable)
                    computable[propriedade.Name] = propriedade.GetValue(minhaInstancia);
                else
                    atributos[propriedade.Name] = propriedade.GetValue(minhaInstancia);

            }

            //chaves do banco
            foreach (var kvp in keys)
            {
                var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                getDTO[property.Key] = property.Value;

            }

            //Colunas computadas do banco
            foreach (var kvp in computable)
            {
                var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                getDTO[property.Key] = property.Value;

            }

            //propiedades gerais
            foreach (var kvp in atributos)
            {

                var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                getDTO[property.Key] = property.Value;
                postDTO[property.Key] = property.Value;

            }

        }

        private void gerarDTO()
        {

            Dictionary<string, object> atributos = new Dictionary<string, object>();

            //pegando atributos...
            var propriedades = typeof(T).GetProperties();

            //testando e colocando no dicionário apropiado
            foreach (var propriedade in propriedades)
            {
                bool isKey = propriedade.GetCustomAttribute<KeyDB>() != null;
                bool isComputable = propriedade.GetCustomAttribute<KeyDB>() != null;

                if (isKey)
                    keys[propriedade.Name] = null;
                else
                    if (isComputable)
                    computable[propriedade.Name] = null;
                else
                    atributos[propriedade.Name] = null;

            }

            //chaves do banco
            foreach (var kvp in keys)
            {
                var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                getDTO[property.Key] = property.Value;

            }

            //Colunas computadas do banco
            foreach (var kvp in computable)
            {
                var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                getDTO[property.Key] = property.Value;

            }

            //propiedades gerais
            foreach (var kvp in atributos)
            {

                var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                getDTO[property.Key] = property.Value;
                postDTO[property.Key] = property.Value;

            }

        }

    }
}
