using MauiMangaReaderApp.Models;

namespace MauiMangaReaderApp.Services
{
    public interface ICBZParser
    {
        Task<List<MangaModel>> LoadCbzAsync(string url);
    }
}
