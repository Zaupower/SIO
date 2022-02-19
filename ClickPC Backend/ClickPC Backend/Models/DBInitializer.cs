using ClickPC_Backend.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClickPC_Backend.Models
{
    public class DBInitializer
    {
        public static Context context;

        public static void Initialize(Context context)
        {
            DBInitializer.context = context;
            context.Database.EnsureCreated();

            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\SAF-T");

            if (directory.Exists)
            {
                if (directory.GetFiles().Length == 1)
                {
                    if (directory.GetFiles()[0].Extension.ToLower().Contains(".xml"))
                    {
                        if (File.Exists(directory.GetFiles()[0].FullName))
                        {
                            Console.WriteLine("Ficheiro saf-t encontrado.");

                            FrontendController fileController = new FrontendController(context);
                            fileController.SetFile(directory.GetFiles()[0].FullName);
                        }
                        else
                        {
                            Console.WriteLine("Erro - Ficheiro não encontrado");
                            return;
                        }
                    }
                    else
                        Console.WriteLine("Ficheiro não é do tipo xml.");
                }
                else
                {
                    Console.WriteLine("Por favor coloque apenas um ficheiro saf-t na pasta.");
                }
            }
            context.SaveChanges();
        }

    }
}
