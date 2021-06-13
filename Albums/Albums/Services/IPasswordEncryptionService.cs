// <copyright file="IPasswordEncryptionService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

namespace Albums.Services
{
  public interface IPasswordEncryptionService
  {
    byte[] Encrypt(byte[] input, byte[] key);

    byte[] Decrypt(byte[] input, byte[] key);

    byte[] GenerateKey(string passphrase);
  }
}
