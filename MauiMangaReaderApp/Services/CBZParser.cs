using System.IO.Compression;
using MauiMangaReaderApp.Models;

namespace MauiMangaReaderApp.Services
{
    public class CBZParser : ICBZParser
    {
        public List<MangaModel> Manga { get; set; } = new List<MangaModel>();
        public async Task<List<MangaModel>> LoadCbzAsync(string url)
        {
            Manga.Clear();
            using (ZipArchive zip = ZipFile.OpenRead(url))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    byte[] bytes;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        await Task.Run(async () =>
                        {
                            await entry.Open().CopyToAsync(stream);
                            bytes = stream.ToArray();

                            Manga.Add(new MangaModel()
                            {
                                Img = bytes,
                                NumberOfPages = zip.Entries.Count,
                                Name = entry.FullName,
                            });
                        });
                    }
                }
                return Manga.OrderBy(x => x.Name).ToList();
            }
        }
    }
}
