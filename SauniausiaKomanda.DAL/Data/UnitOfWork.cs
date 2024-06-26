﻿using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Repositories.Abstractions;

namespace SauniausiaKomanda.DAL.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IApplicationDbContext _context;

        public UnitOfWork(
            IApplicationDbContext context,
            IRecipeRepository recipeRepository,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            IImageRepository imageRepository,
            IStepRepository stepRepository,
            IReviewRepository reviews,
            ILogRepository logs)
        {
            _context = context;
            Recipes = recipeRepository;
            Users = userRepository;
            Images = imageRepository;
            Categories = categoryRepository;
            Steps = stepRepository;
            Reviews = reviews;
            Logs = logs;
        }

        public IRecipeRepository Recipes { get; }
        public IUserRepository Users { get; }
        public IImageRepository Images { get; }
        public ICategoryRepository Categories { get; }
        public IStepRepository Steps { get; }
        public IReviewRepository Reviews { get; }
        public ILogRepository Logs { get; }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
