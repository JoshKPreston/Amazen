<template>
  <div class="wishlist-page page">
    <div class="container bg-light">
      <div class="row p-3">
        <product-component v-for="p in products" :key="p" :product-prop="p" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'WishlistPage',
  setup() {
    return {
      products: computed(() => AppState.products)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
