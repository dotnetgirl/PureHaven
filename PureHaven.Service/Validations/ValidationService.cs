//using System.Net.Mail;
//using System.Text.RegularExpressions;

//namespace PureHaven.Service.Validations;

//public class ValidationService : IValidationService
//{
//    private const string _emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
//    public bool IsValidEmailAddressAsync(string email)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<bool> IsValidNameAsync(string name)
//    {
//        if (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit))
//            return new Task<bool>(false);
//        for (int index = 0; index < name.Length; index++)
//        {
//            if (char.IsLetter(name[index]) || (index > 0
//                && (name[index - 1].ToString().Equals("o", StringComparison.OrdinalIgnoreCase)
//                || name[index - 1].ToString().Equals("g", StringComparison.OrdinalIgnoreCase))
//                && (name[index].ToString().Equals("'") || name[index] == '`')))
//                continue;
//            else return new Task<bool>(false);
//        }
//        return new Task<bool>(true);
//    }

//    public bool IsValidPhoneNumberAsync(string phoneNumber)
//    {
//        throw new NotImplementedException();
//    }
//}