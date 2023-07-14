using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchSystem.App.ViewsModels;
using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;
using AutoMapper;

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
            RoleVM = new RoleViewModel();
        }

        [BindProperty]
        public RoleViewModel RoleVM { get; set; }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<RoleViewModel>>(await _roleRepository.GetEntities()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Role role = await _roleRepository.GetRole(id);

            if (role == null)
                return NotFound();

            RoleVM = new RoleViewModel(role);
            return View(RoleVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid)
                return View(roleViewModel);

            Role role = new Role
            {
                Description = roleViewModel.Description
            };

            try
            {
                await _roleRepository.CreateEntity(role);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                RoleVM = new RoleViewModel(role);
                return View(RoleVM);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Role role = await _roleRepository.GetRole(id);

            if (role == null)
                return NotFound();

            RoleVM = new RoleViewModel(role);
            return View(RoleVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RoleViewModel roleViewModel)
        {
            if (id != roleViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(roleViewModel);

            Role role = await _roleRepository.GetRole(id);
            role.Description = roleViewModel.Description;

            try
            {
                await _roleRepository.UpdateEntity(role);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                RoleVM = new RoleViewModel(role);
                return View(RoleVM);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Role role = await _roleRepository.GetRole(id);

            if (role == null)
                return NotFound();

            RoleVM = new RoleViewModel(role);
            return View(RoleVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Role role = await _roleRepository.GetRoleAsNoTracking(id);

            if (role == null)
                return NotFound();

            try
            {
                await _roleRepository.DeleteEntity(id);
                TempData["Success"] = "Role successfully deleted!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                RoleVM = new RoleViewModel(role);
                return View(RoleVM);
            }
        }
    }
}
