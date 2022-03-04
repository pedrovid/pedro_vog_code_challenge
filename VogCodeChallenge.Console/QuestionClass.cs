using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VogCodeChallenge.Console
{
    public static class QuestionClass
    {
        static List<string> NameList = new List<string>()
        {
            "Jimmy",
            "Jeffrey",
            "John",
        };

        /// <summary>
        ///     Function to iterate NameList property recursively.
        /// </summary>
        public static void RecursivelyIterateNames()
        {
            System.Console.WriteLine("**** Recursive ****\n");

            int itemsInList = NameList.Count;
            if (itemsInList == 0) return;
            if(itemsInList == 1)
            {
                System.Console.WriteLine(NameList.ElementAt(0));
                return;
            }

            int middle = (itemsInList / 2);
            RecursiveApproach(NameList.GetRange(0, middle));
            RecursiveApproach(NameList.GetRange(middle, (itemsInList - middle)));
            
        }

        /// <summary>
        ///     Assistance function to iterate NameList property and show in console its values recursively.
        /// </summary>
        /// <param name="names">
        ///     Segment of the NameList property.
        /// </param>
        private static void RecursiveApproach(List<string> names)
        {
            int itemsInList = names.Count;

            if(itemsInList == 1)
            {
                System.Console.WriteLine(names.ElementAt(0));
                return;
            }

            int middle = (itemsInList / 2) + 1;
            if (itemsInList % 2 == 0)
            {
                RecursiveApproach(names.GetRange(0, itemsInList / 2));
                RecursiveApproach(names.GetRange(middle - 1, (itemsInList - middle + 1)));
            }
            else
            {
                RecursiveApproach(names.GetRange(0, itemsInList / 2));
                System.Console.WriteLine(names.ElementAt(itemsInList / 2));
                RecursiveApproach(names.GetRange(middle, (itemsInList - middle)));
            }
        }

        /// <summary>
        ///     Function to iterate NameList property and show in console its values using a while loop.
        /// </summary>
        /// <param name="names">
        ///     Segment of the NameList property.
        /// </param>
        public static void WhileApproach()
        {
            System.Console.WriteLine("\n**** While ****\n");
            int i = 0;

            while(NameList.ElementAtOrDefault(i) != null)
            {
                System.Console.WriteLine(NameList.ElementAt(i++));
            };
        }
    }
}
