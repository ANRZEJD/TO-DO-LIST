using Aplikacja_konsolowa;
using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;


class Program
{ 
    static void Main()
    {   
        
        List<Users> users = new List<Users>
        {
           new Users("Andrzej", "4R3e2W1q"),

        };
        List<Job> job = new List<Job>
        {

        };
        StreamWriter  ZW;
        int errorlicznik = 0;
        string file  = @"C:\Users\Andrzej\source\repos\Aplikacja konsolowa\errors.txt";
        int licznik = 0;
        bool skrt = true;
        bool login = false;
        bool   uspass = true;
        while (uspass)
        {
            foreach (Users user in users)
            {
                Console.WriteLine("Name");
                string name = Console.ReadLine();
                Console.WriteLine("Password");
                string haslo = Console.ReadLine();
                if (user.Username == name && user.Password == haslo)
                {
                    Console.WriteLine("Login successful");
                    login = true;
                    uspass = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid login information, please try again");
                    continue;
                }
            }
        }
        while (skrt)
        {
            
                if (login)
                {
                try
                {


                    Console.WriteLine("1. Display tasks");
                    Console.WriteLine("2. Generate Report");
                    Console.WriteLine("3. Operations on tasks");
                    Console.WriteLine("4. Close the program");
                    int wybor = int.Parse(Console.ReadLine());
                    if (wybor == 1)
                    {
                        if (job.Count == 0)
                        {
                            Console.WriteLine("You don't have any tasks");
                        }
                        else
                        {
                            foreach (Job job2 in job)
                            {
                                string jobString = $"ID: {job2.Id}, Nazwa zadania: {job2.Namejob}, Deadline: {job2.Deadline}, Ukończone: {job2.IsCopmlited}";
                                Console.WriteLine(jobString);
                            }
                        }
                    }
                    else if (wybor == 2)
                    {
                        Console.WriteLine("You have completed {0} tasks", licznik);
                    }
                    else if (wybor == 3)
                    {
                        try
                        {
                            Console.WriteLine("1. Create a new task");
                            Console.WriteLine("2. Delete a task ");
                            Console.WriteLine("3. Edit a task");
                            Console.WriteLine("4. Mark as completed");
                            int choice1 = int.Parse(Console.ReadLine());
                            if (choice1 == 1)
                            {
                                try
                                {
                                    Console.WriteLine("Give your task a name");
                                    string namez = Console.ReadLine();
                                    Console.WriteLine("By when do you need to complete the task (YYYY-MM-DD HH:MM) ?");
                                    DateTime deadlinedate = Convert.ToDateTime(Console.ReadLine());
                                    JobADE.AddJob(job, namez, deadlinedate);
                                    Console.WriteLine("Task added successfully");
                                }
                                catch (Exception ex)
                                {
                                    errorlicznik++;
                                    Console.WriteLine("AN ERROR OCCURREDD :" + ex.Message);
                                    ZW = new StreamWriter(file, true);
                                    string errormsg = $"{errorlicznik} . {DateTime.Now} : {ex.Message}";
                                    ZW.WriteLine(errormsg);
                                    ZW.Close();
                                }

                            }
                            else if (choice1 == 2)
                            {
                                try
                                {
                                    Console.WriteLine("Provide the task number you want to delete");
                                    int idzad = int.Parse(Console.ReadLine());
                                    if (idzad == job.Count)
                                    {
                                        JobADE.DeleteJob(job, idzad);
                                        Console.WriteLine("Task deleted successfully");
                                    }
                                    else
                                    {

                                        Console.WriteLine("Wrong number");
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    errorlicznik++;
                                    Console.WriteLine("AN ERROR OCCURREDD :" + ex.Message);
                                    ZW = new StreamWriter(file, true);
                                    string errormsg = $"{errorlicznik} . {DateTime.Now} : {ex.Message}";
                                    ZW.WriteLine(errormsg);
                                    ZW.Close();
                                }
                            }
                            else if (choice1 == 3)
                            {
                                try
                                {
                                    Console.WriteLine("Enter the task number you want to edit");
                                    int idzad = int.Parse(Console.ReadLine());
                                    if (idzad == job.Count)
                                    {
                                        try
                                        {
                                            Console.WriteLine("Enter a new name");
                                            string newname1 = Console.ReadLine();
                                            Console.WriteLine("By when do you need to complete the task (YYYY-MM-DD HH:MM) ?");
                                            DateTime deadlinedate = Convert.ToDateTime(Console.ReadLine());
                                            JobADE.EdditJob(job, idzad, newname1, deadlinedate);
                                        }
                                        catch (Exception ex)
                                        {
                                            errorlicznik++;
                                            Console.WriteLine("AN ERROR OCCURREDD :" + ex.Message);
                                            ZW = new StreamWriter(file, true);
                                            string errormsg = $"{errorlicznik} . {DateTime.Now} : {ex.Message}";
                                            ZW.WriteLine(errormsg);
                                            ZW.Close();
                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong number");
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    errorlicznik++;
                                    Console.WriteLine("AN ERROR OCCURREDD :" + ex.Message);
                                    ZW = new StreamWriter(file, true);
                                    string errormsg = $"{errorlicznik} . {DateTime.Now} : {ex.Message}";
                                    ZW.WriteLine(errormsg);
                                    ZW.Close();
                                }

                            }
                            else if (choice1 == 4)
                            {
                                try
                                {
                                    Console.WriteLine("Enter the task number you wish to edit.");
                                    int idzad = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Is the task completed Y/N?");
                                    string choice2 = Console.ReadLine();
                                    choice2 = choice2.ToUpper();

                                    if (choice2 != null)
                                    {
                                        if (choice2 == "T")
                                        {
                                            JobADE.Copletejob(job, idzad, true);
                                            licznik++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Complete the task first");

                                        }


                                    }
                                }
                                catch (Exception ex) 
                                {
                                    errorlicznik++;
                                    Console.WriteLine("AN ERROR OCCURREDD :" + ex.Message);
                                    ZW = new StreamWriter(file, true);
                                    string errormsg = $"{errorlicznik} . {DateTime.Now} : {ex.Message}";
                                    ZW.WriteLine(errormsg);
                                    ZW.Close();
                                }




                            }

                            else
                            {
                                Console.WriteLine("Wrong choice, please choose again");
                                continue;
                            }
                        }
                        catch (Exception ex)
                        {
                            errorlicznik++;
                            Console.WriteLine("AN ERROR OCCURREDD :" + ex.Message);
                            ZW = new StreamWriter(file, true);
                            string errormsg = $"{errorlicznik} . {DateTime.Now} : {ex.Message}";
                            ZW.WriteLine(errormsg);
                            ZW.Close();
                        }
                    }
                    else if (wybor == 4)
                    {
                        Console.WriteLine("End");
                        skrt = false;
                        Environment.Exit(0);


                    }
                }
                catch (Exception ex)
                {
                    errorlicznik++;
                    Console.WriteLine("AN ERROR OCCURREDD :" + ex.Message);
                    ZW = new StreamWriter(file,true);
                    string errormsg = $"{errorlicznik} . {DateTime.Now} : {ex.Message}";
                    ZW.WriteLine(errormsg);
                    ZW.Close();

                }

            }
                else
                {
                    skrt = false;
                    break;
                  
                   
                }

                

            
        }

    }




}


        

                
        

    
