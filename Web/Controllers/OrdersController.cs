using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Create()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Aquí llamarías a tu capa Application para guardar la orden
            // await _orderService.CreateOrder(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GenerateAllOrdersReport()
        {
            var pdfBytes = await _reportService.GenerateAllOrdersPdf();
            return File(pdfBytes, "application/pdf", "AllOrdersReport.pdf");
        }

        public async Task<IActionResult> GenerateOrderDetailsReport(int orderId)
        {
            var pdfBytes = await _reportService.GenerateOrderDetailsPdf(orderId);
            return File(pdfBytes, "application/pdf", $"OrderDetails_{orderId}.pdf");
        }
    }
}
