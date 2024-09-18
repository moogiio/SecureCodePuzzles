class PriceCalculator {
    constructor(config = {}) {
      this.typeDiscounts = config.typeDiscounts || {
        1: 0,
        2: 0.1,
        3: 0.3,
        4: 0.5
      };
      this.maxYearsDiscount = config.maxYearsDiscount || 5;
      this.yearlyDiscountRate = config.yearlyDiscountRate || 0.01; // 1% per year
    }
  
    calculate(amount, type, years) {
      try {
        this.validateInputs(amount, type, years);
  
        const baseDiscount = this.typeDiscounts[type];
        const yearsDiscount = Math.min(years, this.maxYearsDiscount) * this.yearlyDiscountRate;
  
        const basePrice = amount * (1 - baseDiscount);
        const yearlyDiscount = basePrice * yearsDiscount;
  
        const finalPrice = basePrice - yearlyDiscount;
        return Number(finalPrice.toFixed(2)); // Round to 2 decimal places
      } catch (error) {
        console.error('Calculation error:', error.message);
        throw error;
      }
    }
  
    validateInputs(amount, type, years) {
      if (typeof amount !== 'number' || isNaN(amount) || amount < 0) {
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