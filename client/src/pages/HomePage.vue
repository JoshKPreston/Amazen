<template>
  <div class="home-page page">
    <div class="container bg-info">
      <div class="row p-3">
        <product-component v-for="p in products" :key="p" :product-prop="p" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { productService } from '../services/ProductService'
import { AppState } from '../AppState'
export default {
  name: 'HomePage',
  setup() {
    onMounted(async() => {
      await productService.getAll()
    })
    return {
      products: computed(() => AppState.products)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
