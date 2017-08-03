using System;

namespace Galaxy
{
    public class Tradegood
    {
        public int Baseprice { get; set; }  /* one byte */
        public int Gradient { get; set; }   /* five bits plus sign */
        public int Basequant { get; set; }  /* one byte */
        public int Maskbyte { get; set; }   /* one byte */
        public int Units { get; set; }      /* two bits */
        public string Name { get; set; }     /* longest="Radioactives" */

        public Tradegood(int price, int gradient, int baseqant, int maskbyte, int un, String name)
        {
            this.Baseprice = price;
            this.Gradient = gradient;
            this.Basequant = baseqant;
            this.Maskbyte = maskbyte;
            this.Name = name;
        }

    }
}
