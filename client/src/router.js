import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'home-page',
    component: loadPage('home-page')
  },
  {
    path: '/product/:id',
    name: 'product-page',
    component: loadPage('product-page')
  },
  {
    path: '/profile',
    name: 'profile-page',
    component: loadPage('profile-page'),
    beforeEnter: authGuard
  },
  {
    path: '/wishlist',
    name: 'wishlist-page',
    component: loadPage('wishlist-page'),
    beforeEnter: authGuard
  }
]

const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})

export default router
