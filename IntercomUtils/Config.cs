using System.ComponentModel;
using Exiled.API.Interfaces;

namespace IntercomUtils
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("%chaos% %classd% %dead% %foundation% %other% %scientists% %scps% %remaining%")]
        public Constructor Intercom { get; set; } = new Constructor("<color=red>SCP</color> - %scps%\n<color=blue>МОГ</color> - %foundation%\n<color=yellow>Ученые</color> - %scientists%\nStarting...", "<color=red>SCP</color> - %scps%\n<color=blue>МОГ</color> - %foundation%\n<color=yellow>Ученые</color> - %scientists%\nUsing %remaining%!", "<color=red>SCP</color> - %scps%\n<color=blue>МОГ</color> - %foundation%\n<color=yellow>Ученые</color> - %scientists%\nCooldown %remaining%!", "<color=red>SCP</color> - %scps%\n<color=blue>МОГ</color> - %foundation%\n<color=yellow>Ученые</color> - %scientists%\nIntercom ready!");
    }
}
