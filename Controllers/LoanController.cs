// using Microsoft.AspNetCore.Mvc;
// using LoanManagementSystem.API.Models;

// namespace LoanManagementSystem.API.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class LoanController : ControllerBase
//     {
//         [HttpGet]
//         public ActionResult<List<Loan>> GetLoans()
//         {
//             var loans = new List<Loan>
//             {
//                 new Loan { Id = 1, BorrowerName = "Alice", Amount = 50000, InterestRate = 7.5f, TermInMonths = 36 },
//                 new Loan { Id = 2, BorrowerName = "Bob", Amount = 100000, InterestRate = 6.5f, TermInMonths = 60 }
//             };
//             return Ok(loans);
//         }

//         [HttpPost]
//         public ActionResult<Loan> CreateLoan([FromBody] Loan newLoan)
//         {
//             return CreatedAtAction(nameof(GetLoans), new { id = newLoan.Id }, newLoan);
//         }

//     }
// }
using Microsoft.AspNetCore.Mvc;
using LoanManagementSystem.API.Models;
using LoanManagementSystem.API.Services;
using LoanManagementSystem.API.DTOs;
using AutoMapper;

namespace LoanManagementSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;

        public LoanController(ILoanService loanService, IMapper mapper)
        {
            _loanService = loanService;
            _mapper = mapper;
        }

        // just using DI
        // [HttpGet]
        // public ActionResult<List<Loan>> GetLoans()
        // {
        //     return Ok(_loanService.GetAll());
        // }

        //Using DTO nd Automapper
        [HttpGet]
        public ActionResult<List<LoanDto>> GetLoans()
        {
            var loans = _loanService.GetAll();
            var loanDtos = _mapper.Map<List<LoanDto>>(loans); // model to DTO
            return Ok(loanDtos);
        }

        // Just using DI
        // [HttpGet("{id}")]
        // public ActionResult<Loan> GetLoanById(int id)
        // {
        //     var loan = _loanService.GetById(id);
        //     if (loan == null)
        //         return NotFound();

        //     return Ok(loan);
        // }

        //Using Automapper nd DTO
        [HttpGet("{id}")]
        public ActionResult<LoanDto> GetLoanById(int id)
        {
            var loan = _loanService.GetById(id);
            if (loan == null) return NotFound();
            var dto = _mapper.Map<LoanDto>(loan);
            return Ok(dto);
        }


        // Just DI without DTO nd Automapper
        // [HttpPost]
        // public ActionResult<Loan> CreateLoan([FromBody] Loan newLoan)
        // {
        //     var loan = _loanService.Create(newLoan);
        //     return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loan);
        // }
        // DTO nd manual mapping without Automapper
        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public ActionResult<LoanDto> CreateLoan([FromBody] LoanCreateDto newLoanDto)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var loan = new Loan
        //     {
        //         BorrowerName = newLoanDto.BorrowerName,
        //         Amount = newLoanDto.Amount,
        //         InterestRate = newLoanDto.InterestRate,
        //         TermInMonths = newLoanDto.TermInMonths
        //     };
        //     var createdLoan = _loanService.Create(loan);
        //     var createdDto = new LoanDto
        //     {
        //         Id = createdLoan.Id,
        //         BorrowerName = createdLoan.BorrowerName,
        //         Amount = createdLoan.Amount,
        //         InterestRate = createdLoan.InterestRate,
        //         TermInMonths = createdLoan.TermInMonths
        //     };
        //     return CreatedAtAction(nameof(GetLoanById), new { id = createdDto.Id }, createdDto);
        // }

        // Using DTO nd Automapper
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LoanDto> CreateLoan([FromBody] LoanCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var loan = _mapper.Map<Loan>(dto);
            var createdLoan = _loanService.Create(loan);
            var createdDto = _mapper.Map<LoanDto>(createdLoan);
            return CreatedAtAction(nameof(GetLoanById), new { id = createdDto.Id }, createdDto);
        }



        // PUT /Loan/{id}
        // [HttpPut("{id}")]
        // public ActionResult<Loan> UpdateLoan(int id, [FromBody] Loan updatedLoan)
        // {
        //     var loan = _loanService.Update(id, updatedLoan);
        //     if (loan == null)
        //         return NotFound();

        //     return Ok(loan);
        // }

        // Using DTO nd Automapper
        [HttpPut("{id}")]
        public ActionResult<LoanDto> UpdateLoan(int id, [FromBody] LoanUpdateDto dto)
        {
            var existing = _loanService.GetById(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing); // maps onto the existing object
            var updatedLoan = _loanService.Update(id, existing);
            return Ok(_mapper.Map<LoanDto>(updatedLoan));
        }


        // DELETE /Loan/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteLoan(int id)
        {
            var deleted = _loanService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
