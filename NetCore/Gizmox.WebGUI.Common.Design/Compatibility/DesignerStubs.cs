#pragma warning disable CS1591

using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design;

/// <summary>
/// Minimal placeholder for legacy mapped designer type references.
/// </summary>
public class MappedComponentDesigner : ComponentDesigner
{
}

public class ControlDesigner : MappedComponentDesigner
{
}

public class FormDocumentDesigner : ControlDesigner, IRootDesigner
{
    public ViewTechnology[] SupportedTechnologies { get; } = new[] { ViewTechnology.Default };

    public object GetView(ViewTechnology technology)
    {
        return new Panel();
    }
}

public class UserControlDocumentDesigner : ControlDesigner, IRootDesigner
{
    public ViewTechnology[] SupportedTechnologies { get; } = new[] { ViewTechnology.Default };

    public object GetView(ViewTechnology technology)
    {
        return new Panel();
    }
}
