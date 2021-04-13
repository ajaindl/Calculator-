# Calculator

This calculator is a .NET Core console application for processing basic arithmatic expressions. It supports addition, subtraction, multiplication, and division.

## Instructions:

1. Clone the *prod* branch to your local machine. 
2. In Visual Studio or the IDE of your choice (must support the .NET Runtime), open the **Calculator.sln** solution file.
3. Run the application (F5 in Visual Studio is the default key binding).
4. You will see a "Calculate: " prompt in the console window. Now it is time to do math!

### Syntax and rules

The basic syntax for an expression is *operator(operand1,operand2)*, so a basic expression would be add(1,2). Each operand in an expression can also be an expression,
so the following would also be valid: add(1,add(3,3)). The four allowed operators are *add*, *sub*, *mult*, *div*. All numeric operands must be the 32 bit integers.
