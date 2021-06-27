// <copyright file="BiometricCryptoHelper.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Android.Hardware.Biometrics;
using Android.Security.Keystore;
using Java.Security;
using Javax.Crypto;
using Javax.Crypto.Spec;

namespace Albums.Droid.Security
{
  public class BiometricCryptoHelper
  {
    public BiometricCryptoHelper()
    {
      _keystore = KeyStore.GetInstance(KeyStoreName);
      _keystore.Load(null);

      // TODO For testing we delete the key on every restart.
      if (_keystore.ContainsAlias(KeyAlias))
      {
        _keystore.DeleteEntry(KeyAlias);
      }

      CreateKey();
    }

    public static byte[] IV { get; set; }

    public BiometricPrompt.CryptoObject CreateCryptoObject(CipherMode mode)
    {
      var cipher = CreateCipher(mode);

      return new BiometricPrompt.CryptoObject(cipher);
    }

    private Cipher CreateCipher(CipherMode mode)
    {
      var key = _keystore.GetKey(KeyAlias, null);
      var cipher = Cipher.GetInstance($"{KeyProperties.KeyAlgorithmAes}/{KeyProperties.BlockModeCbc}/{KeyProperties.EncryptionPaddingPkcs7}");

      try
      {
        if (mode == CipherMode.DecryptMode)
        {
          cipher.Init(mode, key, new IvParameterSpec(IV));
        }
        else
        {
          cipher.Init(mode, key);
        }
      }
      catch (KeyPermanentlyInvalidatedException)
      {
        // TODO: The key was invalidated because the Biometric setup changed or a permanent lock out happened.
      }

      return cipher;
    }

    private void CreateKey()
    {
      var keyGen = KeyGenerator.GetInstance(KeyProperties.KeyAlgorithmAes, KeyStoreName);
      var keyGenSpec =
          new KeyGenParameterSpec.Builder(KeyAlias, KeyStorePurpose.Encrypt | KeyStorePurpose.Decrypt)
              .SetKeySize(256)
              .SetBlockModes(KeyProperties.BlockModeCbc)
              .SetEncryptionPaddings(KeyProperties.EncryptionPaddingPkcs7)
              .SetUserAuthenticationRequired(true)
              .Build();
      keyGen.Init(keyGenSpec);
      keyGen.GenerateKey();
    }

    private const string KeyStoreName = "AndroidKeyStore";
    private const string KeyAlias = "_todoKey";

    private readonly KeyStore _keystore;
  }
}
