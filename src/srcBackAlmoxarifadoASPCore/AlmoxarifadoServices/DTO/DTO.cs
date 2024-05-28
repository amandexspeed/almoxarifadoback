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
        private T getDTO;
        private T postDTO; 

        public DTO(T minhaInstancia) {

            getDTO = minhaInstancia;
            postDTO = minhaInstancia;

        }

        public DTO()
        {

        }

        public T DTOGet()
        {

            return getDTO;

        }

        public T DTOpost()
        {

            return postDTO;

        }

        public T ToModel()
        {

            return (T)getDTO;

        }

        //private void gerarDTO(T minhaInstancia)
        //{
            
        //    Dictionary<string, object> atributos = new Dictionary<string, object>();

        //    //pegando atributos...
        //    var propriedades = typeof(T).GetProperties();

        //    //testando e colocando no dicionário apropiado
        //    foreach (var propriedade in propriedades)
        //    {
        //        bool isKey = propriedade.GetCustomAttribute<KeyDB>() != null;
        //        bool isComputable = propriedade.GetCustomAttribute<Computable>() != null;
        //        var valor = propriedade.GetValue(minhaInstancia) == null ? null : propriedade.GetValue(minhaInstancia);

        //        if (isKey)
        //            ((IDictionary<string, object>)keys)[propriedade.Name] = valor;
        //        else
        //            if (isComputable)
        //            ((IDictionary<string, object>)computable)[propriedade.Name] = valor;
        //        else
        //            ((IDictionary<string, object>)atributos)[propriedade.Name] = valor;

        //    }

        //    //chaves do banco
        //    foreach (var kvp in keys)
        //    {
        //        var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
        //        getDTO[property.Key] = property.Value;

        //    }

        //    //Colunas computadas do banco
        //    foreach (var kvp in computable)
        //    {
        //        var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
        //        ((IDictionary<string, object>)getDTO)[property.Key] = property.Value;

        //    }

        //    //propiedades gerais
        //    foreach (var kvp in atributos)
        //    {

        //        var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
        //        ((IDictionary<string, object>)getDTO)[property.Key] = property.Value;
        //        ((IDictionary<string, object>)postDTO)[property.Key] = property.Value;

        //    }

        //}

        //private void gerarDTO()
        //{

        //    Dictionary<string, object> atributos = new Dictionary<string, object>();

        //    //pegando atributos...
        //    var propriedades = typeof(T).GetProperties();

        //    //testando e colocando no dicionário apropiado
        //    foreach (var propriedade in propriedades)
        //    {
        //        bool isKey = propriedade.GetCustomAttribute<KeyDB>() != null;
        //        bool isComputable = propriedade.GetCustomAttribute<KeyDB>() != null;

        //        if (isKey)
        //            ((IDictionary<string, object>)keys)[propriedade.Name] = 0;
        //        else
        //            if (isComputable)
        //            ((IDictionary<string, object>)computable)[propriedade.Name] = null;
        //        else
        //            ((IDictionary<string, object>)atributos)[propriedade.Name] = null;

        //    }

        //    //chaves do banco
        //    foreach (var kvp in keys)
        //    {
        //        var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);

        //        if (!((IDictionary<string, object>)getDTO).ContainsKey(property.Key))
        //        {
        //            //((IDictionary<string, object>)getDTO).Add(property.Key, null);
        //            ((IDictionary<string, object>)getDTO)[property.Key] = property.Value;
        //        }

        //        //getDTO[property.Key] = property.Value;

        //    }

        //    //Colunas computadas do banco
        //    foreach (var kvp in computable)
        //    {
        //        var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);

        //        if (!((IDictionary<string, object>)getDTO).ContainsKey(property.Key))
        //        {
        //            ((IDictionary<string, object>)getDTO)[property.Key] = property.Value;
        //        }

        //    }

        //    //propiedades gerais
        //    foreach (var kvp in atributos)
        //    {

        //        var property = new KeyValuePair<string, object>(kvp.Key, kvp.Value);

        //        if (!((IDictionary<string, object>)getDTO).ContainsKey(property.Key))
        //        {
        //            ((IDictionary<string, object>)getDTO)[property.Key] = property.Value;
        //        }
               

        //        if (!((IDictionary<string, object>)postDTO).ContainsKey(property.Key))
        //        {
        //            ((IDictionary<string, object>)postDTO)[property.Key] = property.Value;
        //        }

        //    }

        //}

        
    }
}
