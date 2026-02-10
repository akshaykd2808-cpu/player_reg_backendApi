using playerregproject.Models;

namespace playerregproject.Interface.Repositories
{
    public interface IFormRepository
    {
        Task AddForm(Form form);
        Task<List<Form>> GetAllFormsAsync();
        Task<Form?> GetFormByIdAsync(int id);

        Task UpdateForm(Form form);



    }
}
