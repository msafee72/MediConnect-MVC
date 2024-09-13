using Medi_Connect.Models;
using Medi_Connect.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medi_Connect.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILaboratorianRepository _laboratorianRepository;

        public AdminController(IDoctorRepository doctorRepository, ILaboratorianRepository laboratorianRepository)
        {
            _doctorRepository = doctorRepository;
            _laboratorianRepository = laboratorianRepository;
        }

        //public AdminController(ILaboratorianRepository laboratorianRepository)
        //{
        //    _laboratorianRepository = laboratorianRepository;
        //}


        public IActionResult Index()
            
        {
            //if (User.Identity.Name == "adminmc@mediconnect.com")
            //{
            //    return View("Index", "Admin");
            //}

            return View();
        }


        public IActionResult AddDoctor(int? id)
        {
            //DoctorRepository _doctorRepository = new DoctorRepository();

            if (id.HasValue)
            {
                var doctor = _doctorRepository.View().FirstOrDefault(d => d.Id == id.Value);

                if (doctor != null)
                {
                    return View(doctor);
                }
            }
            return View(new Doctor());
        }


        [HttpPost]
        public IActionResult AddDoctor(Doctor d)
        {
            //DoctorRepository _doctorRepository = new DoctorRepository();

            if (d.Id == 0)
            {
                _doctorRepository.Add(d);
            }
            else
            {
                _doctorRepository.Update(d.Id, d);
            }


            //IRepository<Doctor> repo = new GenericRepository<Doctor>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");
            //repo.Add(d);

            return RedirectToAction("ViewDoctor", "Admin");

        }


        public ViewResult ViewDoctor()
        {
            //DoctorRepository _doctorRepository = new DoctorRepository();

            //List<Doctor> d = _doctorRepository.View();

            //IRepository<Doctor> repo = new GenericRepository<Doctor>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");
            //repo.View(d);


            //IRepository<Doctor> repo = new GenericRepository<Doctor>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");
            //repo.ViewAll();

            return View(_doctorRepository.View());
        }




        public IActionResult EditDoctor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //DoctorRepository _doctorRepository = new DoctorRepository();

            Doctor doctor = _doctorRepository.View().FirstOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return NotFound();
            }

            return View("AddDoctor", doctor);
        }


        [HttpPost]
        public IActionResult EditDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                //DoctorRepository _doctorRepository = new DoctorRepository();

                _doctorRepository.Update(doctor.Id, doctor);
                return RedirectToAction("ViewDoctor");
            }

            return View("AddDoctor", doctor);
        }



        //public IActionResult EditDoctor(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    DoctorRepository doctorRepository = new DoctorRepository();

        //    Doctor doctor = doctorRepository.View().FirstOrDefault(d => d.DoctorId == id);
        //    if (doctor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("AddDoctor", doctor);
        //}

        //public ViewResult Edit(int id)
        //{

        //    Doctor d = DoctorRepository.doctor.Find(d => d.Id == id);

        //    return View("Edit", d);
        //}

        //[HttpPost]
        //public ViewResult Edit(Doctor d)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        foreach (Doctor doc in DoctorRepository.doctor)
        //        {
        //            if (std.Id == s.Id)
        //            {
        //                std.Name = s.Name;
        //                std.Semester = s.Semester;
        //                std.Age = s.Age;
        //                std.CGPA = s.CGPA;
        //                break;
        //            }
        //        }

        //        return View("ListStudents", StudentRepository.students);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(String.Empty, "Please enter correct data");
        //        return View();
        //    }
        //}



        //public ViewResult Edit(int id)
        //{
        //    Student s = StudentRepository.students.Find(s => s.Id == id);
        //    return View("Edit", s);

        //}
        //[HttpPost]
        //public ViewResult Edit(Student s)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (Student std in StudentRepository.students)
        //        {
        //            if (std.Id == s.Id)
        //            {
        //                std.Name = s.Name;
        //                std.Semester = s.Semester;
        //                std.Age = s.Age;
        //                std.CGPA = s.CGPA;
        //                break;
        //            }
        //        }

        //        return View("ListStudents", StudentRepository.students);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(String.Empty, "Please enter correct data");
        //        return View();
        //    }
        //}

        public IActionResult DeleteDoctor(int id)
        {
            //DoctorRepository _doctorRepository = new DoctorRepository();

            _doctorRepository.Delete(id);

            return RedirectToAction("ViewDoctor");
        }







        //public IActionResult AddLaboratorian()
        //{
        //    return View();
        //}
        //public IActionResult ViewLaboratorian()
        //{
        //    return View();
        //}













        public IActionResult AddLaboratorian(int? id)
        {
            //LaboratorianRepository _laboratorianRepository = new LaboratorianRepository();

            if (id.HasValue)
            {
                var laboratorian = _laboratorianRepository.View().FirstOrDefault(d => d.Id == id.Value);

                if (laboratorian != null)
                {
                    return View(laboratorian);
                }
            }

            return View(new Laboratorian());
        }




        [HttpPost]
        public IActionResult AddLaboratorian(Laboratorian l)
        {
            //LaboratorianRepository _laboratorianRepository = new LaboratorianRepository();

            if (l.Id == 0)
            {
                _laboratorianRepository.Add(l);
            }
            else
            {
                _laboratorianRepository.Update(l.Id, l);
            }


            return RedirectToAction("ViewLaboratorian", "Admin");
        }



        public IActionResult ViewLaboratorian()
        {
            //LaboratorianRepository _laboratorianRepository = new LaboratorianRepository();

            //List<Laboratorian> laboratorians = _laboratorianRepository.View();
            
            return View(_laboratorianRepository.View());
        }




        public IActionResult EditLaboratorian(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //LaboratorianRepository _laboratorianRepository = new LaboratorianRepository();

            Laboratorian laboratorian = _laboratorianRepository.View().FirstOrDefault(d => d.Id == id);

            if (laboratorian == null)
            {
                return NotFound();
            }


            return View("AddLaboratorian", laboratorian);
        }



        [HttpPost]
        public IActionResult EditLaboratorian(Laboratorian laboratorian)
        {
            if (ModelState.IsValid)
            {
                //LaboratorianRepository _laboratorianRepository = new LaboratorianRepository();

                _laboratorianRepository.Update(laboratorian.Id, laboratorian);

                return RedirectToAction("ViewLaboratorian");

            }

            return View("AddLaboratorian", laboratorian);
        }



        public IActionResult DeleteLaboratorian(int id)
        {
            //LaboratorianRepository _laboratorianRepository = new LaboratorianRepository();

            _laboratorianRepository.Delete(id);

            return RedirectToAction("ViewLaboratorian");
        }



    }



}



