using EntityFramworkCore.Data;
using EntityFramworkCore.Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Transactions;

namespace EntityFramworkCore.ConsoleApp
{
    internal class Program
    {
        private static ApplicationDbContext context = new ApplicationDbContext();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Insert or Update ?");
            String userCMD = Console.ReadLine().ToUpper();

            if (userCMD.Equals("INSERT"))
            {
                await insertNewSubject();
            }
            else if(userCMD.Equals("UPDATE"))
            {
                await UpdateEntries();
            }
            else
            {
                Console.Beep();
            }
        }
        public static async Task UpdateEntries()
        {
            await GetAvailableSubjects();

            Console.WriteLine("Enter the ID of the subject that your going to Update ? ");
            Int32 tempID = Convert.ToInt32(Console.ReadLine());
            var tempSubject = context.Subjects.Find(tempID);
            Console.WriteLine($"{tempSubject.SubjectName} Should be -> ");
            tempSubject.SubjectName = Console.ReadLine();
            context.SaveChanges();

            await GetAvailableSubjects();
        }
        public static async Task GetAvailableSubjects()
        {
            var objSubject = context.Subjects.ToList();
            foreach (var item in objSubject)
            {
                Console.WriteLine($"{item.Id} - {item.SubjectName}");
            }

        }
        public static async Task insertNewSubject()
        {
            Console.WriteLine("Enter New Subject = ");
            String NewSubject = Console.ReadLine();
            context.Subjects.Add(new Subject { SubjectName = $"{NewSubject}" });
            context.SaveChangesAsync();
            Console.WriteLine("Do yo like to print Subject list ? Y/N");
            String uesrCmd = Console.ReadLine().ToUpper();
            if (uesrCmd.Equals("Y"))
            {
                await GetAvailableSubjects();
            }

            Console.WriteLine($"the \"{NewSubject}\" Added to the subject list");

        }
    }
}
