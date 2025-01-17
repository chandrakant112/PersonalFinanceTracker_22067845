using Newtonsoft.Json;
using PersonalFinanceTracker.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Services
{
    public class AddTransactionServices : IAddTransactionServices
    {
        private readonly string filePath = Path.Combine(AppContext.BaseDirectory, "Resources", "Images", "transactions.json");
        //private readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "C:\\Users\\ramsa\\Desktop\\Third Year\\DotNet\\Coursework\\PersonalFinanceTracker\\Resources\\Images\\transactions.json"); // Path where data will be saved

        public async Task SaveTransactionAsync(TransactionModel transaction)
        {
            try
            {
                // Ensure the directory exists
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {

                    Directory.CreateDirectory(directory);
                }

                // Load existing transactions, or initialize a new list if the file doesn't exist
                var transactions = File.Exists(filePath)
                    ? await LoadTransactionsAsync()
                    : new List<TransactionModel>();

                // Add the new transaction
                transactions.Add(transaction);

                // Save the updated transactions to the file
                var json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
                await File.WriteAllTextAsync(filePath, json);
            }
            catch (Exception ex)
            {
                // Log or rethrow the exception as needed
                Console.WriteLine($"Error saving transaction: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TransactionModel>> GetAllTransactionsAsync()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<TransactionModel>(); // Return an empty list if the file doesn't exist
                }

                // Load and deserialize transactions from the JSON file
                var json = await File.ReadAllTextAsync(filePath);
                var transactions = JsonConvert.DeserializeObject<List<TransactionModel>>(json) ?? new List<TransactionModel>();

                // Ensure that Tags and Labels are set to empty strings if they are null or empty
                foreach (var transaction in transactions)
                {
                    if (string.IsNullOrWhiteSpace(transaction.Tags))
                    {
                        transaction.Tags = string.Empty;  // Ensure Tags is a non-null string
                    }

                    if (string.IsNullOrWhiteSpace(transaction.Labels))
                    {
                        transaction.Labels = string.Empty;  // Ensure Labels is a non-null string
                    }
                }

                return transactions;
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully
                Console.WriteLine($"Error loading transactions: {ex.Message}");
                return new List<TransactionModel>();  // Return an empty list in case of an error
            }
        }


        private async Task<List<TransactionModel>> LoadTransactionsAsync()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<TransactionModel>(); // Return empty list if no file exists
                }

                // Load the existing transactions from the file
                var json = await File.ReadAllTextAsync(filePath);
                return JsonConvert.DeserializeObject<List<TransactionModel>>(json) ?? new List<TransactionModel>();
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully
                Console.WriteLine($"Error loading transactions: {ex.Message}");
                return new List<TransactionModel>();
            }
        }
    }
}