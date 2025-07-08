namespace BlazeClick.Models
{
    public enum ShopItemType { BitMiner, GPUFarm, DataCenter }

    public class ShopItemInfo
    {
        public ShopItemType Type { get; }
        public string Name { get; }
        public int BaseCost { get; }
        public int MiningPower { get; }
        public int Owned { get; set; }
        public int CurrentCost => (int)Math.Ceiling(BaseCost * Math.Pow(1.1, Owned)); // Example formula

        public ShopItemInfo(ShopItemType type, string name, int baseCost, int miningPower)
        {
            Type = type;
            Name = name;
            BaseCost = baseCost;
            MiningPower = miningPower;
            Owned = 0;
        }
    }
}



