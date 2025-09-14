using Microsoft.AspNetCore.Mvc;
using HW_mvc_9.Models;

namespace HW_mvc_9.Controllers
{
    public class MatrixController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int size)
        {
            var model = new Matrix
            {
                Size = size,
                MatrixA = new double[size, size],
                MatrixB = new double[size, size]
            };
            return View("Input", model);
        }


        [HttpPost]
        public ActionResult Calculate(Matrix model)
        {
            int size = model.Size;

          
            var a = new double[size, size];
            var b = new double[size, size];

           
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    string keyA = $"MatrixA[{i}][{j}]";
                    string keyB = $"MatrixB[{i}][{j}]";

                    double.TryParse(Request.Form[keyA], out a[i, j]);
                    double.TryParse(Request.Form[keyB], out b[i, j]);
                }
            }

            
            model.MatrixA = a;
            model.MatrixB = b;
            model.Result = new double[size, size];

           
            if (model.Operation == "Add")
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        model.Result[i, j] = a[i, j] + b[i, j];
            }
            else if (model.Operation == "Multiply")
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        for (int k = 0; k < size; k++)
                            model.Result[i, j] += a[i, k] * b[k, j];
            }

            return View("Result", model);
        }

    }

}
