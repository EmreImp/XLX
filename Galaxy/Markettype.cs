using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy
{
    public class Markettype
    {
        public int[] quantity = new int[IConstants.lasttrade. + 1];

        public int[] price = new int[IConstants.lasttrade + 1];

        /* printout according to the pilot */
        public void info(int[] shipshold)
        {
            int i;
            Console.WriteLine("            Commodity      Price    Quantity   Shiphold.");
            for (i = 0; i <= IConstants.lasttrade; i++)
            {
                if (quantity[i] > 0 || shipshold[i] > 0)
                    Console.WriteLine("\n %18s  %8.1f cr. %8d %s %8d %s.",
                        IConstants.Commodities[i].Name, ((float)(price[i]) / 10),
                        quantity[i],
                        IConstants.unitnames[IConstants.Commodities[i].Units],
                        shipshold[i],
                        IConstants.unitnames[IConstants.Commodities[i].Units]);
            }
		Console.WriteLine("\n");
        }

        /* General Printout w/o shipholds */
        public void info()
        {
            int i;
		Console.WriteLine("            Commodity      Price    Quantity.");
            for (i = 0; i <= IConstants.lasttrade; i++)
            {
                if (quantity[i] > 0)
				Console.WriteLine("\n %18s  %8.1f cr. %8d %s.",
                        IConstants.Commodities[i].Name, ((float)(price[i]) / 10),
                        quantity[i],
                        IConstants.unitnames[IConstants.Commodities[i].Units]);
            }
		Console.WriteLine("\n");
        }

        /**
         * Prices and availabilities are influenced by the planet's economy type
         * (0-7) and a random "fluctuation" byte that was kept within the saved
         * commander position to keep the market prices constant over gamesaves.
         * Availabilities must be saved with the game since the player alters them
         * by buying (and selling(?))
         * 
         * Almost all operations are one byte only and overflow "errors" are
         * extremely frequent and exploited.
         * 
         * Trade Item prices are held internally in a single byte=true value/4. The
         * decimal point in prices is introduced only when printing them.
         * Internally, all prices are integers. The player's cash is held in four
         * bytes.
         */
        public void updateMarket(int fluct, Planet p)
        {
            for (int i = 0; i <= IConstants.lasttrade; i++)
            {
                int q;
                int product = (p.economy) * (IConstants.Commodities[i].Gradient);
                int changing = fluct & (IConstants.Commodities[i].Maskbyte);
                q = (IConstants.Commodities[i].Basequant) + changing - product;
                q = q & 0xFF;
                if ((q & 0x80) > 0)
                {
                    q = 0;
                }/* Clip to positive 8-bit */
                quantity[i] = (int)(q & 0x3F); /* Mask to 6 bits */
                q = (IConstants.Commodities[i].Baseprice) + changing + product;
                q = q & 0xFF;
                price[i] = (int)(q * 4);
            }
            /*Override to force nonavailability */
            quantity[IConstants.AlienItems] = 0;
        }

        /** Prices and availabilities are influenced by the planet's economy type
           (0-7) and a random "fluctuation" byte that was kept within the saved
           commander position to keep the market prices constant over gamesaves.
           Availabilities must be saved with the game since the player alters them
           by buying (and selling(?))

           Almost all operations are one byte only and overflow "errors" are
           extremely frequent and exploited.

           Trade Item prices are held internally in a single byte=true value/4.
           The decimal point in prices is introduced only when printing them.
           Internally, all prices are integers.
           The player's cash is held in four bytes. 
         */
        public Markettype(int fluct, Planet p)
        {
            short i;
            for (i = 0; i <= IConstants.lasttrade; i++)
            {
                int q;
                int product = (p.economy) * (IConstants.Commodities[i].Gradient);
                int changing = fluct & (IConstants.Commodities[i].Maskbyte);
                q = (IConstants.Commodities[i].Basequant) + changing - product;
                q = q & 0xFF;
                if ((q & 0x80) != 0) { q = 0; };                      /* Clip to positive 8-bit */

                this.quantity[i] = (short)(q & 0x3F); /* Mask to 6 bits */

                q = (IConstants.Commodities[i].Baseprice) + changing + product;
                q = q & 0xFF;
                this.price[i] = (short)(q * 4);
            }
            this.quantity[IConstants.AlienItems] = 0; /* Override to force nonavailability */
        }

    }
}
