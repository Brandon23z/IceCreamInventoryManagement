using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamInventoryManagement
{
    public static class RegexStr
    {
        //UNIVERSAL HEADER//
        //HD 0103      2016-03-01
        public const string headerEx = @"^(HD) (\d{4})      (\d{4}-\d{2}-\d{2})(?: )*$";

        //UNIVERSAL TRAILER//
        //T 0003
        public const string trailerEx = @"^(T) (\d{4})(?: )*$";

        //UNIVERSAL TRUCK HEADER//
        //TR |Truck Number|
        public const string truckHeaderEx = @"^(TR) (\d{4})(?: )*$";

        //CITY UPLOAD//
        //Dearborn 1          Dearborn            MI          
        public const string cityEx = @"^(.{20})(.{20})(.{2})(?: )*$";

        //LOAD ICE CREAM TRUCK//
        //|Item Number||Adjustment Quantity|
        public const string truckItemEx = @"^(\d{4})(((\d)|-)\d{3})(?: )*$";
        //IR #ROWS FOR TRUCK
        public const string truckItemsTrailerEx = @"^(IR) (\d{4})(?: )*$";

        //LOAD ICE CREAM TRUCK SALES//
        //|Item Number||Final Quantity|
        public const string truckSalesEx = @"^(\d{4})(\d{4})(?: )*$";
        //SR #ROWS FOR TRUCK
        public const string truckSalesTrailerEx = @"^(SR) (\d{4})(?: )*$";

        //LOAD INVENTORY UPDATE//
        //|Item Number||Warehouse Quantity||Price||Description|
        public const string inventoryItemEx = @"^(\d{4})(\d{6})((\d{4})(.{0,30}))?(?: )*$";

        //LOAD TRUCK ROUTE//
        //|Truck Number||Route Number||Driver Number|
        public const string truckRouteEx = @"^(\d{4})(\d{4})(\d{4})(?: )*$";

        //ROUTE UPLOAD//
        //|action code||Route Number||-----city label-----|*10
        public const string routeCitys = @"^(?:(A|C)(\d{4})(.{20})(.{20})?(.{20})?(.{20})?(.{20})?(.{20})?(.{20})?(.{20})?(.{20})?(.{20})?(?: )*)|(?:(D)(\d{4}))$";

        //TRUCK UPLOAD//
        //|Truck Number|
        public const string trucksEx = @"^(\d{4})(?: )*$";
    }
}
