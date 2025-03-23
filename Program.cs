using System;

namespace Project1
{
    internal class Program
    {
        /*
         *  add the program need ....
         *
         *Simple Student Management Project ( C# project 1 ) 
         *
          Develop a simple Student Management System that allows a user (admin) to manage student records. 
          The program should support the following operations: 
         *   1. Add a new student record (Name, Age, Marks) 
             2. View all students with formatted output and subject-wise marks. 
             3. Find a student by name (case-insensitive search) 
             4. Calculate the class average (rounded to 2 decimals). 
             5. Find the top-performing student 
             6. Sort students by marks (highest to lowest) 
             7. Delete a student record (handle shifting logic). 
             8. Exit the system 
        //----------------------------------------
           Required Logic and Implementation Details 
             1. Menu System (Using switch-case & loop) 
                • The program should display a menu allowing the admin to select an option. 
                • The menu should keep repeating until the user selects "Exit." 
         *   2. Storing Student Data (Using Arrays) 
                • Use parallel arrays:  
                  o string[] names → Student Names 
                  o int[] ages → Student Ages 
                  o double[] marks → Student Marks 
                  o DateTime[] enrollmentDate → Student Enrollment Date 
                • Keep track of the total number of students using a variable. 
             3. Adding a New Student (Input & Array Insertion) 
                • Ask for student details (name, age, marks). - 
                    age (validated > 21 ), marks (validated 0-100), and enrollment date (DateTime.Now). 
                • Store them in the next available index of the arrays. 
                • Ensure the user cannot add more than MAX_STUDENTS. 
             4. Viewing All Students 
                • Loop through the arrays and display all stored students.
             5. Searching for a Student by Name 
                • Ask the user for a name. 
                • Loop through the names array to find a match. - 
                    Convert both input and stored names to lowercase before comparing. 
                • If found, print the student details. Otherwise, display "Not found". 
             6. Calculating the Class Average 
                • Loop through marks[] and sum all values. 
                • Divide by studentCount and round the result using Math.Round(). 
             7. Sorting Students by Marks (Descending Order) 
                • Sort marks[] in descending order, swapping names[] and ages[] accordingly. 
             8. Deleting a Student 
                • Ask for a name to delete. 
                • Find the index of the student. 
                • Shift all elements to the left to remove the record. 
         *
         *
         */
        // declare the array and variable needed ....
        static double[] marks = new double[3];
        static int[] Ages = new int[3];
        static string[] names = new string[3];
        static DateTime[] dates = new DateTime[3];
        static bool[] isPrinted = new bool[3];
        static int[] sorted_index = new int[3];
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
                Console.WriteLine("6. Deleting a Student");
                Console.WriteLine("0.  Exit");

                Console.Write("\nEnter your option: \n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: AddingNewStudent(); break;
                    case 2: ViewingAllStudents(); break;
                    case 3: SearchingForStudentByName(); break;
                    case 4: CalculatingClassAverage(); break;
                    case 5: SortingStudentsByMarksDescending(); break;
                    case 6: DeletingStudent(); break;
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
                    while(Ages[StudentCounter] < 21)
                    {
                        Console.WriteLine("Sory you can not add student age under 21 years old !\n " +
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
                Console.WriteLine();//to give time befor going to the next step .... 

            } while (choice == 'y' || choice == 'Y');


        }
        //2. Viewing All Students .........
        static void ViewingAllStudents()
        {
            Console.WriteLine("Student Information: \nName | Age | Mark | Enrollment date\n");
            //for(int i=0; i< names.Length; i++)
            //{
            //    if (names[i] != "" && Ages[i] != 0 && marks[i] != 0)//to check if there is a record or not to print ..... 
            //    {
            //        Console.WriteLine($"{names[i]} | {Ages[i]} | {marks[i]} | {dates[i]}");
            //    }
            //    else
            //    {
            //        break;//to stop the printing process when the record is finish even if the array size not finish yet ....   
            //    }
            //}
            for (int i = 0; i < StudentCounter; i++)//to view the remain student .... 
            {
                Console.WriteLine($"{names[i]} | {Ages[i]} | {marks[i]} | {dates[i]}");
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

                Console.WriteLine("Do you want to search for anther student? y / n");
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
            for(int i=0; i< StudentCounter; i++)//to loop in all student .....
            {
                double lar_mark = 0;
                int index = 0;
                for (int j=0; j< StudentCounter; j++)
                {
                    if (marks[j] > lar_mark && isPrinted[j] == false)
                    {
                        lar_mark = marks[j];
                        index = Array.IndexOf(marks, marks[j]);
                    }
                }
                sorted_index[i] = index;
                isPrinted[index] = true;

            }
            Console.WriteLine("Student Information (Descending Order): " +
                  "\n\nName | Age | Mark | Enrollment date");
            for(int i=0; i<StudentCounter; i++)
            {
                Console.WriteLine($"{names[sorted_index[i]]} | {Ages[sorted_index[i]]} |" +
                                  $" {marks[sorted_index[i]]} | {dates[sorted_index[i]]}");
            }
        }
        //6. Deleting a Student .....
        static void DeletingStudent()
        {
            char choice;
            do
            {
                //to store name to delete ......
                string delete_name;
                int delete_index = 0;
                // to now if there are no recored match the delete_name and display not found ...
                int flag = 0;
                Console.WriteLine("Enter student name you want to delete:");
                delete_name = Console.ReadLine().ToLower();
                // loop to now if delete_name is exit in the recored or not ....
                for (int i = 0; i < StudentCounter; i++)
                {
                    if (names[i].ToLower() == delete_name)
                    {
                        delete_index = Array.IndexOf(names, names[i]);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    Console.WriteLine($"Student {names[delete_index]} is deleted successfully \n");
                    StudentCounter--;
                    // loop to remove delete_name from the recored and shift all elements to the left after delete_name ... 
                    for (int i = delete_index; i < StudentCounter; i++)
                    {
                        names[i] = names[i + 1];
                        Ages[i] = Ages[i + 1];
                        marks[i] = marks[i + 1];
                        dates[i] = dates[i + 1];
                    }
                    Console.WriteLine("Student Information: \nName | Age | Mark | Enrollment date\n");
                    for (int i = 0; i < StudentCounter; i++)//to view the remain student .... 
                    {
                        Console.WriteLine($"{names[i]} | {Ages[i]} | {marks[i]} | {dates[i]}");
                    }
                }

                Console.WriteLine("Do you want to delete anther student? y / n");
                choice = Console.ReadKey().KeyChar;

            } while (choice == 'y' || choice == 'Y');


        }
    }
}
