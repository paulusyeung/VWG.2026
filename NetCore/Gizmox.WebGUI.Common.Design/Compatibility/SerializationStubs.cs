#pragma warning disable CS1591
#pragma warning disable CS8603
#pragma warning disable CS8604

using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Common.Design.Serialization;

/// <summary>
/// Shared pass-through serializer used by compatibility placeholders.
/// </summary>
public abstract class PassthroughCodeDomSerializer : CodeDomSerializer
{
    public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
    {
        CodeDomSerializer? serializer = GetBaseSerializer(manager);
        return serializer is null ? codeObject : serializer.Deserialize(manager, codeObject);
    }

    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
        CodeDomSerializer? serializer = GetBaseSerializer(manager);
        return serializer is null ? value : serializer.Serialize(manager, value);
    }

    protected static CodeDomSerializer? GetBaseSerializer(IDesignerSerializationManager manager)
    {
        try
        {
            return manager.GetSerializer(typeof(Component), typeof(CodeDomSerializer)) as CodeDomSerializer;
        }
        catch
        {
            return null;
        }
    }
}

public class AspControlBoxCodeDomSerializer : PassthroughCodeDomSerializer
{
}

public class BindingNavigatorCodeDomSerializer : PassthroughCodeDomSerializer
{
}

public class ControlCodeDomSerializer : PassthroughCodeDomSerializer
{
}

public class ControlCollectionCodeDomSerializer : PassthroughCodeDomSerializer
{
}

public class ImageListCodeDomSerializer : PassthroughCodeDomSerializer
{
}

public class ObjectBoxParameterCollectionSelrializer : PassthroughCodeDomSerializer
{
}

public class TableLayoutControlCollectionCodeDomSerializer : PassthroughCodeDomSerializer
{
}

public class TableLayoutPanelCodeDomSerializer : PassthroughCodeDomSerializer
{
}

public class ResourceHandleSerializer : PassthroughCodeDomSerializer
{
    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
        if (value is not null)
        {
            Type valueType = value.GetType();
            var fileProperty = valueType.GetProperty("File");
            if (fileProperty?.GetValue(value) is string file && valueType.FullName is not null)
            {
                object fileSerialization = base.Serialize(manager, file);
                if (fileSerialization is CodeExpression fileExpression)
                {
                    return new CodeObjectCreateExpression(valueType.FullName, fileExpression);
                }
            }
        }

        return base.Serialize(manager, value);
    }
}

public class TypeResourceHandleSerializer : ResourceHandleSerializer
{
    public override object Serialize(IDesignerSerializationManager manager, object value)
    {
        object serialized = base.Serialize(manager, value);

        if (serialized is not CodeObjectCreateExpression create)
        {
            return serialized;
        }

        if (manager.GetService(typeof(IDesignerHost)) is not IDesignerHost host)
        {
            return serialized;
        }

        CodeExpression[] args = new CodeExpression[create.Parameters.Count + 1];
        args[0] = new CodeTypeOfExpression(host.RootComponentClassName);
        create.Parameters.CopyTo(args, 1);

        return new CodeObjectCreateExpression(create.CreateType, args);
    }
}
