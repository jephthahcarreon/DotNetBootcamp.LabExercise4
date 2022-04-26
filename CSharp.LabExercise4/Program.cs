using System;

namespace CSharp.LabExercise4
{
    // Shape Area and Perimeter Calculator
    class UserInputValidator
    {
        public int ValidateUserChoiceInput()
        {
            int userChoiceAsInt;
            while (true)
            {
                Console.Write("\nPlease select a shape: ");
                string userChoiceAsString = Console.ReadLine();

                try
                {
                    userChoiceAsInt = Convert.ToInt32(userChoiceAsString);
                    if (userChoiceAsInt >= 1 && userChoiceAsInt <= 4)
                    {

                        return userChoiceAsInt;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
            }
        }
        public int ValidateUserCalculateChoice()
        {
            int userCalculateChoice;
            while (true)
            {
                Console.Write("\nPlease select a calculation to perform: ");
                string userCalculateChoiceAsString = Console.ReadLine();

                try
                {
                    userCalculateChoice = Convert.ToInt32(userCalculateChoiceAsString);
                    if (userCalculateChoice >= 1 && userCalculateChoice <= 3)
                    {

                        return userCalculateChoice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
            }
        }
        public double ValidateShapePropertyInput(string name)
        {
            double propertyValueInput;
            while (true)
            {
                Console.Write("\nPlease enter {0}: ", name);
                string propertyValueInputAsString = Console.ReadLine();

                try
                {
                    propertyValueInput = Convert.ToDouble(propertyValueInputAsString);
                    if (propertyValueInput > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\tInvalid {0}. Please enter a number.", name);
                        continue;
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException("Invalid {0} value.", name);
                }
            }
            return propertyValueInput;
        }
    }

    class UserInterfaceRenderer
    {
        public void RenderMainScreenOptions()
        {
            Console.WriteLine("**********Area and Perimeter Calculator**********\n");
            Console.WriteLine("1. Circle\n");
            Console.WriteLine("2. Square\n");
            Console.WriteLine("3. Rectangle\n");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("*************************************************\n");
        }

        public void RenderCalculationOptions()
        {
            Console.WriteLine("**********Area and Perimeter Calculator**********\n");
            Console.WriteLine("1. Area\n");
            Console.WriteLine("2. Perimeter/Circumference\n");
            Console.WriteLine("3. Return to main screen\n\n\n");
            Console.WriteLine("*************************************************\n");
        }
    }

    interface IShapeRenderer
    {
        public void RenderComputedArea();
        public void RenderComputedPerimeter();
    }

    class DefaultShapeRenderer : IShapeRenderer
    {
        IShape shape;

        public DefaultShapeRenderer (IShape shape)
        {
            this.shape = shape;
        }
        public void RenderComputedArea()
        {
            Console.WriteLine("\nThe area of {0} is: {1} ", shape.ShapeName, shape.ComputeArea());
        }

        public void RenderComputedPerimeter()
        {
            string computedValue;
            switch (shape.ShapeName)
            {
                case string name when name.ToLower().Contains("circle"):
                    computedValue = "circumference";
                    break;
                default:
                    computedValue = "perimeter";
                    break;
            }
            Console.WriteLine("\nThe {0} of {1} is: {2} ", computedValue, shape.ShapeName, shape.ComputePerimeter());
        }
    }

    interface IShape
    {
        string ShapeName { get; set; }
        public double ComputePerimeter();
        public double ComputeArea();
    }

    abstract class BaseShape
    {
        string _shapeName;
        public string ShapeName { get => _shapeName ; set => _shapeName = value; }
    }

    class Circle : BaseShape, IShape
    {
        double _radius;
        public double Radius { get => _radius; set => _radius = value; }

        public Circle (double radius)
        {
            _radius = radius;
        } 
        public double ComputeArea()
        {
            double computedArea = Math.PI * Math.Pow(_radius, 2);
            double area = Math.Round(computedArea, 2);
            return area;
        }

        public double ComputePerimeter()
        {
            double computedCircumference = Math.PI * 2 * _radius;
            double circumference = Math.Round(computedCircumference, 2);
            return circumference;
        }

        public double ComputeCircumference()
        {
            double computedCircumference = Math.PI * 2 * _radius;
            double circumference = Math.Round(computedCircumference, 2);
            return circumference;
        }
    }

    class Square : BaseShape, IShape
    {
        double _sideLength;
        public double SideLength { get => _sideLength; set => _sideLength = value; }

        public Square (double sideLength)
        {
            _sideLength = sideLength;
        }
        public double ComputeArea()
        {
            double computedArea = Math.Pow(_sideLength, 2);
            double area = Math.Round(computedArea, 2);
            return area;
        }

        public double ComputePerimeter()
        {
            double computedPerimeter = 4 * _sideLength;
            double perimeter = Math.Round(computedPerimeter, 2);
            return perimeter;
        }
    }

    class Rectangle : BaseShape, IShape
    {
        double _length;
        public double Length { get => _length; set => _length = value; }
        double _width;
        public double Width { get => _width; set => _width = value; }

        public Rectangle (double length, double width)
        {
            _length = length;
            _width = width;
        }
        public double ComputeArea()
        {
            double computedArea = _width * _length;
            double area = Math.Round(computedArea, 2);
            return area;
        }

        public double ComputePerimeter()
        {
            double computedPerimeter = 2 * _width + 2 * _length;
            double perimeter = Math.Round(computedPerimeter, 2);
            return perimeter;
        }
    }

    class ShapeCalculator
    {
        public void RunApplication()
        {
            UserInterfaceRenderer userInterfaceRenderer = new UserInterfaceRenderer();
            UserInputValidator userInputValidator = new UserInputValidator();

            while  (true)
            {
                userInterfaceRenderer.RenderMainScreenOptions();
                int userChoiceAsInt = userInputValidator.ValidateUserChoiceInput();
                string shapeName;
                int calculateChoice;
                switch (userChoiceAsInt)
                {
                    // Circle
                    case 1:
                        Console.Clear();
                        userInterfaceRenderer.RenderMainScreenOptions();
                        shapeName = "Circle";
                        Console.WriteLine(shapeName);

                        double radius = userInputValidator.ValidateShapePropertyInput("radius");
                        IShape circle = new Circle(radius); 
                        circle.ShapeName = shapeName;
                        DefaultShapeRenderer circleRenderer = new DefaultShapeRenderer(circle);

                        Console.Clear();
                        userInterfaceRenderer.RenderCalculationOptions();
                        Console.WriteLine(shapeName);
                        Console.WriteLine("\nRadius: {0}", radius);
                        calculateChoice = userInputValidator.ValidateUserCalculateChoice();
                        switch (calculateChoice)
                        {
                            // Area
                            case 1:
                                circleRenderer.RenderComputedArea();
                                break;
                            // Perimeter
                            case 2:
                                circleRenderer.RenderComputedPerimeter();
                                break;
                        }
                        break;

                    // Square
                    case 2:
                        Console.Clear();
                        userInterfaceRenderer.RenderMainScreenOptions();
                        shapeName = "Square";
                        Console.WriteLine(shapeName);

                        double sideLength = userInputValidator.ValidateShapePropertyInput("side length");
                        IShape square = new Square(sideLength);
                        square.ShapeName = shapeName;
                        DefaultShapeRenderer sqaureRenderer = new DefaultShapeRenderer(square);

                        Console.Clear();
                        userInterfaceRenderer.RenderCalculationOptions();
                        Console.WriteLine(shapeName);
                        Console.WriteLine("\nSide length: {0}", sideLength);
                        calculateChoice = userInputValidator.ValidateUserCalculateChoice();
                        switch (calculateChoice)
                        {
                            // Area
                            case 1:
                                sqaureRenderer.RenderComputedArea();
                                break;
                            // Perimeter
                            case 2:
                                sqaureRenderer.RenderComputedPerimeter();
                                break;
                        }
                        break;

                    // Rectangle
                    case 3:
                        Console.Clear();
                        userInterfaceRenderer.RenderMainScreenOptions();
                        shapeName = "Rectangle";
                        Console.WriteLine(shapeName);

                        double length = userInputValidator.ValidateShapePropertyInput("length");
                        double width = userInputValidator.ValidateShapePropertyInput("width");
                        IShape rectangle = new Rectangle(length, width);
                        rectangle.ShapeName = shapeName;
                        DefaultShapeRenderer rectangleRenderer = new DefaultShapeRenderer(rectangle);

                        Console.Clear();
                        userInterfaceRenderer.RenderCalculationOptions();
                        Console.WriteLine(shapeName);
                        Console.WriteLine("\nLength: {0}\nWidth: {1}", length, width);
                        calculateChoice = userInputValidator.ValidateUserCalculateChoice();
                        switch (calculateChoice)
                        {
                            // Area
                            case 1:
                                rectangleRenderer.RenderComputedArea();
                                break;
                            // Perimeter
                            case 2:
                                rectangleRenderer.RenderComputedPerimeter();
                                break;
                        }
                        break;

                    // Exit Application
                    case 4:
                        Console.Clear();
                        goto ExitApp;
                }

                while (true)
                {
                    //prompts user to exit or continue
                    Console.Write("\n\nWould you like to select another shape?\n(y/n): ");
                    string userChoiceInput = Console.ReadLine();
                    Console.WriteLine("");

                    //catch errors from invalid input
                    try
                    {
                        char userChoiceInputChar = char.ToLower(Convert.ToChar(userChoiceInput));

                        switch (userChoiceInputChar)
                        {
                            case 'y':
                                Console.Clear();
                                break;
                            case 'n':
                                Console.Clear();
                                goto ExitApp;
                            default:
                                Console.WriteLine("Invalid input.");
                                continue;
                        }
                        break;
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }
                }
            }

            ExitApp:

            Console.WriteLine("Press any key to close this application . . .");
            Console.ReadLine();
            Console.Clear();
        }
    }

    // Arithmetic Calculator
    static class CalculatorUserInputValidator
    {
        public static int ValidatePrecisionInput()
        {
            while (true)
            {
                Console.Write("  Enter result precision: ");
                string precisionAsString = Console.ReadLine();

                try
                {
                    int precision = Convert.ToInt32(precisionAsString);
                    if (precision >= 0)
                    {
                        return precision;
                    }
                    else
                    {
                        Console.WriteLine("  Invalid input. Please enter a positive integer.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("  Invalid input. Please enter a number");
                    continue;
                }
            }
        }

        public static decimal ValidateNumberValueInput()
        {
            while (true)
            {
                Console.Write("\n\n  Enter a number: ");
                string numAsString = Console.ReadLine();

                try
                {
                    decimal num = Convert.ToDecimal(numAsString);
                    return num;
                }
                catch (Exception)
                {
                    Console.WriteLine("  Invalid input. Please enter a number");
                    continue;
                }
            }
        }

        public static string ValidateOperationChoiceAndExitApp()
        {
            while (true)
            {
                Console.Write("\n  Select Operation or Exit Application: ");
                string userOptionChoice = Console.ReadLine();

                try
                {
                    if (userOptionChoice == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Press any key to close this application . . .");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    if (userOptionChoice == "+" || userOptionChoice == "-" || userOptionChoice == "*" || userOptionChoice == "/")
                    {
                        return userOptionChoice;
                    }
                    else
                    {
                        Console.WriteLine("  Invalid input. Please enter a valid operation");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("  Invalid input. Please enter operation.");
                    continue;
                }
            }
        }

        public static string ValidateOperationChoiceAndReturnToMain()
        {
            while (true)
            {
                Console.Write("\n  Select Operation or Return to Main Menu: ");
                string userOptionChoice = Console.ReadLine();

                try
                {
                    if (userOptionChoice == "+" || userOptionChoice == "-" || userOptionChoice == "*" || userOptionChoice == "/" || userOptionChoice == "1")
                    {
                        return userOptionChoice;
                    }
                    else
                    {
                        Console.WriteLine("  Invalid input. Please enter a valid operation");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("  Invalid input. Please enter operation.");
                    continue;
                }
            }
        }
    }
    static class CalculatorUserInterfaceRenderer
    {
        public static void RenderMainScreenOptions()
        {
            Console.WriteLine("****************Arithmetic Calculator*****************\n");
            Console.WriteLine("  [+]    Addition\n");
            Console.WriteLine("  [-]    Subtraction\n");
            Console.WriteLine("  [*]    Multiplication\n");
            Console.WriteLine("  [/]    Division\n");
            Console.WriteLine("  [1]    Exit Application\n");
            Console.WriteLine("******************************************************\n");
        }

        public static void RenderCaculatorScreenOptions()
        {
            Console.WriteLine("****************Arithmetic Calculator*****************\n");
            Console.WriteLine("  [+]    Addition\n");
            Console.WriteLine("  [-]    Subtraction\n");
            Console.WriteLine("  [*]    Multiplication\n");
            Console.WriteLine("  [/]    Division\n");
            Console.WriteLine("  [1]    Return to main screen\n");
            Console.WriteLine("******************************************************\n");
        }
    }
    interface IResultRenderer
    {
        public void RenderComputedValue(string operation, decimal num1, decimal num2);
    }

    class DefaultResultRenderer : IResultRenderer
    {
        ICalculable calculable;

        public DefaultResultRenderer (ICalculable calculable)
        {
            this.calculable = calculable;
        }
        public void RenderComputedValue(string operation, decimal num1, decimal num2)
        {
            Console.WriteLine("  {0} {1} {2} = {3}", num1, operation, num2, calculable.CalculateValue(num1, num2));
        }
    }
    interface ICalculable
    {
        int Precision {  get; set; }

        public decimal CalculateValue(decimal num1, decimal num2);
    }

    abstract class BaseCalculable
    {
        int _precision;
        public int Precision { get => _precision; set => _precision = value; }

        public BaseCalculable(int precision)
        {
            _precision = precision;
        }
    }

    class Addition : BaseCalculable, ICalculable
    {
        public Addition(int precision) : base(precision)
        {
            this.Precision = precision;
        }

        public decimal CalculateValue(decimal num1, decimal num2)
        {
            decimal sum = Math.Round((num1 + num2), this.Precision);
            return sum;
        }
    }

    class Subtraction : BaseCalculable, ICalculable
    {
        public Subtraction(int precision) : base(precision)
        {
            this.Precision = precision;
        }

        public decimal CalculateValue(decimal num1, decimal num2)
        {
            decimal difference = Math.Round((num1 - num2), this.Precision);
            return difference;
        }
    }

    class Multiplication : BaseCalculable, ICalculable
    {
        public Multiplication(int precision) : base(precision)
        {
            this.Precision = precision;
        }

        public decimal CalculateValue(decimal num1, decimal num2)
        {
            decimal product = Math.Round((num1 * num2), this.Precision);
            return product;
        }
    }

    class Division : BaseCalculable, ICalculable
    {
        public Division(int precision) : base(precision)
        {
            this.Precision = precision;
        }

        public decimal CalculateValue(decimal num1, decimal num2)
        {
            decimal quotient = Math.Round((num1 / num2), this.Precision);
            return quotient;
        }
    }

    class CalculatorApplication
    {
        public void RunApplication()
        {
            int precision;
            decimal num;
            decimal result = 0;

            // Main screen loop
            while (true)
            {
                CalculatorUserInterfaceRenderer.RenderMainScreenOptions();

                // get precision
                precision = CalculatorUserInputValidator.ValidatePrecisionInput();

                ICalculable add = new Addition(precision);
                IResultRenderer additionResultRenderer = new DefaultResultRenderer(add);

                ICalculable subtract = new Subtraction(precision);
                IResultRenderer subtractionResultRenderer = new DefaultResultRenderer(subtract);

                ICalculable multiply = new Multiplication(precision);
                IResultRenderer multiplicationResultRenderer = new DefaultResultRenderer(multiply);

                ICalculable divide = new Division(precision);
                IResultRenderer divisionResultRenderer = new DefaultResultRenderer(divide);


                Console.Clear();
                CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                Console.WriteLine("  Precision: {0} decimal places\n", precision);

                // get first number
                num = CalculatorUserInputValidator.ValidateNumberValueInput();

                Console.Clear();
                CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                Console.WriteLine("  Precision: {0} decimal places\n", precision);
                Console.WriteLine("  {0}", num);

                // get arithmetic operation
                string userOptionChoice;
                userOptionChoice = CalculatorUserInputValidator.ValidateOperationChoiceAndExitApp();

                result = num;
                // perform continuous operations
                while (true)
                {
                    // perform arithmetic procedure
                    switch (userOptionChoice)
                    {
                        case "+":
                            Console.Clear();
                            CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                            Console.WriteLine("  Precision: {0} decimal places\n", precision);
                            Console.WriteLine("  {0} + ", result);

                            // get second number
                            num = CalculatorUserInputValidator.ValidateNumberValueInput();

                            Console.Clear();
                            CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                            Console.WriteLine("  Precision: {0} decimal places\n", precision);

                            decimal sum = add.CalculateValue(result, num);
                            additionResultRenderer.RenderComputedValue(userOptionChoice, result, num);
                            result = sum;
                            break;

                        case "-":
                            Console.Clear();
                            CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                            Console.WriteLine("  Precision: {0} decimal places\n", precision);
                            Console.WriteLine("  {0} - ", result);

                            // get second number
                            num = CalculatorUserInputValidator.ValidateNumberValueInput();

                            Console.Clear();
                            CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                            Console.WriteLine("  Precision: {0} decimal places\n", precision);

                            decimal difference = subtract.CalculateValue(result, num);
                            subtractionResultRenderer.RenderComputedValue(userOptionChoice, result, num);
                            result = difference;
                            break;

                        case "*":
                            Console.Clear();
                            CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                            Console.WriteLine("  Precision: {0} decimal places\n", precision);
                            Console.WriteLine("  {0} * ", result);

                            // get second number
                            num = CalculatorUserInputValidator.ValidateNumberValueInput();

                            Console.Clear();
                            CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                            Console.WriteLine("  Precision: {0} decimal places\n", precision);

                            decimal product = multiply.CalculateValue(result, num);
                            multiplicationResultRenderer.RenderComputedValue(userOptionChoice, result, num);
                            result = product;
                            break;

                        case "/":
                            Console.Clear();
                            CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                            Console.WriteLine("  Precision: {0} decimal places\n", precision);
                            Console.WriteLine("  {0} / ", result);

                            // get second number
                            num = CalculatorUserInputValidator.ValidateNumberValueInput();

                            Console.Clear();
                            CalculatorUserInterfaceRenderer.RenderCaculatorScreenOptions();
                            Console.WriteLine("  Precision: {0} decimal places\n", precision);

                            decimal quotient = divide.CalculateValue(result, num);
                            divisionResultRenderer.RenderComputedValue(userOptionChoice, result, num);
                            result = quotient;
                            break;

                        case "1":
                            goto OuterBreak;
                    }

                    // get arithmetic operation || return to main
                    userOptionChoice = CalculatorUserInputValidator.ValidateOperationChoiceAndReturnToMain();
                }

                OuterBreak:
                Console.Clear();
                CalculatorUserInterfaceRenderer.RenderMainScreenOptions();

                //prompts user to exit or continue
                while (true)
                {
                    Console.Write("  Continue? (y/n): ");
                    string userChoiceInput = Console.ReadLine();
                    Console.WriteLine("");

                    try
                    {
                        char userChoiceInputChar = char.ToLower(Convert.ToChar(userChoiceInput));

                        switch (userChoiceInputChar)
                        {
                            case 'y':
                                break;
                            case 'n':
                                goto ExitApp;
                            default:
                                Console.WriteLine("  Invalid input.");
                                continue;
                        }
                        break;
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("  Invalid input.");
                        continue;
                    }
                }
                Console.Clear();
                continue;
            }

            ExitApp:
            Console.Clear();
            Console.WriteLine("Press any key to close this application . . .");
            Console.ReadLine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Area and Perimeter Calculator
            ShapeCalculator shapeCalculator = new ShapeCalculator();
            shapeCalculator.RunApplication();

            // Basic Arithmetic Calculator
            CalculatorApplication calculatorApplication = new CalculatorApplication();
            calculatorApplication.RunApplication();
        }
    }
}
