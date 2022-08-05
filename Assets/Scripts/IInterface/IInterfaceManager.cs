namespace Assets.Scripts
{
    public interface IInterfaceManager
    {
        public (int curbull, int gunbull) Ammo();
        public float HP();
        public float Armour();
        public int Money();
        public int Items();
    }
}