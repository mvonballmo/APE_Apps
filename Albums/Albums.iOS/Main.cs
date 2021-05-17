// <copyright file="Main.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using UIKit;

namespace Albums.iOS
{
  public class Application
  {
    // This is the main entry point of the application.
    internal static void Main(string[] args)
    {
      // if you want to use a different Application Delegate class from "AppDelegate"
      // you can specify it here.
      UIApplication.Main(args, null, "AppDelegate");
    }
  }
}
