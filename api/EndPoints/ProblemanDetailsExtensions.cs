using Flunt.Notifications;
namespace api.EndPoints
{
    public static class ProblemanDetailsExtensions
    {
        public static IDictionary<string, string[]>  ConvertToDetails(this IReadOnlyCollection<Notification> notifications)
        {
         return notifications
               .GroupBy(g => g.Key)
               .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());

        }
    }
}
