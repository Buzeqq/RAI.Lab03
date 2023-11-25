using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

internal sealed class IdValueConverter : ValueConverter<Id, Guid>
{
    public IdValueConverter(ConverterMappingHints? mappingHints = null)
        : base(x => x.Value, x => new Id(x), mappingHints)
    {
    }
}