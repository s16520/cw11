using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cw11.Models;
using cw11.DTO.Request;

namespace cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly s16520DbContext _context;

        public DoctorsController(s16520DbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors.ToList());
        }

        [HttpPut]
        public IActionResult PostDoctor(DoctorRequest request)
        {
            Doctor doctor = new Doctor { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            _context.Update(doctor);

            return Ok("Dodano lekarza");
        }

        [HttpPost]
        public IActionResult ModifyDoctor(DoctorRequest request)
        {
            Doctor doctor = _context.Doctors.Find(request.IdDoctor);

            if(doctor == null)
            {
                return NotFound("Doctor not found");
            }

            if (request.FirstName != null)
                doctor.FirstName = request.FirstName;
            if (request.LastName != null)
                doctor.LastName = request.LastName;
            if (request.Email != null)
                doctor.Email = request.Email;

            _context.Update(doctor);
            _context.SaveChanges();
            
            return Ok(doctor);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteDoctor(int Id)
        {
            var doctor = _context.Doctors.Find(Id);

            if (doctor==null)
            {
                return NotFound("Doctor not found");
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return Ok("Done, doctor deleted");
        }

    }
}