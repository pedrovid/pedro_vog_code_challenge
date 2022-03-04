using System;

namespace VogCodeChallenge.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionClass.RecursivelyIterateNames();
            QuestionClass.WhileApproach();

            System.Console.WriteLine("\n**** TEST MODULE ****");
            if (TestTESTMODULE())
            {
                System.Console.WriteLine("\nEverything is OK");
            }
            else
            {
                System.Console.WriteLine("\nSomething went wrong :/");
            }
        }


        /// <summary>
        ///     Function that process input through a switch statement and returns a value depending on given conditions.
        ///     Raises Exception if the input is an integer lower than 1.
        /// </summary>
        /// <param name="value">
        ///     Some input that will be evaluated by a switch statement.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     If the input value is an integer lower than 1.
        /// </exception>
        /// <returns>
        ///     Upper case string if input is a string.
        ///     Int if the input is an integer with a value greater or equals to 1.
        ///     Float if the input is a float value equals to 1.0f or 2.0f.
        ///     Same value as input in either other case.
        /// </returns>
        private static object TESTModule(object value)
        {
            switch (value)
            {
                case int n when value.GetType() == typeof(int) && n >= 1 && n <= 4:
                    return n * 2;

                case int n when value.GetType() == typeof(int) && n > 4:
                    return n * 3;

                case int n when value.GetType() == typeof(int) && n < 1:
                    throw new ArgumentOutOfRangeException();

                case float n when value.GetType() == typeof(float) && n == 1.0f || n == 2.0f:
                    return 3.0f;

                case string n when value.GetType() == typeof(string):
                    return n.ToUpper();

                default:
                    return value;
            }
        }


        /// <summary>
        ///     Function that evaluates TESTModule in several test cases.
        /// </summary>
        /// <returns>
        ///     true if all test cases pass, false otherwise.
        /// </returns>
        private static bool TestTESTMODULE()
        {
            bool isRight = true;

            isRight = isRight && (int)TESTModule(1) == 2;
            isRight = isRight && (int)TESTModule(4) == 8;
            isRight = isRight && (int)TESTModule(5) == 15;
            isRight = isRight && (float)TESTModule(1.0f) == 3.0f;
            isRight = isRight && (string)TESTModule("hello") == "HELLO";
            try
            {
                TESTModule(-51);
            }
            catch (ArgumentOutOfRangeException)
            {
                isRight = isRight && true;
            }

            return isRight;
        }
    }
}
