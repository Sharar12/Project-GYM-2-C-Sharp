using System.Collections.Generic;
using System.Text;
using GYMWeb.Model;

namespace GYMWeb.Services
{
    public static class CsvExportService
    {
        public static string ExportMembersToCsv(IEnumerable<Member> members)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id,Name,Email,Status,ExpireDate");
            foreach (var m in members)
            {
                sb.AppendLine($"{m.Id},{m.Name},{m.Email},{m.Status},{m.ExpireDate:yyyy-MM-dd}");
            }
            return sb.ToString();
        }
    }
}
