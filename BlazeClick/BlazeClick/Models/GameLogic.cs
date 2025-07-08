namespace BlazeClick.Models
{
    public class GameLogic
    {
        
        public int BitCount { get; set; } = 0;
        public int Strength { get; set; } = 1;
        public int MiningPower { get; set; } = 0;
        public Dictionary<ShopItemType, ShopItemInfo> ShopItems { get; set; } // Dic of items.

        public GameLogic()
        {
            ShopItems = new Dictionary<ShopItemType, ShopItemInfo>
{
    { ShopItemType.BitPower, new ShopItemInfo(ShopItemType.BitPower, "Bit Power", 20, 0, 1) },
    { ShopItemType.BitMiner, new ShopItemInfo(ShopItemType.BitMiner, "Bit Miner", 150, 2, 0) },
    { ShopItemType.GPUFarm, new ShopItemInfo(ShopItemType.GPUFarm, "GPU Farm", 500, 3, 0) },
    { ShopItemType.DataCenter, new ShopItemInfo(ShopItemType.DataCenter, "Data Center", 1350, 10, 0) }
};

        }

        public void Click()
        {
            BitCount += Strength;
        }
        public void AutoMineTick()
        {
            BitCount += MiningPower; 
        }
        public void BuyItem(ShopItemType type)
        {
            var item = ShopItems[type];
            if (BitCount >= item.CurrentCost)
            {
                BitCount -= item.CurrentCost;
                item.Owned++;
                Strength += item.ClickStrength;
                MiningPower += item.MiningPower;
            }
        }

    }
}
