using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy
{

    public class Planet
    {

        static string pairs0 = "ABOUSEITILETSTONLONUTHNO";

        static string[] govnames =
        {
            "Anarchy",		//0
			"Feudal",		//1
			"Multi-gov",	//2
			"Dictatorship", //3
			"Communist",	//4
			"Confederacy",	//5
			"Democracy",	//6
			"Corporate State" //7
			};

        public string[] econnames =
            {"Rich Ind","Average Ind","Poor Ind","Mainly Ind",
        "Mainly Agri","Rich Agri","Average Agri","Poor Agri"};

        public string[,] desc_list = new string[,]
        {
		/* 81 */	{"fabled", "notable", "well known", "famous", "noted"},
		/* 82 */	{" very", " mildly", " most", " reasonably", ""},
		/* 83 */	{"ancient", (char)0x95+"", "great", "vast", "pink"},
		/* 84 */	{(char)0x9E+" "+(char)0x9D+" plantations", "mountains", (char)0x9C+"", (char)0x94+" forests", "oceans"},
		/* 85 */	{"shyness", "silliness", "mating traditions", "loathing of "+(char)0x86, "love for "+(char)0x86},
		/* 86 */	{"food blenders", "tourists", "poetry", "discos", (char)0x8E+""},
		/* 87 */	{"talking tree", "crab", "bat", "lobst", (char)0xB2+""},
		/* 88 */	{"beset", "plagued", "ravaged", "cursed", "scourged"},
		/* 89 */	{(char)0x96+" civil war", (char)0x9B+" "+(char)0x98+" "+(char)0x99+"s", "a "+(char)0x9B+" disease", (char)0x96+" earthquakes", (char)0x96+" solar activity"},
		/* 8A */	{"its "+(char)0x83+" "+(char)0x84, "the "+(char)0xB1+" "+(char)0x98+" "+(char)0x99,"its inhabitants' "+(char)0x9A+" "+(char)0x85, (char)0xA1+"", "its "+(char)0x8D+" "+(char)0x8E},
		/* 8B */	{"juice", "brandy", "water", "brew", "gargle blasters"},
		/* 8C */	{(char)0xB2+"", (char)0xB1+" "+(char)0x99, (char)0xB1+" "+(char)0xB2, (char)0xB1+" "+(char)0x9B, (char)0x9B+" "+(char)0xB2},
		/* 8D */	{"fabulous", "exotic", "hoopy", "unusual", "exciting"},
		/* 8E */	{"cuisine", "night life", "casinos", "sit coms", " "+(char)0xA1+" "},
		/* 8F */	{(char)0xB0+"", "The planet "+(char)0xB0, "The world "+(char)0xB0, "This planet", "This world"},
		/* 90 */	{"n unremarkable", " boring", " dull", " tedious", " revolting"},
		/* 91 */	{"planet", "world", "place", "little planet", "dump"},
		/* 92 */	{"wasp", "moth", "grub", "ant", (char)0xB2+""},
		/* 93 */	{"poet", "arts graduate", "yak", "snail", "slug"},
		/* 94 */	{"tropical", "dense", "rain", "impenetrable", "exuberant"},
		/* 95 */	{"funny", "wierd", "unusual", "strange", "peculiar"},
		/* 96 */	{"frequent", "occasional", "unpredictable", "dreadful", "deadly"},
		/* 97 */	{(char)0x82+" "+(char)0x81+" for "+(char)0x8A, (char)0x82+" "+(char)0x81+" for "+(char)0x8A+" and "+(char)0x8A, (char)0x88+" by "+(char)0x89, (char)0x82+" "+(char)0x81+" for "+(char)0x8A+" but "+(char)0x88+" by "+(char)0x89," a"+(char)0x90+" "+(char)0x91},
		/* 98 */	{(char)0x9B+"", "mountain", "edible", "tree", "spotted"},
		/* 99 */	{(char)0x9F+"", (char)0xA0+"", (char)0x87+"oid", (char)0x93+"", (char)0x92+""},
		/* 9A */	{"ancient", "exceptional", "eccentric", "ingrained", (char)0x95+""},
		/* 9B */	{"killer", "deadly", "evil", "lethal", "vicious"},
		/* 9C */	{"parking meters", "dust clouds", "ice bergs", "rock formations", "volcanoes"},
		/* 9D */	{"plant", "tulip", "banana", "corn", (char)0xB2+"weed"},
		/* 9E */	{(char)0xB2+"", (char)0xB1+" "+(char)0xB2, (char)0xB1+" "+(char)0x9B, "inhabitant", (char)0xB1+" "+(char)0xB2},
		/* 9F */	{"shrew", "beast", "bison", "snake", "wolf"},
		/* A0 */	{"leopard", "cat", "monkey", "goat", "fish"},
		/* A1 */	{(char)0x8C+" "+(char)0x8B, (char)0xB1+" "+(char)0x9F+" "+(char)0xA2,"its "+(char)0x8D+" "+(char)0xA0+" "+(char)0xA2, (char)0xA3+" "+(char)0xA4, (char)0x8C+" "+(char)0x8B},
		/* A2 */	{"meat", "cutlet", "steak", "burgers", "soup"},
		/* A3 */	{"ice", "mud", "Zero-G", "vacuum", (char)0xB1+" ultra"},
		/* A4 */	{"hockey", "cricket", "karate", "polo", "tennis"}
        };


        int x;
        int y;       /* One byte unsigned */
        public int economy; /* These two are actually only 0-7  */
        int govtype;
        int techlev; /* 0-16 i think */
        int population;   /* One byte */
        int productivity; /* Two byte */
        int radius; /* Two byte (not used by game at all) */
        int[] goatsoupseed = new int[4];
        public Markettype market;
        /**
         * Used to save the planet string properties globally for this galaxy.
         */
        public int[] rnd_seed = new int[4];
        public string name;

        public Planet()
        { }

        public Planet(int x, int y, int economy, int govtype, int techlevel, int population, int productivity, int radius, int[] seed, String name)
        {
            this.x = x;
            this.y = y;
            this.economy = economy;
            this.govtype = govtype;
            this.techlev = techlevel;
            this.population = population;
            this.productivity = productivity;
            this.radius = radius;
            this.goatsoupseed = seed;
            this.name = name;
            this.market = new Markettype(0, this);
        }


        /**
         * Print data for given system 
         **/
        public void info(bool compressed)
        {
            StringBuilder str = new StringBuilder("");
            if (compressed)
            {
                str.Append(string.Format("%10s", this.name));
                str.Append(string.Format(" TL: %2d ", (this.techlev) + 1));
                str.Append(string.Format("%12s", econnames[this.economy]));
                str.Append(string.Format(" %15s", govnames[this.govtype]));
                Console.WriteLine(str.ToString());
            }
            else
            {
                Console.WriteLine("System:  ");
                Console.WriteLine(this.name);
                Console.WriteLine("\nPosition (%d,", this.x);
                Console.WriteLine("%d)", this.y);
                Console.WriteLine("\nEconomy: (%d) ", this.economy);
                Console.WriteLine(econnames[this.economy]);
                Console.WriteLine("\nGovernment: (%d) ", this.govtype);
                Console.WriteLine(govnames[this.govtype]);
                Console.WriteLine("\nTech Level: %2d", (this.techlev) + 1);
                Console.WriteLine("\nTurnover: %d", (this.productivity));
                Console.WriteLine("\nRadius: %d", this.radius);
                Console.WriteLine("\nPopulation: %d Billion", (this.population) >> 3);

                rnd_seed = this.goatsoupseed;
                Console.WriteLine("\n");
                goat_soup((char)0x8F + " is" + (char)0x97 + ".");
                Console.WriteLine();
            }
        }

        int gen_rnd_number()
        {
            int a, x;
            x = (rnd_seed[0] * 2) & 0xFF;
            a = x + rnd_seed[2];
            if (rnd_seed[0] > 127) a++;
            rnd_seed[0] = a & 0xFF;
            rnd_seed[2] = x;

            a = a / 256;    /* a = any carry left from above */
            x = rnd_seed[1];
            a = (a + x + rnd_seed[3]) & 0xFF;
            rnd_seed[1] = a;
            rnd_seed[3] = x;
            return a;
        }

        public void printName()
        {
            Console.WriteLine("%c%s", name[0], name.Substring(1).ToLower());
        }

        public void goat_soup(String source)
        {
            int j = 0;
            StringBuilder goaty = new StringBuilder("");
            for (j = 0; j < source.Length; j++)
            {
                short c = (short)(0XFFFF & source[j]);
                if (c == '\0') break;
                if (c < 0x80)
                    Console.WriteLine("%c", c);
			else
			{
                    if (c <= 0xA4)
                    {
                        int rnd = gen_rnd_number();
                        int mem = 0;
                        if (rnd >= 0x33) mem++;
                        if (rnd >= 0x66) mem++;
                        if (rnd >= 0x99) mem++;
                        if (rnd >= 0xCC) mem++;
                        goat_soup(desc_list[c - 0x81, mem]);
                    }
                    else switch (c)
                        {
                            case 0xB0: /* planet name */
                                {
                                    Console.WriteLine("%c%s", name[0], name.Substring(1).ToLower());
                                }
                                break;
                            case 0xB1: /* <planet name>ian */
                                {
                                    Console.WriteLine("%c%sian", name[0], name.Substring(1).ToLower());
                                }
                                break;
                            case 0xB2: /* random name */
                                {
                                    int i;
                                    int len = gen_rnd_number() & 3;
                                    for (i = 0; i < len; i++)
                                    {
                                        int x = (gen_rnd_number() & 0x3e) % 24;
                                        if (pairs0[x] != '.') goaty.Append(pairs0[x]);
                                        if (i > 0 && (pairs0[x + 1] != '.')) goaty.Append(pairs0[x + 1]);
                                    }
                                    Console.WriteLine("%c%s", goaty[0], goaty.ToString().Substring(1).ToLower());
                                }
                                break;
                            default: Console.WriteLine("<bad char in data [%X]>", c); return;
                        }   /* endswitch */
                }   /* endelse */
            }   /* endwhile */
        }	/* endfunc */

    }
}
