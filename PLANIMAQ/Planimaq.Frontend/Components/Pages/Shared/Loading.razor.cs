using Microsoft.AspNetCore.Components;

namespace Planimaq.Frontend.Components.Pages.Shared
{
    public partial class Loading
    {
        [Parameter] public string? Label { get; set; }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

        }
    }
}