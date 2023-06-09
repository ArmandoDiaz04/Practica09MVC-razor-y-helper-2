﻿using Microsoft.AspNetCore.Mvc;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class EquiposController : Controller
    {
        private readonly equiposDbContext _equiposDbContext;
        public EquiposController(equiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("nombre, descripcion ,tipo_equipo_id ,marca_id ,modelo ,anio_compra ,costo ,vida_util,estado_equipo_id")] equipos equipoNuevo)
        {
            try
            {
                _equiposDbContext.Add(equipoNuevo);
                _equiposDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return View("Index");
        }
    }
}
