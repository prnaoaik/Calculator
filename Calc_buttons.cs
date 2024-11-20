using UnityEngine;
using TMPro;
using System;

public class Calc_buttons : MonoBehaviour
{
    public TMP_Text Top_text, Bottom_text;
    public string button_input, Operation_input; // Переменные вводимого числа и знака оператора
    
    public void on_digit_enter()
    {
        if (Calculator.number_of_digits > 20) { } // Провека на свободное место в строке
        else if (button_input == ",") 
        { 
            if (Calculator.is_float == true){ } // Проверка на наличие запятой в числе
            else
            {
                Bottom_text.text += button_input;
                Calculator.is_float = true;
            }
        } 
        else if (Bottom_text.text == "0")
        {
            Bottom_text.text = button_input;
        }
        else
        {
            Bottom_text.text += button_input;
            Calculator.number_of_digits++;
        }
    }

    private void new_number()
    {
        Bottom_text.text = "0";
        Calculator.is_float = false;
        Calculator.number_of_digits = 1;
    }

    public void on_operand()
    {
        if (Bottom_text.text == "0" || Bottom_text.text == "-") 
        {
            if (Operation_input == "-") 
            { 
                Bottom_text.text = "-"; 
            } 
        }
        else if (Calculator.number_of_operations >= 19)
        {
            Top_text.text = "";
            Bottom_text.text = "Error: Too much operations";
        }
        else if (Calculator.answer != 0)
        {
            Calculator.answer = 0;
            Top_text.text = Bottom_text.text + Operation_input;
            Calculator.previous_numbers[Calculator.number_of_operations] = double.Parse(Bottom_text.text);
            Calculator.previous_operations[Calculator.number_of_operations] = Operation_input;
            new_number();
            Calculator.number_of_operations++;
        }
        else
        {
            Top_text.text += Bottom_text.text + Operation_input;
            Calculator.previous_numbers[Calculator.number_of_operations] = double.Parse(Bottom_text.text);
            Calculator.previous_operations[Calculator.number_of_operations] = Operation_input;
            new_number();
            Calculator.number_of_operations++;
        }
    }

    public void on_clear() 
    {
        Calculator.answer = 0;
        Top_text.text = "";
        new_number();
        Calculator.number_of_operations = 0;
        Array.Clear(Calculator.previous_operations, 0, 20);
        Array.Clear(Calculator.previous_numbers, 0, 20);
    }
    
    public void on_backspace()
    {
        if (Bottom_text.text.Length > 0)
        {
            Bottom_text.text = Bottom_text.text.Remove(Bottom_text.text.Length - 1, 1);
        }
        if (Bottom_text.text == "")
        {
            Bottom_text.text = "0";
        }
    }

    public void on_equals()
    {
        if (Calculator.number_of_operations == 0) { }
        else
        {
            Calculator.previous_numbers[Calculator.number_of_operations] = double.Parse(Bottom_text.text);
            Top_text.text += Bottom_text.text;
            Calculator.Equals();
            Bottom_text.text = Calculator.answer.ToString();
            Calculator.number_of_operations = 0;
            Array.Clear(Calculator.previous_operations, 0, 20);
            Array.Clear(Calculator.previous_numbers, 0, 20);
        }
    }
}
