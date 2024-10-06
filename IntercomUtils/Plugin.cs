using Exiled.API.Features;
using HarmonyLib;

namespace IntercomUtils
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "IntercomUtils";
        public override string Name => "IntercomUtils";
        public override string Author => "angelseraphim.";
        public static Plugin plugin;
        public static Harmony harmony;

        public override void OnEnabled()
        {
            plugin = this;
            harmony = new Harmony("DXUtils");
            harmony.PatchAll();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            plugin = null;
            harmony.UnpatchAll();
            base.OnDisabled();
        }
    }
}
