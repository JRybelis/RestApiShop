﻿namespace RestApiShop.Dtos.Base
{
    public class DtoShopItem : DtoObject
    {
        public int ShopId { get; set; }
        public decimal? Price { get; set; }
    }
}
