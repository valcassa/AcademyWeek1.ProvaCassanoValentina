using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.Prova.Core.IRepository
{
    public interface IRepository<T>
    {
        List<T> Fetch();

    }
}