using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
            {
                app.UseExceptionHandler("/Error");
            }

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}

	public class TestHtmlWriter : IHtmlContent
	{
		public void WriteTo(TextWriter writer, HtmlEncoder encoder)
		{
			throw new InvalidOperationException("Test");
			writer.Write(new StringBuilder("<h1>Hello World!</h1>"));
		}
	}

	public static class TestHtmlHelperExtensions
	{
		public static TestHtmlWriter TestHtmlWriter(this IHtmlHelper helper)
		{
			return new TestHtmlWriter();
		}
	}
}