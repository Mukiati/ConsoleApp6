namespace ConsoleApp6
{
    internal class Program
    {
       static  string url = "http://localhost:3000";
        static ServerConnection connection = new ServerConnection(url);
        static void Main(string[] args)
        {
            //ciklus folyton meghívja a menut 
            while (true)
            {
                //futtatja a menüt
                Managemenu();
            }
        }
        //egy függvény ami kezei a menüt
        static void Managemenu()
        {
            //ki kell írni a menűt
            Writemenu();
            //be kell kérni egy számot
            int num = Getnumber(1, 6);
            //Console.WriteLine("sikeres szám megadás!" + num);
            //kiválasztja a menút
            Switchmenu(num);
            Console.ReadKey();
        }
        //egy fugvény ami kírja a menüt
        static void Writemenu()
        {
            //subject
           
            Console.Clear();
            Console.WriteLine("1. adatok listázása");
            Console.WriteLine("2. adat létrehozása");
            Console.WriteLine("3. legnagyobb adat");
            Console.WriteLine("4. legkisebb adat");
            Console.WriteLine("5. adat törlése");
            Console.WriteLine("6. kilépés");
            Console.WriteLine();
        }
        //egy függvény ami megnézi helyes e a beírt szám
        static int Getnumber(int min = int.MinValue,int max = int.MaxValue)
        {
            Console.Write("Add meg a számot!");
            string line = Console.ReadLine().Trim(' ',',','.');
            int result = 0;
            if (int.TryParse(line, out result))
                if (result >= min && result <= max)
                    return result;
                else
                {
                    Console.WriteLine("Nem megfelelő a szám tartománya");
                }
            else
            
                Console.WriteLine("nem szám lett megadva");
            result = Getnumber(min, max);
            return result;


        }
        //egy függvény ami megnézi melyik számot írtuk be 
        static void Switchmenu(int num)
        {
            switch (num)
            {
                case 1:
                    funcone();
                   
                    break;
                case 2:
                    functwo();
                    
                    break;
                case 3:
                    functhree();
                    
                    break;
                case 4:
                    funcfour();
                    
                    break;
                case 5:
                    funcfive();
                    
                    break;
                case 6:
                    funcsix();
                    
                    break;

                default:
                    Console.WriteLine("Hibás menü pont");
                    break;
            }
        }

        //egy függvény az első funkcióra
        static void funcone()
        {

            connection.GetSubjects();
            for (int i = 0; i < connection.result.Count; i++)
            {

                Console.WriteLine("Adatok a listában : "+connection.result[i].name);
            }
           
        }
        //egy függvény a második funkcióra
        static void functwo()
        {
            Console.WriteLine("add meg mit szeretnél hozzáadni");
            string input = Console.ReadLine();
            connection.PostSubject(input);
        }
        //egy függvény a harmadik funkcióra
        static void functhree()
        {
            connection.GetSubjects();
            string longest = "a";
            foreach (Subject item in connection.result)
            {
                if (item.name.Length > longest.Length)
                {
                    longest = item.name;
                }
            }
            Console.WriteLine("leghoszabb" + longest);


        }
        //egy függvény a negyedik funkcióra
        static void funcfour()
        {
            connection.GetSubjects();
            string shortest = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            foreach (Subject item in connection.result)
            {
                if (item.name.Length <shortest.Length)
                {
                    shortest = item.name;
                }
            }
            Console.WriteLine("legrövidebb" + shortest);

        }
        //egy függvény az ötödik funkcióra
        static void funcfive()
        {
            Console.WriteLine("add meg az id annak amit ki akarsz törölni");
            int num = Convert.ToInt32(Console.ReadLine());
            connection.DeleteSubject(num);
        }
        //egy függvény a hatodik funkcióra
        static void funcsix()
        {
            Environment.Exit(0);
        }
        //egy függvény a kilépésre
        static void funcexit()
        {
            Environment.Exit(0);
        }
    }
}
