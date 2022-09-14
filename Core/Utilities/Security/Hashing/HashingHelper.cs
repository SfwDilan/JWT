using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Hashing
{
    //appsetting.json'da TokenOptions eklendi.
    public class HashingHelper
    {
        //string password,out byte[] passwordHash,out byte[] passwordSalt :biz bir password göndericez dışarıya passwordHash ve passwordSalt değerlerini çıkarıcaz.
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)  //Hash ve Salt oluşturulacak.
        {
            //disposable pattern
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;   //her kullanıcı için farklı key oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt) //out anahtarına gerek yok.Çünkü varolan,elimizdeki hash ve saltı doğrulamak için gönderiyoruz
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
