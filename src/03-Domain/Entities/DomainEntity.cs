using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.Domain.Entities
{
    public class DomainEntity : BaseEntity
    {
        public int MyProperty { get; private set; }

        public DomainEntity(int property)
        {
            MyProperty = property;
        }
    }
}
