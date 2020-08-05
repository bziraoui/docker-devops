using System.Text;

namespace FamillyShare
{
    public static class StringExtensions
    {
        public static string ToBootstrapAlerts(this string message, string state)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"<div class='alert alert-{state}' role='alert'>{message}</div>");

            return sb.ToString();
        }

    
    }
}
