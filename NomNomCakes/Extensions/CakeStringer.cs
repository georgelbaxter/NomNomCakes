using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNomCakes.Extensions
{
    public static class CakeStringer
    {
        public static string BuildCakeImage(this CakeBuilder cakeBuilder)
        {
            string cakeUrl = "";
            string icingUrl = "";
            string toppingUrl = "";
            if (cakeBuilder.Cake != null)
                cakeUrl = cakeBuilder.Cake.ImageUrl;
            if (cakeBuilder.Icing != null)
                cakeUrl = cakeBuilder.Icing.ImageUrl;
            if (cakeBuilder.Topping != null)
                cakeUrl = cakeBuilder.Topping.ImageUrl;
            return buildCakeImage(cakeUrl, icingUrl, toppingUrl);
        }

        public static string BuildCakeImage(this BasketItem item)
        {
            return buildCakeImage(item.Cake.ImageUrl, item.Icing.ImageUrl, item.Topping.ImageUrl);
        }

        static string buildCakeImage(string cakeUrl, string icingUrl, string toppingUrl)
        {
            string imageURL = string.Empty;
            if (cakeUrl != "")
                imageURL += "url(/Content/Images/" + cakeUrl + ")";
            if (icingUrl != "")
                imageURL += (imageURL == string.Empty ? "" : ", ") + "url(/Content/Images/" + icingUrl + ")";
            if (toppingUrl != "")
                imageURL += (imageURL == string.Empty ? "" : ", ") + "url(/Content/Images/" + toppingUrl + ")";
            return imageURL;
        }
    }
}
