using DemoUnitTest;
using DemoUnitTest.Bank;


Calcul calcul = new Calcul();
Console.WriteLine(calcul.Division(5,0));

IBankService s = new BankService();