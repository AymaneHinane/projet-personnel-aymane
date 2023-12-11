using System.Text.Json;
using AspBookApp.Service.Contracts;
using AspBookApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AspBookApp.CompanyEmployees.Controller;


[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{ 
       private readonly IServiceManager _service;

       public EmployeesController(IServiceManager service) => _service = service;

       [HttpGet]
       public async Task<IActionResult> GetEmployeesForCompany(Guid companyId, [FromQuery] EmployeeParameters employeeParameters)
       {

        //get only the employees
           var pagedResult = await _service.EmployeeService.GetEmployeesAsync(companyId,false,employeeParameters);

           Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(pagedResult.metaData));

           return Ok(pagedResult.employees);
        
        //get the employee and the company
        // var company = _service.CompanyService.GetCompanyWithEmployee(companyId, trackChanges: false);
        // return Ok(company);
        
       }

       [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
       public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
       {
          var employee = await _service.EmployeeService.GetEmployeeAsync(companyId, id,trackChanges: false);
          return Ok(employee);

       }

       [HttpPost]
       public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
       {

           if (!ModelState.IsValid)
           {
              return UnprocessableEntity(ModelState);
           }
            if (employee is null)
              return BadRequest("EmployeeForCreationDto object is null");
              
            var employeeToReturn = await _service.EmployeeService
                         .CreateEmployeeForCompanyAsync(companyId, employee, trackChanges: false);

              return CreatedAtRoute(nameof(GetEmployeeForCompany), new
              {
               companyId,
               id = employeeToReturn.Id
              }, employeeToReturn );

        }

      [HttpDelete("{id:guid}")]
      public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
       {
         await _service.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, id, trackChanges:false);
         return NoContent();
       }

      [HttpPut("{id:guid}")]
      public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
      {
        if (employee is null)
           return BadRequest("EmployeeForUpdateDto object is null");

        await _service.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, id, employee
              ,compTrackChanges: false, empTrackChanges: true);

         return NoContent();
      }
}



