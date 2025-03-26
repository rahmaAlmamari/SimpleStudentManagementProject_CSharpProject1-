using System;
using System.Text.RegularExpressions;

namespace Project1
{
    internal class Program
    {
        /*
         *  add the program needs ....
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
        static double[] marks = new double[4];
        static int[] Ages = new int[4];
        static string[] names = new string[4];
        static DateTime[] dates = new DateTime[4];
        static bool[] isPrinted = new bool[4];
        static int[] sorted_index = new int[4];
        static int StudentCounter = 0;


        // main method .............
        static void Main(string[] args)
        {
            // we use while loop to repeat the process and we set true so it will not stop ... 
            while (true) 
            {
                //just to clear the screen ...
                Console.Clear();
                Console.WriteLine("System Menu \n");
                Console.WriteLine("Select option: ");
                Console.WriteLine("1. Adding a New Student");
                Console.WriteLine("2. Viewing All Students");
                Console.WriteLine("3. Searching for a Student by Name");
                Console.WriteLine("4. Calculating the Class Average");
                Console.WriteLine("5. Find the top-performing student");
                Console.WriteLine("6. Sorting Students by Marks (Descending Order)");
                Console.WriteLine("7. Deleting a Student");
                Console.WriteLine("0. Exit");

                int choice = 0;
                // to check if the user int right input or not ... 
                bool flag = false;
                // use try and catch to make sure the the user will input the right input ...
                try
                {
                    Console.Write("\nEnter your option: \n");
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("choosing option process is stoped due to: " + e.Message);
                    Console.ReadLine();//just to hold second ...
                    flag = true;
                }


                if (flag)//it mean if flag is true do the following.. if not do else ...
                {
                    Console.WriteLine("Try to enter one option in the menu plases ... ");
                    Console.ReadLine();//just to hold second ...
                }
                else
                {
                    //switch condation to choose between the functions ...
                    switch (choice)
                    {
                        case 1: AddingNewStudent(); break;
                        case 2: ViewingAllStudents(); break;
                        case 3: SearchingForStudentByName(); break;
                        case 4: CalculatingClassAverage(); break;
                        case 5: FindTopPerformingStudent(); break;
                        case 6: SortingStudentsByMarksDescending(); break;
                        case 7: DeletingStudent(); break;
                        case 0: Console.WriteLine("Have a nice day ..."); return;
                        default: Console.WriteLine("\n You enter unaccepted option! ... try again"); break;
                    }
                    // we add this line just to stop the program from clear 'Console.Clear();'
                    // the screen before the user see the result ...
                    Console.ReadLine();
                }

            }
        }


        //1. Adding a New Student .......
        static void AddingNewStudent()
        {
            char choice;
            // do loop to repeat the process of adding new student 
            //based on the user choice ...
            do
            {
                //declare variables to holde student info ...
                string student_name;
                int student_age = 0;
                double student_mark = 0;
                DateTime student_date;

                //to make such that the user do not enter record more than
                // the arrays size ...
                if(StudentCounter < names.Length)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the following student details:");

                    //student name input process code ... 
                    bool flag_name = false;//to know if the name add or not ...
                    do
                    {
                        //to store student name into student_name variable ....
                        Console.WriteLine("Student Name:");
                        student_name = Console.ReadLine();
                        bool check_name = IsAlpha(student_name);
                        //Console.WriteLine(check_name);
                        if (check_name == false)
                        {
                            Console.WriteLine("Student name can not contains number and con not be null ..." +
                                              "please enter student name again");
                            flag_name = true;
                        }
                        else
                        {
                            flag_name = false;
                        }

                    } while (flag_name);


                    //student age input process code ... 
                    bool flag_age = true;//to know if the age add or not ...
                    do
                    {
                        try
                        {
                            //to store student age into student_age variable ....
                            Console.WriteLine("Student Age (msut be above 21 years old):");
                            student_age = int.Parse(Console.ReadLine());
                            //to check if the age is vailde or not (age must be above 21) ...
                            if (student_age < 21)
                            {
                                //Console.WriteLine("Student Age (msut be above 21 years old):");
                                //Ages[StudentCounter] = int.Parse(Console.ReadLine());
                                Console.WriteLine("Student age not vaild");
                            }
                            else
                            {
                                flag_age = false;
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Student age not add due to: " + e.Message);
                        }
    
                    } while (flag_age);

                    //student mark input process code ... 
                    bool flag_mark = true;//to know if the mark add or not ...
                    do
                    {
                        try
                        {
                            
                            //to store student mark into student_mark variable ....
                            Console.WriteLine("Student Mark (must be btween 0-100):");
                            student_mark = double.Parse(Console.ReadLine());
                            //to check if the mark is vailde or not (mark must be between 0-100) ...
                            if (student_mark < 0 || student_mark > 100)
                            {
                                //Console.WriteLine("Student Mark (must be btween 0-100):");
                                //marks[StudentCounter] = double.Parse(Console.ReadLine());
                                Console.WriteLine("Student mark not vaild");
                            }
                            else
                            {
                                flag_mark = false;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Student mark not add due to: " + e.Message);
                        }

                    } while (flag_mark);


                    //to store date of taday into student_date varible ....
                    student_date = DateTime.Now;

                    //to store student info in the arrays ...
                    names[StudentCounter] = student_name;
                    Ages[StudentCounter] = student_age;
                    marks[StudentCounter] = student_mark;
                    dates[StudentCounter] = student_date;
                    // so the system know that there are one more student added ......
                    StudentCounter++;
                    Console.WriteLine("Student add successfully ...");
                    Console.WriteLine("Do you want to add anther student? y / n");
                    choice = Console.ReadKey().KeyChar;
                    Console.ReadLine();//just to hold second ...
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

            //to print all the recored based on StudentCounter ...
            for (int i = 0; i < StudentCounter; i++) 
            {
                Console.WriteLine($"{names[i]} | {Ages[i]} | {marks[i]} | {dates[i]}");
            }

        }
        //3. Searching for a Student by Name  ......
        static void SearchingForStudentByName()
        {
            char choice;
            // do loop to repeat the process of searching for student by name 
            //based on the user choice ...
            do
            {
                // to now if there are no recored match the search_name and display not found ...
                int flag = 0;
                //to store name to search for ...
                string search_name;
                //to check if the string input valid or not ...
                bool flag_name = false;
                do
                {
                    //string array_name;
                    Console.WriteLine("Enter student name:");
                    search_name = Console.ReadLine().ToLower();
                    //calling IsAlpha method to test the string input ...
                    bool check_name = IsAlpha(search_name);
                    if (check_name == false)
                    {
                        Console.WriteLine("Search name can not contains number and con not be null ..." +
                                          "please enter search name again");
                        flag_name = true;
                    }
                    else
                    {
                        flag_name = false;
                    }

                } while (flag_name);


                // we use StudentCounter to loop based on the number of student exit ....
                for (int i = 0; i < StudentCounter; i++)
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
                Console.ReadLine();//just to hold second ...

            } while (choice == 'y' || choice == 'Y');

        }
        //4. Calculating the Class Average ....
        static void CalculatingClassAverage()
        {
            // to hold the sum of all student marks ... 
            double sum = 0;
            double Average;
            // we use StudentCounter to loop based on the number of student exit ....
            for (int i=0; i< StudentCounter; i++)
            {
                sum = sum + marks[i];
            }
            Average = sum / StudentCounter;
            double rounded_average = Math.Round(Average, 2);
            Console.WriteLine($"The student average is: {rounded_average}");
        }
        //5. Find the top-performing student ....
        static void FindTopPerformingStudent()
        {
            double lar_mark = 0;
            int index = 0;
            for(int i=0; i<StudentCounter; i++)
            {
                //to find the largest mark in marks array ...
                if (marks[i] > lar_mark)
                {
                    lar_mark = marks[i];
                    //index = Array.IndexOf(marks, marks[i]);
                    //to store the index of the largest mark ...
                    index = i;
                }
            }
            //print top performing student detail based on index ... 
            Console.WriteLine($"The top performing student is: {names[index]} with mark: {lar_mark}");
        }
        //6. Sorting Students by Marks (Descending Order) ...
        static void SortingStudentsByMarksDescending()
        {
            //to set all student as not printed ...
            for(int i=0; i< StudentCounter; i++)
            {
                isPrinted[i] = false;
            }
            //to loop in all student ...
            for (int i=0; i< StudentCounter; i++)
            {
                double lar_mark = 0;
                int index = 0;
                //to loop each mark in all marks ...
                for (int j=0; j< StudentCounter; j++)
                {
                    //to check if the mark we hold (marks[j]) is largest
                    //mark or not and if it printed or not ...
                    if (marks[j] > lar_mark && isPrinted[j] == false)
                    {
                        lar_mark = marks[j];
                        //index = Array.IndexOf(marks, marks[j]);
                        //to store the index of the largest mark ...
                        index = j;
                    }
                }
                //to store index of largest mark which is not printed yet in sorted_array ...
                sorted_index[i] = index;
                //to set the largest mark as printed in isPrinted array so we do not print it again ...
                isPrinted[index] = true;

            }
            Console.WriteLine("Student Information (Descending Order): " +
                  "\n\nName | Age | Mark | Enrollment date");
            //to print all student recored after we sorted them (Descending Order) ...
            for (int i=0; i<StudentCounter; i++)
            {
                Console.WriteLine($"{names[sorted_index[i]]} | {Ages[sorted_index[i]]} |" +
                                  $" {marks[sorted_index[i]]} | {dates[sorted_index[i]]}");
            }
        }
        //7. Deleting a Student .....
        static void DeletingStudent()
        {
            char choice;
            // do loop to repeat the process of deleting student 
            //based on the user choice ...
            do
            {
                // to know if there are no recored match the delete_name and display not found ...
                int flag = 0;
                int delete_index = 0;
                //to store name to delete ......
                string delete_name;
                //to check if the string input valid or not ...
                bool flag_name = false;
                do
                {
                    Console.WriteLine("Enter student name you want to delete:");
                    delete_name = Console.ReadLine().ToLower();
                    //calling IsAlpha method to test the string input ...
                    bool check_name = IsAlpha(delete_name);
                    if (check_name == false)
                    {
                        Console.WriteLine("Delete name can not contains number and con not be null ..." +
                                          "please enter delete name again");
                        flag_name = true;
                    }
                    else
                    {
                        flag_name = false;
                    }

                } while (flag_name);

                // loop to know if delete_name is exit in the recored or not ....
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
                    //delete logic ...
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
                    //to view the remain student ....
                    for (int i = 0; i < StudentCounter; i++) 
                    {
                        Console.WriteLine($"{names[i]} | {Ages[i]} | {marks[i]} | {dates[i]}");
                    }
                }

                Console.WriteLine("Do you want to delete anther student? y / n");
                choice = Console.ReadKey().KeyChar;
                Console.ReadLine();//just to hold second ...

            } while (choice == 'y' || choice == 'Y');


        }


        //ADDITIONAL METHODS ...
        //1. To check of the string contains something other than letters (this methos return true or false)....
        static bool IsAlpha(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
    }
}
