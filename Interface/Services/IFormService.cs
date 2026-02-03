using playerregproject.Models;

namespace playerregproject.Interface.Services
{
    public interface IFormService
    {
        Task CreateTaskAsync(Form form, string Username);
        Task<List<Form>> GetFormsAsync();

        Task<Form?> GetFormByIDAsyncs(int Id);

        Task UpdateFormAsync(Form form);
    }
}
