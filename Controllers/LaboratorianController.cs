using Medi_Connect.Models;
using Medi_Connect.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medi_Connect.Controllers
{
    [Authorize(Policy = "LaboratorianPolicy")]
    public class LaboratorianController : Controller
	{
        private readonly ILabTestRepository _labTestRepository;
        private readonly ILabResultRepository _labResultRepository;
        private readonly IWebHostEnvironment _env;

        public LaboratorianController(ILabTestRepository labtestRepository, ILabResultRepository labresultRepository, IWebHostEnvironment env)
        {
            _labTestRepository = labtestRepository;
            _labResultRepository = labresultRepository;
            _env = env;
        }

        public IActionResult Index()
		{
			return View();
		}


        // LAB_TEST
        public IActionResult AddLabTest(int? id)
        {
            //LabTestRepository _labtestrepo = new LabTestRepository();

            if (id.HasValue)
            {
                var laboratorian = _labTestRepository.View().FirstOrDefault(d => d.Id == id.Value);


                if (laboratorian != null)
                {
                    return View(laboratorian);
                }
            }

            return View(new LabTest());
        
        }


        [HttpPost]
        public IActionResult AddLabTest(LabTest l)
        {

            if(!ModelState.IsValid)
            {
                return RedirectToAction();
            }

            //LabTestRepository _labtestrepo = new LabTestRepository();

            if (l.Id == 0)
            {
                _labTestRepository.Add(l);
            }
            else
            {
                _labTestRepository.Update(l.Id, l);
            }

            return RedirectToAction("ViewLabTest", "Laboratorian");

        }

        //[HttpPost]
        //public IActionResult AddLabTest(LabTest l)
        //{
        //    //LabTestRepository _labtestrepo = new LabTestRepository();
        //    if (ModelState.IsValid)
        //    {
        //        if (l.Id == 0)
        //        {
        //            _labTestRepository.Add(l);
        //        }
        //        else
        //        {
        //            _labTestRepository.Update(l.Id, l);
        //        }

        //        return RedirectToAction("ViewLabTest", "Laboratorian");
        //    }
        //    else
        //    {
        //        return View();

        //    }
        //}

        //public ViewResult ViewLabTest(string search)
        //{
        //    LabTestRepository _labtestrepo = new LabTestRepository();
        //    if (search != null)
        //    {
        //        return View(_labtestrepo.Search(search));
        //    }
        //    else
        //    {
        //        return View(_labtestrepo.View());
        //    }
        //}

        public ViewResult ViewLabTest()
        {
           // LabTestRepository _labtestrepo = new LabTestRepository();

            return View(_labTestRepository.View());
        }

        public IActionResult EditLabTest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //LabTestRepository _labtestrepo = new LabTestRepository();

            LabTest labtest = _labTestRepository.View().FirstOrDefault(d => d.Id == id);

            if (labtest == null)
            {
                return NotFound();
            }

            return View("AddLabTest", labtest);
        }



        [HttpPost]
        public IActionResult EditLabTest(LabTest l)
        {
            if (ModelState.IsValid)
            {
                //LabTestRepository _labTestRepository = new LabTestRepository();

                _labTestRepository.Update(l.Id, l) ;

                return RedirectToAction("ViewLabTest");

            }

            return View("AddLabTest", l);

        }



        public IActionResult DeleteLabTest(int id)
        {
            //LabTestRepository _labTestRepository = new LabTestRepository();

            _labTestRepository.Delete(id);

            return RedirectToAction("ViewLabTest");

        }













        // LAB_RESULT

        //private readonly IWebHostEnvironment _env;

        //public LaboratorianController(IWebHostEnvironment env)
        //{
        //    _env = env;
        //}

        public IActionResult UploadLabResult()
        {
            return View();
        }

        //public IActionResult UploadLabResult(int? id)
        //{
        //    LabResultRepository _labResultRepository = new LabResultRepository();

        //    if (id.HasValue)
        //    {
        //        var labresult = _labResultRepository.View().FirstOrDefault(d => d.Id == id.Value);

        //        if (labresult != null)
        //        {
        //            return View(labresult);
        //        }
        //    }
        //    return View(new LabResult());
        //}


        [HttpPost]
        public IActionResult UploadLabResult(LabResult lr)
        {
            //LabResultRepository labResultRepository = new LabResultRepository();
            lr.ResultFilePath = SaveImage(lr.File);
            _labResultRepository.Upload(lr);
            return RedirectToAction("ViewLabResult", "Laboratorian");
        }

        private string SaveImage(IFormFile? image)
        {
            string imageFolder = Path.Combine(_env.WebRootPath, "uploads");
           
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            if (image == null)
            {
                return Path.Combine("uploads", "default_image.png");
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "-" + image.FileName;
            string filePath = Path.Combine(imageFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }


            return Path.Combine("uploads", uniqueFileName);
        }

        public ViewResult ViewLabResult(string search)
        {
            //LabResultRepository labResultRepository = new LabResultRepository();

            if (string.IsNullOrEmpty(search))
            {
                return View(_labResultRepository.View());
            }
            else
            {
                return View(_labResultRepository.Search(search));
            }

        }

        [HttpGet]
        public IActionResult Search(string x)
        {
            Console.WriteLine(x);
            //var results = string.IsNullOrEmpty(search) ? _labResultRepository.View() : _labResultRepository.Search(search);

            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    // Return partial view for AJAX requests
            //    return PartialView("_LabResultsListPartial", results);
            //}

            //// Return regular view for non-AJAX requests
            //return View(results);

            return PartialView("_LabResultsListPartial", _labResultRepository.Search(x));


            return View();
        }





        //public ViewResult ViewLaboratorian()
        //{
        //    LaboratorianRepository _laboratorianRepo = new LaboratorianRepository();

        //    return View(_laboratorianRepo.View());
        //}



        public IActionResult EditLabResult(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //LabResultRepository _labresultrepo = new LabResultRepository();

            LabResult labresult = _labResultRepository.View().FirstOrDefault(d => d.Id == id);

            if (labresult == null)
            {
                return NotFound();
            }

            return View("UploadLabResult", labresult);
        }



        [HttpPost]
        public IActionResult EditLabResult(LabResult l)
        {

            if (ModelState.IsValid)
            {
                //LabResultRepository _labResultRepository = new LabResultRepository();

                _labResultRepository.Update(l.Id, l);

                return RedirectToAction("ViewLabResult");

            }

            return View("UploadLabResult", l);

        }




        public IActionResult DeleteLabResult(int id)
        {
            //LabResultRepository _labResultRepository = new LabResultRepository();

            _labResultRepository.Delete(id);

            return RedirectToAction("ViewLabResult");

        }


        //LabResultRepository _labResultRepository = new LabResultRepository();

        //[HttpPost]
        //public IActionResult UploadLabResult(string patientId, string testName, Stream resultFile)
        //{   
        //    _labResultRepository.UploadLabResult(patientId, testName, resultFile);
        //    return RedirectToAction("ViewLabResults");
        //}

        //public ViewResult ViewLabResult()
        //{
        //    List<LabResult> labResults = _labResultRepository.GetAllLabResults();

        //    return View(labResults);
        //}


    }


}
