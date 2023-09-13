﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using webapi.Data;
using webapi.Model;
using webapi.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordatoriosController : ControllerBase
    {
        //DESARROLLAR AQUI EL METODO ASIGNADO EN CLASE
        //Los ejemplos de abajo son la base     para desarrollar el que te fue asignado en clase
        //Aqui se se invoca el DAO. Recuerda que debes desarrollar el metodo en el DAO  

        // GET: api/<RecordatoriosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RecordatoriosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecordatoriosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecordatoriosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordatoriosController>/5
        [HttpDelete("{id}")]
        
       
            public IActionResult Delete(int ididreordatorio, [FromBody] Recordatorios delRecordatorios)
            {

                if (delRecordatorios == null)
                {
                    return BadRequest("No hay datos a Eliminar.");
                }

                var existingRec = new RecordatoriosDAO().GetOneById(ididreordatorio);

                if (existingRec == null)
                {
                    return NotFound("No se encontro el recordatorio.");
                }

                existingRec.fecha_recordatorio = delRecordatorios.fecha_recordatorio;

                int resultadoEdicion = new RecordatoriosDAO().Eliminar(ididreordatorio);

                if (resultadoEdicion > 0)
                {
                    return Ok(existingRec);
                }
                else
                {
                    return StatusCode(500, "Error al actualizar.");
                }
            }
        



        //EL METODO ME REGRESO UN VALUE
       

    }
    
}

