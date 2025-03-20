namespace Project1
{
    internal class Program
    {
        /*
         *  add the program need ....
         *
         *
         *
         *
         *
         *
         */
        // declare the array and variable needed ....
        static double[] marks = new double[10];
        static int[] Ages = new int[10];
        static string[] names = new string[10];
        static DateTime[] dates = new DateTime[10];
        static int StudentCounter = 0;

        static void Main(string[] args)
        {
            while (true) // we use while loop to repeat the process and we set true so it will not stop ... 
            {
                Console.Clear();
                Console.WriteLine("System Menu \n");
                Console.WriteLine("Select option: ");
                Console.WriteLine("1.  Simple Calculator");
                Console.WriteLine("0.  Exit");

                Console.Write("Enter your option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:  break;
                    case 0: Console.WriteLine("Have a nice day ..."); return;
                    default: Console.WriteLine("\n You enter unaccepted option! ... try again"); break;
                }
                Console.ReadLine();// we add this line just to stop the program from clear 'Console.Clear();' the screen before the user see the result ...

            }
        }
    }
}
