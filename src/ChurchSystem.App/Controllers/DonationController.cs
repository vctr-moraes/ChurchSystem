using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ChurchSystem.App.ViewsModels;
using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChurchSystem.App.Controllers
{
    public class DonationController : Controller
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public DonationController(IDonationRepository donationRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            _donationRepository = donationRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
            DonationVM = new DonationViewModel();
        }

        [BindProperty]
        public DonationViewModel DonationVM { get; set; }

        // GET: Donation
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<DonationViewModel>>(await _donationRepository.GetEntities()));
        }

        // GET: Donation/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            DonationViewModel donationViewModel = await GetDonation(id);

            if (donationViewModel == null)
            {
                return NotFound();
            }

            return View(donationViewModel);
        }

        // GET: Donation/Create
        public IActionResult Create()
        {
            InitializeDonation();
            return View(DonationVM);
        }

        // POST: Donation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonationViewModel donationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(donationViewModel);
            }

            Donation donation = new Donation
            {
                Amount = donationViewModel.Amount,
                Type = (DonationType)donationViewModel.DonationType,
                Date = donationViewModel.Date,
                Member = await _memberRepository.GetMember(donationViewModel.MemberId),
                MemberId = donationViewModel.MemberId
            };

            try
            {
                await _donationRepository.CreateEntity(donation);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                InitializeDonation();
                return View(DonationVM);
            }
        }

        // GET: Donation/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            DonationViewModel donationViewModel = await GetDonation(id);

            if (donationViewModel == null)
            {
                return NotFound();
            }

            return View(donationViewModel);
        }

        // POST: Donation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DonationViewModel donationViewModel)
        {
            if (id != donationViewModel.Id)
            {
                return NotFound();
            }

            DonationViewModel donationViewModelUpdate = await GetDonation(id);
            donationViewModel.Member = donationViewModelUpdate.Member;

            if (!ModelState.IsValid)
            {
                return View(donationViewModel);
            }

            donationViewModelUpdate.Date = donationViewModel.Date;
            donationViewModelUpdate.Amount = donationViewModel.Amount;
            donationViewModelUpdate.Type = donationViewModel.Type;

            await _donationRepository.UpdateEntity(_mapper.Map<Donation>(donationViewModelUpdate));
            return RedirectToAction("Index");
        }

        // GET: Donation/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            DonationViewModel donationViewModel = await GetDonation(id);

            if (donationViewModel == null)
            {
                return NotFound();
            }

            return View(donationViewModel);
        }

        // POST: Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            DonationViewModel donationViewModel = await GetDonation(id);

            if (donationViewModel == null)
            {
                return NotFound();
            }

            await _donationRepository.DeleteEntity(id);

            TempData["Success"] = "Donation successfully deleted!";

            return RedirectToAction("Index");
        }

        private async Task<DonationViewModel> GetDonation(Guid id)
        {
            DonationViewModel donationViewModel = _mapper.Map<DonationViewModel>(await _donationRepository.GetEntityById(id));
            //donationViewModel.Members = _mapper.Map<IEnumerable<MemberViewModel>>(await _memberRepository.GetEntities());
            return donationViewModel;
        }

        private async Task<DonationViewModel> GetMembers(DonationViewModel donationViewModel)
        {
            //donationViewModel.Members = _mapper.Map<IEnumerable<MemberViewModel>>(await _memberRepository.GetEntities());
            return donationViewModel;
        }

        private void InitializeDonation()
        {
            DonationVM.Members = _memberRepository.GetMembers()
                .Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });
        }
    }
}
