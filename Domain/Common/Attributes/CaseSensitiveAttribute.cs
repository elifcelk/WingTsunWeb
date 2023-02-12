
namespace Domain.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false, Inherited = false)]
    public sealed class CaseSensitiveAttribute :Attribute
    {
    }
}
