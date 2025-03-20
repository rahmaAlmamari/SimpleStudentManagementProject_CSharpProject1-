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
        static double[] marks = new double[3];
        static int[] Ages = new int[3];
        static string[] names = new string[3];
        static DateTime[] dates = new DateTime[3];
        static bool[] isPrinted = new bool[3];
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
                Console.WriteLine("2. Viewing All Students");
                Console.WriteLine("3. Searching for a Student by Name");
                Console.WriteLine("4. Calculating the Class Average");
                Console.WriteLine("5. Sorting Students by Marks (Descending Order)");
                Console.WriteLine("0.  Exit");

                Console.Write("\nEnter your option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: AddingNewStudent(); break;
                    case 2: ViewingAllStudents(); break;
                    case 3: SearchingForStudentByName(); break;
                    case 4: CalculatingClassAverage(); break;
                    case 5: SortingStudentsByMarksDescending(); break;
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
        //2. Viewing All Students .........
        static void ViewingAllStudents()
        {
            Console.WriteLine("Student Information: \nName | Age | Mark | Enrollment date\n");
            for(int i=0; i< names.Length; i++)
            {
                if (names[i] != "" && Ages[i] != 0 && marks[i] != 0)//to check if there is a record or not to print ..... 
                {
                    Console.WriteLine($"{names[i]} | {Ages[i]} | {marks[i]} | {dates[i]}");
                }
                else
                {
                    break;//to stop the printing process when the record is finish even if the array size not finish yet ....   
                }
            }

        }
        //3. Searching for a Student by Name  ......
        static void SearchingForStudentByName()
        {
            char choice;
            do
            {
                string search_name;//to store name to search for ......
                //string array_name;
                int flag = 0;// to now if there are no recored match the search_name and display not found
                Console.WriteLine("Enter student name:");
                search_name = Console.ReadLine().ToLower();

                for (int i = 0; i < StudentCounter; i++)// we use StudentCounter to loop based on the number of student exit ....
                {
                    // array_name = names[i].ToLower();
                    if (names[i].ToLower() == search_name)
                    {
                        Console.WriteLine("Student Information: \nName | Age | Mark | Enrollment date\n");
                        Console.WriteLine($"{names[i]} | {Ages[i]} | {marks[i]} | {dates[i]}");
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("Not found");
                }

                Console.WriteLine("Do you want to add anther student? y / n");
                choice = Console.ReadKey().KeyChar;

            } while (choice == 'y' || choice == 'Y');

        }
        //4. Calculating the Class Average ....
        static void CalculatingClassAverage()
        {
            double sum = 0;
            double Average;
            for (int i=0; i< StudentCounter; i++)
            {
                sum = sum + marks[i];
            }
            Average = sum / StudentCounter;
            double rounded_average = Math.Round(Average, 2);
            Console.WriteLine($"The student average is: {rounded_average}");
        }
        //5. Sorting Students by Marks (Descending Order) ...
        static void SortingStudentsByMarksDescending()
        {
            //to set all student as not printed ........
            for(int i=0; i< StudentCounter; i++)
            {
                isPrinted[i] = false;
            }
            for(int i=0; i< StudentCounter; i++)
            {
                double lar_mark = 0;
                int index = 0;
                for (int j=0; j< StudentCounter; j++)
                {
                    if (marks[j] > lar_mark)
                    {
                        lar_mark = marks[j];
                        index = Array.IndexOf(marks, marks[j]);
                    }
                }

            }
        }
    }
}
