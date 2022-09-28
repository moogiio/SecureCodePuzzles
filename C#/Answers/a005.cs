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

public interface ILoyaltyDiscountCalculator{
  decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears);
}
 
public class DefaultLoyaltyDiscountCalculator : ILoyaltyDiscountCalculator{
  public decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears){
    decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 
            Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ? 
            (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY/100 : 
            (decimal)timeOfHavingAccountInYears/100;
    return price - (discountForLoyaltyInPercentage * price);
  }
}

public interface IAccountDiscountCalculatorFactory
{
  IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus);
}
 
public class DefaultAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
{
  public IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus)
  {
    IAccountDiscountCalculator calculator;
    switch (accountStatus)
    {
      case AccountStatus.NotRegistered:
        calculator = new NotRegisteredDiscountCalculator();
        break;
      case AccountStatus.SimpleCustomer:
        calculator = new SimpleCustomerDiscountCalculator();
        break;
      case AccountStatus.ValuableCustomer:
        calculator = new ValuableCustomerDiscountCalculator();
        break;
      case AccountStatus.MostValuableCustomer:
        calculator = new MostValuableCustomerDiscountCalculator();
        break;
      default:
        throw new NotImplementedException();
    }
 
    return calculator;
  }
}

public interface IAccountDiscountCalculator
{
  decimal ApplyDiscount(decimal price);
}
 
public class NotRegisteredDiscountCalculator : IAccountDiscountCalculator
{
  public decimal ApplyDiscount(decimal price)
  {
    return price;
  }
}
 
public class SimpleCustomerDiscountCalculator : IAccountDiscountCalculator
{
  public decimal ApplyDiscount(decimal price)
  {
    return price - (Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS * price);
  }
}
 
public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
{
  public decimal ApplyDiscount(decimal price)
  {
    return price - (Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price);
  }
}
 
public class MostValuableCustomerDiscountCalculator : IAccountDiscountCalculator
{
  public decimal ApplyDiscount(decimal price)
  {
    return price - (Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS * price);
  }
}