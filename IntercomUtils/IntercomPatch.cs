using IntercomUtils;
using HarmonyLib;
using PlayerRoles;
using PlayerRoles.Voice;
using System.Linq;
using Player = Exiled.API.Features.Player;

[HarmonyPatch(typeof(Intercom), nameof(Intercom.Update))]
public static class IntercomPatch
{
    public static void Prefix(Intercom __instance)
    {
        string intercomText = "";
        int RemainingTime = (int)__instance.RemainingTime;

        switch (Intercom.State)
        {
            case IntercomState.Starting:
                intercomText = Replacer(Plugin.plugin.Config.Intercom.Starting, RemainingTime);
                break;
            case IntercomState.InUse:
                intercomText = Replacer(Plugin.plugin.Config.Intercom.InUse, RemainingTime);
                break;
            case IntercomState.Cooldown:
                intercomText = Replacer(Plugin.plugin.Config.Intercom.Cooldown, RemainingTime);
                break;
            default:
                intercomText = Replacer(Plugin.plugin.Config.Intercom.Ready, RemainingTime);
                break;
        }

        IntercomDisplay._singleton.Network_overrideText = intercomText;
    }
    private static string Replacer(string text, int time)
    {
        int ClassD = Player.List.Where(p => p.Role.Team == Team.ClassD).Count();
        int Chaos = Player.List.Where(p => p.Role.Team == Team.ChaosInsurgency).Count();
        int Dead = Player.List.Where(p => p.Role.Team == Team.Dead).Count();
        int Foundation = Player.List.Where(p => p.Role.Team == Team.FoundationForces).Count();
        int Other = Player.List.Where(p => p.Role.Team == Team.OtherAlive).Count();
        int Scientists = Player.List.Where(p => p.Role.Team == Team.Scientists).Count();
        int Scps = Player.List.Where(p => p.Role.Team == Team.SCPs && p.Role.Type != RoleTypeId.Scp0492).Count();

        string Newtext = text.Replace("%remaining%", time.ToString())
            .Replace("%chaos%", Chaos.ToString())
            .Replace("%classd%", ClassD.ToString())
            .Replace("%dead%", Dead.ToString())
            .Replace("%other%", Other.ToString())
            .Replace("%scientists%", Scientists.ToString())
            .Replace("%foundation%", Foundation.ToString())
            .Replace("%scps%", Scps.ToString());
        return Newtext;
    }

}