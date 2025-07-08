namespace BlazeClick.Models
{
    public class GameLogic
    {
        public int BitCount { get; set; } = 0;
        public int Strength { get; set; } = 1;
        public int MiningPower { get; set; } = 0;
        public Dictionary<ShopItemType, ShopItemInfo> ShopItems { get; set; }

        public GameLogic()
        {
        ShopItems = new Dictionary<ShopItemType, ShopItemInfo>
            {
        { ShopItemType.BitMiner, new ShopItemInfo(ShopItemType.BitMiner, "Bit Miner", 10, 1) },
        { ShopItemType.GPUFarm, new ShopItemInfo(ShopItemType.GPUFarm, "GPU Farm", 75, 5) },
        { ShopItemType.DataCenter, new ShopItemInfo(ShopItemType.DataCenter, "Data Center", 200, 10) }
            };
        }

        public void Click()
        {
            BitCount += Strength;
        }
        public void AutoMineTick()
        {
            BitCount += MiningPower; // call this every second, for example
        }
        public void BuyItem(ShopItemType type)
        {
            var item = ShopItems[type];
            if (BitCount >= item.CurrentCost)
            {
                BitCount -= item.CurrentCost;
                item.Owned++;
                MiningPower += item.MiningPower;
            }
        }

    }
}
