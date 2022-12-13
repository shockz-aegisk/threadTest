﻿internal class Program
{
  private static void Main(string[] args)
  {
    var t = new Thread(FaultyThread);
    t.Start();
    t.Join();

    try
    {
      t = new Thread(BadFaultyThread);
      t.Start();
    }
    catch (Exception ex)
    {
      Console.WriteLine("we won't get here!");
    }
  }

  private static void BadFaultyThread()
  {
    Console.WriteLine("Starting a faulty thread...");
    Thread.Sleep(TimeSpan.FromSeconds(2));
    throw new Exception("Boom!");
  }

  private static void FaultyThread()
  {
    try
    {
      Console.WriteLine("Starting a faulty thread...");
      Thread.Sleep(TimeSpan.FromSeconds(1));
      throw new Exception("Boom!");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Exception handled: {0}", ex.Message);
    }
  }
}