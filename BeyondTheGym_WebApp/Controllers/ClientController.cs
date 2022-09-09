using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTG.Models.ClientModels;
using BTG.Services.ClientServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeyondTheGym_WebApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetClients();

            if (clients == null)
            {
                return View();
            }

            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _clientService.CreateClientAsync(model)) return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id is null) return BadRequest();

            var client = await _clientService.GetClientDetailByIDAsync(id);

            return View(client);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ClientEdit model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _clientService.EditClientAsync(id, model)) return RedirectToAction(nameof(Details));
            else
                return UnprocessableEntity();
        }
    }
}