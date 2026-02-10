using playerregproject.Interface.Repositories;
using playerregproject.Models;

namespace playerregproject.Interface.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly IWebHostEnvironment _env;
        public FormService(IFormRepository formRepository, IWebHostEnvironment env)
        {
            _formRepository = formRepository;
            _env = env;
        }

        public async Task CreateTaskAsync(Form form, string Username)
        {

            if (form.Image == null || form.Image.Length == 0)
                throw new Exception("Image is required");

            var uploadPath = Path.Combine(_env.WebRootPath, "uploads/forms");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var extension = Path.GetExtension(form.Image.FileName).ToLower();
            var allowed = new[] { ".jpg", ".jpeg", ".png" };

            if (!allowed.Contains(extension))
                throw new Exception("Invalid image format");

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await form.Image.CopyToAsync(stream);
            }

            form.ImageUrl = $"/uploads/forms/{fileName}";
            form.Image = null; // important

            form.isActive = form.isActive;

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
