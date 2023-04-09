namespace LotteryNumberChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private HashSet<int> ParseIntegersFromTextBox(TextBox textBox, char delimiter = ' ')
        {
            // Split the input string using the specified delimiter.
            string[] inputStrings = textBox.Text.Split(delimiter);

            // Initialize the HashSet.
            HashSet<int> integerSet = new HashSet<int>();

            // Iterate through the input strings, trim any extra whitespace, parse the integers, and add them to the HashSet.
            foreach (string inputString in inputStrings)
            {
                string trimmedInputString = inputString.Trim();
                if (int.TryParse(trimmedInputString, out int parsedInteger))
                {
                    integerSet.Add(parsedInteger);
                }
            }

            return integerSet;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HashSet<int> integerSet1 = ParseIntegersFromTextBox(textBox1);
            HashSet<int> integerSet2 = ParseIntegersFromTextBox(textBox2);

            int[] integerArray1 = integerSet1.ToArray();
            int[] integerArray2 = integerSet2.ToArray();

            int maxSize = Math.Min(integerArray1.Length, integerArray2.Length);
            int[] outputArray = new int[maxSize];

            int outputSize;
            MyCppDLLWrapper.compute_intersection_of_arrays(integerArray1, integerArray1.Length, integerArray2, integerArray2.Length, outputArray, out outputSize);

            HashSet<int> resultSet = new HashSet<int>();
            for (int i = 0; i < outputSize && i < outputArray.Length; i++)
            {
                resultSet.Add(outputArray[i]);
            }

            string integerSetAsString = string.Join(' ', resultSet);

            resultsTextBox.Text = integerSetAsString;
        }
    }
}