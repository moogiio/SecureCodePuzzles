/*
From https://www.codeproject.com/Articles/1083348/Csharp-Bad-Practices-Learn-How-to-Make-Good-Code-b

STEP I – Naming, Naming, Naming
STEP II – Magic Numbers
STEP III – More Readable
STEP IV - Not Obvious Bug
STEP VI - Get Rid of Magic Numbers
STEP VII – Don't Repeat Yourself!
STEP VIII – Remove Few Unnecessary Lines...
*/

public class DiscountManager
{
  private readonly IAccountDiscountCalculatorFactory _factory;
  private readonly ILoyaltyDiscountCalculator _loyaltyDiscountCalculator;
 
  public DiscountManager(IAccountDiscountCalculatorFactory factory, 
                         ILoyaltyDiscountCalculator loyaltyDiscountCalculator)
  {
    _factory = factory;
    _loyaltyDiscountCalculator = loyaltyDiscountCalculator;
  }
 
  public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, 
                               int timeOfHavingAccountInYears)
  {
    decimal priceAfterDiscount = 0;
    priceAfterDiscount = _factory.GetAccountDiscountCalculator
                         (accountStatus).ApplyDiscount(price);
    priceAfterDiscount = _loyaltyDiscountCalculator.ApplyDiscount
                         (priceAfterDiscount, timeOfHavingAccountInYears);
    return priceAfterDiscount;
  }
}