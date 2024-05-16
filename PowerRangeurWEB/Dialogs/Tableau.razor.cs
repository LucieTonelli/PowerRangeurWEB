using Microsoft.AspNetCore.Components;

namespace PowerRangeurWEB.Dialogs
{
    public partial class Tableau<T>
    {

        [Parameter]
        public RenderFragment Header { get; set; }
        [Parameter]
        public RenderFragment<T> Body { get; set; }
        [Parameter]
        public List<T> Data { get; set; }

    }
}