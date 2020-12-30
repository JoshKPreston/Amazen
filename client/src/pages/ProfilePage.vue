<template>
  <div class="page profile-page">
    <div class="container bg-light">
      <div class="row p-3">
        <h1>My Wish Lists</h1>
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
      <div class="row">
        <h1>My Products</h1>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { profileService } from '../services/ProfileService'
export default {
  name: 'ProfilePage',
  setup() {
    onMounted(async() => {
      if (!AppState.profile.id) {
        await profileService.getProfile()
      }
    })
    return {
      profile: computed(() => AppState.profile)

    }
  }
}
</script>

<style scoped>
</style>
