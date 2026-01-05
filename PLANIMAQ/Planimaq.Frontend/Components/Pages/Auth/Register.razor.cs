using Microsoft.AspNetCore.Components;
using MudBlazor;
using Planimaq.Frontend.Repositories;
using Planimaq.Frontend.Services;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Enums;

namespace Planimaq.Frontend.Components.Pages.Auth;

public partial class Register
{
    private UserDTO userDTO = new();
    //private List<Country>? countries;
    //private List<State>? states;
    private List<Empresa>? empresas;
    private bool loading;
    private string? imageUrl;
    private string? titleLabel;

    //private Country selectedCountry = new();
    //private State selectedState = new();
    private Empresa selectedempresa = new();

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ILoginService LoginService { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Parameter, SupplyParameterFromQuery] public bool IsAdmin { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadEmpresasAsync();
    //    //await LoadCountriesAsync();
    }


    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        titleLabel = IsAdmin ? "Registro de Administrador" : "Registro de Usuario";
    }

    private void ImageSelected(string imageBase64)
    {
        userDTO.Photo = imageBase64;
        imageUrl = null;
    }
    private async Task LoadEmpresasAsync()
    {
        var responseHttp = await Repository.GetAsync<List<Empresa>>("/api/empresas/combo");
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(message!, Severity.Error);
            return;
        }
        empresas = responseHttp.Response;

    }

    //private async Task LoadCountriesAsync()
    //{
    //    var responseHttp = await Repository.GetAsync<List<Country>>("/api/countries/combo");
    //    if (responseHttp.Error)
    //    {
    //        var message = await responseHttp.GetErrorMessageAsync();
    //        Snackbar.Add(message!, Severity.Error);
    //        return;
    //    }
    //    countries = responseHttp.Response;
    //}

    //private async Task LoadStatesAsyn(int countryId)
    //{
    //    var responseHttp = await Repository.GetAsync<List<State>>($"/api/states/combo/{countryId}");
    //    if (responseHttp.Error)
    //    {
    //        var message = await responseHttp.GetErrorMessageAsync();
    //        Snackbar.Add(message!, Severity.Error);
    //        return;
    //    }
    //    states = responseHttp.Response;
    //}

    //private async Task LoadCitiesAsyn(int stateId)
    //{
    //    var responseHttp = await Repository.GetAsync<List<City>>($"/api/cities/combo/{stateId}");
    //    if (responseHttp.Error)
    //    {
    //        var message = await responseHttp.GetErrorMessageAsync();
    //        Snackbar.Add(message!, Severity.Error);
    //        return;
    //    }
    //    cities = responseHttp.Response;
    //}

    //private async Task CountryChangedAsync(Country country)
    //{
    //    selectedCountry = country;
    //    selectedState = new State();
    //    selectedCity = new City();
    //    states = null;
    //    cities = null;
    //    await LoadStatesAsyn(country.id);
    //}

    //private async Task StateChangedAsync(State state)
    //{
    //    selectedState = state;
    //    selectedCity = new City();
    //    cities = null;
    //    await LoadCitiesAsyn(state.id);
    //}

    private void EmpresaChanged(Empresa empresa  )
    {
        selectedempresa = empresa;
        userDTO.EmpresaId = empresa.Id;
    }

    //private async Task<IEnumerable<Country>> SearchCountries(string searchText, CancellationToken token)
    //{
    //    await Task.Delay(5);
    //    if (string.IsNullOrWhiteSpace(searchText))
    //    {
    //        return countries!;
    //    }

    //    return countries!
    //        .Where(c => c.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
    //        .ToList();
    //}

    //private async Task<IEnumerable<State>> SearchStates(string searchText, CancellationToken token)
    //{
    //    await Task.Delay(5);
    //    if (string.IsNullOrWhiteSpace(searchText))
    //    {
    //        return states!;
    //    }

    //    return states!
    //        .Where(c => c.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
    //        .ToList();
    //}

    private async Task<IEnumerable<Empresa>> SearchEmpresa(string searchText, CancellationToken token)
    {
        await Task.Delay(5);
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return empresas!;
        }

        return empresas!
            .Where(c => c.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }

    private void ReturnAction()
    {
        NavigationManager.NavigateTo("/");
    }

    private void InvalidForm()
    {
        Snackbar.Add("Por favor llena todos los campos del formulario.", Severity.Warning);
    }

    private async Task CreateUserAsync()
    {
        if (userDTO.Email is null || userDTO.PhoneNumber is null)
        {
            InvalidForm();
            return;
        }

        userDTO.UserType = UserType.Tecnico;
        userDTO.UserName = userDTO.Email;

        if (IsAdmin)
        {
            userDTO.UserType = UserType.Admin;
        }

        loading = true;
        var responseHttp = await Repository.PostAsync<UserDTO, TokenDTO>("/api/accounts/CreateUser", userDTO);
        loading = false;
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(message!, Severity.Error);
            return;
        }

        await LoginService.LoginAsync(responseHttp.Response!.Token);
        NavigationManager.NavigateTo("/");
    }
}
