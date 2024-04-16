using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;
using testcinema1.Models;
using testcinema1.Services;

namespace testcinema1.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class HomeController : Controller
    {
        private readonly IVnPayService _vnPayservice;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IVnPayService vnPayservice) 
        {
            _vnPayservice = vnPayservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Pay(string payment, double amount, string txtCardName, string txtEmail, string txtCustPhone)
        {
            if (payment == "Thanh Toán")
            {
                var vnPayModel = new VnPaymentRequestModel
                {
                    Amount = amount,
                    CreatedDate = DateTime.Now,
                    FullName = txtCardName,
                    Email = txtEmail,
                    PhoneNumber = txtCustPhone,
                    OrderId = new Random().Next(1000, 100000)
                };

                // Create the payment URL using the VnPay service
                var paymentUrl = _vnPayservice.CreatePaymentUrl(HttpContext, vnPayModel);

                // Redirect the user to the payment page
                return Redirect(paymentUrl);
            }

            return View(); // Or return some other response if needed
        }

        //[Authorize]
        public IActionResult PaymentSuccess()
        {
            return View("PaymentSuccess");
        }

        //[Authorize]
        public IActionResult PaymentFail()
        {
            return View();
        }

        //[Authorize]
        public IActionResult PaymentCallBack()
        {
            var response = _vnPayservice.PaymentExecute(Request.Query);

            if (response == null || response.VnPayResponseCode != "00")
            {
                TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayResponseCode}";
                return RedirectToAction("PaymentFail");
            }




            TempData["Message"] = $"Thanh toán VNPay thành công";
            return RedirectToAction("PaymentSuccess");
        }
    }
}
