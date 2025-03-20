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


        // main method .............
        static void Main(string[] args)
        {
            while (true) // we use while loop to repeat the process and we set true so it will not stop ... 
            {
                Console.Clear();
                Console.WriteLine("System Menu \n");
                Console.WriteLine("Select option: ");
                Console.WriteLine("1. Adding a New Student");
                Console.WriteLine("0.  Exit");

                Console.Write("\nEnter your option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: AddingNewStudent(); break;
                    case 0: Console.WriteLine("Have a nice day ..."); return;
                    default: Console.WriteLine("\n You enter unaccepted option! ... try again"); break;
                }
                Console.ReadLine();// we add this line just to stop the program from clear 'Console.Clear();' the screen before the user see the result ...

            }
        }


        //1. Adding a New Student .......
        static void AddingNewStudent()
        {
            char choice;
            do
            {
                if(StudentCounter < names.Length)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the following student details:");

                    //to add student name into array names ....
                    Console.WriteLine("Student Name:");
                    names[StudentCounter] = Console.ReadLine();

                    //to add student age into array ages ....
                    Console.WriteLine("Student Age:");
                    Ages[StudentCounter] = int.Parse(Console.ReadLine());
                    while(Ages[StudentCounter] > 21)
                    {
                        Console.WriteLine("Sory you can not add student age above 21 years old !\n " +
                                          "Please enter anther age:");
                        Ages[StudentCounter] = int.Parse(Console.ReadLine());

                    }
                    //to add student mark into array marks ....
                    Console.WriteLine("Student Mark:");
                    marks[StudentCounter] = double.Parse(Console.ReadLine());
                    while(marks[StudentCounter] < 0 || marks[StudentCounter] > 100)
                    {
                        Console.WriteLine("Sory student mark should be (0-100) !\n " +
                                          "Please enter anther mark:");
                        marks[StudentCounter] = double.Parse(Console.ReadLine());
                    }

                    //to add date of taday into array dates ....
                    dates[StudentCounter] = DateTime.Now;

                    // so the system now that there are one more student added ......
                    StudentCounter++;
                    Console.WriteLine("Do you want to add anther student? y / n");
                    choice = Console.ReadKey().KeyChar;
                }
                else
                {
                    Console.WriteLine("Sory you can not add more student there are no space remain!");
                    Console.WriteLine();
                    choice = 'n';
                }
     

            } while (choice == 'y' || choice == 'Y');


        }
    }
}
