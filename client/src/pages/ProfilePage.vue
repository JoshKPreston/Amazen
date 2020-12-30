<template>
  <div class="profile-page page">
    <div class="container bg-light">
      <div class="row p-3">
        <h2>My Wish Lists</h2>
      </div>
      <div class="row p-3">
        <div class="col-4 justify-content-center">
          <div class="wishlist border border-primary d-flex justify-content-center align-items-center p-4 shadow">
            <h2>
              Christmas
            </h2>
          </div>
        </div>
        <div class="col-4">
          <div class="wishlist border border-primary d-flex justify-content-center align-items-center p-4 shadow">
            <h2>
              Kitchen
            </h2>
          </div>
        </div>
        <div class="col-4">
          <div class="wishlist border border-primary d-flex justify-content-center align-items-center p-4 shadow">
            <h2>
              kid's toys
            </h2>
          </div>
        </div>
      </div>
      <div class="row p-3">
        <h2>My Products</h2>
      </div>
      <div class="row p-3">
        <product-component v-for="p in products" :key="p" :product-prop="p" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { profileService } from '../services/ProfileService'
import ProductComponent from '../components/ProductComponent.vue'
import { productService } from '../services/ProductService'
export default {
  components: { ProductComponent },
  name: 'ProfilePage',
  setup() {
    onMounted(async() => {
      if (!AppState.profile.id) {
        await profileService.getProfile()
      }
      await productService.getAll()
    })
    return {
      profile: computed(() => AppState.profile),
      wishlists: computed(() => AppState.wishlists),
      products: computed(() => AppState.products)
    }
  }
}
</script>

<style scoped>
</style>
