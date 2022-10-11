using System.Reflection;

namespace Vorn.Aaas.Ui;

public class AdditionalAssembliesRegistry
{
    public IEnumerable<Assembly> Assemblies { get; private set; }
    public Assembly CallingAssembly { get; private set; }
    public AdditionalAssembliesRegistry(Assembly callingAssembly, IEnumerable<Assembly>? AdditionalAssemblies = null)
    {
        CallingAssembly = callingAssembly;
        var execAss = Assembly.GetExecutingAssembly();
        Assemblies = new HashSet<Assembly> { execAss, CallingAssembly };
        if(AdditionalAssemblies is not null)
        {
            Assemblies = Assemblies.Concat(AdditionalAssemblies);
        }
    }
}
