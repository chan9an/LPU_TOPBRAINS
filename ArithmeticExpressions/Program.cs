using System;

public static class Solution
{
    public static string EvaluateExpression(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            return "Error:InvalidExpression";

        var parts = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 3)
            return "Error:InvalidExpression";

        if (!int.TryParse(parts[0], out int a) || !int.TryParse(parts[2], out int b))
            return "Error:InvalidNumber";

        string op = parts[1];

        return op switch
        {
            "+" => (a + b).ToString(),
            "-" => (a - b).ToString(),
            "*" => (a * b).ToString(),
            "/" => b == 0 ? "Error:DivideByZero" : (a / b).ToString(),
            _   => "Error:UnknownOperator"
        };
    }
}
