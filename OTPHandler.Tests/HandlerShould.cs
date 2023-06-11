namespace OTPHandler.Tests
{
    [TestClass]
    public class HandlerShould
    {
        
        [TestMethod]
        public void GenerateOTPShould_Return_SixCharacterStringAsOTP()
        {
            //Arrange 
            string userIdMockup = Guid.NewGuid().ToString();
            string result = string.Empty;
            int resultLength;
            OTP_handler.OTPHandler handler = new OTP_handler.OTPHandler();

            //Act
            result = handler.GenerateOTP(userIdMockup,DateTime.Now);

            //Assert
            resultLength = result.Length;
            Assert.AreEqual(resultLength, 6);
        }
        [TestMethod]
        public void ValidateOTPShould_ReturnTrue_WhenOTP_Valid()
        {
            //Arrange
            string userIdMockup = Guid.NewGuid().ToString();
            string result = string.Empty;
            bool validationResult = false;
            OTP_handler.OTPHandler handler = new OTP_handler.OTPHandler();

            //Act
            result = handler.GenerateOTP(userIdMockup,DateTime.Now);
            validationResult = handler.AttemptValidation(result);

            //Assert
            Assert.IsTrue(validationResult);
        }
    }
}