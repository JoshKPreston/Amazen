import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'HomePage',
    component: loadPage('HomePage')
  },
  {
    path: '/product/:id',
    name: 'ProductPage',
    component: loadPage('ProductPage')
  },
  {
    path: '/profile',
    name: 'ProfilePage',
    component: loadPage('ProfilePage'),
    beforeEnter: authGuard
  },
  {
    path: '/wishlist',
    name: 'WishlistPage',
    component: loadPage('WishlistPage'),
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
