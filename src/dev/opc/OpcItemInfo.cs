using OPCAutomation;

namespace Dade.Dms.Opc
{
    public class OpcItemInfo
    {
        public OpcItemInfo(OPCItem item)
        {
            Item = item;
        }

        public OPCItem Item { get; private set; }

        public int ServerHandle { get { return Item.ServerHandle; } }

        public int ClientHandle { get { return Item.ClientHandle; } }

        public string ItemId { get { return Item.ItemID; } }
    }
}
