using System.Linq;
using System.Reflection;
using Verse;

namespace AlcoholV
{
    [StaticConstructorOnStartup]
    internal static class AcOverrideInjector
    {
        static AcOverrideInjector()
        {
            LongEventHandler.QueueLongEvent(Inject, "Initializing", true, null);
        }

        private static Assembly Assembly => Assembly.GetAssembly(typeof (AcOverrideInjector));
        private static string AssemblyName => Assembly.FullName.Split(',').First();

        private static void Inject()
        {
            Log.Message(AssemblyName + " Injecting.");
            var o = new LoadedOverride();
            o.OverrideIntoDefs();
            
        }
    }
}