using Microsoft.AspNetCore.Cryptography.KeyDerivation;

using Posti_it_web.Repository.Models;

namespace Pedalacom.BLogic.Encryption
{
    public class DecryptSalt
    {
      
        internal bool DecryptSaltCredential(User userFound, string password)
        {
            bool result = false;
            byte[] byteSalt = new byte[16];
            string encryptedResult = string.Empty;
            string encryptedSalt = string.Empty;
         
            string pwdHash = string.Empty;

            try
            {
               
                byteSalt = Convert.FromBase64String(userFound.PasswordSalt);

                encryptedResult = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                        password: password,
                        salt: byteSalt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 10000,
                        numBytesRequested: 16)
                        );

                encryptedSalt = Convert.ToBase64String(byteSalt);

               

                if (userFound != null)
                {
                    result = userFound.PasswordHash == encryptedResult;

                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return result;
        }
    }
}
