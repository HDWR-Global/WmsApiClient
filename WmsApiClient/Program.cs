using Weaver.Wms.Api.Client.Interfaces;

namespace WmsApiClient
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            var client = new Weaver.Wms.Api.Client.WmsApiClient("http://localhost:43400", true);
            await client.Login("admin", "admin");
            Console.WriteLine("Materiały:");
            int page = 0;
            int pages = 1;
            while (page < pages)
            {
                page++;
                var materials = await client.CreateRequest<IMaterialClient>().List(new Weaver.Wms.ServiceInterfaces.MaterialService.MaterialFilterDto { Page = page });
                pages = materials.Pages;
                foreach (var material in materials.Items)
                {
                    Console.WriteLine($"{material.Reference} - {material.Name}");
                }
            }
            await client.Logout();
        }
    }
}
