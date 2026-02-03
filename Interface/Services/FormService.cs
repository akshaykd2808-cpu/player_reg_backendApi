using playerregproject.Interface.Repositories;
using playerregproject.Models;

namespace playerregproject.Interface.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task CreateTaskAsync(Form form, string Username)
        {
                        
            form.CreatedAt = DateTime.UtcNow;
            // You can add any business logic here if needed
            await _formRepository.AddForm(form);
        }

        public async Task<List<Form>> GetFormsAsync()
        {
            return await _formRepository.GetAllFormsAsync();
        }

        public async Task<Form?> GetFormByIDAsyncs(int Id)
        {
            return await _formRepository.GetFormByIdAsync(Id);
        }

        public async Task UpdateFormAsync(Form form)
        {
            // You can add any business logic here if needed
            form.CreatedAt = DateTime.UtcNow;
            await _formRepository.UpdateForm(form);
        }


    }
}
