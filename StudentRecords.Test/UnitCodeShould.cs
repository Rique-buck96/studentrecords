using StudentRecords.Models;
using StudentRecords.Services;
using Xunit;

namespace StudentRecords.Test
{
    public class UnitCodeShould
    {
        [Fact]
        public void UnitCodeIsSanitised()
        {
            //Arrange
            var unit = new Units
            {
                UnitCode = "  csg2344   "
            };

            //Act
            var result = new UnitService(unit).SanitiseUnitCode();
            //Assert
            Assert.Matches("CSG2344",result);
        }

        [Fact]
        public void UnitTitleIsSanitised()
        {
            //Arrange
            var unit = new Units()
            {
                UnitTitle = " sYSTEMS dAtabase & design  "
            };

            //Act
            var result = new UnitService(unit).SanitiseUnitTitle();

            //Assert
            Assert.Matches("Systems Database & Design", result);
        }
    }
}
