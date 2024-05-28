using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoDomain.ClassesAbstratas
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyDB : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class Computable : Attribute { }

    public abstract class Modelo<T>
    {

        public T ShallowCopy()
        {

            return (T) this.MemberwiseClone();

        }

        public override string ToString()
        {

            var propriedades = typeof(T).GetProperties();
            string texto = "";

            foreach (var propriedade in propriedades)
            {

                texto = texto + propriedade.Name + " - " + propriedade.GetValue(this) + " - ";

            }

            return texto;

        }

    }
}
