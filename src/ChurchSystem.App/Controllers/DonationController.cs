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
        public IActionResult Index()
        {
            var teste = _donationRepository.GetDonations();
            return View(_mapper.Map<IEnumerable<DonationViewModel>>(teste));
        }

        // GET: Donation/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            Donation donation = await _donationRepository.GetDonation(id);

            if (donation == null)
                return NotFound();

            DonationVM = new DonationViewModel(donation);
            return View(DonationVM);
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
                return View(donationViewModel);

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
            Donation donation = await _donationRepository.GetDonation(id);

            if (donation == null)
                return NotFound();

            DonationVM = new DonationViewModel(donation);
            InitializeDonation();
            return View(DonationVM);
        }

        // POST: Donation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DonationViewModel donationViewModel)
        {
            if (id != donationViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(donationViewModel);

            Donation donation = await _donationRepository.GetDonation(id);

            donation.Amount = donationViewModel.Amount;
            donation.Date = donationViewModel.Date;
            donation.Member = await _memberRepository.GetMember(donationViewModel.MemberId);
            donation.MemberId = donationViewModel.MemberId;
            donation.Type = (DonationType)donationViewModel.Type;

            try
            {
                await _donationRepository.UpdateEntity(donation);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                /* DonationVM = new DonationViewModel(donation); */
                InitializeDonation();
                return View(DonationVM);
            }
        }

        // GET: Donation/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            Donation donation = await _donationRepository.GetDonation(id);

            if (donation == null)
                return NotFound();

            DonationVM = new DonationViewModel(donation);
            return View(DonationVM);
        }

        // POST: Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Donation donation = await _donationRepository.GetDonation(id);

            if (donation == null)
                return NotFound();

            try
            {
                await _donationRepository.DeleteEntity(id);
                TempData["Success"] = "Donation successfully deleted!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                DonationVM = new DonationViewModel(donation);
                return View(DonationVM);
            }
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
