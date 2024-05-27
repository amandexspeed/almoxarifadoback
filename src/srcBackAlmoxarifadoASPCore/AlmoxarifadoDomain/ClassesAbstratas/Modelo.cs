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

            return (T)MemberwiseClone();

        }

    }
}
