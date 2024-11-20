using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    public static bool is_float = false;
    public static int number_of_digits = 1;
    public static int number_of_operations = 0;
    public static string[] previous_operations = new string[20];
    public static double[] previous_numbers = new double[20];
    public static double answer = 0;

    double calculation(double Num1, double Num2, string Operation)
    {
        double result = 0;

        if (Operation == "+")
        {
            result = Num1 + Num2;
        }
        if (Operation == "-")
        {
            result = Num1 - Num2;
        }
        if (Operation == "*")
        {
            result = Num1 * Num2;
        }
        if (Operation == "/")
        {
            result = Num1 / Num2;
        }
        return (result);
    }
    public static void Equals()
    {
        var calc = new Calculator();
        for (int i = 0; i < number_of_operations; i++)
        {
            int j = 0;
            while (previous_operations[i + j + 1] == "*" || previous_operations[i + j + 1] == "/")
            {
                j++;
                previous_numbers[i + j + 1] = calc.calculation(previous_numbers[i + j], previous_numbers[i + j + 1], previous_operations[i + j]);
            }
            previous_numbers[i + j + 1] = calc.calculation(previous_numbers[i], previous_numbers[i + j + 1], previous_operations[i]);
            i += j;
        }
        answer = previous_numbers[number_of_operations];

    }
} 
