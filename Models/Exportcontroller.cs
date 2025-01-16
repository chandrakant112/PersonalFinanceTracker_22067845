using System.Text.Json;

namespace PersonalFinanceTracker.Services
{
    public class Exportcontroller
    {
        public string ExportJsonToCsv(string jsonFilePath)
        {
            string csvFilePath = Path.ChangeExtension(jsonFilePath, ".csv");

            try
            {
                // Read and deserialize the JSON file
                string jsonData = File.ReadAllText(jsonFilePath);
                var transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonData);

                // Convert JSON to CSV
                using (var writer = new StreamWriter(csvFilePath))
                {
                    writer.WriteLine("TransactionId,Amount,Date,Description"); // Example CSV headers
                    foreach (var transaction in transactions)
                    {
                        writer.WriteLine($"{transaction.TransactionId},{transaction.Amount},{transaction.Date},{transaction.Description}");
                    }
                }

                return csvFilePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting CSV: {ex.Message}");
            }
        }

        public class Transaction
        {
            public int TransactionId { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
        }
    }
}
