namespace Test;

public partial class AdvancedCalculatorPage : ContentPage
{
    public AdvancedCalculatorPage()
    {
        InitializeComponent();
        OnClear(this, null);
    }
    string currentEntry = "";
    int currentState = 1;
    string mathOperator;
    double firstNumber, secondNumber;
    string decimalFormat = "N0";




    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;

        currentEntry += pressed;

        if ((this.resultText.Text == "0" && pressed == "0")
            || (currentEntry.Length <= 1 && pressed != "0")
            || currentState < 0)
        {
            this.resultText.Text = "";
            if (currentState < 0)
                currentState *= -1;
        }

        if (pressed == "." && decimalFormat != "N2")
        {
            decimalFormat = "N2";
        }

        this.resultText.Text += pressed;

        // Check if the previous input was an operator, if not, update CurrentCalculation
        if (!IsLastInputOperator())
        {
            // Update the CurrentCalculation label with the selected number
            CurrentCalculation.Text += pressed;
        }
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        LockNumberValue(resultText.Text);

        currentState = -2;
        Button button = (Button)sender;
        string pressed = button.Text;
        mathOperator = pressed;

        // Check if the previous input was not an operator, if not, update CurrentCalculation
        if (!IsLastInputOperator())
        {
            // Update the CurrentCalculation label with the operator
            CurrentCalculation.Text += $" {pressed} ";
        }

        // Clear the resultText for the next number input
        resultText.Text = "";
    }

    bool IsLastInputOperator()
{
    // Check if the last character in CurrentCalculation is an operator
    if (CurrentCalculation.Text.Length > 0)
    {
        char lastChar = CurrentCalculation.Text[CurrentCalculation.Text.Length - 1];
        return lastChar == '+' || lastChar == '-' || lastChar == '×' || lastChar == '÷';
    }
    return false;
}

    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }

            currentEntry = string.Empty;
        }
    }

    private void OnSquareRoot(object sender, EventArgs e)
    {
        if (double.TryParse(resultText.Text, out double currentValue))
        {
            double result = Math.Sqrt(currentValue);
            resultText.Text = result.ToString();
            CurrentCalculation.Text = $"√{currentValue}"; // Display square root symbol in the calculation history
        }
    }

    private void OnMod(object sender, EventArgs e)
    {
        if (double.TryParse(resultText.Text, out double currentValue))
        {
            // Implement Modulus calculation logic as needed
            // For example, calculate remainder when divided by 2:
            double result = currentValue % 2;
            resultText.Text = result.ToString();
            CurrentCalculation.Text = $"{currentValue} Mod 2"; // Display modulus symbol in the calculation history
        }
    }

    private void OnExponent(object sender, EventArgs e)
    {
        if (double.TryParse(resultText.Text, out double currentValue))
        {
            double result = Math.Pow(currentValue, 2); // Squaring for example
            resultText.Text = result.ToString();
            CurrentCalculation.Text = $"{currentValue} ^ 2";
        }
    }

    private void OnLeftParenthesis(object sender, EventArgs e)
    {
        // Implement logic for Left Parenthesis button click
        // For example, concatenate "(" to the current expression
        CurrentCalculation.Text += "(";
    }

    private void OnRightParenthesis(object sender, EventArgs e)
    {
        // Implement logic for Right Parenthesis button click
        // For example, concatenate ")" to the current expression
        CurrentCalculation.Text += ")";
    }



    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        decimalFormat = "N0";
        this.resultText.Text = "0";
        currentEntry = string.Empty;
        CurrentCalculation.Text = "";
    }

    void OnCalculate(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            if (secondNumber == 0)
                LockNumberValue(resultText.Text);

            // Perform multiplication and division operations first
            double tempResult = PerformMultiplicationAndDivision();

            // Perform addition and subtraction operations
            double result = PerformAdditionAndSubtraction(tempResult);

            this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";
            this.resultText.Text = result.ToTrimmedString(decimalFormat);

            firstNumber = result;
            secondNumber = 0;
            currentState = -1;
            currentEntry = string.Empty;
        }
    }

    double PerformMultiplicationAndDivision()
    {
        double tempResult = firstNumber;
        switch (mathOperator)
        {
            case "×":
                tempResult *= secondNumber;
                break;
            case "÷":
                if (secondNumber != 0)
                {
                    tempResult /= secondNumber;
                }
                else
                {
                    // Handle division by zero error
                    // For now, set the result to zero, but you might want to display an error message
                    tempResult = 0;
                }
                break;
        }
        return tempResult;
    }

    double PerformAdditionAndSubtraction(double tempResult)
    {
        switch (mathOperator)
        {
            case "+":
                tempResult += secondNumber;
                break;
            case "-":
                tempResult -= secondNumber;
                break;
        }
        return tempResult;
    }


    void OnNegative(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            secondNumber = -1;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

    void OnPercentage(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            decimalFormat = "N2";
            secondNumber = 0.01;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }
}