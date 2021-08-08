using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore;
using PetStore.Models;
using System.Collections.Generic;

namespace PetStoreTests
{
    [TestClass]
    public class PetTests
    {
        [TestMethod]
        public void PetSortedInReverseOrder()
        {
            var pets = new List<Pet>
            {
                new Pet {
                    Name = "First Pet",
                    Category = new Category{Id = 0, Name = "test" },
                    PhotoUrl = null,
                    Status = "available",
                    Tags = null
                },
                new Pet {
                    Name = "Second Pet",
                    Category = new Category{Id = 0, Name = "test" },
                    PhotoUrl = null,
                    Status = "available",
                    Tags = null
                }
                
            };

            var sortedPets = Program.sortPets(pets);

            Assert.AreEqual(0, sortedPets.FindIndex(p => p.Name == "Second Pet"));
            Assert.AreEqual(1, sortedPets.FindIndex(p => p.Name == "First Pet"));
        }
    }
}
