using lab5_ClassLibrary;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab5.Controllers;

public class LabsController : Controller
{
    [HttpGet]
    public IActionResult Lab1()
    {
        // Create a new instance for the GET request
        return View(new Lab1ViewModel());
    }

    [HttpPost]
    public IActionResult Lab1(string input)
    {
        var model = new Lab1ViewModel();
        if (!string.IsNullOrEmpty(input))
        {
            var labInstance = new lab5_ClassLibrary.Lab1();
            model.Input = input;
            model.Output = labInstance.RunAlgorithmWithStringInput(input);
        }
        return View(model);
    }


    [HttpGet]
    public IActionResult Lab2()
    {
        // Create a new instance for the GET request
        return View(new Lab2ViewModel());
    }

    [HttpPost]
    public IActionResult Lab2(string input)
    {
        var model = new Lab2ViewModel();
        if (!string.IsNullOrEmpty(input))
        {
            var labInstance = new lab5_ClassLibrary.Lab2();
            model.Input = input;
            model.Output = labInstance.RunAlgorithmWithStringInput(input);
        }
        return View(model);
    }
    public IActionResult Lab3()
    {
        // Create a new instance for the GET request
        return View(new Lab3ViewModel());
    }

    [HttpPost]
    public IActionResult Lab3(string input)
    {
        var model = new Lab3ViewModel();
        if (!string.IsNullOrEmpty(input))
        {
            var labInstance = new lab5_ClassLibrary.Lab3();
            model.Input = input;
            model.Output = labInstance.RunAlgorithmWithStringInput(input);
        }
        return View(model);
    }

}



