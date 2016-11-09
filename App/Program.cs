using Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var user = new User[]
                {
                    new User(5)
                     {
                         FirstName = "aqwrfwggughwuhguigaguhgaohggahowhgahgohghiogoaghigi",
                         LastName = "qwef",
                     }
                };

                Validator.IsValid(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Validator.IsValid(Creator.CreateUsers());
                Validator.IsValid(Creator.CreateAdvancedUser());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
