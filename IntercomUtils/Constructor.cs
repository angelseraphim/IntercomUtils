namespace IntercomUtils
{
    public class Constructor
    {
        public string Starting { get; set; }
        public string InUse { get; set; }
        public string Cooldown { get; set; }
        public string Ready { get; set; } 
        public Constructor() { }
        public Constructor(string Starting, string InUse, string Cooldown, string Ready)
        {
            this.Starting = Starting;
            this.InUse = InUse;
            this.Cooldown = Cooldown;
            this.Ready = Ready;
        }
    }
}
