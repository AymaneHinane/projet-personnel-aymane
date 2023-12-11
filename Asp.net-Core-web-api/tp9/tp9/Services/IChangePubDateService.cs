using test8.Model.Library;
using tp9.DTO;

namespace tp9.Services
{
    public interface IChangePubDateService
    {
        ChangePubDateDto GetOriginal(int id);
        Books UpdateBook(ChangePubDateDto dto);
    }
}