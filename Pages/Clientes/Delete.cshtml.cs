using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParcialRostrosFelices.Data;
using ParcialRostrosFelices.Models;

namespace ParcialRostrosFelices.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
		private readonly RostrosFelicesContext _context;

		public DeleteModel(RostrosFelicesContext context)
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

			if (cliente != null)
			{
				Cliente = cliente;
				_context.Clientes.Remove(cliente);
				await _context.SaveChangesAsync();
			}
			else
			{
				Cliente = cliente;
			}
			return RedirectToPage("./Index");
		}

	}
}

