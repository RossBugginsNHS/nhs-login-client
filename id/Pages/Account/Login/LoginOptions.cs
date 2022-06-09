namespace id.Pages.Login;

public class LoginOptions
{
    public static bool AllowLocalLogin = false;
    public static bool AllowRememberLogin = true;
    public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);
    public static string InvalidCredentialsErrorMessage = "Invalid username or password";
}