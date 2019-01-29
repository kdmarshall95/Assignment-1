using System;

namespace Assignment1_S19
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5, b = 15;
            printPrimeNumbers(a, b);

            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);


            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);           


            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);

            int n4 = 5;
            printTriangle(n4);

            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);            

            // This assignment was a good refresher for me as I was able to re-explore the
            // uses for loops and control structures in C#. The application of logic using C#
            // to solve these problems kept me thinking about the various ways problems can
            // be solve through programming. Moving forward, I plan on reviewing what I learned
            // from this assignment, and applying this knowledge to other projects I do that
            // require the use of logic and programming. 

        }

        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                // For loop that increments through the range of numbers entered by
                // the user. It calls the isPrime method to determine whether or not
                // a selected number is prime or not. If it is, it is displayed on the
                // console.
                for (int count = x; count <= y; count++) 
                {
                    if(isPrime(count) == true)
                    {
                        Console.WriteLine(count);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        public static bool isPrime(int num)
        {
            bool prime = false; // bool used to store whether or not number is prime.
            int divisible = 0;

            for (int count = 1; count <= num; count++) 
            {
                if (num % count == 0)
                {
                    divisible++; // Store how many numbers the number is divisible by
                }
            }

            // If the number is divisible by only two numbers, it is identified as prime
            // by the boolean variable prime.
            if (divisible == 2)
            {
                prime = true;
            }

            return prime;
        }

        public static double getSeriesResult(int n)
        {
            double result = 0;
            try
            {
                for (int count = 1; count <= n; count++)
                {
                    if(count == 1)
                    {
                        // This represents the part of the series (1/2)
                        result = 0.5; 
                    }
                    else
                    {
                        // For the other numbers in the series, this if statement 
                        // determines the sign; i.e: if the sign is positive or negative.
                        if (count % 2 == 0)
                        {
                            result -= getFactorial(count) / (count + 1);
                        }
                        else
                        {
                            result += getFactorial(count) / (count + 1);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return Math.Round(result, 3); // Round the result to three decimal places.
        }

        public static double getFactorial(double num)
        {
            double factorial = 1;
            for (int count = 1; count <= num; count++)
            {
                factorial *= count;
            }
            return factorial;
        }

        public static long decimalToBinary(long n)
        {
            string output = ""; // String variable used to store binary 
                                // Variable is converted to long at the end
                                // of the method
            try
            {
                int quotient = 1;                
                while (quotient != 0 )
                {
                    quotient = (int)n / 2;                    
                    output += ((int)n % 2).ToString();
                    n = quotient;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return long.Parse(output);
        }

        public static long binaryToDecimal(long n)
        {
            long output = 0;
            try
            {
                string input = n.ToString(); //Convert input to string
                int power = input.Length - 1; // Determine the power to start with

                // Converts binary to decimal by separating the binary number
                // digit by digit as string and then converting the string to 
                // numeric data types and getting the sum of the converted values.
                for (int count = input.Length - 1; count >= 0; count--)
                {
                    output += int.Parse(input[count].ToString()) * raiseToPower(power);
                    power--;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }
            return output;
        }

        public static int raiseToPower(int power)
        {
            int result = 1;
            // If power is 0, (2^0) the result is one
            if (power == 0)
            {
                result = 1;
            }

            else
            {
                // Calculates result using for loop
                for (int count = 1; count <= power; count++)
                {
                    result *= 2; 
                }
            }
            return result;
        }

        public static void printTriangle(int n)
        {
            try
            {
                int s = n-1;
                int a = 1;
                for (int count = 1; count <= n; count++)
                {
                    // For loop that adds the necessary amount of spaces to
                    // the console output
                    for (int i = 1; i <= s; i++)
                    {
                        Console.Write(" "); 
                    }

                    // For loop that adds the necessary amount of asterisks to
                    // the console output
                    for (int i = 1; i <= a; i++)
                    {
                        Console.Write("*");
                    }

                    s--; // Reduces the amount of spaces added to each line
                    a += 2; // Increases the amount of asterisks added to each line
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static void computeFrequency(int[] a)
        {            
            try
            {

                // Array used to store distinct numbers in array
                int[] distinct = new int[3];

                // For loop used to find distinct members of array
                for (int i = 0; i < a.Length; i++)
                {
                    bool isDuplicate = false;

                    // For loop that determines if a number is distinct or a duplicate
                    for (int j = 0; j < i; j++)
                    {
                        if(a[i] == a[j])
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    if (!isDuplicate)
                    {
                        // Store distinct values in distinct array
                        distinct[i] = a[i];
                    }
                }


                // Header output to console
                Console.WriteLine("Number" + "\t" + "Frequency");
                // For loop used to determine the frequency of distinct value
                for (int i = 0; i < distinct.Length; i++)
                {
                    int sum = 0;
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (distinct[i] == a[j])
                        {
                            sum++;
                        }                        
                    }
                    // Output distinct values and their frequencies to the console 
                    Console.WriteLine(a[i] + "\t" + sum);
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }

    }
}

