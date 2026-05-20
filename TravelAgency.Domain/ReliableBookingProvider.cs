using System;
using System.Threading;

namespace TravelAgency.Domain;

public class ReliableBookingProvider
{
    public bool ExecuteWithRetry(Action operation, int maxAttempts = 3)
    {
        int attempt = 0;
        int delayMs = 500; 

        while (attempt < maxAttempts)
        {
            try
            {
                attempt++;
                operation(); 
                return true; 
            }
            catch (TravelServiceException ex)
            {
                Console.WriteLine($"[Спроба {attempt}/{maxAttempts}] Тимчасовий збій: {ex.Message}");
                
                if (attempt >= maxAttempts)
                {
                    throw;
                }

                Thread.Sleep(delayMs);
                delayMs *= 2; 
            }
        }

        return false;
    }
}