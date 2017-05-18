using Apopad.Domain.Model;

namespace Apopad.Domain.Service
{
    public interface ILookUpService
    {
        void LookupPaperAuthors();
        bool LookUpCandidate(Author author);
    }
}
