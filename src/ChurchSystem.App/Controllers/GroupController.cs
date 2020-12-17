using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ChurchSystem.App.ViewsModels;
using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;

namespace ChurchSystem.App.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupController(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<GroupViewModel>>(await _groupRepository.GetEntities()));
        }

        // GET: Group/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            GroupViewModel groupViewModel = await GetGroup(id);

            if (groupViewModel == null)
            {
                return NotFound();
            }

            return View(groupViewModel);
        }

        // GET: Group/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupViewModel groupViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(groupViewModel);
            }

            Group group = _mapper.Map<Group>(groupViewModel);
            await _groupRepository.CreateEntity(group);

            return RedirectToAction("Index");
        }

        // GET: Group/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            GroupViewModel groupViewModel = await GetGroup(id);

            if (groupViewModel == null)
            {
                return NotFound();
            }

            return View(groupViewModel);
        }

        // POST: Group/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GroupViewModel groupViewModel)
        {
            if (id != groupViewModel.Id)
            {
                return NotFound();
            }

            GroupViewModel groupViewModelUpdate = await GetGroup(id);
            groupViewModelUpdate.Description = groupViewModel.Description;

            await _groupRepository.UpdateEntity(_mapper.Map<Group>(groupViewModelUpdate));

            return RedirectToAction("Index");
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            GroupViewModel groupViewModel = await GetGroup(id);

            if (groupViewModel == null)
            {
                return NotFound();
            }

            return View(groupViewModel);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            GroupViewModel groupViewModel = await GetGroup(id);

            if (groupViewModel == null)
            {
                return NotFound();
            }

            await _groupRepository.DeleteEntity(id);

            TempData["Success"] = "Group successfully deleted!";

            return RedirectToAction("Index");
        }

        private async Task<GroupViewModel> GetGroup(Guid id)
        {
            return _mapper.Map<GroupViewModel>(await _groupRepository.GetEntityById(id));
        }
    }
}
