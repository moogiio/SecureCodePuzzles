class PriceCalculator {
    calculate(amount, type, years) {
      if (typeof amount !== 'number' || amount < 0) {
        throw new Error('Amount must be a non-negative number');
      }
      if (!Number.isInteger(type) || type < 1 || type > 4) {
        throw new Error('Type must be an integer between 1 and 4');
      }
      if (!Number.isInteger(years) || years < 0) {
        throw new Error('Years must be a non-negative integer');
      }
  
      const discountRate = Math.min(years, 5) / 100;
      
      let basePrice;
      switch (type) {
        case 1:
          basePrice = amount;
          break;
        case 2:
          basePrice = amount * 0.9;
          break;
        case 3:
          basePrice = amount * 0.7;
          break;
        case 4:
          basePrice = amount * 0.5;
          break;
      }
  
      const discount = basePrice * discountRate;
      return basePrice - discount;
    }
  }
  
  module.exports = PriceCalculator;