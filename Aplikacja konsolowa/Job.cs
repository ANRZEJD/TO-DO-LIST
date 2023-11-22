using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Aplikacja_konsolowa
{
    internal class Job
    {
        public int Id { get; set; }
        public string Namejob { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCopmlited { get; set; }

        public Job(int id, string namejob, DateTime deadline, bool isCopmlited)
        {
            Id = id;
            Namejob = namejob;
            Deadline = deadline;
            IsCopmlited = isCopmlited;
        }
    }
    


}
