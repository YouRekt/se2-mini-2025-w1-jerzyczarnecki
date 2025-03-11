namespace TDD
{
    public static class Calculator
    {
        public static int Calc(string a)
        {
            if (a == "")
                return 0;

            string[] operands;

            List<string> delimiters = new();

            if (a.StartsWith("//"))
            {
                string noSlash = a.Substring(2);

                if (noSlash.Contains("["))
                {
                    int startIndex = 0;

                    while (true)
                    {
                        // Find the index of the next '['
                        int openBracketIndex = noSlash.IndexOf('[', startIndex);
                        if (openBracketIndex == -1) break; // No more delimiters

                        // Find the index of the next ']'
                        int closeBracketIndex = noSlash.IndexOf(']', openBracketIndex);
                        if (closeBracketIndex == -1) throw new ArgumentException("Invalid delimiter."); // No matching ']'

                        // Extract the delimiter between the brackets
                        string delimiter = noSlash.Substring(openBracketIndex + 1, closeBracketIndex - openBracketIndex - 1);
                        delimiters.Add(delimiter);

                        // Move the start index to after the current ']'
                        startIndex = closeBracketIndex + 1;
                    }

                    a = noSlash.Substring(startIndex);
                }
                else
                {
                    delimiters.Add(noSlash[0].ToString());
                    a = noSlash.Substring(1);
                }
            }
            else
            {
                if (a.Contains(","))
                {
                    delimiters.Add(",");
                }
                else if (a.Contains("\n"))
                {
                    delimiters.Add("\n");
                }
                else if (a.All(c => char.IsDigit(c)))
                {
                    int num = int.Parse(a);
                    if (num < 0)
                        throw new ArgumentException("Negative numbers not allowed.");
                    if (num <= 1000)
                        return num;
                    return 0;
                }
                else
                {
                    throw new ArgumentException("Wrong delimeter");
                }
            }
            operands = a.Split(delimiters.ToArray(), StringSplitOptions.None);

            int result = operands.Aggregate(0, (acc, o) =>
            {
                int num = int.Parse(o);
                if (num < 0)
                    throw new ArgumentException("Negative numbers not allowed.");
                if (num <= 1000)
                    return acc + num;
                return acc;
            });

            return result;
        }
    }
}
