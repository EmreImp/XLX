using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy
{
	class Defitions
	{
        const int galsize = 256;
        const int AlienItems = 16;

        const int lasttrade = AlienItems;

        const int numforLave = 7;       /* Lave is 7th generated planet in galaxy one */
        const int numforZaonce = 129;
        const int numforDiso = 147;
        const int numforRied = 46;

        const int fuelcost = 2; /* 0.2 CR/Light year */
        const int maxfuel = 70; /* 7.0 LY tank */

        const UInt16 base0 = 0x5A4A;
        const UInt16 base1 = 0x0248;
        const UInt16 base2 = 0xB753;  /* Base seed for galaxy 1 */

        seedtype seed;
        fastseedtype rnd_seed;
        bool nativerand;

        internal Planet Galaxy { get => galaxy; set => galaxy = value; }

        const string Pairs0 =
        "ABOUSEITILETSTONLONUTHNOALLEXEGEZACEBISOUSESARMAINDIREA.ERATENBERALAVETIEDORQUANTEISRION";
        const string Pairs = "..LEXEGEZACEBISO"+
			   "USESARMAINDIREA."+
			   "ERATENBERALAVETI"+
			   "EDORQUANTEISRION"; /* Dots should be nullprint characters */

        string[] GovermentTypes={
            "Anarchy","Feudal","Multi-gov","Dictatorship",
            "Communist","Confederacy","Democracy","Corporate State"
        };

        string[] econnames={
            "Rich Ind","Average Ind","Poor Ind","Mainly Ind",
            "Mainly Agri","Rich Agri","Average Agri","Poor Agri"
        };

        string[] Unitnames = {"t","kg","g"};

    }

    struct fastseedtype
    {
        UInt16 a, b, c, d;
    }

    struct seedtype
    {
        UInt16 w0;
        UInt16 w1;
        UInt16 w2;
    } 

    struct Planet
    {
        uint x;
        uint y;       /* One byte unsigned */
        uint economy; /* These two are actually only 0-7  */
        uint govtype;
        uint techlev; /* 0-16 i think */
        uint population;   /* One byte */
        uint productivity; /* Two byte */
        uint radius; /* Two byte (not used by game at all) */
        fastseedtype goatsoupseed;
        string name;
    }


    struct Tradegood
    {                         /* In 6502 version these were: */
        uint baseprice;        /* one byte */
        UInt16 gradient;   /* five bits plus sign */
        uint basequant;        /* one byte */
        uint maskbyte;         /* one byte */
        uint units;            /* two bits */
        string name;         /* longest="Radioactives" */
    }


    struct Markettype
    {
        public uint Quantity { get => Quantity; set => Quantity = value; }
        public uint Price { get => Price; set => Price = value; }
    }

    struct Player
    {
        /* Player workspace */
        Planet currentplanet;           /* Current planet */
        uint galaxynum;               /* Galaxy number (1-8) */
        UInt32 cash;
        uint fuel;
        Markettype localmarket;
        uint holdspace;
        public uint Shipshold { get => Shipshold; set => Shipshold = value; }
    }
    






}
