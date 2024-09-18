class PriceCalculator {
    constructor() {
      this.typeDiscounts = {
        1: 0,
        2: 0.1,
        3: 0.3,
        4: 0.5
      };
      this.maxYearsDiscount = 5;
    }
  
    calculate(amount, type, years) {
      this.validateInputs(amount, type, years);
  
      const baseDiscount = this.typeDiscounts[type] || 0;
      const yearsDiscount = Math.min(years, this.maxYearsDiscount) / 100;
  
      const basePrice = amount * (1 - baseDiscount);
      const yearlyDiscount = basePrice * yearsDiscount;
  
      return basePrice - yearlyDiscount;
    }
  
    validateInputs(amount, type, years) {
      if (typeof amount !== 'number' || amount < 0) {
        throw new Error('Amount must be a non-negative number');
      }
      if (!Number.isInteger(type) || !this.typeDiscounts.hasOwnProperty(type)) {
        throw new Error(`Type must be one of: ${Object.keys(this.typeDiscounts).join(', ')}`);
      }
      if (!Number.isInteger(years) || years < 0) {
        throw new Error('Years must be a non-negative integer');
      }
    }
  }
  
  module.exports = PriceCalculator;