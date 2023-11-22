using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Aplikacja_konsolowa
{
    internal class JobADE
    {

        public static void AddJob(List<Job> job, string namejob, DateTime deadline)
        {
            Job newJob = new Job(job.Count + 1, namejob, deadline, false);
            job.Add(newJob);
            Console.WriteLine("Your task number {0}", job.Count);
        }

        public static void DeleteJob(List<Job> job, int id)
        {
            if (id >= 1 && id <= job.Count)
            {
                job.RemoveAt(id - 1);
                
            }
            else
            {
            
                return;
            }
        }
        public static void EdditJob(List<Job> job, int id, string newname, DateTime newdeadline)
        {
            if (id >= 1 && id <= job.Count)
            {
                Job jobToEdit = job[id - 1];
                jobToEdit.Namejob = newname;
                jobToEdit.Deadline = newdeadline;
            }
            else
            {
                return;
            }
        }

        public static void Copletejob(List<Job> job, int id, bool isComplited)
        {
           
            if (id >= 1 && id <= job.Count)
            {
                job[id - 1].IsCopmlited = true;
             
            }
            else
            {
                return;
            }
        }
       
    
        


    }
   
} 





        


    

