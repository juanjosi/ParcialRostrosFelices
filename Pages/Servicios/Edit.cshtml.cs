using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialRostrosFelices.Data;
using ParcialRostrosFelices.Models;

namespace ParcialRostrosFelices.Pages.Servicios
{
    public class EditModel : PageModel
    {
		private readonly RostrosFelicesContext _context;
		public EditModel(RostrosFelicesContext context)
		{
			_context = context;
		}

		[BindProperty]

		public Servicio Servicio { get; set; } = default!;
		public SelectList Clientes { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Servicios == null)
			{
				return NotFound();
			}

			var servicio = await _context.Servicios.FirstOrDefaultAsync(m => m.Id == id);
			if (servicio == null)
			{
				return NotFound();
			}
			Servicio = servicio;
			ListClient();
			return Page();
		}
		private void ListClient()
		{
			var clientes = _context.Clientes.ToList();
			Clientes = new SelectList(clientes, "Id", "Name");
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				ListClient();
				return NotFound();
			}

			_context.Attach(Servicio).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ServicioExists(Servicio.Id))
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
		private bool ServicioExists(int id)
		{
			return (_context.Servicios?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
