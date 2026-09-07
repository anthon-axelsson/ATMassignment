using System.Reflection.Metadata;

namespace testings;

class Program
{
    static int balance = 0;
    static bool isRunning = true;
    static List<string> history = new List<string>();
    static void Main()
    {
        while (isRunning == true)
        {
            try
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("To make a deposit press 'd'");
                Console.WriteLine("To make a withdrawal press 'w'");
                Console.WriteLine("To show transaction history 't'");
                Console.WriteLine("To check balance press 'b'");
                Console.WriteLine("To end session press 'x'");
                Console.WriteLine("--------------------------------------");


                var key = Console.ReadLine();

                switch (key)
                {
                    case "b":
                        ShowBalance();
                        break;
                    case "d":
                        HandleDeposit();
                        break;
                    case "w":
                        HandleWithdrawal();
                        break;

                    case "t":
                        History();
                        break;
                    
                    case "x":
                        Console.WriteLine("Thank you for using the banking service. Goodbye!");
                        isRunning = false;
                        break;

                    default:
                        throw new Exception("Invalid option! Please enter 'd', 'w', 't', 'b', or 'x'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error]: {ex.Message}");        
            }   
        } 
    }

    static void ShowBalance()
    {
        Console.WriteLine($"Your balance now is: {balance}");
    }

    static void HandleDeposit()
    {
        Console.WriteLine("How much do you want to Deposit?");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int amount) || amount <= 0)
        {
            throw new Exception("You must enter a positive integer to make a deposit.");
        }

        Deposit(amount);
    }

    static void Deposit(int amount)
    {
        balance += amount;
        history.Add($"{DateTime.Now} Deposit: +{amount} sek");
        Console.WriteLine($"You deposited +{amount} sek");
    }

    static void HandleWithdrawal()
    {
        Console.WriteLine("How much do you want to withdraw?");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int amount) || amount <= 0)
        {
            throw new Exception("You must enter a positive integer to make a withdrawal.");
        }

        Withdraw(amount);
    }


    static void Withdraw(int amount)
    {
        if (balance < amount)
        {
            throw new Exception($"Insufficient funds! You only have {balance} sek.");
        }

        balance -= amount;
        history.Add($"{DateTime.Now} Withdrawal: -{amount} sek");
        Console.WriteLine($"You withdrew -{amount} sek");
    }

    static void History()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("No transactions have been done");
        }
        else
        {
            foreach (var record in history)
            {
                Console.WriteLine(record);
            }
        }
    }
}

// felhantering, aldrig gå ut ur while loop