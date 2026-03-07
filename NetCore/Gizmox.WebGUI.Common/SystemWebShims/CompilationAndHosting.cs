using System.Reflection;
using System.CodeDom.Compiler;

namespace System.Web.Compilation
{
    public static class BuildManager
    {
        public static Type GetCompiledType(string virtualPath) =>
            throw new NotImplementedException($"BuildManager.GetCompiledType for '{virtualPath}' - requires ASP.NET Core BuildManager replacement");
    }

    public abstract class BuildProvider
    {
        public virtual string VirtualPath { get; set; } = "";
        public virtual System.IO.Stream OpenStream() => throw new NotImplementedException("BuildProvider.OpenStream");
        public virtual void GenerateCode(AssemblyBuilder assemblyBuilder) => throw new NotImplementedException("BuildProvider.GenerateCode");
        public virtual Type GetGeneratedType(CompilerResults compilerResults) => throw new NotImplementedException("BuildProvider.GetGeneratedType");
    }

    public abstract class AssemblyBuilder
    {
        public abstract void AddCodeCompileUnit(BuildProvider provider, System.CodeDom.CodeCompileUnit compileUnit);
    }
}

namespace System.Web.Hosting
{
    public static class HostingEnvironment
    {
        public static string ApplicationIdentityToken
        {
            get
            {
                var pi = typeof(HostingEnvironment).GetProperty("ApplicationIdentityToken",
                    BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                if (pi != null)
                    return (string?)pi.GetValue(null) ?? "";
                return Guid.NewGuid().ToString("N");
            }
        }
    }
}
