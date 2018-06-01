using System;
using System.Collections.Generic;

namespace Calculator
{
    public class SimpleCalculator
    {
        private string ArithmeticOperators = "-+*/";
        public SimpleCalculator()
        {
            string playAgain;
            do
            {
                Console.WriteLine("Please Enter Equation : ");
                // read Equation From User
                string equation = Console.ReadLine();

                // check if string Length Greater than three , start with number and end with number 
                if (equation.Length < 3 || !Char.IsNumber(equation[0]) || !Char.IsNumber(equation[equation.Length - 1]))
                {
                    Console.WriteLine("You Enterd InValid Equation Please Try Again!");
                }
                else
                {
                    // create stack to fill it with string 
                    Stack<string> equationStack = new Stack<string>();
                    // this is for loop to add equation characters to stack
                    for (int i = equation.Length - 1; i >= 0; i--)
                    {
                        if (isOdd(i))
                        {
                            // Odd Number Must check if char is Operator
                            if (!checkOperatorsVaildation(equation[i]))
                            {
                                Console.WriteLine("You Enterd InValid Equation Please Try Again! Not Vaild Operator ");
                                return;
                            }
                        }
                        else
                        {
                            // Even Number Must Check if char is Number
                            if (!char.IsNumber(equation[i]))
                            {
                                Console.WriteLine("You Enterd InValid Equation Please Try Again! Dosn't Contains Numbers ");
                                return;
                            }
                        }
                        // add char to stack
                        equationStack.Push(equation[i].ToString());
                    }
                    Console.WriteLine("Result is : {0}", Calculate(equationStack).Pop());
                }
                Console.Write("Do you want to run program again! (y/n)?");
                playAgain = Console.ReadLine();

            } while (playAgain == "y");
        }

        public Stack<string> Calculate(Stack<string> equation)
        {
            if (equation.Count != 1)
            {
                float result = getResult(float.Parse(equation.Pop()), equation.Pop(), float.Parse(equation.Pop()));
                equation.Push(result.ToString());
                Calculate(equation);
            }
            return equation;
        }
        public float getResult(float num1, string operation, float num2)
        {
            switch (operation)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    break;
            }
            return 0.0f;
        }


        public bool checkOperatorsVaildation(char equationChar)
        {
            if (ArithmeticOperators.Contains(equationChar.ToString()))
            {
                return true;
            }
            return false;
        }
        public bool isOdd(int number)
        {
            return (number % 2 != 0);
        }
    }
}
