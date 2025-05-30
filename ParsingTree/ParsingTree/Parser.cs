// <copyright file="Parser.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// A class for parsing arithmetic expressions and building a parse tree.
/// </summary>
public class Parser
{
    private int currentToken;
    private List<string>? tokens;

    /// <summary>
    /// Parses the input expression and builds a parse tree.
    /// </summary>
    /// <param name="input">Input expression.</param>
    /// <returns>Returns the root of the resulting tree.</returns>
    /// <exception cref="InvalidDataException">It is thrown if the string with the expression was empty or if there were problems with splitting.
    /// </exception>
    public Node Parse(string input)
    {
        List<string> symbols = this.Splitting(input);
        this.tokens = symbols;
        this.currentToken = 0;

        if (this.tokens.Count == 0)
        {
            throw new InvalidDataException("empty file");
        }

        Node root = this.ParseOperand();

        if (this.currentToken != this.tokens.Count)
        {
            throw new InvalidDataException("unexpected tokens");
        }

        return root;
    }

    private List<string> Splitting(string input)
    {
        List<string> symbols = new List<string>();
        int position = 0;
        while (position < input.Length)
        {
            if (char.IsWhiteSpace(input[position]))
            {
                position++;
            }
            else if (char.IsDigit(input[position]) || (input[position] == '-' && (position + 1 < input.Length && char.IsDigit(input[position + 1]))))
            {
                int start = position++;
                while (position < input.Length && char.IsDigit(input[position]))
                {
                    position++;
                }

                symbols.Add(input.Substring(start, position - start));
            }
            else if (input[position] == '(' || input[position] == ')')
            {
                symbols.Add(input[position].ToString());
                position++;
            }
            else if (this.IsOperator(input[position]))
            {
                symbols.Add(input[position].ToString());
                position++;
            }
            else
            {
                throw new InvalidDataException($"Invalid symbol {input[position]}");
            }
        }

        return symbols;
    }

    private bool IsOperator(char symbol)
    {
        return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }

    private Node ParseOperand()
    {
        if (this.tokens == null)
        {
            throw new ArgumentNullException("tokens is null");
        }

        if (this.currentToken >= this.tokens.Count)
        {
            throw new InvalidDataException();
        }

        string token = this.tokens[this.currentToken];
        if (token == "(")
        {
            this.currentToken++;
            return this.ParseExpression();
        }
        else
        {
            if (!int.TryParse(token, out int value))
            {
                throw new InvalidDataException($"invalid number: {token}");
            }

            this.currentToken++;
            return new NumberNode(value);
        }
    }

    private Node ParseExpression()
    {
        if (this.tokens == null)
        {
            throw new ArgumentNullException("tokens is null");
        }

        if (this.currentToken >= this.tokens.Count)
        {
            throw new InvalidDataException();
        }

        string operatators = this.tokens[this.currentToken];
        this.currentToken++;
        Node left = this.ParseOperand();
        Node right = this.ParseOperand();

        if (this.currentToken >= this.tokens.Count || this.tokens[this.currentToken] != ")")
        {
            throw new InvalidDataException("expected ')'");
        }

        this.currentToken++;

        return operatators switch
        {
            "+" => new AdditionNode(left, right),
            "-" => new SubtractionNode(left, right),
            "*" => new MultiplyingNode(left, right),
            "/" => new DivisionNode(left, right),
            _ => throw new NotImplementedException(),
        };
    }
}
