using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ParcialRostrosFelices.Data;
using ParcialRostrosFelices.Models;

namespace ParcialRostrosFelices.Pages.Clientes
{
    public class CreateModel : PageModel
    {
		private readonly RostrosFelicesContext _context;
		public CreateModel(RostrosFelicesContext context)
		{
			_context = context;
		}
		public IActionResult OnGet()
		{
			return Page();
		}
		[BindProperty]

		public Cliente Cliente { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Clientes == null || Cliente == null)
			{
				return Page();
			}
			_context.Clientes.Add(Cliente);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}

