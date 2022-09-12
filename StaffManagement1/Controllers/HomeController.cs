using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using StaffManagement1.Models;
using StaffManagement1.ViewModels;

namespace StaffManagement1.Controllers;

public class HomeController : Controller
{
    private readonly IStaffRepository _staffRepository;
    private readonly IWebHostEnvironment webHost;

    public HomeController(IStaffRepository staffRepository, IWebHostEnvironment _webHost)
    {
        _staffRepository = staffRepository;
        webHost = _webHost;
    }

    public ViewResult Index()
    {
        HomeIndexViewModel viewModel = new HomeIndexViewModel()
        {
            Staffs = _staffRepository.GetAll()
        };
        return View(viewModel);
    }

    public ViewResult Details(int? id)
    {
        HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
        {
            Staff = _staffRepository.Get(id ?? 1)
        };
        return View(viewModel);
    }

    [HttpGet]
    public ViewResult Create()
    {
        return View();
    }

    [HttpGet]
    public ViewResult Edit(int id)
    {
        Staff staff = _staffRepository.Get(id);
        HomeEditViewModel viewModel = new HomeEditViewModel()
        {
            Id = staff.Id,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            Email = staff.Email,
            Department = staff.Department,
            ExsitingPhoto = staff.PhotoFilePath
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(HomeCreateViewModel staff)
    {
        if (ModelState.IsValid)
        {
            string uniqueFileName = UploadPhoto(staff);

            Staff newStaff = new Staff
            {
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Email = staff.Email,
                Department = staff.Department,
                PhotoFilePath = uniqueFileName
            };

            newStaff = _staffRepository.Create(newStaff);
            return RedirectToAction("Details", new { id = newStaff.Id });
        }

        return View();
    }

    [HttpPost]
    public IActionResult Edit(HomeEditViewModel staff)
    {
        if (ModelState.IsValid)
        {
            var newStaff = _staffRepository.Get(staff.Id);
            newStaff.Id = staff.Id;
            newStaff.FirstName = staff.FirstName;
            newStaff.LastName = staff.LastName;
            newStaff.Email = staff.Email;
            newStaff.Department = staff.Department;
            if (staff.Photo != null)
            {
                newStaff.PhotoFilePath = UploadPhoto(staff);
            }
            _staffRepository.Update(newStaff);
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _staffRepository.Delete(id);
        return RedirectToAction("Index");
    }

    private string UploadPhoto(HomeCreateViewModel staff)
    {
        string uniqueFileName = string.Empty;
        if (staff.Photo != null)
        {
            string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.Photo.FileName;
            string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
            staff.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
        }

        return uniqueFileName;
    }
}

