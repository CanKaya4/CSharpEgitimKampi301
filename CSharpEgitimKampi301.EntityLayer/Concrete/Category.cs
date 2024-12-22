using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        /*
         Field - Variable - Property

        int x; -- Bir değişken direkt olarak bir sınıfın içerisine tanımlanırsa bu field'dır.
        public int y {get;set;} // Eğer bu field sonuna get ve set değerleri alırsa property olur.
        int z -- Eğer bir değer bir metot içerisinde tanımlanırsa bu variable'dır.
         */


        /*
         
         */
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product> Products { get; set; }
    }
}
