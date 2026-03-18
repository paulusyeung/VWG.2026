using System.Collections;
using System.Collections.Generic;

namespace EnvDTE;

public class DTE
{
    public virtual ItemOperations ItemOperations { get; } = new();
}

public class ItemOperations
{
    public virtual Window OpenFile(string fileName)
    {
        return null;
    }
}

public class Window
{
    public virtual Document Document { get; set; } = new();

    public virtual bool Visible { get; set; }

    public virtual void Activate()
    {
    }
}

public class Document
{
    public virtual bool ReadOnly { get; set; }
}

public class Project
{
    public virtual ProjectItems ProjectItems { get; } = new();
}

public class ProjectItem
{
    public virtual ProjectItems ProjectItems { get; } = new();

    public virtual Project ContainingProject { get; set; }

    public virtual DTE DTE { get; } = new();

    public virtual FileCodeModel FileCodeModel { get; set; } = new();

    public virtual short FileCount { get; set; }

    public virtual string Name { get; set; } = string.Empty;

    public virtual void Delete()
    {
    }

    public virtual string get_FileNames(short index)
    {
        return string.Empty;
    }

    public virtual Window Open()
    {
        return null;
    }
}

public class ProjectItems : IEnumerable<ProjectItem>
{
    private readonly List<ProjectItem> _items = new();

    public virtual ProjectItem AddFromFileCopy(string fileName)
    {
        return null;
    }

    public IEnumerator<ProjectItem> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class FileCodeModel
{
    public virtual CodeElements CodeElements { get; set; } = new();
}

public class CodeElements : IEnumerable<CodeElement>
{
    private readonly List<CodeElement> _items = new();

    public IEnumerator<CodeElement> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class CodeElement
{
    public virtual CodeElements Children { get; set; } = new();

    public virtual string FullName { get; set; } = string.Empty;

    public virtual vsCMElement Kind { get; set; }

    public virtual string Name { get; set; } = string.Empty;
}

public enum vsCMElement
{
    vsCMElementClass = 1,
    vsCMElementNamespace = 2
}