// <copyright file="PasswordEncryptionService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Linq;
using System.Text;
using Albums.Services;
using Javax.Crypto;
using Javax.Crypto.Spec;
using Xamarin.Forms;

[assembly: Dependency(typeof(Albums.Droid.PasswordEncryptionService))]

namespace Albums.Droid
{
  public class PasswordEncryptionService : IPasswordEncryptionService
  {
    public byte[] Encrypt(byte[] input, byte[] key)
    {
      var secretKey = new SecretKeySpec(key, "AES");
      var cipher = Cipher.GetInstance("AES");
      cipher.Init(CipherMode.EncryptMode, secretKey);

      // TODO: In production you should generate a random IV and store it somewhere.

      return cipher.DoFinal(input);
    }

    public byte[] Decrypt(byte[] input, byte[] key)
    {
      using (var secretKey = new SecretKeySpec(key, "AES"))
      {
        var cipher = Cipher.GetInstance("AES");
        cipher.Init(CipherMode.DecryptMode, secretKey);

        // TODO: In production you should load and provide your IV (Initialization Vector) here.

        return cipher.DoFinal(input);
      }
    }

    public byte[] GenerateKey(string passphrase)
    {
      // Number of PBKDF2 hardening rounds to use. Larger values increase
      // computation time. You should select a value that causes computation
      // to take >100ms.
      var iterations = 5000;

      // Generate a 256-bit key
      var outputKeyLength = 256;

      var secretKeyFactory = SecretKeyFactory.GetInstance("PBKDF2WithHmacSHA1");
      using (var keySpec = new PBEKeySpec(passphrase.ToCharArray(), _salt.Take(32).ToArray(), iterations, outputKeyLength))
      {
        var secretKey = secretKeyFactory.GenerateSecret(keySpec);

        return secretKey.GetEncoded();
      }
    }

    private static readonly byte[] _salt = Encoding.UTF8.GetBytes("SuperSalt1234");
  }
}