using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy
{
    public enum WHERE
    {
        FLYING,
        LANDED,
        MARKET,
        TECH,
    }
    public enum HIT_RESULTS
    {
        DAMAGED,
        PARRIED,
        DODGED,
        BLOCKED,
        MISSED
    }

    public class IConstants
    {
        static int galsize = 256;
        public static int AlienItems = 16;
        static int numforLave = 7;
        public static int maxfuel = 70;
        public static int fuelcost = 2;
        public static int lasttrade { get; set; }  = AlienItems;
        static string pairs = "..LEXEGEZACEBISOUSESARMAINDIREA.ERATENBERALAVETIEDORQUANTEISRION"; /* Dots should be nullprint characters */
        public static string[] unitnames = { "t", "kg", "g" };

        public static Tradegood[] Commodities = {
            new Tradegood(0x13,-0x02,0x06,0x01,0,"Food"),
            new Tradegood(0x14,-0x01,0x0A,0x03,0,"Textiles"),
            new Tradegood(0x41,-0x03,0x02,0x07,0,"Radioactives"),
            new Tradegood(0x28,-0x05,0xE2,0x1F,0,"Slaves"),
            new Tradegood(0x53,-0x05,0xFB,0x0F,0,"Liquor/Wines"),
            new Tradegood(0xC4,+0x08,0x36,0x03,0,"Luxuries"),
            new Tradegood(0xEB,+0x1D,0x08,0x78,0,"Narcotics"),
            new Tradegood(0x9A,+0x0E,0x38,0x03,0,"Computers"),
            new Tradegood(0x75,+0x06,0x28,0x07,0,"Machinery"),
            new Tradegood(0x4E,+0x01,0x11,0x1F,0,"Alloys"),
            new Tradegood(0x7C,+0x0d,0x1D,0x07,0,"Firearms"),
            new Tradegood(0xB0,-0x09,0xDC,0x3F,0,"Furs"),
            new Tradegood(0x20,-0x01,0x35,0x03,0,"Minerals"),
            new Tradegood(0x61,-0x01,0x42,0x07,1,"Gold"),
            new Tradegood(0xAB,-0x02,0x37,0x1F,1,"Platinum"),
            new Tradegood(0x2D,-0x01,0xFA,0x0F,2,"Gem-Strones"),
            new Tradegood(0x35,+0x0F,0xC0,0x07,0,"Alien Items")
        };

    }
}
