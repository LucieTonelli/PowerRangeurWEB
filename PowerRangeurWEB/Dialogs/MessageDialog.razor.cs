using Microsoft.AspNetCore.Components;

namespace PowerRangeurWEB.Dialogs
{
    public partial class MessageDialog
    {

        [Parameter, EditorRequired]
        public RenderFragment ChildContent { get; set; }

        [Parameter, EditorRequired]
        public RenderFragment TitleContent { get; set; }

    }
}