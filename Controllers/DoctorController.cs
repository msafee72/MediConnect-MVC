using Medi_Connect.Models; 
using Medi_Connect.Models.Interfaces;
using Medi_Connect.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medi_Connect.Controllers
{
    [Authorize(Policy = "DoctorPolicy")]
    public class DoctorController : Controller
	{
        private readonly IWebHostEnvironment _env;
        private readonly IPatientRepository _patientRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;

        private readonly string _connectionString;

        public DoctorController(IPatientRepository patientRepository, IPrescriptionRepository prescriptionRepository, IWebHostEnvironment env, IConfiguration configuration)
        {
            _patientRepository = patientRepository;
            _prescriptionRepository = prescriptionRepository; 
            _env = env;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public IActionResult Index()
		{
			return View();
		}

        //public IActionResult AddPatient(int? id)
        //{
        //    PatientRepository _patientRepository = new PatientRepository();

        //    if (id.HasValue)
        //    {
        //        var patient = _patientRepository.GetPatientById(id.Value);

        //        if (patient != null)
        //        {
        //            return View(patient);
        //        }
        //    }

        //    return View(new Patient());
        //}

        //// POST: /Doctor/AddPatient
        //[HttpPost]
        //public IActionResult AddPatient(Patient patient)
        //{
        //    PatientRepository _patientRepository = new PatientRepository();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (patient.PatientId == 0)
        //            {
        //                _patientRepository.Add(patient);
        //            }
        //            else
        //            {
        //                _patientRepository.Update(patient.PatientId, patient);
        //            }

        //            return RedirectToAction("ViewPatient");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError(string.Empty, $"An error occurred while adding the patient: {ex.Message}");
        //        }
        //    }

        //    // If the model state is not valid or an error occurred, redisplay the form with errors
        //    return View(patient);
        //}

        //public ViewResult ViewPatient()
        //{
        //    PatientRepository _patientRepository = new PatientRepository();

        //    List<Patient> p = _patientRepository.GetAllPatients();

        //    return View(p);
        //}



        //*****************PATIENT*****************
        public IActionResult AddPatient(int? id)
        {
            //PatientRepository _patientRepository = new PatientRepository();

            if (id.HasValue)
            {
                var patient = _patientRepository.View().FirstOrDefault(p => p.Id == id.Value);

                if (patient != null)
                {
                    return View(patient);
                }
            }

            return View(new Patient());
        }
 

        [HttpPost]
        public IActionResult AddPatient(Patient p)
        {
            //PatientRepository _patientRepository = new PatientRepository();

            if (p.Id == 0)
            {
                _patientRepository.Add(p);
            }
            else
            {
                _patientRepository.Update(p.Id, p);
            }
            return RedirectToAction("ViewPatient", "Doctor");
        }


        public ViewResult ViewPatient()
        {
            //PatientRepository _patientRepository = new PatientRepository();

            IEnumerable<Patient> p = _patientRepository.View();


            List<Patient> patientsList = p.ToList();

            string message = string.Empty;

            if (HttpContext.Request.Cookies.ContainsKey("first-visit"))
            {
                string? data = HttpContext.Request.Cookies["first-visit"];

                message = $"Welcome Back {data}";
            }

            else
            {
                CookieOptions option = new CookieOptions();
                option.Expires = System.DateTime.Now.AddDays(1);

                message = $"Welcome! You visited first time";
                HttpContext.Response.Cookies.Append("first-visit", DateTime.Now.ToString(), option);
            }

            PateintCookie pateintCookie = new PateintCookie {
                Data = message,
                Patients = patientsList
            };



            return View(pateintCookie);
            //return View("Index", message);
            //return View(p);


            //return View(p);
        }



        public IActionResult EditPatient(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //PatientRepository _patientRepository = new PatientRepository();

            Patient p = _patientRepository.View().FirstOrDefault(p => p.Id == id);

            if (p == null)
            {
                return NotFound();
            }

            return View("AddPatient", p);
        }


        [HttpPost]
        public IActionResult EditPatient(Patient p)
        {
            if (ModelState.IsValid)
            {
                //PatientRepository _patientRepository = new PatientRepository();

                _patientRepository.Update(p.Id, p);

                return RedirectToAction("ViewPatient");
            }

            return View("AddPatient", p);
        }



        public IActionResult DeletePatient(int id)
        {
            //PatientRepository _patientRepository = new PatientRepository();

            _patientRepository.Delete(id);

            return RedirectToAction("ViewPatient");

        }













        //*****************PRESCRIPTION*****************
        public IActionResult AddPrescription(int? id)
        {
            //PrescriptionRepository _prescriptionRepository = new PrescriptionRepository();

            if (id.HasValue)
            {
                var prescription = _prescriptionRepository.View().FirstOrDefault(p => p.Id == id.Value);

                if (prescription != null)
                {
                    return View(prescription);
                }
            }

            return View(new Prescription());
        }


        [HttpPost]
        public IActionResult AddPrescription(Prescription p)
        {
            //PrescriptionRepository _prescriptionRepository = new PrescriptionRepository();

            if (p.Id == 0)
            {
                _prescriptionRepository.Add(p);
            }
            else
            {
                _prescriptionRepository.Update(p.Id, p);
            }

            return RedirectToAction("ViewPrescription", "Doctor");
        }


        public ViewResult ViewPrescription()
        {
            //PrescriptionRepository _prescriptionRepository = new PrescriptionRepository();

            return View(_prescriptionRepository.View());
        }

        public IActionResult EditPrescription(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //PrescriptionRepository _prescriptionRepository = new PrescriptionRepository();

            Prescription prescription = _prescriptionRepository.View().FirstOrDefault(p => p.Id == id);

            if (prescription == null)
            {
                return NotFound();
            }

            return View("AddPrescription", prescription);
        }


        [HttpPost]
        public IActionResult EditPrescription(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                //PrescriptionRepository _prescriptionRepository = new PrescriptionRepository();

                _prescriptionRepository.Update(prescription.Id, prescription);

                return RedirectToAction("ViewPrescription");
            }

            return View("AddPrecription", prescription);
        }



        public IActionResult DeletePrescription(int id)
        {
            //PrescriptionRepository _prescriptionRepository = new PrescriptionRepository();

            _prescriptionRepository.Delete(id);

            return RedirectToAction("ViewPrescription");

        }

















        //*****************SEARCH LAB TEST RESULT*****************
        public ViewResult ViewLabTest(string search)
        {
            LabResultRepository labResultRepository = new LabResultRepository(_connectionString);

            if (string.IsNullOrEmpty(search))
            {
                return View(labResultRepository.View());
            }

            else
            {
                return View(labResultRepository.Search(search));
            }

        }





        //public ViewResult ViewLaboratorian()
        //{
        //    LaboratorianRepository _laboratorianRepo = new LaboratorianRepository();

        //    return View(_laboratorianRepo.View());
        //}



        //public IActionResult EditLabResult(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    LabResultRepository _labresultrepo = new LabResultRepository();

        //    LabResult labresult = _labresultrepo.View().FirstOrDefault(d => d.Id == id);

        //    if (labresult == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("UploadLabResult", labresult);
        //}



        //[HttpPost]
        //public IActionResult EditLabResult(LabResult l)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        LabResultRepository _labResultRepository = new LabResultRepository();

        //        _labResultRepository.Update(l.Id, l);

        //        return RedirectToAction("ViewLabResult");

        //    }

        //    return View("UploadLabResult", l);

        //}




        //public IActionResult DeleteLabResult(int id)
        //{
        //    LabResultRepository _labResultRepository = new LabResultRepository();

        //    _labResultRepository.Delete(id);

        //    return RedirectToAction("ViewLabResult");

        //}


        //public ViewResult SearchLabTest()
        //{
        //    return View();
        //}
        //public ViewResult ViewLabTest()
        //{
        //    return View();
        //}

    }

}
