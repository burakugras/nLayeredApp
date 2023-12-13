using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class BusinessMessages
    {
        public static string CategoryLimit = "Kategori sayısı max 10 olabilir.";
        public static string CategoryProductLimit = "Bir kategoride ürün sayısı max 20 olabilir.";

        public static string ContactNameLimit = "Aynı ContactName'den 1'den fazla olamaz.";
        public static string CityLimit = "Bir şehirden maksimum 10 müşteri olabilir";
    }
}
