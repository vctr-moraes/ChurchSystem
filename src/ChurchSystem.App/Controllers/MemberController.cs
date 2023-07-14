using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using ChurchSystem.App.ViewsModels;
using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;

namespace ChurchSystem.App.Controllers
{
    public class MemberController : BaseController
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepository memberRepository,
                                IGroupRepository groupRepository,
                                IRoleRepository roleRepository,
                                IMapper mapper)
        {
            _memberRepository = memberRepository;
            _groupRepository = groupRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
            MemberVM = new MemberViewModel();
        }

        [BindProperty]
        public MemberViewModel MemberVM { get; set; }

        [BindProperty]
        public List<MemberViewModel> Members { get; set; }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MemberViewModel>>(await _memberRepository.GetEntities()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Member member = await _memberRepository.GetMember(id);

            if (member == null)
                return NotFound();

            MemberVM = new MemberViewModel(member);
            return View(MemberVM);
        }

        public IActionResult Create()
        {
            InitializeMember();
            return View(MemberVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberViewModel memberViewModel)
        {
            if (!ModelState.IsValid)
                return View(memberViewModel);

            Member member = new Member
            {
                Name = memberViewModel.Name,
                Document = memberViewModel.Document,
                DateBirth = memberViewModel.DateBirth,
                Address = memberViewModel.Address,
                Neighborhood = memberViewModel.Neighborhood,
                City = memberViewModel.City,
                State = memberViewModel.State,
                Mailbox = memberViewModel.Mailbox,
                Email = memberViewModel.Email,
                PhoneNumber = memberViewModel.PhoneNumber,
                Baptized = memberViewModel.Baptized,
                Status = memberViewModel.Status,
                RegistrationDate = memberViewModel.RegistrationDate
            };

            foreach (var item in memberViewModel.GroupsIds ?? Enumerable.Empty<Guid>())
            {
                member.AddGroup(await _groupRepository.GetEntityById(item));
            }

            foreach (var item in memberViewModel.RolesIds ?? Enumerable.Empty<Guid>())
            {
                member.AddRole(await _roleRepository.GetEntityById(item));
            }

            try
            {
                await _memberRepository.CreateEntity(member);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                InitializeMember();
                return View(MemberVM);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Member member = await _memberRepository.GetMember(id);

            if (member == null)
                return NotFound();

            MemberVM = new MemberViewModel(member);
            InitializeMember();
            return View(MemberVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MemberViewModel memberViewModel)
        {
            if (id != memberViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(memberViewModel);

            Member member = await _memberRepository.GetMember(id);

            member.Name = memberViewModel.Name;
            member.Document = memberViewModel.Document;
            member.DateBirth = memberViewModel.DateBirth;
            member.Address = memberViewModel.Address;
            member.Neighborhood = memberViewModel.Neighborhood;
            member.City = memberViewModel.City;
            member.State = memberViewModel.State;
            member.Mailbox = memberViewModel.Mailbox;
            member.Email = memberViewModel.Email;
            member.PhoneNumber = memberViewModel.PhoneNumber;
            member.Baptized = memberViewModel.Baptized;
            member.Status = memberViewModel.Status;

            if (memberViewModel.GroupsIds != null)
            {
                IEnumerable<Group> groups = await _groupRepository.GetGroupsById(memberViewModel.GroupsIds);
                member.UpdateGroup(groups);
            }

            if (memberViewModel.RolesIds != null)
            {
                IEnumerable<Role> roles = await _roleRepository.GetRolesById(memberViewModel.RolesIds);
                member.UpdateRole(roles);
            }

            try
            {
                await _memberRepository.UpdateEntity(member);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                InitializeMember();
                return View(MemberVM);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Member member = await _memberRepository.GetMember(id);

            if (member == null)
                return NotFound();

            MemberVM = new MemberViewModel(member);
            return View(MemberVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Member member = await _memberRepository.GetMemberAsNoTracking(id);

            if (member == null)
                return NotFound();

            try
            {
                await _memberRepository.DeleteEntity(id);
                TempData["Success"] = "Donation successfully deleted!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                MemberVM = new MemberViewModel(member);
                return View(MemberVM);
            }
        }

        private void InitializeMember()
        {
            if (MemberVM != null)
            {
                MemberVM.Groups = _groupRepository.GetGroups()
                    .Select(g => new SelectListItem
                    {
                        Text = g.Description,
                        Value = g.Id.ToString()
                    });

                MemberVM.Roles = _roleRepository.GetRoles()
                    .Select(r => new SelectListItem
                    {
                        Text = r.Description,
                        Value = r.Id.ToString()
                    });
            }
        }
    }
}
