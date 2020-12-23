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
        @click="login"
        v-if="user.isAuthenticated"
      >
        Post Product
      </button>
    </nav>
  </div>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
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
</style>
