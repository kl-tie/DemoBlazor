using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Components.Pages;

public partial class MudPlayground : ComponentBase
{
    bool _expanded = true;

    private void OnExpandCollapseClick()
    {
        _expanded = !_expanded;
    }





    public string Text { get; set; } = "????";
    public string ButtonText { get; set; } = "Click Me";
    public int ButtonClicked { get; set; }

    void ButtonOnClick()
    {
        ButtonClicked += 1;
        Text = $"Awesome x {ButtonClicked}";
        ButtonText = "Click Me Again";
    }
}
