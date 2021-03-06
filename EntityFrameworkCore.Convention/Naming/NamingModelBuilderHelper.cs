using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Convention.Naming
{
	public static class NamingModelBuilderHelper
	{
		/// <summary>
		/// 	Configure naming convention for entity frameworks.
		/// </summary>
		/// <param name="builder">Model builder of entity entity framework</param>
		/// <param name="configure">Convention configure setter</param>
		/// <returns>Origin model builder</returns>
		public static ModelBuilder UseNamingConvention(this ModelBuilder builder, Action<ConventionBuilder> configure)
		{
			var conventionBuilder = new ConventionBuilder();
			configure(conventionBuilder);

			conventionBuilder.Apply(builder);
			return builder;
		}

		/// <summary>
		/// 	Apply specific naming convention for all settable name file of entities.
		/// </summary>
		/// <param name="builder">Model Builder</param>
		/// <param name="convention">Convention</param>
		/// <returns>origin model builder</returns>
		public static ModelBuilder UseNamingConvention(this ModelBuilder builder, INamingConvention convention)
		{
			return builder.UseNamingConvention(cb => cb.UseNamingConvention(convention));
		}
	}
}