// See https://aka.ms/new-console-template for more information
using OTP_handler;

OTPHandler handler = new OTPHandler();
int choice = 0;
string choiceAsString;

Console.WriteLine("OTP Generator v1.0");
Console.WriteLine("Available Options are: 1 - Generate OTP, 2 - Validate Generated OTP, 9 - Exit Application");
try
{
    do
    {
        Console.WriteLine("Please enter your option:");
        choiceAsString = Console.ReadLine();
        choice = int.Parse(choiceAsString);
        switch (choice)
        {
            case 1:
                {
                    string userId;
                    string generatedOtp;
                    Console.WriteLine("Please Input your UserId:");
                    userId = Console.ReadLine();
                    generatedOtp = handler.GenerateOTP(userId, DateTime.Now);
                    Console.WriteLine("Your OTP is: " + generatedOtp);
                    break;
                }

            case 2:
                {
                    string otpInputted;
                    bool otpValidity;
                    string isValidText;
                    System.ConsoleColor consoleColorFormatting;
                    Console.WriteLine("Input your OTP for validation:");
                    otpInputted = Console.ReadLine();
                    otpValidity = handler.AttemptValidation(otpInputted);
                    isValidText = otpValidity ? "OTP correct, welcome!" : "OTP incorrect or expired";
                    consoleColorFormatting = otpValidity ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.ForegroundColor = consoleColorFormatting;
                    Console.WriteLine(isValidText);
                    Console.ResetColor();
                    break;
                }
            case 9:
                {
                    Console.WriteLine("Application will now exit....");
                    break;
                }
        }

    } while (choice != 9);

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
