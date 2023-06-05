// <copyright file="Program.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using UIKit;

namespace Albums;

internal static class Program
{
  // This is the main entry point of the application.
  private static void Main(string[] args)
  {
    // if you want to use a different Application Delegate class from "AppDelegate"
    // you can specify it here.
    UIApplication.Main(args, null, typeof(AppDelegate));
  }
}