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
        }

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
        public async Task<IActionResult> Create()
        {
            DonationViewModel donationViewModel = await GetMembers(new DonationViewModel());
            return View(donationViewModel);
        }

        // POST: Donation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonationViewModel donationViewModel)
        {
            donationViewModel = await GetMembers(donationViewModel);

            if (!ModelState.IsValid)
            {
                return View(donationViewModel);
            }

            await _donationRepository.CreateEntity(_mapper.Map<Donation>(donationViewModel));
            return RedirectToAction("Index");
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
            donationViewModel.Members = _mapper.Map<IEnumerable<MemberViewModel>>(await _memberRepository.GetEntities());
            return donationViewModel;
        }

        private async Task<DonationViewModel> GetMembers(DonationViewModel donationViewModel)
        {
            donationViewModel.Members = _mapper.Map<IEnumerable<MemberViewModel>>(await _memberRepository.GetEntities());
            return donationViewModel;
        }
    }
}
