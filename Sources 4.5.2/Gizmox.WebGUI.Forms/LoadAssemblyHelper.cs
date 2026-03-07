using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// This class is used only to avoid exceptions in the Assembly.Load if there is no Forms assembly.
    /// The namespace of this class must be as the assembly name, and the name of the class must be LoadAssemblyHelper.
    /// </summary>
    internal class LoadAssemblyHelper
    {
    }
}
