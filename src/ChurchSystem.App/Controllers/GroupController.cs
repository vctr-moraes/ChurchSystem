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
            GroupVM = new GroupViewModel();
        }

        [BindProperty]
        public GroupViewModel GroupVM { get; set; }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<GroupViewModel>>(await _groupRepository.GetEntities()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Group group = await _groupRepository.GetGroup(id);

            if (group == null)
                return NotFound();

            GroupVM = new GroupViewModel(group);
            return View(GroupVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupViewModel groupViewModel)
        {
            if (!ModelState.IsValid)
                return View(groupViewModel);

            Group group = new Group
            {
                Description = groupViewModel.Description
            };

            try
            {
                await _groupRepository.CreateEntity(group);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                GroupVM = new GroupViewModel(group);
                return View(GroupVM);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Group group = await _groupRepository.GetGroup(id);

            if (group == null)
                return NotFound();

            GroupVM = new GroupViewModel(group);
            return View(GroupVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GroupViewModel groupViewModel)
        {
            if (id != groupViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(groupViewModel);

            Group group = await _groupRepository.GetGroup(id);
            group.Description = groupViewModel.Description;

            try
            {
                await _groupRepository.UpdateEntity(group);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                GroupVM = new GroupViewModel(group);
                return View(GroupVM);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Group group = await _groupRepository.GetGroup(id);

            if (group == null)
                return NotFound();

            GroupVM = new GroupViewModel(group);
            return View(GroupVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Group group = await _groupRepository.GetGroupAsNoTracking(id);

            if (group == null)
                return NotFound();

            try
            {
                await _groupRepository.DeleteEntity(id);
                TempData["Success"] = "Group successfully deleted!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                GroupVM = new GroupViewModel(group);
                return View(GroupVM);
            }
        }
    }
}
