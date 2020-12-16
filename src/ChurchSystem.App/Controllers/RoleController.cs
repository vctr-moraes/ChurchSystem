using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchSystem.App.ViewsModels;
using ChurchSystem.Business.Interfaces;
using AutoMapper;
using ChurchSystem.Business.Models;

namespace ChurchSystem.App.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        // GET: RoleViewModels
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<RoleViewModel>>(await _roleRepository.GetEntities()));
        }

        // GET: RoleViewModels/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            RoleViewModel roleViewModel = await GetRole(id);

            if (roleViewModel == null)
            {
                return NotFound();
            }

            return View(roleViewModel);
        }

        // GET: RoleViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(roleViewModel);
            }

            Role role = _mapper.Map<Role>(roleViewModel);
            await _roleRepository.CreateEntity(role);

            return RedirectToAction("Index");
        }

        // GET: RoleViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            RoleViewModel roleViewModel = await GetRole(id);

            if (roleViewModel == null)
            {
                return NotFound();
            }

            return View(roleViewModel);
        }

        // POST: RoleViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RoleViewModel roleViewModel)
        {
            if (id != roleViewModel.Id)
            {
                return NotFound();
            }

            RoleViewModel roleViewModelUpdate = await GetRole(id);
            roleViewModelUpdate.Description = roleViewModel.Description;

            await _roleRepository.UpdateEntity(_mapper.Map<Role>(roleViewModelUpdate));

            return RedirectToAction("Index");
        }

        // GET: RoleViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            RoleViewModel roleViewModel = await GetRole(id);

            if (roleViewModel == null)
            {
                return NotFound();
            }

            return View(roleViewModel);
        }

        // POST: RoleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            RoleViewModel roleViewModel = await GetRole(id);

            if (roleViewModel == null)
            {
                return NotFound();
            }

            await _roleRepository.DeleteEntity(id);

            TempData["Success"] = "Role successfully deleted!";

            return RedirectToAction("Index");
        }

        private async Task<RoleViewModel> GetRole(Guid id)
        {
            return _mapper.Map<RoleViewModel>(await _roleRepository.GetEntityById(id));
        }
    }
}
