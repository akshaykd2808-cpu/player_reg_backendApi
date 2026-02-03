using Microsoft.EntityFrameworkCore;
using playerregproject.Data;
using playerregproject.Models;

namespace playerregproject.Interface.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly PlayerRegDbContext _dbContext;

        public FormRepository(PlayerRegDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddForm(Form form)
        {
            await _dbContext.Forms.AddAsync(form);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Form>> GetAllFormsAsync()
        {
            return await _dbContext.Forms.ToListAsync();
        }

        public async Task<Form?> GetFormByIdAsync(int Id)
        {
            return await _dbContext.Forms.FindAsync(Id);
        }

        public async Task UpdateForm(Form form)
        {
            _dbContext.Forms.Update(form); // Removed 'await' as Update is not asynchronous
            await _dbContext.SaveChangesAsync(); // Save changes asynchronously
        }
    }
}
