<template>
    <div class="bid-calculator">
      <h1>Bid Calculation Tool</h1>
      <form @submit.prevent="calculateTotalCost" class="bid-form">
        <div class="form-group">
          <label for="basePrice">Vehicle Base Price:</label>
          <div class="input-group">
            <span class="input-group-text">$</span>
            <input type="number" v-model.number="basePrice" required />
          </div>
        </div>
        <div class="form-group">
          <label for="vehicleType">Vehicle Type:</label>
          <select v-model="vehicleType" required>
            <option disabled value="">Select a vehicle type</option>
            <option value="Common">Common</option>
            <option value="Luxury">Luxury</option>
          </select>
        </div>
        <button type="submit">Calculate Total Cost</button>
      </form>
      <div v-if="totalCost !== null" class="result">
        <h2>Total Cost: {{ formattedTotalCost }}</h2>
      </div>
    </div>
  </template>
  
  <script>
  import { calculateTotalCost } from '../services/api';
  
  export default {
    data() {
      return {
        id: 1, // Pode ser incrementado ou gerenciado conforme necessário
        basePrice: 0,
        vehicleType: '', // Inicializando como vazio
        totalCost: null,
      };
    },
    computed: {
      formattedTotalCost() {
        return `$${this.totalCost.toFixed(2)}`;
      },
    },
    methods: {
      async calculateTotalCost() {
        try {
          const response = await calculateTotalCost({
            id: this.id,
            basePrice: this.basePrice,
            type: this.vehicleType
          });
          this.totalCost = response.totalCost;
        } catch (error) {
          console.error('Error calculating total cost:', error);
        }
      },
    },
  };
  </script>
  
  <style src="../assets/styles/bid-calculator.css"></style>
  