using Apopad.Domain.Model;
using System.Collections.Generic;

namespace Apopad.Domain.Service
{
    public interface IPretreatmentService
    {
        void pretreatPaper();
        List<Author> getAuthors(Paper paper);
    }
}
