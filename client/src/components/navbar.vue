<template>
  <div>
    <nav class="navbar navbar-expand navbar-dark bg-primary">
      <router-link class="navbar-brand" :to="{ name: 'HomePage' }">
        <div class="align-items-center">
          <!-- <img
            alt="logo"
            src="../assets/img/cw-logo.png"
            height="45"
          /> -->
          <h1 class="text-light">
            AmaZen
          </h1>
        </div>
      </router-link>
      <button
        class="navbar-toggler text-light"
        type="button"
        data-toggle="collapse"
        data-target="#navbarText"
        aria-controls="navbarText"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon navbar-light" />
      </button>
      <div class="ml-auto" id="navbarText">
        <span class="navbar-text">
          <button
            class="btn btn-outline-light text-uppercase text-light bg-primary"
            @click="login"
            v-if="!user.isAuthenticated"
          >
            Login
          </button>

          <div class="dropdown" v-else>
            <div
              class="dropdown-toggle"
              @click="state.dropOpen = !state.dropOpen"
            >
              <img
                :src="user.picture"
                alt="user photo"
                height="40"
                class="rounded"
              />
              <span class="mx-3">{{ user.name }}</span>
            </div>
            <div
              class="dropdown-menu p-0 list-group w-100"
              :class="{ show: state.dropOpen }"
              @click="state.dropOpen = false"
            >
              <router-link :to="{ name: 'ProfilePage' }">
                <div class="list-group-item list-group-item-action hoverable">
                  Profile
                </div>
              </router-link>
              <div
                class="list-group-item list-group-item-action hoverable"
                @click="logout"
              >
                logout
              </div>
            </div>
          </div>
        </span>
      </div>
    </nav>
    <nav class="navbar navbar-secondary bg-secondary">
      <ul class="navbar-nav d-flex flex-row ml-3">
        <li class="nav-item px-3">
          <router-link :to="{ name: 'HomePage' }" class="nav-link text-light">
            Home
          </router-link>
        </li>
        <li class="nav-item px-3"
            v-if="user.isAuthenticated"
        >
          <router-link :to="{ name: 'ProfilePage' }" class="nav-link text-light">
            Profile
          </router-link>
        </li>
      </ul>
      <button
        class="btn btn-outline-light text-uppercase text-light bg-primary"
        v-if="user.isAuthenticated"
        data-toggle="modal"
        data-target="#newProductForm"
      >
        Post Product
      </button>
      <div id="newProductForm" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
          <div class="modal-content">
            <div class="modal-header d-flex justify-content-between">
              <h4 class="modal-title">
                Post a product
              </h4>
              <button class="close btn btn-danger" data-dismiss="modal">
                &times;
              </button>
            </div>
            <div class="modal-body">
              <form @submit.prevent="postProduct" class="">
                <div class="form-group">
                  <input required
                         class="form-control"
                         v-model="state.newProduct.title"
                         type="text"
                         name="Title"
                         placeholder="Title"
                  />
                </div>
                <div class="form-group">
                  <input required
                         class="form-control"
                         v-model="state.newProduct.price"
                         type="number"
                         min="1"
                         step="0.01"
                         name="Price"
                         placeholder="Price"
                  />
                </div>
                <div class="form-group">
                  <textarea required
                            class="form-control"
                            v-model="state.newProduct.description"
                            name="Description"
                            placeholder="Description"
                  ></textarea>
                </div>
                <div class="form-group">
                  <input required
                         class="form-control"
                         v-model="state.newProduct.category"
                         type="text"
                         name="Category"
                         placeholder="Category"
                  />
                </div>
                <div class="form-group">
                  <input required
                         class="form-control"
                         v-model="state.newProduct.image"
                         type="text"
                         name="ImageUrl"
                         placeholder="ImageUrl"
                  />
                </div>
                <button type="submit" class="btn btn-primary form-control">
                  Submit
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
import { productService } from '../services/ProductService'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false,
      newProduct: {
        title: '',
        price: null,
        description: '',
        category: '',
        image: ''
      }
    })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      },
      async postProduct() {
        await productService.create(state.newProduct)
        state.newProduct = {}
        document.getElementById('newProductForm').classList.remove('show')
        document.getElementById('newProductForm').classList.add('hide')
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.nav-item .nav-link.router-link-exact-active{
  color: var(--primary);
}
textarea {
  resize: none;
}
</style>
