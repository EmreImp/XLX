using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy
{
    public class Pilot
    {

            WHERE position = WHERE.LANDED;

            String name;
            /** Current planet the pilot is located */
            Planet currentPlanet = new Planet();
            int galaxynum = 1;
            int fuel = IConstants.maxfuel;

            /** Contents of the pilot's cargo bay */
            int[] shipshold = new int[IConstants.lasttrade + 1];
            int credits;
            int holdspace;

        public Pilot(String Name, int Credits)
            {
                name = Name;
                credits = Credits;
                holdspace = 20;
            }

            public void landToPlanet(Planet planet)
            {
                this.currentPlanet = planet;
                planet.market.updateMarket(0x00, planet);
                Console.WriteLine("Welcome to the planet ");
                planet.printName();
                Console.WriteLine(" captain.");
                planet.info(true);
                Console.Write("\n");
            }


            public void info()
            {
                Console.WriteLine("  Name:" + name);
                Console.WriteLine("  Current Galaxy:" + galaxynum);
                Console.Write("  Current System: "); currentPlanet.printName(); Console.Write("\n");
                Console.WriteLine("  Credits: %.1f cr.    Fuel: %.1f LY.\n", (double)credits / 10, (double)fuel / 10);
                Console.WriteLine("  Cargobay Info:\n  Empty holds:%d.\n", holdspace);
                for (int i = 0; i < IConstants.lasttrade; i++)
                    if (shipshold[i] != 0)
                        Console.WriteLine("  %s  %8d t.\n", IConstants.Commodities[i].Name, shipshold[i]);
            }

            public string getPilotInfo()
            {
                StringBuilder str = new StringBuilder("");
                str .Append("  Name:" + name + "\n");
                str.Append("  Current Galaxy:" + galaxynum + "\n");
                str.Append("  Current System: " + currentPlanet.name);
                str.Append("\n");
                str.Append(string.Format("  Credits: %.1f cr.    Fuel: %.1f LY.\n", (double)credits / 10, (double)fuel / 10));
                str.Append(string.Format("  Cargobay Info:\n  Empty holds:%d.\n", holdspace));
                for (int i = 0; i < IConstants.lasttrade; i++)
                    if (shipshold[i] != 0)
                        str.Append(string.Format("  %s  %8d t.\n", IConstants.Commodities[i].Name, shipshold[i]));
                return str.ToString();
            }

            public void inMarket()
            {
                if (position == WHERE.FLYING)
                {
                    Console.WriteLine("Command only available if you are landed on a planet.");
                    return;
                }
                Console.WriteLine("Welcome to the Trade Center of %s.\n", currentPlanet.name);
                currentPlanet.market.info();
                Console.WriteLine("\nFuel :%.1f", (float)fuel / 10);
                Console.WriteLine("Holdspaces :%d.\n", holdspace);
                position = WHERE.MARKET;
            }

            void dofuel(string[] args)
            {
                if (args.Length <= 1)
                {
                    Console.WriteLine("How much fuel you want to buy captain?");
                    return;
                }
                int amount = Convert.ToInt16(args[1]);
                if (amount + fuel > IConstants.maxfuel)
                    amount = IConstants.maxfuel - fuel;
                if (IConstants.fuelcost > 0)
                {
                    if ((int)amount * IConstants.fuelcost > credits)
                        amount = (int)(credits / IConstants.fuelcost);
                }
                fuel += amount;
                credits -= IConstants.fuelcost * amount;
                if (amount == 0)
                    Console.WriteLine("Can't buy any fuel captain.");
		        else
			Console.WriteLine("Bought %.1fLY fuel captain.\n", (float)amount / 10);
            }

            /** Try to buy ammount a  of good i  Return ammount bought
            * Cannot buy more than is availble, can afford, or will fit in hold 
            */
            int gamebuy(int item, int amount)
            {
                int traded;
                if (credits < 0)
                    traded = 0;
                else
                {
                    traded = Math.Min(currentPlanet.market.quantity[item], amount);
                    if ((IConstants.Commodities[item].Units) == 0)
                    {
                        traded = Math.Min(holdspace, traded);
                    }
                    traded = Math.Min(traded, (int)Math.Floor((double)credits / (currentPlanet.market.price[item])));
                }
                shipshold[item] += traded;
                currentPlanet.market.quantity[item] -= traded;
                credits -= traded * (currentPlanet.market.price[item]);
                if ((IConstants.Commodities[item].Units) == 0)
                {
                    holdspace -= traded;
                }
                return traded;
            }

            /** As gamebuy but selling */
            int gamesell(int item, int amount)
            {
                int traded = Math.Min(shipshold[item], amount);
                shipshold[item] -= traded;
                currentPlanet.market.quantity[item] += traded;
                if ((IConstants.Commodities[item].Units) == 0)
                {
                    holdspace += traded;
                }
                credits += traded * (currentPlanet.market.price[item]);
                return traded;
            }

            public Markettype getCurrentMarket()
            {
                return currentPlanet.market;
            }

            public Planet getCurrentPlanet()
            {
                return currentPlanet;
            }

        }
}
