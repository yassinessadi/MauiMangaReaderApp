namespace MauiMangaReaderApp.Models
{
    public class MangaModel
    {
        public byte[] Img { get; set; }
        public string Image => $"data:image/jpg;base64,{Convert.ToBase64String(Img)}";
        public long NumberOfPages { get; set; }
        public string Name { get; set; }
    }
}
