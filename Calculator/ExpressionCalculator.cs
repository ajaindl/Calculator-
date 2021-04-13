using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class ExpressionCalculator
    {
        private Stack<string> OperationsStack { get; set; }
        public ExpressionCalculator()
        {
            OperationsStack = new Stack<string>();
        }

        public int Calculate(string input)
        {
            var operandStack = new Stack<int>();
            int operand = 0;
            for (int index = 0; index < input.Length;)
            {
                if (input[index] == '(')
                {
                    var depth = 1;
                    var currIndex = index + 1;
                    while (currIndex < input.Length && depth > 0)
                    {
                        if (input[currIndex] == ')')
                        {
                            depth--;
                        }
                        if (input[currIndex] == '(')
                        {
                            depth++;
                        }
                        currIndex++;
                    }
                    //use recursion to search the expression within the scope of the outer parentheses 
                    var expressionValue = Calculate(input.Substring(index + 1, (currIndex-1) - (index+1))); 

                    //need our main loop to skip over any rescursed substrings
                    index = currIndex - 1;

                    operandStack.Push(expressionValue);
                }
                else if (char.IsDigit(input[index]))
                {
                    while (index < input.Length && Char.IsDigit(input[index]))
                    {
                        //construct the opperand, multiplying by 10 for each ten's place
                        operand = operand * 10 + ((int)input[index] - '0'); 
                        index++;
                    }
                    if (operand > int.MaxValue || operand < int.MinValue)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    operandStack.Push(operand);
                    operand = 0;
                }

                else if (char.IsLetter(input[index]))
                {
                    var opBuilder = new StringBuilder();
                    while (index < input.Length &&  char.IsLetter(input[index]))
                    {
                        opBuilder.Append(input[index]);
                        index++;
                    }
                    //use global operations stack for persistance through recursive calls
                    OperationsStack.Push(opBuilder.ToString());
                }
         
                else
                {
                    index++;
                }
                
            }


            //Operand stack will only contain a single value if it is the result of nested expressions
            if (operandStack.Count == 1)
            {
                return operandStack.Pop();
            }

            var num1 = operandStack.Pop();
            var num2 = operandStack.Pop();
            int result;
            switch (OperationsStack.Pop())
            {
                case "add":
                    result = num2 + num1;
                    break;
                case "sub":
                    result = num2 - num1;
                    break;
                case "mult":
                    result = num2 * num1;
                    break;
                case "div":
                    result = num2 / num1;
                    break;
                default:
                    throw new ArgumentException("Bad input");
            }
            return result;
        }
    }
}
