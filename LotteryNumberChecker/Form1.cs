namespace LotteryNumberChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // This method parses integers from a given TextBox and returns them as a HashSet.
        // The delimiter parameter specifies the character to use as the separator between integers.
        private HashSet<int> ParseIntegersFromTextBox(TextBox textBox, char delimiter = ' ')
        {
            // Split the input string using the specified delimiter.
            string[] inputStrings = textBox.Text.Split(delimiter);

            // Initialize the HashSet.
            HashSet<int> integerSet = new HashSet<int>();

            // Iterate through the input strings, trim any extra whitespace, parse the integers, and add them to the HashSet.
            foreach (string inputString in inputStrings)
            {
                // Trim any extra whitespace from the input string.
                string trimmedInputString = inputString.Trim();

                // Try to parse the trimmed input string as an integer.
                if (int.TryParse(trimmedInputString, out int parsedInteger))
                {
                    // Add the parsed integer to the HashSet.
                    integerSet.Add(parsedInteger);
                }
            }

            // Return the HashSet containing the parsed integers.
            return integerSet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Parse integers from textBox1 and textBox2 and store them in HashSet objects.
            HashSet<int> integerSet1 = ParseIntegersFromTextBox(textBox1);
            HashSet<int> integerSet2 = ParseIntegersFromTextBox(textBox2);

            // Convert the HashSets into arrays.
            int[] integerArray1 = integerSet1.ToArray();
            int[] integerArray2 = integerSet2.ToArray();

            // Determine the maximum size of the output array.
            int maxSize = Math.Min(integerArray1.Length, integerArray2.Length);
            int[] outputArray = new int[maxSize];

            // Call the external DLL function to compute the intersection of the arrays.
            int outputSize;
            MyCppDLLWrapper.compute_intersection_of_arrays(integerArray1, integerArray1.Length, integerArray2, integerArray2.Length, outputArray, out outputSize);

            // Initialize a HashSet to store the result.
            HashSet<int> resultSet = new HashSet<int>();

            // Copy the intersection results from the output array to the HashSet.
            for (int i = 0; i < outputSize && i < outputArray.Length; i++)
            {
                resultSet.Add(outputArray[i]);
            }

            // Convert the result HashSet to a string and display it in the resultsTextBox.
            string integerSetAsString = string.Join(' ', resultSet);
            resultsTextBox.Text = integerSetAsString;
        }
    }
}