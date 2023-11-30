using Microsoft.AspNetCore.Mvc;
using WebAPI_SDK.Dtos;
using WebAPI_SDK.Services;

//Marcelo Modesto de Lima Junior CB3015823
//Bruna Helena Silva Santos      CB3016111

namespace TP04.Controllers
{
    public class AtividadesController : Controller
    {
        private readonly AtividadesService atividadesService;

        public AtividadesController(AtividadesService atividadesService)
        {
            this.atividadesService = atividadesService;
        }

        public async Task<IActionResult> Index()
        {
            var atividades = await atividadesService.GetAll();
            return View(atividades);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var atividade = await atividadesService.GetById((int)id);

            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtividadeDTO atividade)
        {
            if (ModelState.IsValid)
            {
                await atividadesService.Create(atividade);
                return RedirectToAction(nameof(Index));
            }
            return View(atividade);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var atividade = await atividadesService.GetById((int)id);

            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AtividadeDTO atividade)
        {
            if (ModelState.IsValid)
            {
                await atividadesService.Update((int)id, atividade);
                return RedirectToAction(nameof(Index));
            }
            return View(atividade);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var atividade = await atividadesService.GetById((int)id);

            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await atividadesService.Delete((int)id);
            return RedirectToAction(nameof(Index));
        }

    }
}
