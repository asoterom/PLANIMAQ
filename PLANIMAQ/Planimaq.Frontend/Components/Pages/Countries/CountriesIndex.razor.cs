using Microsoft.AspNetCore.Components;
using Planimaq.Frontend.Repositories;
using Planimaq.Shared.Entities;


namespace Planimaq.Frontend.Components.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        private List<Country>? countries;

        protected override async Task OnInitializedAsync()
        {
            

            var httpResult  = await Repository.GetAsync<List<Country>>("/api/countries");
        
            countries = httpResult.Response;

        }

    }

}