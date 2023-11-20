using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParcialRostrosFelices.Data;
using ParcialRostrosFelices.Models;

namespace ParcialRostrosFelices.Pages.Clientes
{
    public class EditModel : PageModel
    {
		private readonly RostrosFelicesContext _context;
		public EditModel(RostrosFelicesContext context)
		{
			_context = context;
		}

		[BindProperty]

		public Cliente Cliente { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}

			var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
			if (cliente == null)
			{
				return NotFound();
			}
			Cliente = cliente;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}

			_context.Attach(Cliente).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ClienteExists(Cliente.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToPage("./Index");

		}
		private bool ClienteExists(int id)
		{
			return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
