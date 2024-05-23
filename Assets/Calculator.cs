using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Calculator : MonoBehaviour
{
    public TMP_Text outputTxt;
    public float num1;
    public float num2;
    public string operation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            btn0();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            btn1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            btn2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            btn3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            btn4();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            btn5();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            btn6();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            btn7();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            btn8();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            btn9();
        }
    }
    public void Addition()
    {
        num1 = float.Parse(outputTxt.text);
        operation = ("+");
        outputTxt.text = "";
    }

    public void Subtraction()
    {
        num1 = float.Parse(outputTxt.text);
        operation = ("-");
        outputTxt.text = "";
    }
    public void Division()
    {
        num1 = float.Parse(outputTxt.text);
        operation = ("/");
        outputTxt.text = "";
    }

    public void Multiplication()
    {
        num1 = float.Parse(outputTxt.text);
        operation = ("*");
        outputTxt.text = "";
    }

    public void btn7()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "7";
        }
        else
        {
            outputTxt.text = outputTxt.text + "7";
        }
    }
    public void btn8()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "8";
        }
        else
        {
            outputTxt.text = outputTxt.text + "8";
        }
    }
    public void btn9()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "9";
        }
        else
        {
            outputTxt.text = outputTxt.text + "9";
        }
    }
    public void btn6()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "6";
        }
        else
        {
            outputTxt.text = outputTxt.text + "6";
        }
    }
    public void btn5()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "5";
        }
        else
        {
            outputTxt.text = outputTxt.text + "5";
        }
    }
    public void btn4()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "4";
        }
        else
        {
            outputTxt.text = outputTxt.text + "4";
        }
    }

    public void btn3()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "3";
        }
        else
        {
            outputTxt.text = outputTxt.text + "3";
        }
    }
    public void btn2()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "2";
        }
        else
        {
            outputTxt.text = outputTxt.text + "2";
        }
    }
    public void btn1()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "1";
        }
        else
        {
            outputTxt.text = outputTxt.text + "1";
        }
    }
    public void btn0()
    {
        if (outputTxt.text == Convert.ToString("0"))
        {
            outputTxt.text = "0";
        }
        else
        {
            outputTxt.text = outputTxt.text + "0";
        }
    }

    public void Equals()
    {
        float answer = 0f;
        num2 = float.Parse(outputTxt.text);

        if (operation == "+")
        {
            answer = num1 + num2;
            outputTxt.text = answer.ToString();
        }

        if (operation == "-")
        {
            answer = num1 - num2;
            outputTxt.text = answer.ToString();
        }

        if (operation == "*")
        {
            answer = num1 * num2;
            outputTxt.text = answer.ToString();
        }

        if (operation == "/")
        {
            answer = num1 / num2;
            outputTxt.text = answer.ToString();
        }
    }

    public void calculatorClear()
    {
        outputTxt.text = "0";
    }

    public void calculatorEntryClear()
    {
        outputTxt.text = "0";
        string f, s;

        f = Convert.ToString(num1);
        s = Convert.ToString(num2);

        f = "";
        s = "";
    }

    public void BackSpace()
    {
        if (outputTxt.text.Length > 0)
        {
            outputTxt.text = outputTxt.text.Remove(outputTxt.text.Length - 1, 1);
        }

        if (outputTxt.text == "")
        {
            outputTxt.text = "0";
        }
    }

    public void PlusMinus()
    {
        float q = float.Parse(outputTxt.text);
        outputTxt.text = Convert.ToString(-1 * q);
    }

    public void Decimal()
    {
        if (!outputTxt.text.Contains("."))
        {
            outputTxt.text = outputTxt.text + ".";
        }
    }
}
