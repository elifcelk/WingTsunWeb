using Application.Extensions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Helpers
{
    public class CaseSensitiveConverter : ValueConverter<string, string>
    {
        public CaseSensitiveConverter() : base(x => x.ToFilterText(), x => x) { }
    }
}
