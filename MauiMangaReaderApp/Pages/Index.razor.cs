using MauiMangaReaderApp.Models;
using MauiMangaReaderApp.Services;
using Microsoft.AspNetCore.Components;

namespace MauiMangaReaderApp.Pages
{
    public partial class Index
    {
        [Inject] public ICBZParser _Service { get; set; }
        List<MangaModel> Models { get; set; } = new List<MangaModel>();
        protected override async Task OnInitializedAsync()
        {
            var res = await FilePicker.PickMultipleAsync();
			foreach (var loc in res)
			{
				var result = await _Service.LoadCbzAsync(loc.FullPath);
				await Task.Delay(2000);
				foreach (var item in result)
				{
					MainThread.BeginInvokeOnMainThread(() =>
					{
						Models.Add(item);
					});
				}
			}
        }
    }
}
