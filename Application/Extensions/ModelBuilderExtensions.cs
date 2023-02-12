using Application.Helpers;
using Application.Interfaces;
using Domain.Common;
using Domain.Common.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace Application.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void UseEncryption(this ModelBuilder modelBuilder, IEncryptionProvider encryptionProvider)
        {
            if (modelBuilder is null)
                throw new ArgumentNullException(nameof(modelBuilder), "ModelBuilder nesnesi tanımlanmamış.");
            if (encryptionProvider is null)
                throw new ArgumentNullException(nameof(encryptionProvider), "Şifreleme aracısı tanımlanmamış.");

            var encryptionConverter = new EncryptionConverter(encryptionProvider);

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && !IsDiscriminator(property))
                    {
                        object[] attributes = property.PropertyInfo.GetCustomAttributes(typeof(EncryptedAttribute), false);
                        if (attributes.Any())
                            property.SetValueConverter(encryptionConverter);
                            
                    }
                }
            }
        }

        private static bool IsDiscriminator(IMutableProperty property) => property.Name == "Discriminator" || property.PropertyInfo == null;

        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(ModelBuilderExtensions)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void UseSoftDeleteFilter(this ModelBuilder modelBuilder)
        {
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                SetSoftDeleteFilterMethod.MakeGenericMethod(type.ClrType).Invoke(null, new object[] { modelBuilder });
            }
        }

        static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder) where TEntity : BaseEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
        }

        public static void UseCaseSensitiveFilter(this ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder), "ModelBuilder nesnesi tanımlanmamış.");
            }

            var caseSensitiveConverter = new CaseSensitiveConverter();

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && !IsDiscriminator(property))
                    {
                        object[] caseSensitiveAttr = property.PropertyInfo.GetCustomAttributes(typeof(CaseSensitiveAttribute),false);
                        object[] encryptAttr = property.PropertyInfo.GetCustomAttributes(typeof(EncryptedAttribute), false);
                        if (caseSensitiveAttr.Any() && !encryptAttr.Any())
                        {
                            property.SetValueConverter(caseSensitiveConverter);
                        }
                    }
                }
            }
        }
    }
}
