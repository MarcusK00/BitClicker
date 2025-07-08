namespace BlazeClick.Models
{
    public enum ShopItemType { BitPower, BitMiner, GPUFarm, DataCenter }

    public class ShopItemInfo
    {
        public ShopItemType Type { get; }
        public string Name { get; }
        public int BaseCost { get; }
        public int MiningPower { get; }
        public int Owned { get; set; }
        public int ClickStrength { get; set; }
        public int CurrentCost => (int)Math.Ceiling(BaseCost * Math.Pow(1.1, Owned)); // Example formula

        public ShopItemInfo(ShopItemType type, string name, int baseCost, int miningPower, int clickStrength)
        {
            Type = type;
            Name = name;
            BaseCost = baseCost;
            MiningPower = miningPower;
            Owned = 0;
            ClickStrength = clickStrength;
        }
    }
}



