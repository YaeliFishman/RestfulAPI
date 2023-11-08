using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTful_API.Entities;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        //private List<Event> events = new List<Event> { new Event { Id = 1, Title = "first event" } };

        private static List<Appointment> appointmentsList = new List<Appointment> {};

        // GET: api/<AppointmentController>
        [HttpGet]
        //שליפת רשימה
        public IEnumerable<Appointment> Get()
        {
            return appointmentsList;
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        //שליפת אוביקט בודד לפי מזהה
        public ActionResult<Appointment> Get(int id)
        {
            var appointment = appointmentsList.Find(x => x.Id == id);
            if (appointment == null)
                return NotFound();
            return appointment;
            //return Ok(appointment);
        }

        // GET api/<AppointmentController>/2023,11,07
        [HttpGet("{date}")]
        //שליפת אוביקטים לפי תאריך
        public ActionResult<List<Appointment>> Get(DateOnly date)
        {
            List<Appointment> temp = new List<Appointment>();
            temp = appointmentsList.FindAll(x => x.Date == date);
            if (temp == null)
                return NotFound();
            return temp;
        }

        // POST api/<AppointmentController>
        [HttpPost]
        //הוספה
        public void Post([FromBody] Appointment appointment)
        {
            appointmentsList.Add(new Appointment { Id = appointment.Id, Subject = appointment.Subject, Date = appointment.Date });
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        //עדכון
        public void Put(int id, [FromBody] Appointment updateAppointment)
        {
            //id - מציאת אוביקט עפי ה
            var a = appointmentsList.Find(x => x.Id == id);

            //עדכון המשתנים
            //a.Id=updateAppointment.Id;
            a.Subject = updateAppointment.Subject;
            a.Date = updateAppointment.Date;
        }
        

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        //מחיקה
        public void Delete(int id)
        {
            var a=appointmentsList.Find(x => x.Id == id);
            appointmentsList.Remove(a);
        }
    }
}