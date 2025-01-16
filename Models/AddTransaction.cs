using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace PersonalFinanceTracker.Models
{
    // This class is serializable, useful for serialization if needed
    [Serializable]
    public class TransactionModel
    {
        /// <summary>
        /// Unique identifier for the transaction, generated as a string.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Type of transaction, e.g., "debit" or "credit".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The title or description of the transaction.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Amount involved in the transaction.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Current balance after the transaction.
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// Optional notes or additional details for the transaction.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Date and time of the transaction.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Tags or labels associated with the transaction.
        /// </summary>
        public string Labels { get; set; } 
        public string Tags { get; set; } 


        /// <summary>
        /// Constructor initializes the date to the current date by default.
        /// </summary>
        public TransactionModel()
        {
            Date = DateTime.Now;
        }
    }
}
