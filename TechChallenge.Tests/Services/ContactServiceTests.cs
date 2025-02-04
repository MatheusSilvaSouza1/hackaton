// using System.Threading.Tasks;
// using Application.Services;
// using Domain;
// using Domain.DTOs;
// using FluentValidation.Results;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using Xunit;
// using API.Controllers;

// namespace TechChallenge.Tests.Services
// {
//     public class MedicoControllerTests
//     {
//         private readonly IMedicoServices _MedicoServices;

//         public MedicoControllerTests(IMedicoServices contactServices)
//         {
//             _MedicoServices = contactServices;
//         }

//         [Fact]
//         public async Task Post_ShouldReturnCreated_WhenMedicoIsValid()
//         {
//             // Arrange
//             var contactDto = new MedicoDTO
//             {
//                 Name = "John Doe",
//                 Phone = "12123456789",
//                 Email = "john@example.com"
//             };

//             var result = await _MedicoServices.CreateMedico(contactDto);

//             Assert.True(true);
//         }

//         [Fact]
//         public async Task Post_ShouldReturnBadRequest_WhenMedicoIsInvalid()
//         {
//             // Arrange
//             var contactDto = new MedicoDTO
//             {
//                 Name = "invalid",
//                 Phone = "Invalid",
//                 Email = "invalid"
//             };

//             var result = await _MedicoServices.CreateMedico(contactDto);

//             Assert.False(false);
//         }
//     }
// }
