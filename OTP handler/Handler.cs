using OtpNet;

namespace OTP_handler
{
    public class OTPHandler
    {
        private byte[] secretBytes;
        private Totp totp;
        private byte[] SecretBytes { get => secretBytes; set => secretBytes = value; }
        private Totp Totp { get => totp; set => totp = value; }

        public OTPHandler()
        {   

            secretBytes = KeyGeneration.GenerateRandomKey(OtpHashMode.Sha512);
            this.Totp = new Totp(secretBytes, mode: OtpHashMode.Sha512);
        }
        public string GenerateOTP(string userId, DateTime dateTime)
        {
            try
            {
                return Totp.ComputeTotp();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public bool AttemptValidation(string otp) 
        {
            try
            {
                return Totp.VerifyTotp(otp, out long timeStepMatched, VerificationWindow.RfcSpecifiedNetworkDelay);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}