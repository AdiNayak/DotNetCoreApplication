using POS.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services.Settings
{
  public partial  interface IItemService
    {
        int InsertItem(Item item);
        int UpdateItem(Item item);
        List<Item> GetAllItem();
        Item GetItemByItemId(int itemId);
        void DeleteItem(int itemId);
        List<Brand> GetAllBrand();
        List<Product> GetAllProduct();
    }
}
