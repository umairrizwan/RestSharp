using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwaggerAPI;
using SwaggerAPI.DTO;
using System.Net;
using static SwaggerAPI.DTO.Pet;
using NUnit.Framework;

namespace SwaggerTest
{
    
    [TestFixture]
    public class UnitTest1
    {
        [Test, Order(1)]
        public void CreatePet()
        {
            Pet petObj = new Pet();
            var petCategory = new Category();

            petObj.id = 85;
            petObj.name = "Pitbull";
            string[] photourl = { "string" };
            petObj.photoUrls = photourl;
            petCategory.id = 0;
            petCategory.name = "Dog";            

            var petCategory1 = new Category();
            petCategory1.id = 1;
            petCategory1.name = "Cat";
            Category[] categories = { petCategory, petCategory1 };
            petObj.tags = categories;
            petObj.status = "available";      
                     
            var user = new FunctionHelper<CreatePet>();           
            var response = user.creatPets("pet/", petObj);            
            var userss = new APIHelper<Pet>();
            Pet userDTO = userss.getContent<Pet>(response);

            //Assertions         
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(userDTO.name, Is.EqualTo("Pitbull"));
        }


        [Test, Order(2)]
        public void GetPetsByPetId()
        {
            var functionHelper = new FunctionHelper<ListOfPets>();
            var pets = functionHelper.getPet("pet/{petId}");

            //Assertions
            Assert.That(pets.id, Is.EqualTo(85),"Pet Id not found");
        }

        [Test, Order(3)]
        public void UpdatePet()
        {
            string payload = @"{
                            ""id"": 66,
                            ""category"": {
                            ""id"": 0,
                            ""name"": ""Dog""
                                        },
                            ""name"": ""Pitbull"",
                            ""photoUrls"": [
                            ""string""
                                   ],
                            ""tags"": [
                        {
                            ""id"": 0,
                            ""name"": ""string""
                         }
                             ],
                         ""status"": ""available""
                               }";

            var pet = new FunctionHelper<UpdatePet>();
            var petObj = pet.updatePet("pet/", payload);

            //Assertions         
            Assert.That(petObj.Id, Is.EqualTo(66), "Pet Id not found");           
        }

        [Test, Order(4)]
        public void DeletePetsByPetId()
        {           
            var pet = new FunctionHelper<Pet>();
            var response = pet.deletePet("pet/{petId}");         
          
            //Assertions         
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),"Pet not available");
        }
    }
}
